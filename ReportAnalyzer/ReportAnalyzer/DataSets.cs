using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReportAnalyzer
{
    class DataSets
    {
        Logger logger;
        Writer writer;

        //private DataSet DataSetPOReport = new DataSet();
        private DataTable DataTablePOReport = new DataTable();
        //private DataSet DataSetCompareReport = new DataSet();
        private DataTable DataTableCompareReport = new DataTable();
        public DataSets(Logger logger_imp, Writer writer_imp)
        {
            this.logger = logger_imp;
            this.writer = writer_imp;
            DataTablePOReport.Columns.Add("Employee", typeof(string));
            DataTablePOReport.Columns.Add("CC", typeof(string));
            DataTablePOReport.Columns.Add("Summarized time in Empower", typeof(double));
            DataTablePOReport.Columns.Add("Summarized time in Tracker", typeof(double));
            DataTablePOReport.Columns.Add("Summarized final time", typeof(double));
            
            DataTableCompareReport.Columns.Add("Error type");
            DataTableCompareReport.Columns.Add("Error desciption");
            DataTableCompareReport.Columns.Add("Date");
            DataTableCompareReport.Columns.Add("CC");
            DataTableCompareReport.Columns.Add("Employee");
            DataTableCompareReport.Columns.Add("Calculation");
        }
        /// <summary>
        /// Adds data to PO-report data set
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="cc"></param>
        /// <param name="empTime"></param>
        /// <param name="traTime"></param>
        /// <param name="finalTime"></param>
               
        public void AddToReport(string employee, string cc, double empTime, double traTime, double finalTime)
        {
            DataTablePOReport.Rows.Add(employee, cc, empTime, traTime, finalTime);
   
        }
        /// <summary>
        /// Adds data with discrepancies betwen Enmpower and Tracker
        /// example: E	EMP>TRA	31/07/2019	PHI_QLMAJV_098	Employee name	5.12>3.95
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="errorDesc"></param>
        /// <param name="date"></param>
        /// <param name="cc"></param>
        /// <param name="employee"></param>
        /// <param name="calculation"></param>
        public void AddToReport(string errorType, string errorDesc, string date, string cc, string employee, string calculation)
        {
            DataTableCompareReport.Rows.Add(errorType, errorDesc, date, cc, employee, calculation);

        }
        public void SavePOReport()
        {
            DataSet DataSetPOReport = new DataSet();
            DataSetPOReport.Tables.Add(DataTablePOReport);
            ExportDataSetToExcel(DataSetPOReport);


        }
        public void SaveComparisonReport()
        {
            DataSet DataSetCompareReport = new DataSet();
            DataSetCompareReport.Tables.Add(DataTableCompareReport);
            ExportDataSetToExcel(DataSetCompareReport);

        }
        private void ExportDataSetToExcel(DataSet data)
        {
            writer.SaveToFile(data);
        }
    }
}
