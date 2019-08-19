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
        }

        private void button2_Click(object sender, EventArgs e)
        {
                    }

        public void OnMsgToDisplay(Object sender, string message)
        {
            textBox1.AppendText(message);
        }
        private void button1_Click(object sender, EventArgs e)
        {


            Logger logger = new Logger();
            ReportReader ReportReader = new ReportReader(logger);
            logger.passMsgToDisplay += OnMsgToDisplay;
            logger.LogOnScreen("Start");
            ReportReader.LoadReports(textBoxTracker.Text, textBoxEmp.Text);
            DataAnalyzer dataAnalyzer = new DataAnalyzer(ReportReader.EmpRecords, ReportReader.TrackerRecords, logger);
            //dataAnalyzer.test_2();
            dataAnalyzer.check();
            //dataAnalyzer.temp_list_data();
            //dataAnalyzer.ReportCCEmp("Engineering");
            //foreach (Tuple<DateTime, string, string, string, double, string> a in ReportReader.TrackerRecords)
            // {
            //textBox1.AppendText(a.Item1.ToString()+"\n");
            //textBox1.AppendText(a.Item2.ToString() + "\n");
            //textBox1.AppendText(a.Item3.ToString() + "\n");
            //textBox1.AppendText(a.Item4.ToString() + "\n");
            //textBox1.AppendText(a.Item5.ToString() + "\n");
            //textBox1.AppendText(a.Item6.ToString() + "\n");
            // }
            // textBox1.AppendText(ReportReader.TrackerRecords.ToString());
            logger.LogOnScreen("Done");
        }
    }
}
