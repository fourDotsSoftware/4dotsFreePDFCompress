using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace _4dotsFreePDFCompress
{
    class PasswordHelper
    {
        
        public static string RemovePasswords(DataTable dt)
        {
            string err = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                string errpdf = RemovePDFPassword(dt.Rows[k]["fullfilepath"].ToString(),dt.Rows[k]["password"].ToString());

                if (errpdf != String.Empty)
                {
                    err += errpdf + "\r\n";
                }
            }

            return err;
        }

        public static string RemovePDFPassword(string filepath,string userpassword)
        {
            try
            {
                //string outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath), System.IO.Path.GetFileNameWithoutExtension(filepath) + "_unprotected.pdf");

                string outfilepath="";

                if (frmMain.Instance.rdDocumentsFolder.Checked)
                {
                    outfilepath = Module.UserDocumentsFolder + "\\" + System.IO.Path.GetFileName(filepath);
                }
                else
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);
                    outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_unprotected.pdf");
                }

                return RemoveRestrictions(filepath, outfilepath, userpassword);
                //return SetRestrictions(filepath, outfilepath, "test", "secret");

            }
            catch (Exception ex)
            {
                return TranslateHelper.Translate("Error could not Remove Passwords from File") + " : " + filepath + " - " + TranslateHelper.Translate("Error") + " : " + ex.Message;
            }

            return String.Empty;
        }

        public static string RemoveRestrictions(string InputFile, string OutputFile, string Password)
        {
            Stream input = null;
            PdfReader reader = null;
            PdfReader rdmsg=null;
            PdfReader reader_out=null;

            string tmpfile = System.IO.Path.GetTempFileName();

            try
            {
                try
                {
                    //using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    //{


                    while (true)
                    {
                        input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read);

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

                            frmMain.Instance.backgroundWorker1.CancelAsync();

                            while (frmMain.Instance.backgroundWorker1.IsBusy)
                            {
                                Application.DoEvents();
                            }

                            Module.ShowMessage("Please enter the correct User Password !");

                            frmPassword f2 = new frmPassword();

                            DialogResult dres = f2.ShowDialog();

                            frmMain.Instance.backgroundWorker1.RunWorkerAsync();

                            if (dres == DialogResult.OK)
                            {
                                Password = f2.txtPassword.Text;

                            }
                            else
                            {
                                return TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                            }
                        }
                    }
                }
                finally
                {

                }





                using (MemoryStream msmsg = new MemoryStream())
                {
                    Document docmsg = new Document(PageSize.A4);
                    using (PdfWriter writer = PdfWriter.GetInstance(docmsg, msmsg))
                    {
                        writer.CloseStream = false;
                        docmsg.Open();
                        docmsg.NewPage();
                        Font arial = FontFactory.GetFont("Courier", 16, iTextSharp.text.BaseColor.BLACK);
                        docmsg.Add(new Paragraph());
                        Paragraph p1 = new Paragraph("PDF PASSWORD REMOVED WITH 4DOTS SOFTWARE PDF PASSWORD REMOVER", arial);
                        docmsg.Add(p1);
                        docmsg.Add(new Paragraph(" "));
                        docmsg.Add(new Paragraph("GET A FREE TRIAL COPY AT www.pdfdocmerge.com", arial));
                        //docmsg.Add(new Paragraph(" "));
                        //docmsg.Add(new Paragraph("4dots Software - www.4dots-software.com", arial));
                        docmsg.Close();
                        writer.Close();

                        msmsg.Seek(0, SeekOrigin.Begin);
                        rdmsg = new PdfReader(msmsg);





                        //   reader.RemoveUsageRights();

                        /*
                        PdfEncryptor.Encrypt(reader, output, false, null, null, PdfWriter.ALLOW_ASSEMBLY | PdfWriter.ALLOW_COPY
                  | PdfWriter.ALLOW_DEGRADED_PRINTING | PdfWriter.ALLOW_FILL_IN
                  | PdfWriter.ALLOW_MODIFY_ANNOTATIONS | PdfWriter.ALLOW_MODIFY_CONTENTS
                  | PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_SCREENREADERS);
                        */

                        Document document = new Document();
                        using (FileStream fs = new FileStream(tmpfile, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (PdfCopy copy = new PdfCopy(document, fs))
                                {
                                    document.Open();


                                    Random rnd = new Random();

                                    for (int i = 1; i <= reader.NumberOfPages; i++)
                                    {
                                        PdfImportedPage importedPage = copy.GetImportedPage(reader, i);
                                        copy.AddPage(importedPage);                                                                                

                                        if (frmAbout.LDT == String.Empty)
                                        {
                                            if (rnd.Next(0, 5) == 4)
                                            {
                                                copy.AddPage(copy.GetImportedPage(rdmsg, 1));
                                            }
                                        }
                                    }

                                    copy.Outlines = SimpleBookmark.GetBookmark(reader);



                                    //FileStream fs = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None);

                                    /*                    
                                    fs.Flush();

                                   PdfCopyFields copyf=new PdfCopyFields(fs);
                                    copyf.AddDocument(
                                

                                    copy.Info=reader.Info;
                                   */
                                    /*
                                    PdfCopyFields copyfi=new PdfCopyFields(reader);
                    
                                    IEnumerator<KeyValuePair<string, AcroFields.Item>> en =    
                                    reader.AcroForm.Fields.GetEnumerator();

                                    while (en.MoveNext())
                                    {
                                    String fieldName = en.Current.Key;
                                    AcroFields.Item field = en.Current.Value;
                                    for (int k = 0; k < field.Size; ++k)
                                    {
                                        //PdfDictionary pdct = field.GetMerged(k);
                                        cen.Current.Key,
                        
                                    }
                                    foreach (DictionaryEntry d in reader.Info.Keys)
                                    {
                    
                                    }
                   
                                    foreach (string dkey in reader.Info.Keys)  
                                    {
                                        copy.Info.Put(new PdfName(dkey), (PdfObject)reader.Info.Values[dkey]);
                                    }


                                    //foreach (KeyValuePair<PdfName, PdfObject> d in reader.AcroForm.Fields)                    
                                    foreach (DictionaryEntry d in reader.AcroForm.Fields)
                                    {
                                        copy.AcroForm.Put((PdfName)d.Key, (PdfObject)d.Value);
                                    }
                                */


                                    writer.Close();
                                    document.Close();



                                    reader_out = new PdfReader(tmpfile);

                                    using (PdfStamper pdfstamper = new PdfStamper(reader_out, new FileStream(OutputFile, FileMode.Create)))
                                    {
                                        pdfstamper.MoreInfo = reader.Info;

                                        //System.Collections.Hashtable info = (System.Collections.Hashtable)reader.Info;
                                        //info.put("Subject", "Hello World");


                                        reader_out.Close();
                                        pdfstamper.Close();
                                        reader.Close();

                                        if (input != null)
                                        {
                                            try
                                            {
                                                input.Close();
                                            }
                                            catch { }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                /*
                        PdfEncryptor.Encrypt(reader, output,true, Password, null, PdfWriter.AllowAssembly | PdfWriter.AllowCopy
                  | PdfWriter.AllowDegradedPrinting | PdfWriter.AllowFillIn
                  | PdfWriter.AllowModifyAnnotations | PdfWriter.AllowModifyContents
                  | PdfWriter.AllowPrinting | PdfWriter.AllowScreenReaders);
                        */

                /*
                PdfEncryptor.Encrypt(reader, output, false, null, null, PdfWriter.ALLOW_ASSEMBLY  | PdfWriter.ALLOW_COPY 
          | PdfWriter.ALLOW_DEGRADED_PRINTING  | PdfWriter.ALLOW_FILL_IN 
          | PdfWriter.ALLOW_MODIFY_ANNOTATIONS  | PdfWriter.ALLOW_MODIFY_CONTENTS 
          | PdfWriter.ALLOW_PRINTING | PdfWriter.ALLOW_SCREENREADERS);
                */
                //}

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (reader_out != null)
                {
                    reader_out.Close();
                }

                if (rdmsg != null)
                {
                    rdmsg.Close();
                }

                if (System.IO.File.Exists(tmpfile))
                {
                    System.IO.File.Delete(tmpfile);
                }
            }

            return String.Empty;
        }

        public static string SetRestrictions(string InputFile, string OutputFile, string UserPassword,string OwnerPassword)
        {            
            using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true,UserPassword,OwnerPassword ,PdfWriter.ALLOW_SCREENREADERS);
                }
            }

            return String.Empty;
        }


    }
}
