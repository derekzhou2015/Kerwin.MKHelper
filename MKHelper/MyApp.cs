using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Interceptor;
namespace MKHelper
{

    public class MyApp
    {
        public event EventHandler<EventArgs> On_ToggleState;
        public bool RunningState { get; set; }
        private Input inputObj;
        private Thread thread1;
        public MyApp()
        {
            RunningState = false;
            inputObj = new Input();
            inputObj.KeyboardFilterMode = KeyboardFilterMode.All;
            inputObj.Load();
        }

        private void Thead1_ThreadStart()
        {
            #region
            /**var key_str = Config.ExcuteKey.ToString();
            var control = Regex.IsMatch(key_str, @"Ctrl");
            var shift = Regex.IsMatch(key_str, @"Shift");
            var alt = Regex.IsMatch(key_str, @"Alt");
            var letter = Regex.Match(key_str, @"[F]?[A-Z0-9]\d?$").Value;
            letter = Regex.Replace(letter, @"^\d$", "D$0");
            var key = (Keys)Enum.Parse(typeof(Keys), letter, true);**/
            #endregion
            var i = 0;
            while (RunningState)
            {
                Thread.Sleep(AppCon.Delay);
                if (!CheckCurrentWindow()) continue;
                i++;
                inputObj.SendKey(AppCon.ExcuteKey, KeyState.Down);
                Task.Delay(5);
                inputObj.SendKey(AppCon.ExcuteKey, KeyState.Up);
                if (i > AppCon.Repeat && AppCon.Repeat != 0)
                    ToggleState(false);
            }
        }

        private bool CheckCurrentWindow()
        {
            var hWnd = WinAPI.GetForegroundWindow();
            int processId;
            WinAPI.GetWindowThreadProcessId(hWnd, out processId);
            if (processId == 0) return false;
            Process proc = Process.GetProcessById(processId);
            return AppCon.Window == proc.MainWindowTitle;
        }

        public void ToggleState(bool state)
        {
            RunningState = state;
            if (On_ToggleState != null)
                On_ToggleState(null, new EventArgs());
        }

        public void Run()
        {
            AppCon.Load();
            ToggleState(true);
            if (thread1 == null || thread1.ThreadState == System.Threading.ThreadState.Stopped)
            {
                thread1 = new Thread(Thead1_ThreadStart);
                thread1.Start();
            }
        }

        public void Stop()
        {
            ToggleState(false);
        }
    }
}
