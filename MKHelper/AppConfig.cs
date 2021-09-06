using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MKHelper
{
    public class AppConfig
    {
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string defValue, StringBuilder retValue, int size, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        public string ConfigFileName { get; set; }
        public AppConfig(string configFileName)
        {
            ConfigFileName = configFileName;
            InitConfigFile();
        }

        private string ReadValue(string section, string key)
        {
            if (File.Exists(ConfigFileName))
            {
                StringBuilder stringBuilder = new StringBuilder(255);
                GetPrivateProfileString(section, key, string.Empty, stringBuilder, 255, ConfigFileName);
                return stringBuilder.ToString();
            }
            return string.Empty;
        }

        private void WriteValue(string section, string key, string value)
        {
            if (File.Exists(ConfigFileName))
            {
                WritePrivateProfileString(section, key, value, ConfigFileName);
            }
        }

        private void InitConfigFile()
        {
            if (!File.Exists(ConfigFileName))
            {
                File.Create(ConfigFileName).Close();
                WriteValue("Config", "PowerKey", "F10");
                WriteValue("Config", "Key", "F8");
                WriteValue("Config", "Repeat", "0");
                WriteValue("Config", "Window", "");
                WriteValue("Config", "Handler", "");
                WriteValue("Config", "Delay", "500");
                WriteValue("Config", "IsTop", "1");
            }
        }

        public void SetConfig(string key,string value)
        {
            WriteValue("Config", key, value);
        }

        public string GetConfig(string key)
        {
            return ReadValue("Config", key);
        }

        public int GetConfigWithInt(string key)
        {
            int result;
            int.TryParse(GetConfig(key), out result);
            return result;
        }
    }
}
