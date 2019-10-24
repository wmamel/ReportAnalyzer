using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Data;

namespace ReportAnalyzer
{
    class Writer
    {
        Logger logger;
        private string path;
        private string filename;

        

        public Writer(Logger logger_imp)
        {
            this.logger = logger_imp;

        }
        /// <summary>
        /// Sets path to folder in which excel reports will be stored
        /// </summary>
        /// <param name="path"></param>
        public void SetPath(string pathToFolder)
        {
            if(pathToFolder.Substring(pathToFolder.Length-1) != "\\")
                {
                pathToFolder = pathToFolder + "\\";
            }
            path = pathToFolder;
        }
        /// <summary>
        /// Set the filename of excel report
        /// </summary>
        /// <param name="excelFilename"></param>
        public void SetFilename(string excelFilename)
        {
            filename = excelFilename.Replace("/", "_");
            logger.LogOnScreen(filename+"\n");
        }
        public void SaveToFile(DataSet data)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                for (int i = 0; i < data.Tables.Count; i++)
                {

                    wb.Worksheets.Add(data.Tables[i], data.Tables[i].TableName);
                   
                }

                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                wb.SaveAs(path+filename+".xlsx");
                logger.LogOnScreen(path + filename + ".xlsx\n");

            }
        }

    }
}
