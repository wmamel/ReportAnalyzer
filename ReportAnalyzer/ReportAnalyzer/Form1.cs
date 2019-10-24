using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace ReportAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SelectProductionEng();
            
            //FillListOfEmployeeToCHeck(); ;


        }
        

        private void SelectProductionEng()
        {
            UINameList.SetItemChecked(0, true); //Alicja Marglewska
            UINameList.SetItemChecked(1, true); //Blazej Agacinski
            UINameList.SetItemChecked(2, true); //Dawid Marchlewicz
            UINameList.SetItemChecked(3, true); //Malgorzata Marcysiak
            UINameList.SetItemChecked(4, true); //Pawel Sochal
            UINameList.SetItemChecked(5, true); //Przemyslaw Nejman
            UINameList.SetItemChecked(6, true); //Radoslaw Domian
            UINameList.SetItemChecked(7, true); //Slawomir Jasiecki
            UINameList.SetItemChecked(8, true); //Szymon Kaszak
            UINameList.SetItemChecked(9, true); //Szymon Kobylinski
            UINameList.SetItemChecked(10, true); //Tomasz Tojek
            UINameList.SetItemChecked(11, true); //Wojciech Mamel

        }


        public void OnMsgToDisplay(Object sender, string message)
        {
            textBox1.AppendText(message);
        }
        private List<string> DateRangeToList(DateTime startdate, DateTime enddate)
        {
            List<string> selectedDates = new List<string>();
            for (DateTime date = startdate; date <= enddate; date = date.AddDays(1))
            {
                selectedDates.Add(date.ToShortDateString());
            }
            return selectedDates;
        }

        private void UIButtonCompareEMPnTRA_Click(object sender, EventArgs e)
        {

            List<string> employeeListToCheck = new List<string>();
            employeeListToCheck = UINameList.CheckedItems.OfType<string>().ToList();
            List<string> selectedDates = new List<string>();
            selectedDates = DateRangeToList(UIdateTimePickerStart.Value.Date, UIdateTimePickerEnd.Value.Date);
            Logger logger = new Logger();
            Writer writer = new Writer(logger);
            writer.SetFilename("Comparison_report_"+ DateTime.Today.ToShortDateString().Replace("\\", "_"));
            writer.SetPath(textBoxPath.Text);
            ReportReader ReportReader = new ReportReader(logger);
            logger.passMsgToDisplay += OnMsgToDisplay;
            //logger.LogOnScreen("Start");
            ReportReader.LoadReports(textBoxTracker.Text, textBoxEmp.Text);
            DataAnalyzer dataAnalyzer = new DataAnalyzer(ReportReader.EmpRecords, ReportReader.TrackerRecords, employeeListToCheck, selectedDates, logger, writer);
            //dataAnalyzer.test_2();

            dataAnalyzer.CompareEmpAndTra();
        }

        private void UIButtonCreatePOReport_Click_1(object sender, EventArgs e)
        {
            List<string> employeeListToCheck = new List<string>();
            employeeListToCheck = UINameList.CheckedItems.OfType<string>().ToList();
            List<string> selectedDatesF = new List<string>();
            selectedDatesF = DateRangeToList(UIdateTimePickerStart.Value.Date, UIdateTimePickerEnd.Value.Date);
            MessageBox.Show(UIdateTimePickerStart.Value.Date.ToShortDateString() + "  " + UIdateTimePickerEnd.Value.Date.ToShortDateString());
            //prepares the list of user to check, other user will not be taken into consideration
            Logger logger = new Logger();
            Writer writer = new Writer(logger);
            writer.SetFilename("PO_report_"+ DateTime.Today.ToShortDateString().Replace("\\", "_"));
            writer.SetPath(textBoxPath.Text);
            ReportReader ReportReader = new ReportReader(logger);
            logger.passMsgToDisplay += OnMsgToDisplay;
            //logger.LogOnScreen("Start");
            ReportReader.LoadReports(textBoxTracker.Text, textBoxEmp.Text);
            DataAnalyzer dataAnalyzer = new DataAnalyzer(ReportReader.EmpRecords, ReportReader.TrackerRecords, employeeListToCheck, selectedDatesF, logger, writer);
            dataAnalyzer.CreatePOReport();
            
            
        }

 
    }
}
