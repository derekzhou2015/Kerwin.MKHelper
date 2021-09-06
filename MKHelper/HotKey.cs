using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interceptor;

namespace MKHelper
{
    public static class HotKey
    {
        private static Thread thread;
        private static int deviceId;

        public static event EventHandler<EventArgs> On_KeyUp;

        public static void InstallHook()
        {
            thread = new Thread(HotkeyThread_ThreadStart);
            thread.Start();
        }

        private static void HotkeyThread_ThreadStart()
        {
            IntPtr intPtr = InterceptionDriver.CreateContext();
            Stroke stroke = new Stroke();
            InterceptionDriver.SetFilter(intPtr, InterceptionDriver.IsKeyboard, (int)KeyboardFilterMode.KeyUp);
            while (InterceptionDriver.Receive(intPtr, deviceId = InterceptionDriver.Wait(intPtr), ref stroke, 1) > 0)
            {
                if (stroke.Key.Code == AppCon.PowerKey)
                {
                    if (On_KeyUp != null)
                        On_KeyUp(null, new EventArgs());
                };

                InterceptionDriver.Send(intPtr, deviceId, ref stroke, 1);
            }
        }

    }
}
