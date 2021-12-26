using System;
using System.Collections.Generic;
using System.Text;

namespace _4dotsFreePDFCompress
{
    class OutputFolderHelper
    {
        public static void SaveOutputFolder(string folder)
        {
            if (folder == TranslateHelper.Translate("Subfolder of PDF Document")
                || folder == TranslateHelper.Translate("Overwrite PDF Document")
                || folder == TranslateHelper.Translate("Same Folder of PDF Document")
                || folder == Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString()
                || folder.StartsWith("---------------------")
                || folder.Trim() == string.Empty
                )
            {
                return;
            }
            else if (!folder.StartsWith(TranslateHelper.Translate("Subfolder") + " : ")
                && !System.IO.Directory.Exists(folder))
            {
                return;
            }
            /*
            {                    
                try 
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(folder);
                }
                catch
                {
                    return;
                }
            }
            */

            List<string> lst = new List<string>();

            if (Properties.Settings.Default.OutputFolder1 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder1);
            }

            if (Properties.Settings.Default.OutputFolder2 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder2);
            }

            if (Properties.Settings.Default.OutputFolder3 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder3);
            }

            if (Properties.Settings.Default.OutputFolder4 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder4);
            }

            if (Properties.Settings.Default.OutputFolder5 != string.Empty)
            {
                lst.Add(Properties.Settings.Default.OutputFolder5);
            }

            int lsi = lst.IndexOf(folder);

            if (lsi < 0)
            {
                lst.Insert(0, folder);
            }
            else
            {
                lst.RemoveAt(lsi);
                lst.Insert(0, folder);
            }

            int cmbc=frmMain.Instance.cmbOutputDir.Items.Count;
            for (int k = 5; k < cmbc; k++)
            {
                frmMain.Instance.cmbOutputDir.Items.RemoveAt(5);
            }

            for (int k = 0; k < 5 && k<lst.Count; k++)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(5 + k, lst[k]);

                if (k == 0)
                {
                    Properties.Settings.Default.OutputFolder1 = lst[k];
                }
                else if (k == 1)
                {
                    Properties.Settings.Default.OutputFolder2 = lst[k];
                }
                if (k == 2)
                {
                    Properties.Settings.Default.OutputFolder3 = lst[k];
                }
                if (k == 3)
                {
                    Properties.Settings.Default.OutputFolder4 = lst[k];
                }
                if (k == 4)
                {
                    Properties.Settings.Default.OutputFolder5 = lst[k];
                }
            }

            frmMain.Instance.cmbOutputDir.SelectedIndex = 5;
        }

        public static void LoadOutputFolders()
        {
            int k = 5;
            if (Properties.Settings.Default.OutputFolder1 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++,Properties.Settings.Default.OutputFolder1);
            }

            if (Properties.Settings.Default.OutputFolder2 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder2);
            }

            if (Properties.Settings.Default.OutputFolder3 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder3);
            }

            if (Properties.Settings.Default.OutputFolder4 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder4);
            }

            if (Properties.Settings.Default.OutputFolder5 != string.Empty)
            {
                frmMain.Instance.cmbOutputDir.Items.Insert(k++, Properties.Settings.Default.OutputFolder5);
            }
        }
    }
}
