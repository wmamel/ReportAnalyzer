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

        private List<Tuple<DateTime, string, string, double, string>> empList = new List<Tuple<DateTime, string, string, double, string>>();
        private List<Tuple<DateTime, string, string, string, double, string>> trackerList = new List<Tuple<DateTime, string, string, string, double, string>>();

        public DataAnalyzer(List<Tuple<DateTime, string, string, double, string>> empRecords, List<Tuple<DateTime, string, string, string, double, string>> trackerRecords, Logger logger_imp)
        {
            this.empList = empRecords;
            this.trackerList = trackerRecords;
            this.logger = logger_imp;
        }
        HashSet<string> myHashSet = new HashSet<string>();

        private void CreateDataSets()
        {
            foreach (Tuple<DateTime, string, string, double, string> empLine in empList)
            {
                setOfDates.Add(empLine.Item1.ToShortDateString());
                setOfNames.Add(empLine.Item5);
                setOfCC.Add(empLine.Item2.Trim());
            }
            foreach (Tuple<DateTime, string, string, string, double, string> trackerLine in trackerList)
            {
                setOfDates.Add(trackerLine.Item1.ToShortDateString());
                setOfNames.Add(trackerLine.Item6);
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
        public List<Tuple<string, string, double, string>> ReportccEmp(string cc)
        {
            CreateDataSets();
            List<Tuple<string, string, double, string>> ReportCCList = new List<Tuple<string, string, double, string>>();
            foreach (string employee in setOfNames) 
            {
                foreach (string date in setOfDates)
                {
                    double sum = new double();
                    foreach (Tuple<DateTime, string, string, double, string> empLine in empList)
                    {
                        if ((empLine.Item5==employee) & (empLine.Item1.ToShortDateString()==date) & cc.Trim().ToUpper()==empLine.Item2.Trim().ToUpper())
                        {
                            sum = sum + empLine.Item4;
                        }

                    }
                    if (sum>0 )
                    {
                        ReportCCList.Add(Tuple.Create(employee, date, sum, cc));
                    }
                    
                }
            }
            return ReportCCList;
        }
        public List<Tuple<string, string, double, string>> ReportdateEmp(string date)
        {

        }
    }
}
