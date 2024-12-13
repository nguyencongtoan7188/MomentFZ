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
    public class DataDao
    {
        SQLHelper sqldao = new SQLHelper(Application.StartupPath + "\\DATA.mdb", "6006");

        /// <summary>
        /// INSERT DATA
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool insetdata(DataFZ dt)
        {
            return sqldao.InsertModel<DataFZ>(dt, "DataFZ") && sqldao.InsertModel<DataFZ>(dt, "temp");
        }

        /// <summary>
        /// QUERY DATA
        /// </summary>
        /// <param name="sn"></param>
        /// <returns>返回data类型list</returns>
        public List<DataFZ> selectdata(string sn)
        {
            string sql = $"select * from [DataFZ] where [SN] = '{sn}' order by [Datatime] desc ";
            return sqldao.GetDataList<DataFZ>(sql);
        }

        /// <summary>
        /// SELECT COUNT
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public int selectSnCount(string sn)
        {
            string sql = $"select * from [DataFZ] where [SN]='{sn}'";
            return sqldao.GetDataCount(sql);
        }

        /// <summary>
        /// Lấy dữ liệu trong ngày lấy được SN
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public List<DataFZ> getSNNewState()
        {
            string sql = "select * from [DataFZ] where (DATEDIFF('d',[Datatime],now())=0)";
            return sqldao.GetDataList<DataFZ>(sql);
        }
    }
}
