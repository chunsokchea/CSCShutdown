
namespace CSCShutdown
{
    partial class FormShutdown
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShutdown));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDmonth = new System.Windows.Forms.RadioButton();
            this.rbDWeek = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbRestart = new System.Windows.Forms.RadioButton();
            this.rbShutdown = new System.Windows.Forms.RadioButton();
            this.lblbuild = new System.Windows.Forms.Label();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.lblNow = new System.Windows.Forms.Label();
            this.lblDateN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSDD = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDay = new System.Windows.Forms.Label();
            this.cboDayNo = new System.Windows.Forms.ComboBox();
            this.cboDay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHour = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbStart = new System.Windows.Forms.CheckBox();
            this.cbState = new System.Windows.Forms.CheckBox();
            this.lbltimer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "ABC";
            this.notifyIcon1.BalloonTipTitle = "A";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Tag = "Z";
            this.notifyIcon1.Text = "CSCShutdown";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 52);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(549, 276);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 34);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 239);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "status : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDmonth);
            this.groupBox1.Controls.Add(this.rbDWeek);
            this.groupBox1.Controls.Add(this.rbMonthly);
            this.groupBox1.Controls.Add(this.rbDaily);
            this.groupBox1.Location = new System.Drawing.Point(20, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(139, 196);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // rbDmonth
            // 
            this.rbDmonth.AutoSize = true;
            this.rbDmonth.Location = new System.Drawing.Point(8, 108);
            this.rbDmonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbDmonth.Name = "rbDmonth";
            this.rbDmonth.Size = new System.Drawing.Size(106, 20);
            this.rbDmonth.TabIndex = 2;
            this.rbDmonth.Text = "Day of Month";
            this.rbDmonth.UseVisualStyleBackColor = true;
            this.rbDmonth.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbDWeek
            // 
            this.rbDWeek.AutoSize = true;
            this.rbDWeek.Location = new System.Drawing.Point(8, 80);
            this.rbDWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbDWeek.Name = "rbDWeek";
            this.rbDWeek.Size = new System.Drawing.Size(106, 20);
            this.rbDWeek.TabIndex = 2;
            this.rbDWeek.Text = "Day of Week";
            this.rbDWeek.UseVisualStyleBackColor = true;
            this.rbDWeek.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(8, 52);
            this.rbMonthly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(74, 20);
            this.rbMonthly.TabIndex = 1;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            this.rbMonthly.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Location = new System.Drawing.Point(8, 23);
            this.rbDaily.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(59, 20);
            this.rbDaily.TabIndex = 0;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbRestart);
            this.groupBox2.Controls.Add(this.rbShutdown);
            this.groupBox2.Location = new System.Drawing.Point(167, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(139, 196);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operation";
            // 
            // rbRestart
            // 
            this.rbRestart.AutoSize = true;
            this.rbRestart.Location = new System.Drawing.Point(8, 52);
            this.rbRestart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbRestart.Name = "rbRestart";
            this.rbRestart.Size = new System.Drawing.Size(71, 20);
            this.rbRestart.TabIndex = 1;
            this.rbRestart.Text = "Restart";
            this.rbRestart.UseVisualStyleBackColor = true;
            // 
            // rbShutdown
            // 
            this.rbShutdown.AutoSize = true;
            this.rbShutdown.Checked = true;
            this.rbShutdown.Location = new System.Drawing.Point(8, 23);
            this.rbShutdown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbShutdown.Name = "rbShutdown";
            this.rbShutdown.Size = new System.Drawing.Size(86, 20);
            this.rbShutdown.TabIndex = 0;
            this.rbShutdown.TabStop = true;
            this.rbShutdown.Text = "Shutdown";
            this.rbShutdown.UseVisualStyleBackColor = true;
            // 
            // lblbuild
            // 
            this.lblbuild.AutoSize = true;
            this.lblbuild.Location = new System.Drawing.Point(16, 300);
            this.lblbuild.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblbuild.Name = "lblbuild";
            this.lblbuild.Size = new System.Drawing.Size(62, 16);
            this.lblbuild.TabIndex = 4;
            this.lblbuild.Text = "Version : ";
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Location = new System.Drawing.Point(25, 265);
            this.lblCountDown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(53, 16);
            this.lblCountDown.TabIndex = 5;
            this.lblCountDown.Text = "Status : ";
            // 
            // lblNow
            // 
            this.lblNow.AutoSize = true;
            this.lblNow.Location = new System.Drawing.Point(140, 214);
            this.lblNow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNow.Name = "lblNow";
            this.lblNow.Size = new System.Drawing.Size(30, 16);
            this.lblNow.TabIndex = 3;
            this.lblNow.Text = "N/A";
            // 
            // lblDateN
            // 
            this.lblDateN.AutoSize = true;
            this.lblDateN.Location = new System.Drawing.Point(489, 214);
            this.lblDateN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateN.Name = "lblDateN";
            this.lblDateN.Size = new System.Drawing.Size(30, 16);
            this.lblDateN.TabIndex = 4;
            this.lblDateN.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Date :";
            // 
            // lblSDD
            // 
            this.lblSDD.AutoSize = true;
            this.lblSDD.Location = new System.Drawing.Point(340, 214);
            this.lblSDD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDD.Name = "lblSDD";
            this.lblSDD.Size = new System.Drawing.Size(133, 16);
            this.lblSDD.TabIndex = 6;
            this.lblSDD.Text = "Next Shutdown Date :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(313, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(345, 196);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setup";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDay);
            this.flowLayoutPanel1.Controls.Add(this.cboDayNo);
            this.flowLayoutPanel1.Controls.Add(this.cboDay);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dtpHour);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePicker1);
            this.flowLayoutPanel1.Controls.Add(this.cbStart);
            this.flowLayoutPanel1.Controls.Add(this.cbState);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 17);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 171);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(4, 0);
            this.lblDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(32, 16);
            this.lblDay.TabIndex = 3;
            this.lblDay.Text = "Day";
            // 
            // cboDayNo
            // 
            this.cboDayNo.FormattingEnabled = true;
            this.cboDayNo.Location = new System.Drawing.Point(4, 20);
            this.cboDayNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDayNo.Name = "cboDayNo";
            this.cboDayNo.Size = new System.Drawing.Size(201, 24);
            this.cboDayNo.TabIndex = 5;
            this.cboDayNo.Visible = false;
            // 
            // cboDay
            // 
            this.cboDay.FormattingEnabled = true;
            this.cboDay.Location = new System.Drawing.Point(4, 52);
            this.cboDay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(201, 24);
            this.cboDay.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time";
            // 
            // dtpHour
            // 
            this.dtpHour.CustomFormat = "HH:mm:ss";
            this.dtpHour.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHour.Location = new System.Drawing.Point(4, 100);
            this.dtpHour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHour.Name = "dtpHour";
            this.dtpHour.Size = new System.Drawing.Size(201, 22);
            this.dtpHour.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(4, 130);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 22);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Visible = false;
            // 
            // cbStart
            // 
            this.cbStart.AutoSize = true;
            this.cbStart.Location = new System.Drawing.Point(4, 160);
            this.cbStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(86, 20);
            this.cbStart.TabIndex = 4;
            this.cbStart.Text = "Auto Start";
            this.cbStart.UseVisualStyleBackColor = true;
            // 
            // cbState
            // 
            this.cbState.AutoSize = true;
            this.cbState.Location = new System.Drawing.Point(4, 188);
            this.cbState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(145, 20);
            this.cbState.TabIndex = 4;
            this.cbState.Text = "Minimize on start up";
            this.cbState.UseVisualStyleBackColor = true;
            // 
            // lbltimer
            // 
            this.lbltimer.AutoSize = true;
            this.lbltimer.Location = new System.Drawing.Point(140, 265);
            this.lbltimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltimer.Name = "lbltimer";
            this.lbltimer.Size = new System.Drawing.Size(61, 16);
            this.lbltimer.TabIndex = 8;
            this.lbltimer.Text = "TimerCD";
            this.lbltimer.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 282);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormShutdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 327);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbltimer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblSDD);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDateN);
            this.Controls.Add(this.lblbuild);
            this.Controls.Add(this.lblNow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormShutdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSCShutdown";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CSCShutdown_FormClosing);
            this.Load += new System.EventHandler(this.CSCShutdown_Load);
            this.Shown += new System.EventHandler(this.CSCShutdown_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDmonth;
        private System.Windows.Forms.RadioButton rbDWeek;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbRestart;
        private System.Windows.Forms.RadioButton rbShutdown;
        private System.Windows.Forms.Label lblbuild;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Label lblDateN;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.Label lblSDD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.ComboBox cboDayNo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHour;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbStart;
        private System.Windows.Forms.CheckBox cbState;
        private System.Windows.Forms.Label lbltimer;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Timer timer1;
    }
}

