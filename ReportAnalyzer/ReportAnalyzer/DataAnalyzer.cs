using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAnalyzer
{
    class DataAnalyzer
    {
        Logger logger;
        private HashSet<string> setOfNames = new HashSet<string>();
        private HashSet<string> setOfDates = new HashSet<string>();
        private HashSet<string> setOfCC = new  HashSet<string>();

        private List<Tuple<DateTime, string, double, string, string>> empList = new List<Tuple<DateTime, string, double, string, string>>();
        private List<Tuple<DateTime, string, double, string, string>> trackerList = new List<Tuple<DateTime, string, double, string, string>>();

        public DataAnalyzer(List<Tuple<DateTime, string, double, string, string>> empRecords, List<Tuple<DateTime, string, double, string, string>> trackerRecords, Logger logger_imp)
        {
            this.empList = empRecords;
            this.trackerList = trackerRecords;
            this.logger = logger_imp;
            CreateDataSets();
        }
        HashSet<string> myHashSet = new HashSet<string>();

        private void CreateDataSets()
        {
            foreach (Tuple<DateTime, string, double, string, string> empLine in empList)
            {
                setOfDates.Add(empLine.Item1.ToShortDateString());
                setOfNames.Add(empLine.Item4);
                setOfCC.Add(empLine.Item2.Trim());
            }
            foreach (Tuple<DateTime, string, double, string, string> trackerLine in trackerList)
            {
                setOfDates.Add(trackerLine.Item1.ToShortDateString());
                setOfNames.Add(trackerLine.Item4);
                setOfCC.Add(trackerLine.Item2.Trim());

            }

        }

        public void temp_list_data()
        {
            CreateDataSets();
            foreach (string a in setOfNames)
            {
                logger.LogOnScreen(a+"\n");

            }
            foreach (string b in setOfDates)
            {
                logger.LogOnScreen(b + "\n");

            }

        }
        public List<Tuple<string, string, double, string>> GetSummarizedTimes(List<Tuple<DateTime, string, double, string, string>> recordList, string date, string cc, string employee)
        {
            //CreateDataSets();
            List<Tuple<string, string, double, string>> ReportCCList = new List<Tuple<string, string, double, string>>();
            double sum = new double();
            foreach (Tuple<DateTime, string, double, string, string> reportLine in recordList)
            {
                if ((reportLine.Item4 == employee) & (reportLine.Item1.ToShortDateString() == date) & cc.Trim().ToUpper() == reportLine.Item2.Trim().ToUpper())
                {
                    sum = sum + reportLine.Item3;
                }
            }
            if (sum > 0)
            {
                ReportCCList.Add(Tuple.Create(date, cc, sum, employee));
            }
            return ReportCCList;

        }
        public List<Tuple<string, string, double, string>> GetListForCC(List<Tuple<DateTime, string, double, string, string>> recordList, string cc)
        {
            foreach(string costCode in setOfCC)
            {

            }
        }


    }
}
