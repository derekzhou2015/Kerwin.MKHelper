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

using Interceptor;
namespace MKHelper
{
    public partial class Form1 : Form
    {
        private delegate void BeginInvokeCallback();
        private MyApp myApp;
        public bool IsRunning = false;

        public Form1()
        {
            InitializeComponent();
            AppCon.Load();
            myApp = new MyApp();
            myApp.On_ToggleState += delegate (object sender, EventArgs e)
            {
                ChangeForm();
            };

            HotKey.InstallHook();
            HotKey.On_KeyUp += btn_startorstop_Click;
        }

        private void btn_startorstop_Click(object sender, EventArgs e)
        {
            if (myApp.RunningState)
            {
                myApp.Stop();
            }
            else
            {
                myApp.Run();
            }
            ChangeForm();
        }
        private void btn_save_config_Click(object sender, EventArgs e)
        {
            AppCon.ExcuteKey = (Interceptor.Keys)Enum.Parse(typeof(Interceptor.Keys), txt_key.Text);
            AppCon.PowerKey = (Interceptor.Keys)Enum.Parse(typeof(Interceptor.Keys), tbox_startkey.Text);
            AppCon.Repeat = (int)ntxt_repeat.Value;
            AppCon.Delay = (int)ntxt_delay.Value;
            AppCon.Window = tbox_target.Text;
            AppCon.Handler = lab_handler.Text;
            AppCon.IsTop = TopMost = cbox_istop.Checked;
            AppCon.Save();
            MessageBox.Show("Save setting successfully.", "Save setting message.");
        }
        private void txt_key_KeyDown(object sender, KeyEventArgs e)
        {
            tbox_KeyDown(sender, e);
        }
        private void tbox_startkey_KeyDown(object sender, KeyEventArgs e)
        {
            tbox_KeyDown(sender, e);
        }
        private void tbox_target_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        private void btn_find_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point point;
                WinAPI.GetCursorPos(out point);
                IntPtr hWnd = WinAPI.WindowFromPoint(point);
                lab_handler.Text = hWnd.ToString();
                int processId;
                WinAPI.GetWindowThreadProcessId(hWnd, out processId);
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
            LoadAppConfig();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "exit")
            {
                Environment.Exit(0);
                base.OnClosed(e);
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
            val = e.KeyCode.ToString().ToUpper();
            tbox.Text = val;
        }
        private void LoadAppConfig()
        {
            txt_key.Text = AppCon.ExcuteKey.ToString();
            tbox_startkey.Text = AppCon.PowerKey.ToString();
            ntxt_repeat.Value = AppCon.Repeat;
            ntxt_delay.Value = AppCon.Delay;
            tbox_target.Text = AppCon.Window;
            lab_handler.Text = AppCon.Handler;
            cbox_istop.Checked = TopMost = AppCon.IsTop;
        }
        private void ChangeForm()
        {
            btn_startorstop.BeginInvoke(new BeginInvokeCallback(() =>
            {
                btn_startorstop.Text = !myApp.RunningState ? "Run" : "Stop";
            }));
            progressBar1.BeginInvoke(new BeginInvokeCallback(() =>
            {
                progressBar1.Style = myApp.RunningState ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            }));
        }

        #endregion


    }
}
