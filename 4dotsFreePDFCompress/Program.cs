using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace _4dotsFreePDFCompress
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        const int ATTACH_PARENT_PROCESS = -1;
        const int ERROR_ACCESS_DENIED = 5;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///               
                
        [STAThread]
        static void Main(string[] args)
        {                        
            //Module.args = args;
            
            for (int k = 0; k < args.Length; k++)
            {
                //Module.ShowMessage(args[k]);

            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ExceptionHandlersHelper.AddUnhandledExceptionHandlers();

            frmLanguage.SetLanguages();
            frmLanguage.SetLanguage();

            if (args.Length > 0 && args[0].StartsWith("/uninstall"))
            {
                Module.DeleteApplicationSettingsFile();
                /*
                frmUninstallQuestionnaire fq = new frmUninstallQuestionnaire();
                fq.ShowDialog();
                */

                System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?uninstall=true&app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
                
                Environment.Exit(0);

                return;
            }                        

            if (args.Length > 0)
            {
                //System.Threading.Thread.Sleep(2000);
            }


            Module.args = args;                       

            if (ArgsHelper.IsFromCommandLine)
            {
                if (!AttachConsole(ATTACH_PARENT_PROCESS) && Marshal.GetLastWin32Error() == ERROR_ACCESS_DENIED)
                {
                    AllocConsole();
                }

                ArgsHelper.ExamineArgs(args);

                ArgsHelper.ExecuteCommandLine();

                Environment.Exit(0);
            }
            else if (ArgsHelper.IsFromWindowsExplorer)
            {
                ArgsHelper.ExamineArgs(args);
            }                        

            Application.Run(frmMain.Instance);                                    
        }        
    }
}