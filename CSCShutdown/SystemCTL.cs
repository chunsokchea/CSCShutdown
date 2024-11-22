using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSCShutdown
{
    public static class SystemCTL
    {
        //public static bool IsFirstSunday(DateTime date)
        //{
        //    if (date.DayOfWeek == DayOfWeek.Sunday)
        //    {
        //        int day = date.Day;
        //        return day <= 7; // The first Sunday will always be in the first 7 days of the month
        //    }
        //    return false;
        //}
        public static bool IsFirstDayofMonth(DateTime date, string dayName)
        {
            if (date.DayOfWeek.ToString() == dayName)
            {
                int day = date.Day;
                return day <= 7; // The first Sunday will always be in the first 7 days of the month
            }
            return false;
        }
        //public static int IsFirstDayofMonthDay(DateTime date, string dayName)
        //{
        //    if (date.DayOfWeek.ToString() == dayName)
        //    {
        //        int day = date.Day;
        //        return day; // The first Sunday will always be in the first 7 days of the month
        //    }
        //    else
        //        return 0;
        //}
        public static DateTime GetFirstSundayOfMonth(DateTime datein, string dayName)
        {
            for (int day = 1; day <= DateTime.DaysInMonth(datein.Year, datein.Month); day++)
            {
                DateTime date = new DateTime(datein.Year, datein.Month, day);
                if (date.DayOfWeek.ToString() == dayName)
                {
                    return date;
                }
            }
            throw new InvalidOperationException("This should never happen.");
        }
        public static bool IsDayofWeek(DateTime date, string dayName) 
        { 
            return date.DayOfWeek.ToString() == dayName; 
        }
        public static bool IsMonthly(DateTime date)
        {
            return date.Day == DateTime.Now.Day;
        }
        //public static DateTime GetFirstSunday(int year, int month)
        //{
        //    // Start with the first day of the month
        //    DateTime firstDay = new DateTime(year, month, 1);

        //    // Calculate the number of days to add to get to the first Sunday
        //    int daysToAdd = ((int)DayOfWeek.Sunday - (int)firstDay.DayOfWeek + 7) % 7;

        //    // Add the calculated number of days to the first day of the month
        //    return firstDay.AddDays(daysToAdd);
        //}

        public static void Shutdown(int seconds=0)
        {
            Process.Start(new ProcessStartInfo("shutdown", $"/s /f /t {seconds}")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });
            //.return true;
        }

        public static void Restart(int seconds=0)
        {
            Process.Start(new ProcessStartInfo("shutdown", $"/r /f /t {seconds}")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });
           /// return true;
        }
        public static bool IsInteger(string input)
        {
            return int.TryParse(input, out _); // Using int.TryParse to check for integer value
        }
        public static bool IsDecimal(string input)
        {
            return decimal.TryParse(input, out _); // Using decimal.TryParse to check for decimal value
        }


        public static void AddApplicationToStartup()
        {
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(startupFolderPath, "CSCShutdown.lnk");

            if (!System.IO.File.Exists(shortcutPath))
            {
                WshShell wshShell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)wshShell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.Description = "CSC Shutdown";
                shortcut.Save();
            }
        }

    }
}
