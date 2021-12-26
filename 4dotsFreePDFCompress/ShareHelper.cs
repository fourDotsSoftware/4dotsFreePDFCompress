using System;
using System.Collections.Generic;
using System.Text;

namespace _4dotsFreePDFCompress
{
    class ShareHelper
    {
        private static string ShareURL
        {
            get
            {
                string url = Module.HelpURL;

                if (!Module.HelpURL.EndsWith("/"))
                {
                    int epos = Module.HelpURL.LastIndexOf("/");
                    url = Module.HelpURL.Substring(0, epos + 1);
                }

                return url;
            }
        }

        private static string ShareText
        {
            get
            {
                string txt = TranslateHelper.Translate("I did find a free application to compress PDF files !").Replace(" ", "%20");

                return txt;
            }
        }
        public static void ShareFacebook()
        {                                
            System.Diagnostics.Process.Start("http://www.facebook.com/sharer.php?u="+ShareURL+"&t="+ShareText);
                                       
        }

        public static void ShareTwitter()
        {            
            System.Diagnostics.Process.Start("http://twitter.com/share?text=" + ShareText + "&url=" + ShareURL);
        }

        public static void ShareGooglePlus()
        {             
            System.Diagnostics.Process.Start("https://plus.google.com/share?url=" + ShareURL);
        }

        public static void ShareLinkedIn()
        {            
            System.Diagnostics.Process.Start("https://www.linkedin.com/shareArticle?mini=true&url="+ShareURL+"&title="+ShareText+"%20!&summary=&source=");
        }
        
        public static void ShareEmail()
        {            
            System.Diagnostics.Process.Start("mailto:?&subject=" + ShareText + "&body=" + ShareText + "%20" + ShareURL);
        }
    }
}
