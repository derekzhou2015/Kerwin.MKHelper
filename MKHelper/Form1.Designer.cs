
namespace MKHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_save_config = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.cbox_istop = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ntxt_repeat = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ntxt_delay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tbox_startkey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_find = new System.Windows.Forms.Button();
            this.tbox_target = new System.Windows.Forms.TextBox();
            this.lab_handler = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_startorstop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ntxt_repeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxt_delay)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save_config
            // 
            this.btn_save_config.Location = new System.Drawing.Point(6, 370);
            this.btn_save_config.Name = "btn_save_config";
            this.btn_save_config.Size = new System.Drawing.Size(214, 29);
            this.btn_save_config.TabIndex = 101;
            this.btn_save_config.Text = "Save setting";
            this.btn_save_config.UseVisualStyleBackColor = true;
            this.btn_save_config.Click += new System.EventHandler(this.btn_save_config_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key";
            // 
            // txt_key
            // 
            this.txt_key.Location = new System.Drawing.Point(78, 13);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(138, 27);
            this.txt_key.TabIndex = 102;
            this.txt_key.Text = "F8";
            this.txt_key.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_key_KeyDown);
            // 
            // cbox_istop
            // 
            this.cbox_istop.AutoSize = true;
            this.cbox_istop.Checked = true;
            this.cbox_istop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbox_istop.Location = new System.Drawing.Point(16, 293);
            this.cbox_istop.Name = "cbox_istop";
            this.cbox_istop.Size = new System.Drawing.Size(104, 24);
            this.cbox_istop.TabIndex = 107;
            this.cbox_istop.Text = "Always top";
            this.cbox_istop.UseVisualStyleBackColor = true;
            this.cbox_istop.CheckedChanged += new System.EventHandler(this.cbox_istop_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Repeat";
            // 
            // ntxt_repeat
            // 
            this.ntxt_repeat.Location = new System.Drawing.Point(78, 60);
            this.ntxt_repeat.Name = "ntxt_repeat";
            this.ntxt_repeat.Size = new System.Drawing.Size(134, 27);
            this.ntxt_repeat.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Delay";
            // 
            // ntxt_delay
            // 
            this.ntxt_delay.Location = new System.Drawing.Point(78, 107);
            this.ntxt_delay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ntxt_delay.Name = "ntxt_delay";
            this.ntxt_delay.Size = new System.Drawing.Size(134, 27);
            this.ntxt_delay.TabIndex = 104;
            this.ntxt_delay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hot Key";
            // 
            // tbox_startkey
            // 
            this.tbox_startkey.Location = new System.Drawing.Point(78, 154);
            this.tbox_startkey.Name = "tbox_startkey";
            this.tbox_startkey.Size = new System.Drawing.Size(138, 27);
            this.tbox_startkey.TabIndex = 105;
            this.tbox_startkey.Text = "F10";
            this.tbox_startkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_startkey_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Target";
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(191, 199);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(25, 29);
            this.btn_find.TabIndex = 11;
            this.btn_find.Text = "F";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_find_MouseMove);
            // 
            // tbox_target
            // 
            this.tbox_target.Location = new System.Drawing.Point(82, 200);
            this.tbox_target.Name = "tbox_target";
            this.tbox_target.Size = new System.Drawing.Size(103, 27);
            this.tbox_target.TabIndex = 106;
            this.tbox_target.Text = "剑侠情缘叁怀旧服 - 神都洛阳 @ 怀旧大区";
            this.tbox_target.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbox_target_KeyDown);
            // 
            // lab_handler
            // 
            this.lab_handler.Location = new System.Drawing.Point(82, 245);
            this.lab_handler.Name = "lab_handler";
            this.lab_handler.Size = new System.Drawing.Size(134, 25);
            this.lab_handler.TabIndex = 14;
            this.lab_handler.Text = "0";
            this.lab_handler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Handler";
            // 
            // btn_startorstop
            // 
            this.btn_startorstop.Location = new System.Drawing.Point(6, 335);
            this.btn_startorstop.Name = "btn_startorstop";
            this.btn_startorstop.Size = new System.Drawing.Size(214, 29);
            this.btn_startorstop.TabIndex = 100;
            this.btn_startorstop.Text = "Run";
            this.btn_startorstop.UseVisualStyleBackColor = true;
            this.btn_startorstop.Click += new System.EventHandler(this.btn_startorstop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 410);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(228, 10);
            this.progressBar1.TabIndex = 15;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MKHelper";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 28);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(102, 24);
            this.exit.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 420);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lab_handler);
            this.Controls.Add(this.tbox_target);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.ntxt_delay);
            this.Controls.Add(this.ntxt_repeat);
            this.Controls.Add(this.cbox_istop);
            this.Controls.Add(this.tbox_startkey);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_startorstop);
            this.Controls.Add(this.btn_save_config);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MKHelper V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ntxt_repeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxt_delay)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save_config;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.CheckBox cbox_istop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ntxt_repeat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ntxt_delay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbox_startkey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox tbox_target;
        private System.Windows.Forms.Label lab_handler;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_startorstop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exit;
    }
}

