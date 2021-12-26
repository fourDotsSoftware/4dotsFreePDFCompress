using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    class TranslateHelper
    {
        private static System.Resources.ResourceManager rm = null;

        public static string Translate(string str)
        {
            if (rm == null)
            {
                TranslateHelper cm = new TranslateHelper();
                rm = new System.Resources.ResourceManager("_4dotsFreePDFCompress.ResTranslate", cm.GetType().Assembly);

            }
            try
            {
                string trnstr = "";
                if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString() == "en-US")
                {
                    trnstr = rm.GetString(str, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    trnstr = rm.GetString(str);
                }
                if (trnstr == null || trnstr == "")
                {
                    trnstr = rm.GetString(str, System.Globalization.CultureInfo.InvariantCulture);
                    if (trnstr == null)
                    {
                        return str;
                    }
                    else
                    {
                        return trnstr;
                    }
                }
                else
                {
                    return trnstr;
                }
            }
            catch
            {
                return str;
            }
        }
    }
}
