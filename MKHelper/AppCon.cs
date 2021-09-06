using Interceptor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHelper
{
    public static class AppCon
    {
        public static AppConfig Config { get; set; }
        public static Keys ExcuteKey { get; set; }
        public static Keys PowerKey { get; set; }
        public static int Repeat { get; set; }
        public static int Delay { get; set; }
        public static string Window { get; set; }
        public static string Handler { get; set; }
        public static bool IsTop { get; set; }

        static AppCon()
        {
            Config = new AppConfig(Directory.GetCurrentDirectory() + "\\config.ini");
        }

        public static void Save()
        {
            Config.SetConfig("Key", ExcuteKey.ToString());
            Config.SetConfig("PowerKey", PowerKey.ToString());
            Config.SetConfig("Repeat", Repeat.ToString());
            Config.SetConfig("Window", Window.ToString());
            Config.SetConfig("Handler", Handler.ToString());
            Config.SetConfig("Delay", Delay.ToString());
            Config.SetConfig("IsTop", IsTop ? "1" : "0");
        }

        public static void Load()
        {
            ExcuteKey = (Keys)Enum.Parse(typeof(Keys), Config.GetConfig("Key"));
            PowerKey = (Keys)Enum.Parse(typeof(Keys), Config.GetConfig("PowerKey"));
            Repeat = Config.GetConfigWithInt("Repeat");
            Window = Config.GetConfig("Window");
            Handler = Config.GetConfig("Handler");
            Delay = Config.GetConfigWithInt("Delay");
            IsTop = Config.GetConfigWithInt("IsTop") == 1;
        }
    }
}
