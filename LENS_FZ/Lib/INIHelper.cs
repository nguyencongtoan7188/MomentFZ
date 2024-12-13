using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace LENS_FZ
{
    public class INIHelper
    {
        private static string INIPATH;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public INIHelper(string iniPath)
        {
            INIPATH = iniPath;
        }

        public bool ExistINIFile()
        {
            return File.Exists(INIPATH);
        }

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, INIPATH);
            return temp.ToString();
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, INIPATH);
        }
    }
}
