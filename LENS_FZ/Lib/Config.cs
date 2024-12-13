using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Resources;
using System.Text;
using MOD;

namespace LENS_FZ
{
    public class Config
    {
        public static List<string> list_funcName = new List<string>();
        public static List<FZConfig> list_funcParam = new List<FZConfig>();

        public static bool SCanOption = false;

        public static bool NETEnable = false;

        public static string IPAddr = "127.0.0.1";

        /// <summary>
        /// Mở và đóng cổng COM
        /// </summary>
        /// <param name="port">Kiểm soát cổng COM</param>
        /// <param name="state">打开为true,关闭为Fale</param>
        public static bool setPort(SerialPort port, bool state = true)
        {
            try
            {
                if (state)
                {
                    if (port.IsOpen)
                        port.Close();

                    //Open
                    port.Open();
                    return true;
                }
                else
                {
                    if (port == null) return false;
                    if (port.IsOpen)
                        port.Close();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
