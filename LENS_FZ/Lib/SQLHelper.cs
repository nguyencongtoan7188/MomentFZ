using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace LENS_FZ
{
    public class SQLHelper
    {
        //private readonly static string connstr_key = "ConnAccess";
        private readonly static string connstr = @"Provider=Microsoft.jet.OLEDB.4.0;Persist Security Info=True;Jet OLEDB:Database Password=6006;Data Source=" + Application.StartupPath + @"\MFMZ_Data.mdb";

        /// <summary>
        /// Query model list
        /// </summary>
        /// <typeparam name="T">泛指类</typeparam>
        /// <param name="sql">数据库语言</param>
        /// <returns></returns>
        public List<T> GetDataList<T>(string sql)
        {
            return DataSetHelper.DataSetToList<T>(getAccessDataset(sql), 0);
        }

        public List<T> GetDataList2<T>(string sql)
        {
            return DataSetHelper.DataSetToList2<T>(getAccessDataset(sql), 0);
        }

        /// <summary>
        /// Query model
        /// </summary>
        /// <typeparam name="T">泛指类</typeparam>
        /// <param name="sql">Command</param>
        /// <returns></returns>
        public T GetDataModel<T>(string sql)
        {
            return DataSetHelper.DataSetToList<T>(getAccessDataset(sql), 0).FirstOrDefault();
        }

        /// <summary>
        /// Query string
        /// </summary>
        /// <param name="sql">Command</param>
        /// <returns></returns>
        public bool IsEqual(string sql)
        {
            var ds = getAccessDataset(sql);
            if (ds == null)
            {
                return false;
            }
            else
            {
                if (ds.Tables.Count == 0)
                {
                    return false;
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int a = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        return a > 0;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="sql">Command</param>
        /// <returns></returns>
        public int GetDataCount(string sql)
        {
            var ds = getAccessDataset(sql);
            if (ds == null)
            {
                return 0;
            }
            else
            {
                if (ds.Tables.Count == 0)
                {
                    return 0;
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Insert Update Delete
        /// </summary>
        /// <param name="sql">Command</param>
        /// <returns></returns>
        public bool SetData(string sql)
        {
            return setAccessDataset(sql);
        }

        /// <summary>
        /// Trả về Id khóa chính tương ứng
        /// </summary>
        /// <param name="sql">Command</param>
        /// <returns></returns>
        public int InsertDataReturnId(string sql)
        {
            return InsertAccessDatasetReturnId(sql);
        }

        #region Access Class
        /// <summary>
        /// 获取Access数据库(读取INI,配置AccessPassword，AccessPath，路径debug下)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DataSet getAccessDataset(string sql)
        {
            //var a = ConfigHelper.GetAppConfig("ConnAccess");
            DataSet DS = new DataSet();
            //搜索查询数据库
            try
            {
                OleDbDataAdapter AD;
                //string connstr = ConfigHelper.GetAppConfig(connstr_key);
                //LOGHelper.loginfoSql("连接字符串：" + connstr);
                OleDbConnection conn = new OleDbConnection(connstr);
                //("provider=microsoft.Jet.OLEDB.4.0;data source=" & CurDir() & "\data.mdb")
                AD = new OleDbDataAdapter(sql, conn);
                DS = new DataSet();
                AD.Fill(DS);
            }
            catch (Exception ex)
            {
                //LOGHelper.logerrorSql("数据库错误：" + ex.ToString());

                LogHelper.LogFlag = true;
                LogHelper.LogError("数据库错误：" + ex.ToString());
                LogHelper.LogFlag = false;

                LogHelper.ExitThread();
            }
            return DS;
        }
        /// <summary>
        /// 往Access数据库中加入、删除、更改数据(读取INI,配置AccessPassword，AccessPath，路径debug下)
        /// </summary>
        private bool setAccessDataset(string sql)
        {
            try
            {
                //string connstr = ConfigHelper.GetAppConfig(connstr_key);
                //LOGHelper.loginfoSql("连接字符串：" + connstr);
                OleDbConnection conn = new OleDbConnection(connstr);
                //連接數據庫
                conn.Open();
                //打開數據庫
                OleDbCommand ad = new OleDbCommand(sql, conn);
                //定義一個操作命令，并按照sql中的語句進行操作數據庫
                ad.ExecuteNonQuery();
                //執行sql語句并返回受影響的行數（數據庫物理操作）
                conn.Close();
                //關閉數據庫
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogFlag = true;
                LogHelper.LogError("数据库错误：" + ex.ToString());
                LogHelper.LogFlag = false;

                LogHelper.ExitThread();
                return false;
            }
        }

        /// <summary>
        /// 添加数据库返回对应主键Id
        /// </summary>
        /// <param name="sql">数据库语句</param>
        /// <returns></returns>
        private int InsertAccessDatasetReturnId(string sql)
        {
            try
            {
                int i = -1;
                //string connstr = ConfigHelper.GetAppConfig(connstr_key);
                //LOGHelper.loginfoSql("连接字符串：" + connstr);
                OleDbConnection conn = new OleDbConnection(connstr);
                //連接數據庫
                conn.Open();
                //打開數據庫
                OleDbCommand ad = new OleDbCommand(sql, conn);
                //定義一個操作命令，并按照sql中的語句進行操作數據庫
                ad.ExecuteNonQuery();
                //關閉數據庫
                ad.CommandText = "SELECT @@IDENTITY AS ID";
                ad.Parameters.Clear();
                //執行sql語句并返回受影響的行數（數據庫物理操作）
                i = Convert.ToInt32(ad.ExecuteScalar());
                conn.Close();
                return i;

            }
            catch (Exception ex)
            {
                LogHelper.LogFlag = true;
                LogHelper.LogError("数据库错误：" + ex.ToString());
                LogHelper.LogFlag = false;

                LogHelper.ExitThread();
                return -1;
            }
        }
        #endregion

    }
}
