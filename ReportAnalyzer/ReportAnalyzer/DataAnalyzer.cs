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
        private HashSet<string> setOfSelectedDates = new HashSet<string>();
        const double treshold = 1.1;
        const double marza= 1.15;

        private List<Tuple<DateTime, string, double, string, string>> empList = new List<Tuple<DateTime, string, double, string, string>>();
        private List<Tuple<DateTime, string, double, string, string>> trackerList = new List<Tuple<DateTime, string, double, string, string>>();
        private List<Tuple<string, string, double, string>> summarizedEmpList = new List<Tuple<string, string, double, string>>();
        private List<Tuple<string, string, double, string>> summarizedTrackerList = new List<Tuple<string, string, double, string>>();
        public DataAnalyzer(List<Tuple<DateTime, string, double, string, string>> empRecords, List<Tuple<DateTime, string, double, string, string>> trackerRecords, Logger logger_imp)
        {
            this.empList = empRecords;
            this.trackerList = trackerRecords;
            this.logger = logger_imp;
            CreateDataSets();
            setOfSelectedDates = setOfDates;
            CreateSummarizedList(empList, summarizedEmpList);
            CreateSummarizedList(trackerList, summarizedTrackerList);

        }
        //HashSet<string> myHashSet = new HashSet<string>();

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

        private void temp_list_data()
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
        private void test_2()
        {
            List<Tuple<string, string, double, string>> aa = new List<Tuple<string, string, double, string>>();
            List<Tuple<string, string, double, string>> bb = new List<Tuple<string, string, double, string>>();
            aa= GetSubListForGivenEmployee("Radoslaw Domian", GetSubListForGivenCC("PHI_MLMAQX_118", summarizedTrackerList));
            bb=GetSubListForGivenEmployee("Radoslaw Domian", GetSubListForGivenCC("PHI_MLMAQX_118", summarizedEmpList));
            int c =new int();

            c++;
            

        }
        public void CompareEmpAndTra()
        {
            //sumuje czasy , tworzy liste bez duplikatow w danym dniu
            double trackerTime = new double();
            double empTime = new double();

            foreach (string employee in setOfNames)
            {
                foreach (string date in setOfDates)
                {
                    foreach (string cc in setOfCC)
                    {
                        if (cc!= "Engineering")
                        { 
                            List<Tuple<string, string, double, string>> internaltrackerList = new List<Tuple<string, string, double, string>>();
                            List<Tuple<string, string, double, string>> internalempList = new List<Tuple<string, string, double, string>>();
                            trackerTime = 0;
                            empTime = 0;
                            internaltrackerList = GetSubListForGivenDate(date, GetSubListForGivenEmployee(employee, GetSubListForGivenCC(cc, summarizedTrackerList)));
                            internalempList = GetSubListForGivenDate(date, GetSubListForGivenEmployee(employee, GetSubListForGivenCC(cc, summarizedEmpList)));
                            //var empRecord = new Tuple<string, string, double, string>();
                            // var trackerRecord;
                            if (internaltrackerList.Any())
                            {
                                //trackerRecord = trackerList.First();
                                trackerTime = internaltrackerList.First().Item3;
                                //trackerTime = Math.Ceiling(trackerTime);
                            }
                            if (internalempList.Any())
                            {
                                //empRecord = empList.First();
                                //empTime = empRecord.Item3;
                                empTime = internalempList.First().Item3;
                                empTime = Math.Round(empTime, 2);
                            }

                            if (empTime>trackerTime*treshold)
                            {
                                logger.LogOnScreen("E\tEMP>TRA\t"+internalempList.First().Item1 + "\t"+ internalempList.First().Item2 + "\t" + internalempList.First().Item4  +"\t"+ empTime.ToString() + ">" + trackerTime.ToString()+"\n");

                            }
                            if (empTime == 0 && trackerTime>0)
                            {
                                logger.LogOnScreen("W\tEMP=0, TRA>0\t" + internaltrackerList.First().Item1 + "\t" + internaltrackerList.First().Item2 + "\t" + internaltrackerList.First().Item4 + "\tEMP=0 TRA=" + trackerTime.ToString() + "\n");
                            }
                        }


                    }
                }
            }
            logger.LogOnScreen("done check");

        }

        public void CreatePOReport ()
        {
            foreach(string employee in setOfNames)
            {
                List<Tuple<string, double>> summarizedEmpCCList = new List<Tuple<string, double>>();
                List<Tuple<string, double>> summarizedTraList = new List<Tuple<string, double>>();
                summarizedEmpCCList = GetListOfSummarizedTimes(GetSubListForGivenEmployee(employee, summarizedEmpList));
                summarizedTraList = GetListOfSummarizedTimes(GetSubListForGivenEmployee(employee, summarizedTrackerList));
                foreach(string cc in setOfCC)
                {
                    double empTime = new double();
                    double traTime = new double();
                    double finalTime = new double();
                    foreach (Tuple<string, double> empRecord in summarizedEmpCCList)
                    {
                        if (cc== empRecord.Item1)
                        {
                            empTime = empRecord.Item2;
                        }
                    }
                    foreach (Tuple<string, double> traRecord in summarizedTraList)
                    {
                        if (cc == traRecord.Item1)
                        {
                            traTime = traRecord.Item2;
                        }
                    }

                    if (empTime*marza>traTime)
                    {
                        finalTime = empTime * marza;
                    }
                    else
                    {
                        finalTime = traTime;
                    }
                    if (finalTime > 0)
                    {
                        logger.LogOnScreen($"{employee}\t{cc}\t{empTime}\t{traTime}\t{finalTime}\n");
                    }
                }

                
            }
            
        }
        public List<Tuple<string, string, double, string>> GetSummarizedTimeForSpecificDateCCEmployee(List<Tuple<DateTime, string, double, string, string>> recordList, string date, string cc, string employee)
        {
            //CreateDataSets();
            List<Tuple<string, string, double, string>> ReportCCList = new List<Tuple<string, string, double, string>>();
            double sum = new double();
            foreach (Tuple<DateTime, string, double, string, string> recordLine in recordList)
            {
                if ((recordLine.Item4 == employee) & (recordLine.Item1.ToShortDateString() == date) & cc.Trim().ToUpper() == recordLine.Item2.Trim().ToUpper())
                {
                    sum = sum + recordLine.Item3;
                }
            }
            if (sum > 0)
            {
                ReportCCList.Add(Tuple.Create(date, cc, sum, employee));
            }
            return ReportCCList;

        }
        public List<Tuple<string, double>> GetListOfSummarizedTimes(List<Tuple<string, string, double, string>> recordList)
        {
            //CreateDataSets();
            List<Tuple<string, double>> summarizedCCList = new List<Tuple<string, double>>();
            //double sum = new double();
            foreach(string cc in setOfCC)
            {
                double sum = new double();
                foreach (Tuple<string, string, double, string> recordLine in recordList)
                {
                    if (cc.Trim().ToUpper() == recordLine.Item2.Trim().ToUpper())
                    {
                        sum = sum + recordLine.Item3;
                    }
                }
                if (sum>0)
                {
                    summarizedCCList.Add(Tuple.Create(cc.Trim().ToUpper(), sum));
                }
            
            }
            return summarizedCCList;

        }


        private void CreateSummarizedList(List<Tuple<DateTime, string, double, string, string>> recordList, List<Tuple<string, string, double, string>> targetSummarizedList)
        {
            //sumuje czasy , tworzy liste bez duplikatow w danym dniu
            double sum = new double();
            foreach (string employee in setOfNames)
            {
                foreach(string date in setOfDates)
                {
                    foreach (string cc in setOfCC)
                    {
                        sum = 0;
                        foreach (Tuple<DateTime, string, double, string, string> recordLine in recordList)
                        {
                            if ((recordLine.Item4 == employee) & (recordLine.Item1.ToShortDateString() == date) & cc.Trim().ToUpper() == recordLine.Item2.Trim().ToUpper())
                            {
                                sum = sum + recordLine.Item3;
                            }
                        }
                        if (sum > 0)
                        {
                            targetSummarizedList.Add(Tuple.Create(date, cc, sum, employee));
                        }
                        
                    }
                }
            }
        }

        private List<Tuple<string, string, double, string>> GetSubListForGivenEmployee(string employee, List<Tuple<string, string, double, string>> recordList)
        {
            List<Tuple<string, string, double, string>> subList = new List<Tuple<string, string, double, string>>();
            foreach (Tuple<string, string, double, string> recordLine in recordList)
            {
                if (recordLine.Item4 == employee)
                {
                    subList.Add(recordLine);
                }
            }
            return subList;
        }
        private List<Tuple<string, string, double, string>> GetSubListForGivenCC(string cc, List<Tuple<string, string, double, string>> recordList)
        {
            List<Tuple<string, string, double, string>> subList = new List<Tuple<string, string, double, string>>();
            foreach (Tuple<string, string, double, string> recordLine in recordList)
            {
                if (cc.Trim().ToUpper() == recordLine.Item2.Trim().ToUpper())
                {
                    subList.Add(recordLine);
                }
            }
            return subList;
        }
        private List<Tuple<string, string, double, string>> GetSubListForGivenDate(string date, List<Tuple<string, string, double, string>> recordList)
        {
            List<Tuple<string, string, double, string>> subList = new List<Tuple<string, string, double, string>>();
            foreach (Tuple<string, string, double, string> recordLine in recordList)
            {
                if (recordLine.Item1 == date)
                {
                    subList.Add(recordLine);
                }
            }
            return subList;
        }

    }
}
