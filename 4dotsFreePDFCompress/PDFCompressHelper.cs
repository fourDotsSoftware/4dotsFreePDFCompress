using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;
using iTextSharp.text.pdf.parser;
 
using System.IO;
using System.Collections;
using System.Windows.Forms;

using FreeImageAPI;

/*1
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Security;
*/

namespace _4dotsFreePDFCompress
{
    class PDFCompressHelper
    {
        //PdfEncryptor.Encrypt(reader,myFileStream,PdfWriter.ENCRYPTION_RC4_128,sU 
        //Password,"test",PdfWriter.AllowPrinting|PdfWriter.AllowCopy); 

        public static string Title = "";
        public static string Author = "";
        public static string Subject = "";
        public static string Keywords = "";

        public static DateTime CreationDate = DateTime.Now;
        public static DateTime ModificationDate = DateTime.Now;
        public static string Creator = "";

        public static bool SetDocInfo = false;

        public static bool CANCELLED = false;

        public static string DefaultPassword = "";

        public static string ErrMultiple = "";

        public static long BytesBefore = 0;
        public static long BytesAfter = 0;

        public static string CompressDecompressMultiplePDF(DataTable dt,string OutputDir,bool compress_images,int images_quality,bool overwrite,bool keep_backup)
        {
            string err = "";
            
            CANCELLED = false;
            BytesBefore = 0;
            BytesAfter = 0;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (CANCELLED)
                {
                    //frmMain.Instance.bwCompress.CancelAsync();
                    return err;
                }

                string outfilepath = "";
                string filepath = dt.Rows[k]["fullfilepath"].ToString();
                string password = dt.Rows[k]["userpassword"].ToString();
                string rootfolder = dt.Rows[k]["rootfolder"].ToString();

                if (OutputDir.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);

                    outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_compressed.pdf");
                    /*
                    if (frmMain.Instance.rdCompress.Checked)
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_compressed.pdf");
                    }
                    else if (frmMain.Instance.rdDecompress.Checked)
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_decompressed.pdf");
                    }*/
                }
                else if (OutputDir.StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = OutputDir.Substring(subfolderspos);

                    outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, System.IO.Path.GetFileName(filepath));
                }
                //else if (OutputDir.Trim() == TranslateHelper.Translate("Overwrite PDF Document"))
                else if (overwrite)
                {
                    outfilepath = filepath;
                }
                else
                {
                    if (rootfolder != string.Empty && Properties.Settings.Default.KeepFolderStructure)
                    {
                        string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                        string outdfp = OutputDir + dep;

                        outfilepath = System.IO.Path.Combine(outdfp, System.IO.Path.GetFileName(filepath));

                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outfilepath)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outfilepath));
                        }
                    }
                    else
                    {
                        outfilepath = System.IO.Path.Combine(OutputDir, System.IO.Path.GetFileName(filepath));
                    }                    
                }
                
                try
                {
                    err += CompressDecompressSinglePDF(filepath, outfilepath, password,compress_images,images_quality,overwrite,keep_backup);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }

                frmMain.Instance.bwCompress.ReportProgress(1);
            }

            return err;
        }

        public static string CompressDecompressMultiplePDFCmd(DataTable dt)
        {
            string err = "";
            BytesBefore = 0;
            BytesAfter = 0;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (Module.CmdLogFileWriter != null)
                {
                    Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Compressing PDF file : " + dt.Rows[k]["fullfilepath"].ToString());
                }

                string outfilepath = "";
                string filepath = dt.Rows[k]["fullfilepath"].ToString();
                string password = dt.Rows[k]["userpassword"].ToString();

                if (Module.CmdOutputFolder==string.Empty)                                        
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);

                    if (Module.CmdCompress)
                    {
                        if (Module.CmdOutputFile == string.Empty)
                        {
                            outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_compressed.pdf");
                        }
                        else
                        {
                            outfilepath = System.IO.Path.Combine(dirpath, Module.CmdOutputFile.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(filepath)).Replace("[EXT]", System.IO.Path.GetExtension(filepath)));
                        }
                    }
                    else
                    {
                        if (Module.CmdOutputFile == string.Empty)
                        {
                            outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_decompressed.pdf");
                        }
                        else
                        {
                            outfilepath = System.IO.Path.Combine(dirpath, Module.CmdOutputFile.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(filepath)).Replace("[EXT]", System.IO.Path.GetExtension(filepath)));
                        }
                    }
                }
                
                if (Module.CmdOverwritePDF)
                {
                    outfilepath = filepath;
                }

                if (Module.CmdOutputFolder!=string.Empty)
                {
                    outfilepath = System.IO.Path.Combine(Module.CmdOutputFolder, System.IO.Path.GetFileName(filepath));
                }

                try
                {
                    err += CompressDecompressSinglePDF(filepath, outfilepath, password,Module.CmdCompressImages,Module.CmdImageQuality,Module.CmdOverwritePDF,Module.CmdKeepBackup);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }

            return err;
        }


        public static string CompressDecompressSinglePDF(string InputFile, string OutputFile, string Password,bool CompressImages,int ImageQuality,bool Overwrite,bool KeepBackup)
        {
            string err = "";

            
            

            try
            {
                System.IO.FileInfo fi = new FileInfo(InputFile);

                DateTime dtcreated = fi.CreationTime;

                DateTime dtlastmod = fi.LastWriteTime;

                //                using (FileStream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                PdfReader reader = null;
                string OutputFile2 = "";
                
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(OutputFile)))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(OutputFile));
                    }
                    catch (Exception exd)
                    {
                        err += TranslateHelper.Translate("Error. Could not Create Directory for File") + " : " + InputFile + "\r\n" + exd.Message + "\r\n";
                        return err;
                    }
                }


                try
                {
                    //  reader = new PdfReader(input);

                    while (true)
                    {
                        using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(Password))
                                {
                                    reader = new PdfReader(input, Encoding.Default.GetBytes(Password));
                                    //reader = new PdfReader(input, Encoding.UTF8.GetBytes(Password));

                                }
                                else
                                {
                                    reader = new PdfReader(input);
                                }

                                break;
                            }
                            catch (iTextSharp.text.pdf.BadPasswordException ex)
                            {
                                if (reader != null)
                                {
                                    reader.Close();
                                }

                                if (input != null)
                                {
                                    input.Close();
                                }

                                if (Properties.Settings.Default.DoNotAskForPassword)
                                {
                                    err += TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                                    return err;
                                }

                                //frmMain.Instance.backgroundWorker1.CancelAsync();

                                //while (frmMain.Instance.backgroundWorker1.IsBusy)
                                //{
                                //Application.DoEvents();
                                //}

                                if (string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(DefaultPassword))
                                {
                                    Password = DefaultPassword;
                                }
                                else
                                {
                                    frmProgress.Instance.HideForm();

                                    Module.ShowMessage("Please enter the correct User Password !");

                                    frmPassword f2 = new frmPassword(InputFile);



                                    DialogResult dres = f2.ShowDialog();

                                    frmProgress.Instance.ShowForm();

                                    //frmMain.Instance.backgroundWorker1.RunWorkerAsync();

                                    if (dres == DialogResult.OK)
                                    {
                                        Password = f2.txtPassword.Text;

                                        if (f2.chkPassword.Checked)
                                        {
                                            DefaultPassword = Password;
                                        }

                                    }
                                    else
                                    {
                                        err += TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                                        return err;
                                    }
                                }
                            }
                        }
                    }

                    // do stuff


                    string TmpFile = "";

                    if (Overwrite)
                    {
                        TmpFile = OutputFile;
                        OutputFile = System.IO.Path.GetTempFileName();
                    }

                    //if ((Module.IsCommandLine && Module.CmdCompress) || (!Module.IsCommandLine && frmMain.Instance.rdCompress.Checked))
                    //{                    
                        /*
                        using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(Password))
                                {
                                    reader2 = new PdfReader(input, Encoding.Default.GetBytes(Password));
                                }
                                else
                                {
                                    reader2 = new PdfReader(input);
                                }

                                
                            }
                            catch (Exception exr2)
                            {
                                err += "Error. Could not read PDF File !" + exr2.Message + "\n\n";
                            }
                        }
                        */

                        /*
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (PdfStamper stamper = new PdfStamper(reader2, ms))
                            {
                                stamper.Writer.CompressionLevel = 9;
                                stamper.SetFullCompression();
                                stamper.FormFlattening = true;

                                stamper.Close();
                            }


                            File.WriteAllBytes(OutputFileRedu, ms.ToArray());
                        }

                        reader2.Close();
                        */

                        if (CompressImages)
                        {                            
                            //ReduceResolution2(reader, (long)ImageQuality);

                            ReduceResolution(reader, (long)ImageQuality);
                        }

                        OutputFile2 = OutputFile + ".temp.pdf";

                        if (CANCELLED)
                        {
                            return err;
                        }


                        using (MemoryStream memoryStream = new MemoryStream())
                        {                                                                                   
                            PdfStamper stamper = new PdfStamper(reader, memoryStream,PdfWriter.VERSION_1_5);
                            stamper.Writer.CompressionLevel = 9;
                            
                            stamper.FormFlattening = true;
                            stamper.SetFullCompression();

                            int total = reader.NumberOfPages + 1;
                            for (int i = 1; i < total; i++)
                            {
                                if (CANCELLED)
                                {
                                    stamper.Close();
                                    reader.Close();
                                    return err;
                                }

                                //c
                                Application.DoEvents();

                                reader.SetPageContent(i, reader.GetPageContent(i));
                            }
                            stamper.SetFullCompression();
                            stamper.Close();
                            reader.Close();

                            File.WriteAllBytes(OutputFile2, memoryStream.ToArray());
                        }

                        if (CANCELLED)
                        {
                            return err;
                        }

                        //return err;

                        using (Stream input = new FileStream(OutputFile2, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(Password))
                                {
                                    reader = new PdfReader(input, Encoding.Default.GetBytes(Password));
                                }
                                else
                                {
                                    reader = new PdfReader(input);
                                }                                
                            }
                            catch (Exception exr2)
                            {
                                err += "Error. Could not read PDF File ! "+OutputFile2+" " + exr2.Message + "\n\n";
                            }
                        }

                         //c
                        Application.DoEvents();

                        using (Stream outputPdfStream = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Document document = new Document();
                            PdfSmartCopy copy = new PdfSmartCopy(document, outputPdfStream);
                            copy.CompressionLevel = 9;
                            copy.SetFullCompression();
                            try
                            {
                                reader.RemoveUnusedObjects();
                            }
                            catch { }

                            document.Open();

                            int totalPageCnt = reader.NumberOfPages;

                            for (int t = 1; t <= totalPageCnt; t++)
                            {
                                if (CANCELLED)
                                {
                                    reader.Close();
                                    copy.Close();
                                    document.Close();
                                    return err;
                                }


                                //c
                                Application.DoEvents();

                                copy.AddPage(copy.GetImportedPage(reader, t));
                            }

                            copy.FreeReader(reader);
                            reader.Close();
                            copy.Close();
                            document.Close();

                        }
                    /*
                    }
                    else
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {                                                        
                            PdfStamper stamper = new PdfStamper(reader, memoryStream);
                            Document.Compress = false;

                            int total = reader.NumberOfPages + 1;
                            for (int i = 1; i < total; i++)
                            {
                                reader.SetPageContent(i, reader.GetPageContent(i));
                            }

                            stamper.Close();
                            reader.Close();

                            File.WriteAllBytes(OutputFile, memoryStream.ToArray());
                        }

                        Document.Compress = true;
                    }
                    */
                    /*
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfStamper stamper = new PdfStamper(reader, memoryStream);
                            if (dict.Count > 0)
                            {
                                stamper.MoreInfo = dict;
                            }

                            stamper.Close();
                            reader.Close();

                            File.WriteAllBytes(OutputFile, memoryStream.ToArray());
                        }
                    */


                        if (CANCELLED)
                        {
                            return err;
                        }

                    if (TmpFile != string.Empty)
                    {
                        if (KeepBackup)
                        {
                            string bakfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(TmpFile),
                            System.IO.Path.GetFileNameWithoutExtension(TmpFile) + ".bak.pdf");

                            System.IO.File.Move(TmpFile, bakfilepath);
                        }
                        else
                        {
                            System.IO.File.Delete(TmpFile);
                        }
                        System.IO.File.Move(OutputFile, TmpFile);

                        OutputFile = TmpFile;
                    }

                    try
                    {
                        if (System.IO.File.Exists(InputFile) && System.IO.File.Exists(OutputFile))
                        {
                            FileInfo fibefore = new FileInfo(InputFile);
                            BytesBefore += fibefore.Length;

                            FileInfo fiafter = new FileInfo(OutputFile);
                            BytesAfter += fiafter.Length;
                        }
                    }
                    catch 
                    { }

                    FileInfo fi2 = new FileInfo(OutputFile);

                    if (Properties.Settings.Default.KeepCreationDate)
                    {
                        fi2.CreationTime = dtcreated;
                    }

                    if (Properties.Settings.Default.KeepLastModificatonDate)
                    {
                        fi2.LastWriteTime = dtlastmod;
                    }

                    return err;
                }
                catch (Exception exm)
                {
                    err += TranslateHelper.Translate("An error occured while protecting PDF File") + " : " + InputFile + "\r\n" + exm.Message + "\r\n";
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    if (System.IO.File.Exists(OutputFile2))
                    {
                        try
                        {
                            System.IO.File.Delete(OutputFile2);
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                err += TranslateHelper.Translate("An error occured while compressing PDF File") + " : " + InputFile + "\r\n" + ex.Message + "\r\n";
            }
            
            
            
            return err;
        }

        public static void ReduceResolution(PdfReader reader, long quality)
        {
            int n = reader.XrefSize;
            for (int i = 0; i < n; i++)
            {
                if (CANCELLED)
                {
                    return;
                }

                PdfObject obj = reader.GetPdfObject(i);
                if (obj == null || !obj.IsStream()) { continue; }

                PdfDictionary dict = (PdfDictionary)PdfReader.GetPdfObject(obj);
                PdfName subType = (PdfName)PdfReader.GetPdfObject(
                  dict.Get(PdfName.SUBTYPE)
                );
                if (!PdfName.IMAGE.Equals(subType)) { continue; }

                PRStream stream = (PRStream)obj;
                try
                {
                    PdfImageObject image = new PdfImageObject(stream);
                    PdfName filter = (PdfName)image.Get(PdfName.FILTER);
                    /*
                    if (
                      PdfName.JBIG2DECODE.Equals(filter)
                      || PdfName.JPXDECODE.Equals(filter)
                      || PdfName.CCITTFAXDECODE.Equals(filter)
                      || PdfName.FLATEDECODE.Equals(filter)
                    ) continue;
                    */
                    System.Drawing.Image img = image.GetDrawingImage();
                    if (img == null) continue;

                    var ll = image.GetImageBytesType();
                    int width = img.Width;
                    int height = img.Height;
                    using (System.Drawing.Bitmap dotnetImg =
                       new System.Drawing.Bitmap(img))
                    {
                        // set codec to jpeg type => jpeg index codec is "1"
                        System.Drawing.Imaging.ImageCodecInfo codec =
                        System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                        // set parameters for image quality
                        System.Drawing.Imaging.EncoderParameters eParams =
                         new System.Drawing.Imaging.EncoderParameters(1);
                        eParams.Param[0] =
                         new System.Drawing.Imaging.EncoderParameter(
                           System.Drawing.Imaging.Encoder.Quality, quality
                        );
                        using (MemoryStream msImg = new MemoryStream())
                        {
                            dotnetImg.Save(msImg, codec, eParams);
                            msImg.Position = 0;
                            stream.SetData(msImg.ToArray());
                            stream.SetData(
                             msImg.ToArray(), false, PRStream.BEST_COMPRESSION
                            );
                            stream.Put(PdfName.TYPE, PdfName.XOBJECT);
                            stream.Put(PdfName.SUBTYPE, PdfName.IMAGE);
                            stream.Put(PdfName.FILTER, filter);
                            stream.Put(PdfName.FILTER, PdfName.DCTDECODE);
                            stream.Put(PdfName.WIDTH, new PdfNumber(width));
                            stream.Put(PdfName.HEIGHT, new PdfNumber(height));
                            stream.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(8));
                            stream.Put(PdfName.COLORSPACE, PdfName.DEVICERGB);
                        }
                    }
                }
                catch
                {
                    // throw;
                    // iText[Sharp] can't handle all image types...
                }
                finally
                {
                    // may or may not help      
                    reader.RemoveUnusedObjects();
                }
            }
        }

        public static void ReduceResolution2(PdfReader reader, long quality)
        {
            int n = reader.XrefSize;
            for (int i = 0; i < n; i++)
            {
                if (CANCELLED)
                {
                    return;
                }

                PdfObject obj = reader.GetPdfObject(i);
                if (obj == null || !obj.IsStream()) { continue; }

                PdfDictionary dict = (PdfDictionary)PdfReader.GetPdfObject(obj);
                PdfName subType = (PdfName)PdfReader.GetPdfObject(
                  dict.Get(PdfName.SUBTYPE)
                );
                if (!PdfName.IMAGE.Equals(subType)) { continue; }

                PRStream stream = (PRStream)obj;                

                string imgpath = "";

                try
                {
                    imgpath = "";

                    PdfImageObject image = new PdfImageObject(stream);
                    //3PdfName filter = (PdfName)image.Get(PdfName.FILTER);
                    
                    object filter = (object)image.Get(PdfName.FILTER);                                        

                    System.Drawing.Image img = null;                    

                    try
                    {
                        img = image.GetDrawingImage();

                        if (Properties.Settings.Default.InvertImages)
                        {
                            img = InvertImage(img);
                        }

                    }
                    catch
                    {
                        imgpath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString() + ".bmp");

                        // create a memory stream
                        MemoryStream imageStream = new MemoryStream(image.GetImageAsBytes());
                        // create a FIBITMAP from that stream
                        FIBITMAP dib = FreeImage.LoadFromStream(imageStream);

                        if (dib.IsNull) continue;
                        //turn it into a normal Bitmap 

                        if (Properties.Settings.Default.InvertImages2)
                        {
                            FreeImage.Invert(dib);
                        }

                        System.Drawing.Bitmap bitmap = FreeImage.GetBitmap(dib);
                        bitmap.Save(imgpath);
                        //unload the FIBITMAP 
                        FreeImage.UnloadEx(ref dib);
                        bitmap.Dispose();


                        img = System.Drawing.Image.FromFile(imgpath);

                        /*
                        System.Drawing.Bitmap img2 = new System.Drawing.Bitmap(imgpath);

                        for (int y = 0; (y <= (img2.Height - 1)); y++)
                        {
                            for (int x = 0; (x <= (img2.Width - 1)); x++)
                            {
                                System.Drawing.Color inv = img2.GetPixel(x, y);
                                inv = System.Drawing.Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                                img2.SetPixel(x, y, inv);
                            }
                        }

                        img = (System.Drawing.Image)img2;
                        */
                        //3img = image.GetDrawingImage();
                    }
                    finally
                    {
                        if (imgpath != string.Empty && System.IO.File.Exists(imgpath))
                        {
                            try
                            {
                                System.IO.File.Delete(imgpath);
                            }
                            catch { }
                        }
                    }
                    /*
                    catch
                    {                        
                        sucImg = false;

                        return;

                        try
                        {
                            PdfDictionary pg = reader.GetPageN(i);
                            PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));

                            PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                            if (xobj != null)
                            {
                                foreach (PdfName name in xobj.Keys)
                                {
                                    PdfObject obj2 = xobj.Get(name);
                                    if (obj2.IsIndirect())
                                    {
                                        PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj2);
                                        PdfName type = (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                                        if (PdfName.IMAGE.Equals(type))
                                        {
                                            int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj2).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                            PdfObject pdfObj = reader.GetPdfObject(XrefIndex);

                                            PRStream stream2 = (PRStream)pdfObj;

                                            PdfStream pdfStrem = (PdfStream)pdfObj;
                                            //3byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);

                                            byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)stream2);

                                            if ((bytes != null))
                                            {
                                                using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes))
                                                {
                                                    memStream.Position = 0;
                                                    img = System.Drawing.Image.FromStream(memStream);
                                                    var ll2 = image.GetImageBytesType();
                                                    int width2 = img.Width;
                                                    int height2= img.Height;
                                                    using (System.Drawing.Bitmap dotnetImg =
                                                    new System.Drawing.Bitmap(img))
                                                    {
                                                        // set codec to jpeg type => jpeg index codec is "1"
                                                        System.Drawing.Imaging.ImageCodecInfo codec =
                                                        System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                                                        // set parameters for image quality
                                                        System.Drawing.Imaging.EncoderParameters eParams =
                                                        new System.Drawing.Imaging.EncoderParameters(1);
                                                        eParams.Param[0] =
                                                        new System.Drawing.Imaging.EncoderParameter(
                                                        System.Drawing.Imaging.Encoder.Quality, quality
                                                );
                                                        using (MemoryStream msImg = new MemoryStream())
                                                        {
                                                            dotnetImg.Save(msImg, codec, eParams);
                                                            msImg.Position = 0;

                                                            stream2.Clear();
                                                            //stream.SetData(msImg.ToArray());
                                                            stream2.SetData(
                                             msImg.ToArray(), false, PRStream.BEST_COMPRESSION
                                            );
                                                            stream2.Put(PdfName.TYPE, PdfName.XOBJECT);
                                                            stream2.Put(PdfName.SUBTYPE, PdfName.IMAGE);
                                                            //stream.Put(PdfName.FILTER, (PdfObject)filter);
                                                            stream2.Put(PdfName.FILTER, (PdfObject)filter);
                                                            stream2.Put(PdfName.FILTER, PdfName.DCTDECODE);
                                                            stream2.Put(PdfName.WIDTH, new PdfNumber(width2));
                                                            stream2.Put(PdfName.HEIGHT, new PdfNumber(height2));
                                                            stream2.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(8));
                                                            stream2.Put(PdfName.COLORSPACE, PdfName.DEVICERGB);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }                        
                    }*/
                    /*
                            //System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);
                            // must save the file while stream is open.
                            if (!Directory.Exists(outputPath))
                                Directory.CreateDirectory(outputPath);

                            string path = Path.Combine(outputPath, String.Format(@"{0}.jpg", pageNumber));
                            System.Drawing.Imaging.EncoderParameters parms = new System.Drawing.Imaging.EncoderParameters(1);
                            parms.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
                            System.Drawing.Imaging.ImageCodecInfo jpegEncoder = Utilities.GetImageEncoder("JPEG");
                            img.Save(path, jpegEncoder, parms);
                            break;
                        }
                    }
                    
                    System.Drawing.Image img = image.GetDrawingImage();
                    */                    

                    if (img == null) continue;

                    /*
                    if (
                      PdfName.JBIG2DECODE.Equals(filter)
                      || PdfName.JPXDECODE.Equals(filter)
                      || PdfName.CCITTFAXDECODE.Equals(filter)
                      || PdfName.FLATEDECODE.Equals(filter)
                    )
                    {

                    }                                        
                    */
                    
                    var ll = image.GetImageBytesType();
                    int width = img.Width;
                    int height = img.Height;                    

                    using (System.Drawing.Bitmap dotnetImg =
                       new System.Drawing.Bitmap(img))
                    {
                                                
                        // set codec to jpeg type => jpeg index codec is "1"
                        System.Drawing.Imaging.ImageCodecInfo codec =
                        System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                        // set parameters for image quality
                        System.Drawing.Imaging.EncoderParameters eParams =
                         new System.Drawing.Imaging.EncoderParameters(1);
                        eParams.Param[0] =
                         new System.Drawing.Imaging.EncoderParameter(
                           System.Drawing.Imaging.Encoder.Quality, quality
                        );

                        using (MemoryStream msImg = new MemoryStream())
                        {
                            dotnetImg.Save(msImg, codec, eParams);
                            msImg.Position = 0;

                            if (Properties.Settings.Default.Grayscale)
                            {
                                System.Drawing.Bitmap img2 = new System.Drawing.Bitmap(img.Width,img.Height,System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);

                                img2 = ColorSpace.Grayscale((System.Drawing.Bitmap)img);

                                using (MemoryStream msImg2 = new MemoryStream())
                                {
                                    img2.Save(msImg2, codec, eParams);//, System.Drawing.Imaging.ImageFormat.Tiff);
                                    msImg2.Position = 0;

                                    stream.Clear();
                                    //stream.SetData(msImg.ToArray());
                                    stream.SetData(
                                     msImg2.ToArray(), false, PRStream.BEST_COMPRESSION
                                    );
                                    stream.Put(PdfName.TYPE, PdfName.XOBJECT);
                                    stream.Put(PdfName.SUBTYPE, PdfName.IMAGE);
                                    //stream.Put(PdfName.FILTER, (PdfObject)filter);
                                    stream.Put(PdfName.FILTER, (PdfObject)filter);
                                    stream.Put(PdfName.FILTER, PdfName.DCTDECODE);
                                    stream.Put(PdfName.WIDTH, new PdfNumber(width));
                                    stream.Put(PdfName.HEIGHT, new PdfNumber(height));
                                    stream.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(8));
                                    stream.Put(PdfName.COLORSPACE, PdfName.DEVICERGB);
                                }
                            }
                            else if (Properties.Settings.Default.BlackAndWhite)
                            {
                                /*
                                System.Drawing.Bitmap img3 = new System.Drawing.Bitmap(img);

                                System.Drawing.Bitmap img2=new System.Drawing.Bitmap(img.Width,img.Height,System.Drawing.Imaging.PixelFormat.Format1bppIndexed);

                                using (System.Drawing.Graphics g2=System.Drawing.Graphics.FromImage(img2))
                                {
                                    g2.DrawImage(img,0,0);
                                }                                                                                                                                                               
                                */

                                System.Drawing.Bitmap img3 = new System.Drawing.Bitmap(msImg);

                                System.Drawing.Bitmap img2 = ColorSpace.GetBlackAndWhiteImage(img3);

                                using (MemoryStream msImg2 = new MemoryStream())
                                {
                                    //3img2.Save(msImg2, codec, eParams);//, System.Drawing.Imaging.ImageFormat.
                                    //img2.Save(msImg2, System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[3], null);

                                    img2.Save(msImg2, System.Drawing.Imaging.ImageFormat.Png);

                                    //img2.Save(@"c:\1\testpdf.png", System.Drawing.Imaging.ImageFormat.Png);

                                    msImg2.Position = 0;                                                                        
                                    
                                    stream.Clear();
                                    stream.SetData(msImg2.ToArray());
                                    stream.Put(PdfName.TYPE, PdfName.XOBJECT);
                                    stream.Put(PdfName.SUBTYPE, PdfName.IMAGE);
                                    stream.Put(PdfName.FILTER, PdfName.FLATEDECODE);
                                    stream.Put(PdfName.COLORSPACE, PdfName.DEVICEGRAY);

                                    stream.Put(PdfName.WIDTH, new PdfNumber(width));
                                    stream.Put(PdfName.HEIGHT, new PdfNumber(height));                                    
                                    stream.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(System.Drawing.Image.GetPixelFormatSize(img2.PixelFormat)));

                                    /*

                                    Image pdfimg = Image.GetInstance(msImg2.ToArray());

                                    PdfImage imagebw = new PdfImage(pdfimg, "", null);

                                    using (MemoryStream msImg3 = new MemoryStream())
                                    {
                                        /*
                                        byte[] pb = imagebw.GetBytes();

                                        for (int m = 0; m < pb.Length; m++)
                                        {
                                            msImg3.WriteByte(pb[m]);
                                        }

                                        msImg3.Position = 0;

                                        stream.SetData(msImg3.ToArray());
                                        */
                                    /*
                                    stream.SetData(imagebw.GetBytes());

                                    stream.Put(PdfName.TYPE, PdfName.XOBJECT);
                                    stream.Put(PdfName.SUBTYPE, PdfName.IMAGE);
                                    stream.Put(PdfName.FILTER, PdfName.FLATEDECODE);
                                    stream.Put(PdfName.COLORSPACE, PdfName.DEVICEGRAY);

                                    stream.Put(PdfName.WIDTH, new PdfNumber(width));                                        
                                    stream.Put(PdfName.HEIGHT, new PdfNumber(height));                                                                                                                                                               

                                    foreach (iTextSharp.text.pdf.PdfName entry in imagebw.Keys)
                                    {
                                        stream.Put(entry, imagebw.Get(entry));
                                    }
                                    */
                                        /*
                                    stream.SetData(
                                     msImg2.ToArray(), false, PRStream.BEST_COMPRESSION                                     
                                    );

                                    
                                    
                                                                        
                                   /*
                                    stream.Put(PdfName.TYPE, PdfName.XOBJECT);
                                    stream.Put(PdfName.SUBTYPE, PdfName.IMAGE);
                                    //stream.Put(PdfName.FILTER, (PdfObject)filter);
                                    stream.Put(PdfName.FILTER, (PdfObject)filter);
                                    stream.Put(PdfName.FILTER, PdfName.DCTDECODE);
                                    stream.Put(PdfName.WIDTH, new PdfNumber(width));
                                    stream.Put(PdfName.HEIGHT, new PdfNumber(height));
                                    //3stream.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(8));

                                    stream.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(System.Drawing.Image.GetPixelFormatSize(img2.PixelFormat)));
                                    stream.Put(PdfName.COLORSPACE, PdfName.DEVICERGB);
                                        */
                                    //}
                                }
                            }
                            else
                            {
                                stream.Clear();
                                //stream.SetData(msImg.ToArray());
                                stream.SetData(
                                 msImg.ToArray(), true, PRStream.BEST_COMPRESSION
                                );
                                stream.Put(PdfName.TYPE, PdfName.XOBJECT);
                                stream.Put(PdfName.SUBTYPE, PdfName.IMAGE);
                                //stream.Put(PdfName.FILTER, (PdfObject)filter);
                                stream.Put(PdfName.FILTER, (PdfObject)filter);
                                stream.Put(PdfName.FILTER, PdfName.DCTDECODE);
                                stream.Put(PdfName.WIDTH, new PdfNumber(width));
                                stream.Put(PdfName.HEIGHT, new PdfNumber(height));
                                stream.Put(PdfName.BITSPERCOMPONENT, new PdfNumber(8));
                                stream.Put(PdfName.COLORSPACE, PdfName.DEVICERGB);
                            }
                        }
                    }
                }
                catch
                {
                    // throw;
                    // iText[Sharp] can't handle all image types...
                }
                finally
                {
                    // may or may not help      
                    reader.RemoveUnusedObjects();
                }
            }
        }

        private static System.Drawing.Image InvertImage(System.Drawing.Image img)
        {            
            System.Drawing.Bitmap pic = new System.Drawing.Bitmap(img);

            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    System.Drawing.Color inv = pic.GetPixel(x, y);
                    inv = System.Drawing.Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }

            return (System.Drawing.Image)pic;
        }
        public byte[] CompressPdf(byte[] src)
        {
            PdfReader reader = new PdfReader(src);
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfStamper stamper =
                    new PdfStamper(reader, ms, PdfWriter.VERSION_1_5))
                {
                    stamper.Writer.CompressionLevel = 9;
                    int total = reader.NumberOfPages + 1;
                    for (int i = 1; i < total; i++)
                    {
                        reader.SetPageContent(i, reader.GetPageContent(i));
                    }
                    stamper.SetFullCompression();
                }
                return ms.ToArray();
            }
        }
        // ---------------------------------------------------------------------------
        /**
         * Manipulates a PDF file src with the file dest as result
         * @param src the original PDF
         */
        public byte[] DecompressPdf(byte[] src)
        {
            PdfReader reader = new PdfReader(src);
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfStamper stamper = new PdfStamper(reader, ms))
                {
                    Document.Compress = false;
                    int total = reader.NumberOfPages + 1;
                    for (int i = 1; i < total; i++)
                    {
                        reader.SetPageContent(i, reader.GetPageContent(i));
                    }
                }
                Document.Compress = true;
                return ms.ToArray();
            }
        }
    }

    
}

