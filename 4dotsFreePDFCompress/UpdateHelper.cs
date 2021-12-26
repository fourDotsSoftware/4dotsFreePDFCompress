using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    public class UpdateHelper
    {
        private static System.ComponentModel.BackgroundWorker bwCheckVersion = new System.ComponentModel.BackgroundWorker();

        public static void InitializeCheckVersionWeek()
        {
            string lastcheck = Properties.Settings.Default.LastCheckVersion;

            if (lastcheck != string.Empty)
            {
                int month = int.Parse(lastcheck.Substring(0, 2));
                int day = int.Parse(lastcheck.Substring(2, 2));
                int year = int.Parse(lastcheck.Substring(4, 4));

                DateTime dtlast = new DateTime(year, month, day);

                if (dtlast.AddDays(15).CompareTo(DateTime.Now) <= 0)
                {
                    InitializeCheckVersion();
                }
            }
            else
            {
                InitializeCheckVersion();
            }

            Properties.Settings.Default.LastCheckVersion = DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + DateTime.Now.Year.ToString("D4");

            Properties.Settings.Default.Save();
        }

        public static void InitializeCheckVersion()
        {
            bwCheckVersion.WorkerReportsProgress = true;
            bwCheckVersion.DoWork += bwCheckVersion_DoWork;
            bwCheckVersion.RunWorkerCompleted += bwCheckVersion_RunWorkerCompleted;
            bwCheckVersion.ProgressChanged += bwCheckVersion_ProgressChanged;

            bwCheckVersion.RunWorkerAsync();
        }

        static void bwCheckVersion_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            CheckVersionResult res = (CheckVersionResult)e.UserState;

            if (res.OutputMessage != String.Empty)
            {
                if (!res.NewVersionReleased)
                {
                    Module.ShowMessage(res.OutputMessage);

                    if (res.ItIsNecessaryToUpdate)
                    {
                        frmDownloadUpdate fdu = new frmDownloadUpdate();
                        fdu.ShowDialog();
                    }
                }
                else
                {
                    DialogResult resq = Module.ShowQuestionDialogYesFocus(TranslateHelper.Translate("A new version has been released. Would you like to download it now ?"), TranslateHelper.Translate("Download new version ?"));
                    if (resq == DialogResult.Yes)
                    {
                        //System.Diagnostics.Process.Start(Module.DownloadURL);
                        frmDownloadUpdate fdu = new frmDownloadUpdate();
                        fdu.ShowDialog();
                    }
                }
            }
        }

        static void bwCheckVersion_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            
        }

        static void bwCheckVersion_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CheckVersionResult res = CheckVersionBackground();

            bwCheckVersion.ReportProgress(100, res);
        }
        public static CheckVersionResult CheckVersionBackground()
        {
            bool onstart = true;
            CheckVersionResult res = new CheckVersionResult();

            try
            {
                string str = DownloadPage(Module.VersionURL);

                if (str.StartsWith("http://") || str.StartsWith("https://"))
                {
                    System.Diagnostics.Process.Start(str);
                    return res;
                }

                if (str.Contains("|||"))
                {
                    int epos = str.IndexOf("|||");
                    string price = str.Substring(epos + 3);
                    str = str.Substring(0, epos);

                    Properties.Settings.Default.Price = price;
                }

                if (str != "Error" && str != String.Empty)
                {
                    StringReader sr = new StringReader(str);
                    string line;

                    bool found = false;

                    while ((line = sr.ReadLine()) != null)
                    {
                        int epos = line.IndexOf("=");

                        string title = line.Substring(0, epos);
                        string version = line.Substring(epos + 1, line.Length - epos - 1);
                                                
                        if (version.StartsWith("D"))
                        {
                            version = version.Substring(1);
                            int verdotpos = version.IndexOf(".");
                            int vermajor = int.Parse(version.Substring(0, verdotpos));
                            int verminor = int.Parse(version.Substring(verdotpos + 1));

                            int curverepos = Module.ShortApplicationTitle.LastIndexOf("V");

                            if (curverepos >= 0)
                            {
                                string curver = Module.ShortApplicationTitle.Substring(curverepos + 1);

                                int dotpos=curver.IndexOf(".");

                                int curmajor = int.Parse(curver.Substring(0, dotpos));
                                int curminor=int.Parse(curver.Substring(dotpos+1));

                                if (curmajor < vermajor || (curmajor==vermajor && curminor < verminor))
                                {
                                    found = true;
                                    res.OutputMessage = TranslateHelper.Translate("It is necessary to upgrade to the latest version of the application. Press the OK button to download the new version");
                                    res.ItIsNecessaryToUpdate = true;

                                    return res;
                                }
                            }
                        }

                        string app = title + " V" + version;

                        if (Module.ShortApplicationTitle.StartsWith(title) && app != Module.ShortApplicationTitle)
                        {
                            found = true;
                            res.OutputMessage = TranslateHelper.Translate("A new version has been released. Press the OK button to download the new version");
                            res.NewVersionReleased = true;

                            //System.Diagnostics.Process.Start(Module.DownloadURL);
                        }
                        else if (Module.ShortApplicationTitle.StartsWith(title))
                        {
                            found = true;
                            if (!onstart)
                            {
                                res.OutputMessage = TranslateHelper.Translate("This is the latest version !");
                            }
                        }
                    }

                    if (!found)
                    {
                        if (!onstart)
                        {
                            res.OutputMessage = TranslateHelper.Translate("An error occured !");
                        }
                    }
                }
                else
                {
                    if (!onstart)
                    {
                        res.OutputMessage = TranslateHelper.Translate("An error occured !");
                    }
                }
            }
            catch
            {
                if (!onstart)
                {
                    res.OutputMessage = TranslateHelper.Translate("An error occured !");
                }
            }

            return res;
        }

        public static string DownloadPage(string uri)
        {
            try
            {
                WebClient client = new WebClient();

                Stream data = client.OpenRead(uri);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return s;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public static void CheckVersion(bool onstart)
        {
            try
            {
                string str = DownloadPage(Module.VersionURL);

                if (str != "Error" && str != String.Empty)
                {
                    StringReader sr = new StringReader(str);
                    string line;

                    bool found = false;

                    while ((line = sr.ReadLine()) != null)
                    {
                        int epos = line.IndexOf("=");

                        string title = line.Substring(0, epos);
                        string version = line.Substring(epos + 1, line.Length - epos - 1);

                        string app = title + " V" + version;

                        if (Module.ShortApplicationTitle.StartsWith(title) && app != Module.ShortApplicationTitle)
                        {
                            found = true;
                            Module.ShowMessage("A new version has been released. Press the OK button to download the new version");

                            System.Diagnostics.Process.Start(Module.DownloadURL);
                        }
                        else if (Module.ShortApplicationTitle.StartsWith(title))
                        {
                            found = true;
                            if (!onstart)
                            {
                                Module.ShowMessage("This is the latest version !");
                            }
                        }
                    }

                    if (!found)
                    {
                        if (!onstart)
                        {
                            Module.ShowMessage("An error occured !");
                        }
                    }
                }
                else
                {
                    if (!onstart)
                    {
                        Module.ShowMessage("An error occured !");
                    }
                }
            }
            catch
            {
                if (!onstart)
                {
                    Module.ShowMessage("An error occured !");
                }
            }
        }
    }

    public class CheckVersionResult
    {
        public bool NewVersionReleased = false;
        public bool ItIsNecessaryToUpdate = false;
        public string OutputMessage = "";
    }
}
