using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD
{
    public class DataFZ
    {
        //public int ID { get; set; }
        public string LensName { get; set; }
        public string StageID { get; set; }
        public string SN { get; set; }
        public string Result { get; set; }
        public string NGName { get; set; }
        public string StaffName { get; set; }
        public string FZtype { get; set; }
        public float FZData { get; set; }
        public DateTime Datatime { get; set; }
    }
}
