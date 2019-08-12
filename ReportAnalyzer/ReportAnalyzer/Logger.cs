using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAnalyzer
{
    class Logger
    {
        public event EventHandler<string> passMsgToDisplay;
        public void LogOnScreen(string message)
        {
            passMsgToDisplay?.Invoke(this, message);
        }
    }
}
