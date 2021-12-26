using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    class DownloadSuggestionsHelper
    {
        private ToolStripMenuItem tsiDownloadRoot = null;
        private List<string> Category = new List<string>();
        private List<string> App = new List<string>();
        private List<string> Url = new List<string>();
        
        public void SetupDownloadMenuItems(ToolStripMenuItem tsiDownload)
        {
            tsiDownloadRoot = tsiDownload;

            Category.Add(TranslateHelper.Translate("Audio Applications"));
            Category.Add(TranslateHelper.Translate("Video Applications"));
            Category.Add(TranslateHelper.Translate("Office Applications"));
            Category.Add(TranslateHelper.Translate("PDF Applications"));
            Category.Add(TranslateHelper.Translate("File Management Applications"));
            Category.Add(TranslateHelper.Translate("System Utilities"));
            Category.Add(TranslateHelper.Translate("Password Recovery"));
            Category.Add(TranslateHelper.Translate("Webdesign Applications"));
            Category.Add(TranslateHelper.Translate("Graphics Applications"));            
            Category.Add(TranslateHelper.Translate("Desktop Applications"));
            Category.Add(TranslateHelper.Translate("Other Applications"));


            Url.Add("http://www.4dots-software.com/d/AudioConverter4dots/");

            Url.Add("http://www.4dots-software.com/d/SimpleMP3CutterJoinerEditor/");

            Url.Add("http://www.4dots-software.com/d/FreeFLACToMP3Converter4dots/");

            Url.Add("http://www.4dots-software.com/d/FreeVideoToMP3/");

            Url.Add("http://www.4dots-software.com/d/FreeConvertFLACToMP3/");

            Url.Add("http://www.4dots-software.com/d/FreeConvertMP3ToWAV/");

            Url.Add("http://www.4dots-software.com/d/FreeConvertM4AToMP3/");

            Url.Add("http://www.4dots-software.com/d/FreeConvertWAVToMP3/");

            Url.Add("http://www.4dots-software.com/d/FreeConvertWMAToMP3/");

            Url.Add("http://www.4dots-software.com/d/FreeAPEToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeWavPackToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeMusepackToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeOGGToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeConvertMP4ToMP3/");

            Url.Add("http://www.4dots-software.com/d/FreeAVIToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeFLVToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeWMVToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeSWFToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeMKVToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeMPEGToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeMOVToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/FreeVOBToMP3Converter/");

            Url.Add("http://www.4dots-software.com/d/Free3GPToMP3Converter/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/FreeVideoCutterExpert/");

            Url.Add("http://www.4dots-software.com/d/VideoConverterExpert/");

            Url.Add("http://www.4dots-software.com/d/VideoJoinerExpert/");

            Url.Add("http://www.4dots-software.com/d/SimpleVideoCompressor/");

            Url.Add("http://www.4dots-software.com/d/SimpleVideoSplitter/");

            Url.Add("http://www.4dots-software.com/d/VideoRotatorAndFlipper/");            

            Url.Add("http://www.4dots-software.com/d/VideoWatermarkRemover/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/ConvertPowerpointToVideo/");

            Url.Add("http://www.4dots-software.com/d/ConvertWordToVideo/");

            Url.Add("http://www.4dots-software.com/d/BatchDocumentImageReplacer/");

            Url.Add("http://www.4dots-software.com/d/BatchOfficeImageExtractor/");

            Url.Add("http://www.4dots-software.com/d/OfficeToImagesConverter/");

            Url.Add("http://www.4dots-software.com/d/WordToImagesConverter/");

            Url.Add("http://www.4dots-software.com/d/PowerpointToImagesConverter/");

            Url.Add("http://www.4dots-software.com/d/ExcelToImagesConverter/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/FreePDFPasswordRemover/");

            Url.Add("http://www.4dots-software.com/d/4dotsFreePDFCompress/");

            Url.Add("http://www.4dots-software.com/d/PDFToJPGExpert/");

            Url.Add("http://www.4dots-software.com/d/FreePDFSplitterMerger/");

            Url.Add("http://www.4dots-software.com/d/FreePDFImageExtractor/");

            Url.Add("http://www.4dots-software.com/d/FreePDFMetadataEditor/");

            Url.Add("http://www.4dots-software.com/d/PDFEncrypter/");

            Url.Add("http://www.4dots-software.com/d/FreePDFToTextConverter/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/FreeFileUnlocker/");

            Url.Add("http://www.4dots-software.com/d/MultipleSearchReplace/");

            Url.Add("http://www.4dots-software.com/d/EmptyFolderCleaner/");

            Url.Add("http://www.4dots-software.com/d/QuickFileLocker/");

            Url.Add("http://www.4dots-software.com/d/SplitByte/");

            Url.Add("http://www.4dots-software.com/d/MD5HashCheck/");

            Url.Add("http://www.4dots-software.com/d/CopyPathToClipboard/");

            Url.Add("http://www.4dots-software.com/d/CopyTextContents/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/Simple Disable Key/");

            Url.Add("http://www.4dots-software.com/d/KeyRemapper/");

            Url.Add("http://www.4dots-software.com/d/OpenCommandPromptHere/");
            
            Url.Add("http://www.4dots-software.com/d/RunWithParameters/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/RARPasswordCrackerExpert/");

            Url.Add("http://www.4dots-software.com/d/ZIPPasswordCrackerExpert/");

            Url.Add("http://www.4dots-software.com/d/PDFPasswordCrackerExpert/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/BatchHTMLValidator/");

            Url.Add("http://www.4dots-software.com/d/FreeImagemapper/");

            Url.Add("http://www.4dots-software.com/d/CSSSpritesGenerator/");

            Url.Add("http://www.4dots-software.com/d/FreeWebeditor/");

            Url.Add("http://www.4dots-software.com/d/FreeSitemapCreator/");            

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/PictureSlideshowMaker/");

            Url.Add("http://www.4dots-software.com/d/PhotoSideBySide/");

            Url.Add("http://www.4dots-software.com/d/ImgTransformer/");

            Url.Add("http://www.4dots-software.com/d/FreeColorwheel/");

            Url.Add("-");

            Url.Add("http://www.4dots-software.com/d/PrivacyHide/");

            Url.Add("http://www.4dots-software.com/d/MinimizeToTrayTool/");

            Url.Add("-");            

            Url.Add("http://www.4dots-software.com/d/FreeDocusTree/");


            App.Add("Audio Converter 4dots");

            App.Add("Simple MP3 Cutter Joiner Editor");

            App.Add("MP3 Joiner Expert");

            App.Add("Free Video To MP3");

            App.Add("Convert FLAC To MP3");

            App.Add("Convert MP3 To WAV");

            App.Add("Convert M4A To MP3");

            App.Add("Convert WAV To MP3");

            App.Add("Convert WMA To MP3");

            App.Add("APE To MP3 Converter");

            App.Add("WavPack To MP3 Converter");

            App.Add("Musepack To MP3 Converter");

            App.Add("OGG To MP3 Converter");

            App.Add("Convert MP4 To MP3");

            App.Add("AVI To MP3 Converter");

            App.Add("FLV To MP3 Converter");

            App.Add("WMV To MP3 Converter");

            App.Add("SWF To MP3 Converter");

            App.Add("MKV To MP3 Converter");

            App.Add("MPEG To MP3 Converter");

            App.Add("MOV To MP3 Converter");

            App.Add("VOB To MP3 Converter");

            App.Add("3GP To MP3 Converter");

            App.Add("-");

            App.Add("Free Video Cutter Expert");

            App.Add("Video Converter Expert");

            App.Add("Video Joiner Expert");

            App.Add("Simple Video Compressor");

            App.Add("Simple Video Splitter");

            App.Add("Video Rotator And Flipper");

            App.Add("Video Watermark Remover");

            App.Add("-");

            App.Add("Convert Powerpoint to Video");

            App.Add("Convert Word to Video");

            App.Add("Batch Document Image Replacer");

            App.Add("Batch Office Image Extractor");

            App.Add("Office To Images Converter 4dots");

            App.Add("Word To Images Converter 4dots");

            App.Add("Powerpoint To Images Converter 4dots");

            App.Add("Excel To Images Converter 4dots");

            App.Add("-");

            App.Add("Free PDF Password Remover");

            App.Add("4dots Free PDF Compress");

            App.Add("PDF To JPG Expert");

            App.Add("Free PDF Splitter Merger");

            App.Add("Free PDF Image Extractor");

            App.Add("Free PDF Metadata Editor");

            App.Add("Free PDF Protector 4dots");

            App.Add("Free PDF To Text Converter");

            App.Add("-");

            App.Add("Free File Unlocker");

            App.Add("Multiple Search Replace");

            App.Add("Empty Folder Cleaner");

            App.Add("Quick File Locker");

            App.Add("SplitByte");

            App.Add("MD5 Hash Check");

            App.Add("Copy Path To Clipboard");

            App.Add("Copy Text Contents");

            App.Add("-");

            App.Add("Simple Disable Key");

            App.Add("Key Remapper");

            App.Add("Open Command Prompt Here");            

            App.Add("Run With Parameters");

            App.Add("-");

            App.Add("RAR Password Cracker Expert");

            App.Add("ZIP Password Cracker Expert");

            App.Add("PDF Password Cracker Expert");

            App.Add("-");

            App.Add("Batch HTML Validator");

            App.Add("Free Imagemapper");

            App.Add("CSS Sprites Generator");

            App.Add("Free Webeditor");

            App.Add("Free Sitemap Creator");            

            App.Add("-");

            App.Add("Picture Slideshow Maker 4dots");

            App.Add("Photo Side By Side");

            App.Add("ImgTransformer");

            App.Add("Free Colorwheel");

            App.Add("-");

            App.Add("Privacy Hide");

            App.Add("Minimize To Tray Tool");

            App.Add("-");            

            App.Add("Free DocusTree");

            int lastapp = 0;

            for (int m = 0; m < Category.Count; m++)
            {
                ToolStripMenuItem tsic;
                tsic = new ToolStripMenuItem(Category[m]);

                tsiDownload.DropDownItems.Add(tsic);

                for (int k = lastapp; k < App.Count; k++)
                {
                    if (App[k] != "-")
                    {
                        ToolStripMenuItem tsi;
                        tsi = new ToolStripMenuItem(App[k]);
                        tsic.DropDownItems.Add(tsi);
                        tsi.Tag = Url[lastapp];
                        tsi.Click += tsi_Click;

                        lastapp++;
                    }
                    else
                    {
                        lastapp++;
                        break;
                    }                   
                }
            }
        }

        void tsi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi=(ToolStripMenuItem)sender;

            Process.Start(tsi.Tag.ToString());            
        }
    }
}
