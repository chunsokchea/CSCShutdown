using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace CSCShutdown
{
    public partial class CSCShutdown : Form
    {
        Version version=Assembly.GetExecutingAssembly().GetName().Version;
        string dayName;
        DateTime date;
        int type;
        bool opera;
        int dayNo;
        bool isStartup;
        bool isMinimize;
        public CSCShutdown()
        {
            InitializeComponent();
            

            dtpHour.Value=DateTime.Now;
            PopulateComboBox(cboDay);
            PopulateComboBoxMonth(cboDayNo);
            groupBox2.Visible = false;
            setSetting();
            lblbuild.Text = lblbuild.Text.ToString() + version.ToString();

            ConfigureStartupCheckbox();
            if (isMinimize == true)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            if (isStartup == true)
            {
                if (StartupShortcut.IsApplicationInStartup() == false)
                    StartupShortcut.AddApplicationToStartup();
            }
        }
        private void ConfigureStartupCheckbox()
        {
            cbStart.Checked = StartupShortcut.IsApplicationInStartup();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Check if the close button was clicked or Alt+F4 was pressed
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the close operation
                this.Hide(); // Hide the form
                notifyIcon1.Visible = true; // Show the NotifyIcon
            }
        }
        int selectedOption = 1;
        private void Form1_Resize(object sender, EventArgs e)
        {            
            if (this.WindowState == FormWindowState.Minimized) 
            { 
                this.Hide(); 
                notifyIcon1.Visible = true; 
            }
        }

        private void ConfigureDailyTimer()
        {           
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show(); 
            this.WindowState = FormWindowState.Normal; 
            notifyIcon1.Visible = false;
        }

        private void InitializeDailyCheck()
        {
            // Set the timer to check every day
            timer1.Interval = (int)TimeSpan.FromDays(1).TotalMilliseconds;
            timer1.Tick += Timer1_Tick;

            // Optionally, start the timer immediately for testing
            Timer1_Tick(this, EventArgs.Empty);

            // Start the timer
            timer1.Start();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            today = DateTime.Now;
            //today = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyy") + " " + DateTime.Now.TimeOfDay.ToString());            
            daysInCurrentMonth = DateTime.DaysInMonth(today.Year, today.Month);
            dayNo = dayNo > daysInCurrentMonth ? daysInCurrentMonth : dayNo;
            date = Convert.ToDateTime(dayNo.ToString() + today.ToString("/MM/yyy") + " " + date.TimeOfDay.ToString());

            doShutdownorRestart();            
            
            lblNow.Text = today.ToString();
            lblDateN.Text = date.ToString() ;
        }
        private void PopulateComboBoxMonth(ComboBox comboBox1)
        {
            for (int i = 1; i <= 31; i++)
            {
                comboBox1.Items.Add(i);
            }

            // Optionally, you can set the default selected item
            comboBox1.SelectedIndex = 0; // Selects the first item (1) by default
        }
        private void PopulateComboBox(ComboBox comboBox1)
        {
            comboBox1.Items.Add("Monday");
            comboBox1.Items.Add("Tuesday");
            comboBox1.Items.Add("Wednesday");
            comboBox1.Items.Add("Thursday");
            comboBox1.Items.Add("Friday");
            comboBox1.Items.Add("Saturday");
            comboBox1.Items.Add("Sunday");

            // Optionally, you can set the default selected item
            comboBox1.SelectedIndex = 0; // Selects the first item (Monday) by default
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                groupBox2.Visible = true;
                switch (radioButton.Name)
                {
                    case "rbDaily":
                        selectedOption = 1;
                        lblDay.Visible = false;
                        cboDay.Visible = false;
                        cboDayNo.Visible = false;
                        label1.Text = "Option 1 selected ";
                        break;
                    case "rbMonthly":
                        selectedOption = 2;
                        groupBox2.Visible = true;                        
                        cboDay.Visible = false;
                        lblDay.Visible = true;
                        cboDayNo.Visible = true;
                        //dtpDate.CustomFormat = " dd ";

                        label1.Text = "Option 2 selected " ;
                        break;
                    case "rbDWeek":
                        selectedOption = 3;
                        groupBox2.Visible = true;
                        cboDay.Visible = true;
                        lblDay.Visible = true;
                        //dtpDate.CustomFormat = " dd(ddd) ";
                        cboDayNo.Visible = false;
                        label1.Text = "Option 3 selected " ;
                        break;
                    case "rbDmonth":
                        selectedOption = 4;
                        groupBox2.Visible = true;
                        cboDay.Visible = true;
                        lblDay.Visible = true;
                        //dtpDate.CustomFormat = " dd(ddd) ";
                        cboDayNo.Visible = false;
                        label1.Text = "Option 4 selected " ;
                        break;
                    default:
                        label1.Text = "No option selected";
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (groupBox2.Visible == false)
            {
                MessageBox.Show("Please select one of type in select list!");
                return;
            }
            dayName= cboDay.Text;
            date = dtpHour.Value;
            type = selectedOption;
            opera= rbShutdown.Checked ? true : false;
            dayNo = Convert.ToInt32(cboDayNo.Text.Trim());

            Properties.Settings.Default.SDay = dayName;
            Properties.Settings.Default.STime = (TimeSpan)date.TimeOfDay;
            Properties.Settings.Default.SType = type;
            Properties.Settings.Default.Sopera = opera;
            Properties.Settings.Default.DayNum = dayNo;
            Properties.Settings.Default.IsMinimize = cbState.Checked ? true : false;
            Properties.Settings.Default.Startup = cbStart.Checked ? true : false;

            Properties.Settings.Default.Save();
            
            if (cbStart.Checked == true)
            {
                if(StartupShortcut.IsApplicationInStartup()==false)
                    StartupShortcut.AddApplicationToStartup();
            }
            else
            {
                if (StartupShortcut.IsApplicationInStartup() == true)
                    StartupShortcut.RemoveApplicationFromStartup();
            }
            //label1.Text = dayNo.ToString()+"-" + Properties.Settings.Default.DayNo.ToString();
            MessageBox.Show("Save New Settings Success!");
        }
        
        private void setSetting()
        {
            try
            {
                dayName = Properties.Settings.Default.SDay.ToString();
                date = Convert.ToDateTime(DateTime.Now.Date.ToString("dd/MM/yyy") + " " + Properties.Settings.Default.STime.ToString());
                type = Properties.Settings.Default.SType;
                opera = Properties.Settings.Default.Sopera;
                dayNo = Properties.Settings.Default.DayNum;
                isMinimize = Properties.Settings.Default.IsMinimize;
                isStartup = Properties.Settings.Default.Startup;

                groupBox2.Visible = true;
                cboDay.Text = dayName;
                dtpHour.Value = date;
                cboDayNo.Text = dayNo.ToString();
                cbState.Checked = isMinimize;
                cbStart.Checked = isStartup;
                //var a = DateTime.Now.Date.ToString("dd/MM/yyy") + " " + Properties.Settings.Default.Time.ToString();
                selectTypeRadio(type);
                if (opera == true)
                    rbShutdown.Checked = true;
                else
                    rbRestart.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong Setting! " + ex.ToString());
                //throw;
            }
            
        }

        private void selectTypeRadio(int opt)
        {
            if (opt == 1)
                rbDaily.Checked = true;
            else if (opt == 2)
                rbMonthly.Checked = true;
            else if (opt == 3)
                rbDWeek.Checked = true;
            else
                rbDmonth.Checked = true;

        }
        ///SystemCTL sysCrl =  SystemCTL();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            //today = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyy") + " " + DateTime.Now.TimeOfDay.ToString());
            //daysInCurrentMonth = DateTime.DaysInMonth(today.Year, today.Month);
            //date = Convert.ToDateTime(daysInCurrentMonth.ToString() + today.ToString("/MM/yyy") + " " + date.TimeOfDay.ToString());
            //doShutdownorRestart();
        }

        private void doShutdownorRestart()
        {            
            switch (type)
            {
                case 1:                   
                    isDaily();
                    break;
                case 2:                    
                    isMonthly();
                    break;
                case 3:                    
                    IsDayofWeek();
                    break;
                case 4:                    
                    IsDayofMonth();
                    break;
            }            
        }
        private void isDaily()
        {
            lblSDD.Visible = false;
            lblDateN.Visible = false;
            date = Convert.ToDateTime(DateTime.Now.Date.ToString("dd/MM/yyy") + " " + date.TimeOfDay.ToString());
            DoOperation();
        }
        int daysInCurrentMonth;
        private void isMonthly()
        {
            //DateTime today = DateTime.Today;            
            lblSDD.Visible = false;
            lblDateN.Visible = false;

            if (SystemCTL.IsMonthly(date) && today.Day==dayNo )
            {
                DoOperation();

                label1.Text = $"{today:dddd, MMMM d, yyyy} is day {dayNo.ToString()} of the Month.";
            }
            else
            {
                if(today.Day == daysInCurrentMonth)
                {
                    lblCountDown.Text = "Not time yet! ";
                    DoOperation();

                    label1.Text = $"{today:dddd, MMMM d, yyyy} is day {daysInCurrentMonth} of the Month.";
                }
                else
                {
                    label1.Text = $"{today:dddd, MMMM d, yyyy} is not day {dayNo.ToString()} of the Month.";

                    lblCountDown.Text = "Not time yet! ";
                }
                    
            }
        }
        private void IsDayofWeek()
        {
            lblSDD.Visible = false;
            lblDateN.Visible = false;
            if (SystemCTL.IsDayofWeek(today, dayName))
            {
                DoOperation();

                label1.Text = $"{today:dddd, MMMM d, yyyy} is {dayName} of the week.";

            }
            else
            {
                label1.Text = $"{today:dddd, MMMM d, yyyy} is not {dayName} of the week.";
            }
        }
        private void IsDayofMonth()
        {
            lblSDD.Visible = true;
            lblDateN.Visible = true;
            DateTime today = DateTime.Today;
            if (SystemCTL.IsFirstDayofMonth(today, dayName))
            {
                DoOperation();

                label1.Text = $"{today:dddd, MMMM d, yyyy} is the first {dayName} of the month.";
            }
            else
            {
                label1.Text = $"{today:dddd, MMMM d, yyyy} is not the first {dayName}.";
                
            }
            if (SystemCTL.GetFirstSundayOfMonth(today, dayName).Day < today.Day)
            {
                date = Convert.ToDateTime(SystemCTL.GetFirstSundayOfMonth(today.AddMonths(1), dayName).ToString("dd/MM/yyy") + " " + date.TimeOfDay.ToString());
            }
            else
            {
                date = Convert.ToDateTime(SystemCTL.GetFirstSundayOfMonth(today, dayName).ToString("dd/MM/yyy") + " " + date.TimeOfDay.ToString());
            }
        }
        DateTime today;
        private void DoOperation()
        {
            var t1 = today;
            var t2 = date;
            var t3 = (t2 - t1);
            var operation = opera == true ? "Shutdown" : "Restart";
            try
            {
                if (t3.TotalMinutes <= 60 && t3.TotalMinutes > 0)
                {

                    lblCountDown.Text = $"{operation} in {t3.Minutes} Minute {t3.Seconds} second";

                    if ((int)t3.Seconds == 0 && (int)t3.Minutes == 1 && (int)t3.Hours == 0)
                    {
                        if (opera == true)
                            SystemCTL.Shutdown((int)t3.TotalSeconds);
                        else
                            SystemCTL.Restart((int)t3.TotalSeconds);
                        //lblCountDown.Text = "Operation S R";
                    }else if((t3.Minutes==10 || t3.Minutes== 5 || t3.Minutes == 2 || t3.Minutes == 1) && t3.Hours == 0 && t3.Seconds == 0)
                    {
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipTitle = $"{operation}"; 
                        notifyIcon1.BalloonTipText = $"Computer will be {operation} in {t3.Minutes} Minute!"; 
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                }
                else if (t3.TotalMinutes < 0)
                    lblCountDown.Text = $"Over time to {operation}!";
                else
                    lblCountDown.Text = "Not time yet! ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : "+ex.ToString());
                //throw;
            }            
            
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show(); 
            this.WindowState = FormWindowState.Normal; 
            notifyIcon1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false; 
            Application.Exit();
        }

        private void CSCShutdown_FormClosing(object sender, FormClosingEventArgs e)
        {            
            //this.Hide();
            //notifyIcon1.Visible = true;
        }

        private void CSCShutdown_Shown(object sender, EventArgs e)
        {
            if (isMinimize == true)
            {
                this.Hide();
                notifyIcon1.Visible = true; // Ensure the NotifyIcon is visible
                notifyIcon1.BalloonTipTitle = "CSCShutdown Minimized";
                notifyIcon1.BalloonTipText = "The CSCShutdown is running in the background.";
                notifyIcon1.ShowBalloonTip(3000); // Show notification for 3 seconds
            }            
        }
    }
}
