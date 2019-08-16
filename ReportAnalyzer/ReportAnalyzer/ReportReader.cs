using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ReportAnalyzer
{
    class ReportReader
    {
        Logger logger;
        public ReportReader(Logger logger_imp)
            {
            this.logger = logger_imp;
            }
        
        private XLWorkbook empWb;
        private XLWorkbook trackerWb;
        private IXLWorksheet trackerWs;
        private IXLWorksheet empWs;
       // private List<Tuple<DateTime, string, string, string, double, string>> trackerRecords;
        //private List<Tuple<DateTime, string, string, double, string>> empRecords;
        private List<Tuple<DateTime, string, double, string, string>> empRecords = new List<Tuple<DateTime, string, double, string, string>>();
        private List<Tuple<DateTime, string, double, string, string>> trackerRecords = new List<Tuple<DateTime, string, double, string, string>> ();
        private string[] trackerFiles;
        private string[] empFiles;
        public List<Tuple<DateTime, string, double, string, string>> TrackerRecords { get
            {
                return trackerRecords;
            }
        
        }
        public List<Tuple<DateTime, string, double, string, string>> EmpRecords { get
            {
                return empRecords;
            }

        }
        public void LoadReports(string trackerPath, string empPath)

        {
            MessageBox.Show("Load");
            this.logger.LogOnScreen("LoadReports");
            ListFiles(trackerPath, empPath);
            List<Tuple<DateTime, string, double, string, string>> empRecords = new List<Tuple<DateTime, string, double, string, string>>();
            List<Tuple<DateTime, string, double, string, string>> trackerRecords = new List<Tuple<DateTime, string, double, string, string>>();
            foreach (string trackerReportFile in trackerFiles)
            {
                LoadTrackerExcel(trackerReportFile);
            }
            foreach (string empReportFile in empFiles)
            {
                LoadEmpExcel(empReportFile);
            }

        }

        private void ListFiles(string trackerPath, string empPath)

        {
            
            if (Directory.Exists(trackerPath))
            {
                trackerFiles = Directory.GetFiles(trackerPath, "*.xlsx", SearchOption.TopDirectoryOnly);

            }
            if (Directory.Exists(trackerPath))
            {
                empFiles = Directory.GetFiles(empPath, "*.xlsx", SearchOption.TopDirectoryOnly);

            }

        }


    private void LoadEmpExcel(string path)
        {
            
            using (XLWorkbook empWb = new XLWorkbook(path))
            {
                //empRecords.Clear();
                empWs = empWb.Worksheet(1);
                for (int i = 2; i < empWs.LastRowUsed().RowNumber(); i++)
                //for (int i = 2; i < empWs.RowCount(); i++)
                {
                    if (LoadEmpLine(i, path) != null)
                    {
                        empRecords.Add(LoadEmpLine(i, path));
                    }
                        
                }

            }
        }
        private void LoadTrackerExcel(string path)
        {
            
            using (XLWorkbook trackerWb = new XLWorkbook(path))
            {
                // trackerRecords.Clear();
                trackerWs = trackerWb.Worksheet(1);
                //for (int i = 2; i < trackerWs.RowCount(); i++)
                for (int i = 2; i < trackerWs.LastRowUsed().RowNumber(); i++)

                    {
                    if (LoadTrackerLine(i, path)!=null)
                        {
                        
                        trackerRecords.Add(LoadTrackerLine(i, path));
                    }
                    
                }
            }
        }
        private Tuple<DateTime, string, double, string, string> LoadEmpLine(int rowNumber, string path)
        {
            
            DateTime date;
            string cc;
            string project;
            //string jobType;
            double time;
            string employee;
            try
            {


                date = empWs.Row(rowNumber).Cell(6).GetDateTime();
                cc = empWs.Row(rowNumber).Cell(4).GetString();
                project = empWs.Row(rowNumber).Cell(2).GetString();
                //jobType = empWs.Row(rowNumber).Cell(5).GetString();
                time = empWs.Row(rowNumber).Cell(9).GetDouble() / 60;
                employee = empWs.Row(rowNumber).Cell(3).GetString();
            }
            catch (Exception e)
            {
                logger.LogOnScreen(path + " " + e.Message);
                return null;
            }

            return Tuple.Create(date, cc, time, employee, project);
            
        }

        

        private Tuple<DateTime, string, double, string, string> LoadTrackerLine(int rowNumber, string path)
        {
            DateTime date;
            string cc;
            string project;
            string jobType;
            double time;
            string employee;
            if (!trackerWs.Row(rowNumber).Cell(1).IsEmpty())
            {
                try
                {
                    //date = trackerWs.Row(rowNumber).Cell(1).GetDateTime();
                    date = trackerWs.Row(rowNumber).Cell(1).GetDateTime();
                    cc = trackerWs.Row(rowNumber).Cell(2).GetString().Trim().Replace(" ", "");
                    project = trackerWs.Row(rowNumber).Cell(3).GetString();
                    //jobType = trackerWs.Row(rowNumber).Cell(4).GetString();
                    time = trackerWs.Row(rowNumber).Cell(5).GetDouble();
                    employee = GetEmployeeFromPath(path);
                }
                catch (Exception e)
                {
                    logger.LogOnScreen(path + " " + e.Message);
                    return null;
                }
                return Tuple.Create(date, cc, time, employee, project);
            }
            else
            {
                return null;
            }
                


        }
        private string GetEmployeeFromPath(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            if (filename.ToUpper().Contains("RADEK"))
            {
                return "Radoslaw Domian";
            }
            else if (filename.ToUpper().Contains("SLAWEK"))
            {
                return "Slawomir Jasiecki";
            }
            else if (filename.ToUpper().Contains("PAWEL"))
            {
                return "Pawel Sochal";
            }
            else if (filename.ToUpper().Contains("SZYMON K1"))
            {
                return "Szymon Kaszak";
            }
            else if (filename.ToUpper().Contains("SZYMON K2"))
            {
                return "Szymon Kobylinski";
            }
            else if (filename.ToUpper().Contains("GOSIA"))
            {
                return "Malgorzata Marcysiak";
            }
            else if (filename.ToUpper().Contains("TOMEK"))
            {
                return "Tomasz Tojek";
            }
            else if (filename.ToUpper().Contains("PRZEMEK"))
            {
                return "Przemyslaw Nejman";
            }
            else if (filename.ToUpper().Contains("BLAZEJ"))
            {
                return "Blazej Agacinski";
            }
            else if (filename.ToUpper().Contains("ALICJA"))
            {
                return "Alicja Marglewska";
            }
            else if (filename.ToUpper().Contains("DAWID"))
            {
                return "Dawid Marchlewicz";
            }
            else
            {
                return "Unknown";
            }


        }
    }
}
