using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Excel;
using System.Data;

namespace _4dotsFreePDFCompress
{
    class ExcelImporter
    {
        public void ImportListExcel(string filepath)
        {
            using (FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = null;

                string curdir = Environment.CurrentDirectory;

                try
                {
                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(filepath);

                    if (filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlt"))
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (filepath.ToLower().EndsWith(".xlsx"))
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    //excelReader.IsFirstRowAsColumnNames = chkHasHeaders.Checked;

                    DataSet result = excelReader.AsDataSet(false);

                    if (result.Tables.Count > 0)
                    {
                        for (int m = 0; m < result.Tables.Count; m++)
                        {
                            for (int k = 0; k < result.Tables[m].Rows.Count; k++)
                            {
                                if (result.Tables[m].Columns.Count > 0)
                                {                                    
                                    try
                                    {
                                        string file = result.Tables[m].Rows[k][0].ToString();

                                        file = GetPart(file);

                                        file = Path.GetFullPath(file);                                        

                                        frmMain.Instance.AddFile(file);
                                    }
                                    catch (Exception exk)
                                    {
                                        Module.ShowError(exk);
                                    }

                                    finally
                                    {                                        
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Environment.CurrentDirectory = curdir;

                    if (excelReader != null)
                    {
                        excelReader.Close();
                        excelReader.Dispose();
                    }
                }
            }
        }

        private static string GetPart(string part)
        {
            if (part.StartsWith("\""))
            {
                int epos = part.IndexOf("\"", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }
            else if (part.StartsWith("'"))
            {
                int epos = part.IndexOf("'", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }

            return part;
        }
    }
}
