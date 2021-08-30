using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKHelper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        public UInt32 vkCode;
        public UInt32 scanCode;
        public UInt32 flags;
        public UInt32 time;
        public IntPtr extraInfo;
    }

    public enum HookType : int
    {
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14
    }

    public static class Hook
    {
        public delegate IntPtr HookProc(int code, int wParam, IntPtr lParam);
        private static IntPtr _hhook = IntPtr.Zero;
        private static HookProc _hookProc = KeyBoardHookProc;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(int ZeroOnly, string lpWindowName);

        public static void InstallHook()
        {
            if (_hhook == IntPtr.Zero)
            {
                var hInstance =LoadLibrary("user32");
                _hhook = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _hookProc, hInstance, 0);
            }
        }

        public static void UninstallHook()
        {
            if (_hhook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hhook);
                _hhook = IntPtr.Zero;
            }
        }

        public static IntPtr KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT kbh = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                if (kbh.vkCode == (int)Keys.T)
                {
                    return (IntPtr)1;
                }
                return IntPtr.Zero;
            }
            return CallNextHookEx(_hhook, nCode, wParam, lParam);
        }

    }
}