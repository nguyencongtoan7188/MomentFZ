using MOD;
using PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class MysqlDao
    {
        INIHelper ini = new INIHelper(Application.StartupPath + "\\setting.ini");
        MySqlHelper mysqldao;

        public MysqlDao()
        {
            mysqldao = new MySqlHelper(ini.IniReadValue("setting", "MysqlDatabaseName"), ini.IniReadValue("setting", "MysqlIP"), ini.IniReadValue("setting", "MysqlUsername"), ini.IniReadValue("setting", "MysqlPassword"));
        }

        /// <summary>
        /// Lấy phần dữ liệu mới nhất
        /// </summary>
        /// <param name="tabel"></param>
        /// <param name="sn"></param>
        /// <returns></returns>
        public DataFZ getDataMode(string tabel,string sn, string IDColumm)
        {
            return getataList(tabel,sn, IDColumm).FirstOrDefault();
        }

        public List<DataFZ> getListData(string tabel, string sn, string IDColumm, bool QueryDay = false)
        {
            return getataList(tabel, sn, IDColumm, QueryDay);
        }

        private List<DataFZ> getataList(string tabel, string sn, string IDColumm, bool QueryDay = false)
        {
            List<DataFZ> datas = new List<DataFZ>();

            string sql = $"select * from {tabel} where {IDColumm} = '{sn}' order by Datatime desc ";
            if (QueryDay)
            {
                string dStart = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                string dEnd = DateTime.Now.ToString("yyyy-MM-dd 23:59:00");

                sql = $"select * from {tabel} where (DATEDIFF('{dStart}', '{dEnd}')";
            }

            System.Data.DataSet ds = mysqldao.GetDataSet(mysqldao.Conn, System.Data.CommandType.Text, sql, null);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<DataFZ> ngList = DataSetHelper.DataSetToList<DataFZ>(ds, 0);
                    if (ngList.Count > 0)
                    {
                        datas = ngList;
                    }
                }
            }
            return datas;
        }
    }
}
