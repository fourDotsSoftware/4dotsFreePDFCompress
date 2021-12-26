using System;
using System.Collections.Generic;
using System.Text;

namespace _4dotsFreePDFCompress
{
    class RecentFilesHelper
    {
        public static void FillMenuRecentFile()
        {
            string[] str = Properties.Settings.Default.AddFilesRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmMain.Instance.tsdbAddFile.DropDownItems.Add(str[k]);                
            }
        }

        public static void FillMenuRecentFolder()
        {
            string[] str = Properties.Settings.Default.AddFolderRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmMain.Instance.tsdbAddFolder.DropDownItems.Add(str[k]);
            }
        }

        public static void FillMenuRecentImportList()
        {
            string[] str = Properties.Settings.Default.ImportListRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmMain.Instance.tsdbImportList.DropDownItems.Add(str[k]);
            }
        }

        public static void AddRecentFile(string filepath)
        {
            string[] str = Properties.Settings.Default.AddFilesRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }
            
            strl.Insert(0, filepath);

            frmMain.Instance.tsdbAddFile.DropDownItems.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmMain.Instance.tsdbAddFile.DropDownItems.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.AddFilesRecent = newrec;
        }

        public static void ImportListRecent(string filepath)
        {
            string[] str = Properties.Settings.Default.ImportListRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmMain.Instance.tsdbImportList.DropDownItems.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k<=12; k++)
            {
                frmMain.Instance.tsdbImportList.DropDownItems.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.ImportListRecent = newrec;
        }

        public static void AddRecentFolder(string filepath)
        {
            string[] str = Properties.Settings.Default.AddFolderRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmMain.Instance.tsdbAddFolder.DropDownItems.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmMain.Instance.tsdbAddFolder.DropDownItems.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.AddFolderRecent = newrec;
        }

        public static List<string> ArrayToListString(string[] str)
        {
            List<string> strl = new List<string>();

            for (int k = 0; k < str.Length; k++)
            {
                strl.Add(str[k]);
            }

            return strl;
        }
    }
}
