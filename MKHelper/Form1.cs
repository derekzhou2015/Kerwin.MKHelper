using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MKHelper
{
    public partial class Form1 : Form
    {
        public static bool isRun = false;
        public static Thread actionThread;
        private bool mouseIsDown = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_startorstop_Click(object sender, EventArgs e)
        {
            if (isRun)
            {
                isRun = false;
                btn_startorstop.Text = "Run";
            }
            else
            {
                isRun = true;
                btn_startorstop.Text = "Stop";
                actionThread = new Thread(actionThread_ThreadStart);
                actionThread.IsBackground = true;
                actionThread.Start();
            }
            controls_status_change();
        }
        private void txt_key_KeyDown(object sender, KeyEventArgs e)
        {
            tbox_KeyDown(sender, e);
        }
        private void tbox_startkey_KeyDown(object sender, KeyEventArgs e)
        {
            tbox_KeyDown(sender, e);
        }
        private void tbox_stopkey_KeyDown(object sender, KeyEventArgs e)
        {
            tbox_KeyDown(sender, e);
        }
        private void tbox_target_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        private void btn_find_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            Cursor = Cursors.Default;

        }
        private void btn_find_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            Cursor = Cursors.Cross;
        }
        private void btn_find_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                Point point;
                MKEvents.GetCursorPos(out point);
                label7.Text = point.X.ToString() + "/" + point.Y.ToString();
                IntPtr hWnd = MKEvents.WindowFromPoint(point);
                int processId;
                MKEvents.GetWindowThreadProcessId(hWnd, out processId);
                Process proc = Process.GetProcessById(processId);
                tbox_target.Text = proc.MainWindowTitle;
            }

        }
        private void cbox_istop_CheckedChanged(object sender, EventArgs e)
        {
            var cbox = (CheckBox)sender;
            if (cbox.Checked)
                TopMost = true;
            else
                TopMost = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = cbox_istop.Checked;
            Hook.InstallHook();
        }
        private void actionThread_ThreadStart(object sender)
        {
            var repeat = (int)ntxt_repeat.Value;
            var delay = (int)ntxt_delay.Value;
            var key_str = txt_key.Text.Trim();
            var control = Regex.IsMatch(key_str, @"Ctrl");
            var shift = Regex.IsMatch(key_str, @"Shift");
            var alt = Regex.IsMatch(key_str, @"Alt");
            var letter = Regex.Match(key_str, @"[F]?[A-Z0-9]\d?$").Value;
            letter = Regex.Replace(letter, @"^\d$", "D$0");
            var key = (Keys)Enum.Parse(typeof(Keys), letter, true);
            var bvk = Convert.ToByte((char)key);
            var i = 0;
            while (isRun)
            {
                Thread.Sleep(delay);
                if (!checkActivedWindow(tbox_target.Text)) continue;
                i++;
                if (control)
                    MKEvents.keybd_event(MKEvents.vbKeyControl, 0, 0, 0);
                if (shift)
                    MKEvents.keybd_event(MKEvents.vbKeyShift, 0, 0, 0);
                if (alt)
                    MKEvents.keybd_event(MKEvents.vbKeyAlt, 0, 0, 0);
                MKEvents.keybd_event(bvk, 0, 0, 0);
                MKEvents.keybd_event(bvk, 0, 2, 0);
                if (control)
                    MKEvents.keybd_event(MKEvents.vbKeyControl, 0, 2, 0);
                if (shift)
                    MKEvents.keybd_event(MKEvents.vbKeyShift, 0, 2, 0);
                if (alt)
                    MKEvents.keybd_event(MKEvents.vbKeyAlt, 0, 2, 0);

                if (i >= repeat && repeat != 0)
                    break;
            }
        }

        #region Common function
        private void tbox_KeyDown(object sender, KeyEventArgs e)
        {
            var tbox = (TextBox)sender;
            e.SuppressKeyPress = true;
            string val = string.Empty;
            if (e.Control)
                val += "Ctrl+";
            if (e.Shift)
                val += "Shift+";
            if (e.Alt)
                val += "Alt+";
            if (char.IsDigit((char)e.KeyValue))
                val += ((char)e.KeyValue).ToString();
            else
                val += e.KeyCode.ToString().ToUpper();
            tbox.Text = val;
        }
        private void controls_status_change()
        {
            foreach (var item in Controls)
            {
                var pattern = @"(NumericUpDown|TextBox)$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(item.GetType().ToString()))
                {
                    var con = item as Control;
                    con.Enabled = !isRun;
                }
            }
        }
        private bool checkActivedWindow(string targetWindowTitle)
        {
            var hWnd = MKEvents.GetForegroundWindow();
            int processId;
            MKEvents.GetWindowThreadProcessId(hWnd, out processId);
            if (processId == 0) return false;
            Process proc = Process.GetProcessById(processId);
            return targetWindowTitle == proc.MainWindowTitle;
        }
        #endregion


    }
}
