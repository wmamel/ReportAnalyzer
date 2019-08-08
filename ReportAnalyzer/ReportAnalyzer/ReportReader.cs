using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReportAnalyzer
{
    class ReportReader
    {
        private XLWorkbook empWb;
        private XLWorkbook trackerWb;
        private IXLWorksheet trackerWs;
        private IXLWorksheet empWs;
        private List<Tuple<DateTime, string, string, string, double, string>> trackerRecords;
        private List<Tuple<DateTime, string, string, string, double>> empRecords;

        private void LoadEmpExcel(string path)
        {
            using (XLWorkbook empWb = new XLWorkbook(path))
            {
                empRecords.Clear();
                empWs = empWb.Worksheet(1);
                for (int i = 2; i < trackerWs.RowCount(); i++)
                {
                    trackerRecords.Add(LoadEmpLine(i));
                }

            }
        }
        private void LoadTrackerExcel(string path)
        {
            using (XLWorkbook trackerWb = new XLWorkbook(path))
            {
                trackerRecords.Clear();
                trackerWs = trackerWb.Worksheet(1);
                for (int i = 2; i < trackerWs.RowCount(); i++)
                {
                    trackerRecords.Add(LoadTrackerLine(i, GetEmployeeFromPath(path)));
                }
            }
        }
        private Tuple<DateTime, string, string, double, string> LoadEmpLine(int rowNumber)
        {

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

        private Tuple<DateTime, string, string,string,double, string> LoadTrackerLine(int rowNumber, string employee)
            {
            DateTime date;
            string cc;
            string project;
            string jobType;
            double time;
            date = trackerWs.Row(rowNumber).Cell(1).GetDateTime();
            cc= trackerWs.Row(rowNumber).Cell(2).GetString();
            project = trackerWs.Row(rowNumber).Cell(2).GetString();
            jobType = trackerWs.Row(rowNumber).Cell(2).GetString();
            time = trackerWs.Row(rowNumber).Cell(2).GetDouble();
            return Tuple.Create(date, cc, project, jobType, time, employee);

        }
    }
}
