using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD
{
    public class FZConfig
    {
        public int ID { get; set; } //STT
        public string FZtype { get; set; } //Tên trạm
        public int NextTime { get; set; }  //Thời gian hoàn thành
        public double FZMax { get; set; }  //Giá trị lớn nhất
        public double FZMin { get; set; }  //Giá trị nhỏ nhất
        public int FZNum { get; set; }     //Số lần kiểm tra
        public string FZVideo { get; set; } //Link video
        public float MaxData { get; set; } //Kết quả đọc được cuối cùng
        public DateTime Datatime { get;set; } //Thời gian đọc cuối cùng
        public string FZResult { get; set; } //Kết quả cuối cùng
        
    }
}
