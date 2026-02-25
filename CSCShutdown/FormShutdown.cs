using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace CSCShutdown
{
    public partial class FormShutdown : Form
    {
        Version version=Assembly.GetExecutingAssembly().GetName().Version;
        Dictionary<string, string> settings = new Dictionary<string, string>();
        string dayName;
        DateTime date;
        DateTime dateToday=DateTime.Now;
        int type;
        bool opera;
        int dayNo;
        bool isStartup;
        bool isMinimize;
        static DateTime nextTargetTime;
        static System.Timers.Timer timer;
        public FormShutdown()
        {
            InitializeComponent();            

            dtpHour.Value=DateTime.Now;
            PopulateComboBox(cboDay);
            PopulateComboBoxMonth(cboDayNo);
            groupBox2.Visible = false;            
            lblbuild.Text = lblbuild.Text.ToString() + version.ToString();

            checkExisting();
            setSetting();

            if (isMinimize == true)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            if (isStartup == true)
            {
                if (StartupShortcut.IsApplicationInStartup() == false)
                    StartupShortcut.AddApplicationToStartup();
            }
            ConfigureStartupCheckbox();
            dateToday= DateTime.Now;
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
            try
            {
                Console.WriteLine(timer1.Interval.ToString());
                dateToday = DateTime.Now;
                //today = Convert.ToDateTime(dateTimePicker1.Value.ToString("dd/MM/yyy") + " " + DateTime.Now.TimeOfDay.ToString());            
                daysInCurrentMonth = DateTime.DaysInMonth(dateToday.Year, dateToday.Month);
                dayNo = dayNo > daysInCurrentMonth ? daysInCurrentMonth : dayNo;
                //date = Convert.ToDateTime(dayNo.ToString() + today.ToString("/MM/yyy") + " " + date.TimeOfDay.ToString());
                lbltimer.Text = date.ToString() + " " + dateToday.ToString() + " " + (date - dateToday).TotalMinutes.ToString();
                doShutdownorRestart();

                lblNow.Text = dateToday.ToShortDateString();
                lblDateN.Text = SystemCTL.GetFirstSundayOfMonth(dateToday.AddMonths(1), dayName).ToShortDateString();

                var t1 = dateToday;
                var t2 = date;
                var t3 = (t2 - t1);

                Console.WriteLine($"Inverval: {timer1.Interval.ToString()}, Days: {t3.Days}, Hours: {t3.Hours}, Minutes: {t3.Minutes}");
                //reset timer
                if (t3.Days >= 0 && t3.Hours >= 2 && t3.Minutes >= 0)
                {
                    timer1.Interval = (int)TimeSpan.FromHours(1).TotalMilliseconds; // 1h
                    Console.WriteLine($"Days: {t3.Days}, Hours: {t3.Hours}, Minutes: {t3.Minutes}");
                }
                else if (t3.Days >= 0 && t3.Hours >= 1 && t3.Minutes >= 0)
                {
                    timer1.Interval = (int)TimeSpan.FromMinutes(30).TotalMilliseconds; // 30m
                    Console.WriteLine($"Days: {t3.Days}, Hours: {t3.Hours}, Minutes: {t3.Minutes}");
                }
                else
                if (t3.Days >= 0 && t3.Hours >= 0 && t3.Minutes >= 30)
                {
                    timer1.Interval = (int)TimeSpan.FromSeconds(10).TotalMilliseconds; // 10s                                                                                             
                    Console.WriteLine($"Days: {t3.Days}, Hours: {t3.Hours}, Minutes: {t3.Minutes}");
                }
                else
                {
                    timer1.Interval = 1000; // 1s                                                 
                    Console.WriteLine($"Days: {t3.Days}, Hours: {t3.Hours}, Minutes: {t3.Minutes}");
                }
                Console.WriteLine($"Inverval: {timer1.Interval.ToString()}, Days: {t3.Days}, Hours: {t3.Hours}, Minutes: {t3.Minutes}");

            }
            catch (Exception ex)
            {
                timer1.Stop();
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Wrong Setting! " + ex.ToString());
                
            }
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
                        isDaily();
                        break;
                    case "rbMonthly":
                        selectedOption = 2;
                        groupBox2.Visible = true;                        
                        cboDay.Visible = false;
                        lblDay.Visible = true;
                        cboDayNo.Visible = true;
                        //dtpDate.CustomFormat = " dd ";
                        isMonthly();
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
                        IsDayofWeek();
                        break;
                    case "rbDmonth":
                        selectedOption = 4;
                        groupBox2.Visible = true;
                        cboDay.Visible = true;
                        lblDay.Visible = true;
                        //dtpDate.CustomFormat = " dd(ddd) ";
                        cboDayNo.Visible = false;
                        label1.Text = "Option 4 selected " ;
                        IsDayofMonth();
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
            isMinimize = cbState.Checked ? true : false;
            isStartup = cbStart.Checked ? true : false;
            //Properties.Settings.Default.SDay = dayName;
            //Properties.Settings.Default.STime = (TimeSpan)date.TimeOfDay;
            //Properties.Settings.Default.SType = type;
            //Properties.Settings.Default.Sopera = opera;
            //Properties.Settings.Default.DayNum = dayNo;
            //Properties.Settings.Default.IsMinimize = cbState.Checked ? true : false;
            //Properties.Settings.Default.Startup = cbStart.Checked ? true : false;
            // Properties.Settings.Default.Save();
            string settingsText =
$@"SDay={dayName}
STime={date.ToString("HH:mm:ss")}
SType={type}
Sopera={opera}
DayNum={dayNo}
IsMinimize={isMinimize}
Startup={isStartup}";

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appFolder = Path.Combine(documentsPath, "CSCShutdownApp");

            // Ensure folder exists
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }

            string filePath = Path.Combine(appFolder, "CSCShutdownSettings.txt");

            // Save settings
            File.WriteAllText(filePath, settingsText);

            //MessageBox.Show("Settings saved successfully!");           
            
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
            timer1.Interval = 1000;            
            setSetting();
            MessageBox.Show("Save New Settings Success!");
        }
        private void readTxtFile()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appFolder = Path.Combine(documentsPath, "CSCShutdownApp");
            string filePath = Path.Combine(appFolder, "CSCShutdownSettings.txt");

            // Dictionary to hold settings
            settings = new Dictionary<string, string>();

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Split by '=' into key and value
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        settings[key] = value;
                    }
                }

                // Example: print out the settings
                foreach (var kvp in settings)
                {
                    Console.WriteLine($"{kvp.Key} = {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("Settings file not found.");
            }
        }
        private void checkExisting()
        {
            try
            {
                // Default settings text
                string defaultSettings = @"SType=3
SDay=Sunday
STime=21:00:00
Sopera=False
DayNum=1
IsMinimize=False
Startup=False";

                // Get the user's Documents folder
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Define your app folder inside Documents
                string appFolder = Path.Combine(documentsPath, "CSCShutdownApp");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(appFolder))
                {
                    Directory.CreateDirectory(appFolder);
                    Console.WriteLine("App folder created.");
                }

                // Define the file path
                string filePath = Path.Combine(appFolder, "CSCShutdownSettings.txt");

                // If the file doesn't exist, create it with default content
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, defaultSettings);
                    Console.WriteLine("Default settings file created.");
                }
                else
                {
                    Console.WriteLine("Settings file already exists.");
                }

                Console.WriteLine($"Path: {filePath}");
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void setSetting()
        {
            try
            {
                //dayName = Properties.Settings.Default.SDay.ToString();
                //date = Convert.ToDateTime(DateTime.Now.Date.ToString("dd/MM/yyy") + " " + Properties.Settings.Default.STime.ToString());
                //type = Properties.Settings.Default.SType;
                //opera = Properties.Settings.Default.Sopera;
                //dayNo = Properties.Settings.Default.DayNum;
                //isMinimize = Properties.Settings.Default.IsMinimize;
                //isStartup = Properties.Settings.Default.Startup;

                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string appFolder = Path.Combine(documentsPath, "CSCShutdownApp");
                string filePath = Path.Combine(appFolder, "CSCShutdownSettings.txt");

                settings = SettingsLoader.LoadSettings(filePath);

                dayName = settings["SDay"];
                //date = Convert.ToDateTime(DateTime.Now.Date.ToString("dd/MM/yyyy") + " " + settings["STime"]);
                var date = DateTime.Now.Date;
                var time = TimeSpan.Parse(settings["STime"]); // e.g. "14:30"
                var datetime = date.Add(time);
                Console.WriteLine(datetime.ToLocalTime());
                date = datetime;

                type = int.Parse(settings["SType"]);
                opera = bool.Parse(settings["Sopera"]);
                dayNo = int.Parse(settings["DayNum"]);
                isMinimize = bool.Parse(settings["IsMinimize"]);
                isStartup = bool.Parse(settings["Startup"]);

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

                timer1.Enabled = true;
                timer1.Start();
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MessageBox.Show("Wrong Setting! " + ex.ToString());
                Console.WriteLine(ex.ToString());
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
            else if (opt == 4)
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
            dateToday= DateTime.Now;
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
            //dateToday = Convert.ToDateTime(DateTime.Now.Date.ToString("dd/MM/yyy") + " " + dateToday.TimeOfDay.ToString());
            
            lblNow.Text = dateToday.ToLongDateString();

            DoOperation();
        }
        int daysInCurrentMonth;
        private void isMonthly()
        {
            if(DateTime.Now.Day>dayNo)
                dateToday = Convert.ToDateTime(dayNo.ToString() +$"/{DateTime.Now.AddMonths(1).Month.ToString()}"+ dateToday.ToString("/yyy") + " " + dateToday.TimeOfDay.ToString());
            else
                dateToday = Convert.ToDateTime(dayNo.ToString() + dateToday.ToString("/MM/yyy") + " " + dateToday.TimeOfDay.ToString());
            lblSDD.Visible = false;
            lblDateN.Visible = false;

            lblNow.Text = dateToday.ToLongDateString();

            if (SystemCTL.IsMonthly(date) && dateToday.Day==dayNo )
            {
                DoOperation();

                label1.Text = $"{dateToday:dddd, MMMM d, yyyy} is day {dayNo.ToString()} of the Month.";
            }
            else
            {
                if(dateToday.Day == daysInCurrentMonth)
                {
                    lblCountDown.Text = "Not time yet! ";
                    DoOperation();

                    label1.Text = $"{dateToday:dddd, MMMM d, yyyy} is day {daysInCurrentMonth} of the Month.";
                }
                else
                {
                    label1.Text = $"{dateToday:dddd, MMMM d, yyyy} is not day {dayNo.ToString()} of the Month.";

                    lblCountDown.Text = "Not time yet! ";
                }
                    
            }
        }
        private void IsDayofWeek()
        {
            lblSDD.Visible = false;
            lblDateN.Visible = false;
            //date=dateToday;
            //dateToday = Convert.ToDateTime(DateTime.Now.Date.ToString("dd/MM/yyy") + " " + dateToday.TimeOfDay.ToString());
            dateToday = DateTime.Today;

            lblNow.Text = dateToday.ToLongDateString();

            if (SystemCTL.IsDayofWeek(dateToday, dayName))
            {
                DoOperation();
                //Console.WriteLine("It's time to do operation");
                label1.Text = $"{dateToday:dddd, MMMM d, yyyy} is {dayName} of the week.";

            }
            else
            {
                label1.Text = $"{dateToday:dddd, MMMM d, yyyy} is not {dayName} of the week.";
                lblCountDown.Text = "Not time yet! ";
            }
        }
        private void IsDayofMonth()
        {
            lblSDD.Visible = true;
            lblDateN.Visible = true;
            dateToday = DateTime.Today;

            lblNow.Text = dateToday.ToLongDateString();

            if (SystemCTL.IsFirstDayofMonth(dateToday, dayName))
            {
                DoOperation();

                label1.Text = $"{dateToday:dddd, MMMM d, yyyy} is the first {dayName} of the month.";
            }
            else
            {
                label1.Text = $"{dateToday:dddd, MMMM d, yyyy} is not the first {dayName} of the month.";
                lblCountDown.Text = "Not time yet! ";

            }
            //if (SystemCTL.GetFirstSundayOfMonth(today, dayName).Day < today.Day)
            //{
            //    date = Convert.ToDateTime(SystemCTL.GetFirstSundayOfMonth(today.AddMonths(1), dayName).ToString("dd/MM/yyy") + " " + date.TimeOfDay.ToString());
            //}
            //else
            //{
            //    date = Convert.ToDateTime(SystemCTL.GetFirstSundayOfMonth(today, dayName).ToString("dd/MM/yyy") + " " + date.TimeOfDay.ToString());
            //}
        }
        
        private void DoOperation()
        {
            Console.WriteLine(date.ToString() + " " + dateToday.ToString());
            var t1 = dateToday;
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
                        //Console.WriteLine($"It is Time Days: {t3.Days}, Hours: {t3.Hours}, Minutes: {t3.Minutes}");
                    }
                    else if((t3.Minutes==10 || t3.Minutes== 5 || t3.Minutes == 2 || t3.Minutes == 1) && t3.Hours == 0 && t3.Seconds == 0)
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
                timer1.Stop();
                //MessageBox.Show("Error : "+ex.ToString());
                //throw;
                Console.WriteLine(ex.ToString());
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

        private void CSCShutdown_Load(object sender, EventArgs e)
        {
            dateToday = DateTime.Now;
            //DoOperation();            
            var time1 = TimeSpan.Parse(settings["STime"]); // e.g. "14:30"
            var datetime = dateToday.Date.Add(time1);
            date = datetime;

            dtpHour.Format = DateTimePickerFormat.Time;
            dtpHour.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(timer1.Interval.ToString());
            readTxtFile();
        }

        //static void SetNextInterval()
        //{
        //    TimeSpan remaining = nextTargetTime - DateTime.Now;

        //    if (remaining.TotalHours >= 2)
        //    {               
        //        timer.Interval = TimeSpan.FromHours(1).TotalMilliseconds; // 1h
        //    }
        //    else if (remaining.TotalHours >= 1)
        //    {
        //        timer.Interval = TimeSpan.FromMinutes(30).TotalMilliseconds; // 30m
        //    }
        //    else if (remaining.TotalMinutes >= 1)
        //    {
        //        timer.Interval = TimeSpan.FromSeconds(10).TotalMilliseconds; // 10s
        //    }
        //    else
        //    {
        //        timer.Interval = 1000; // 1s
        //    }            
        //    Console.WriteLine($"Next interval set to {timer.Interval / 1000} seconds");
        //}
        //static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    TimeSpan remaining = nextTargetTime - DateTime.Now;

        //    if (remaining <= TimeSpan.Zero)
        //    {
        //        Console.WriteLine("Target time reached!");
        //        timer.Stop();
        //        return;
        //    }

        //    Console.WriteLine($"Remaining: {remaining}");
        //    SetNextInterval(); // Adjust interval dynamically
        //}
    }
}
