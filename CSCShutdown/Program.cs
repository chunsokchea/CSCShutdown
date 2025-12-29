using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CSCShutdown
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, "YourUniqueMutexName", out createdNew))
            {
                if (!createdNew)
                {
                    MessageBox.Show("Another instance of the application is already running.", "Instance Already Running",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormShutdown());
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CSCShutdown());
        }
    }
}
