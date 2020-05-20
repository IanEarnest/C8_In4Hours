using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IssuesTrackerInfrastructure
{
    public class LogHelper
    {
        private static List<LogDetail> _logs = new List<LogDetail>();
        public event EventHandler<List<LogDetail>> LogUpdated;

        public void LogInfo(string msg)
        {
            _logs.Add(new LogDetail 
            { 
                Message = msg, 
                LogTime = DateTime.Now 
            });
            this.LogUpdated(this, _logs);
        }

        public List<LogDetail> GetAllLogInfo()
        {
            return _logs;
        }
    }
    public class LogDetail
    {
        public string Message { get; set; }
        public DateTime LogTime { get; set; }

        //Overriding ToString Method

        public override string ToString()
        {
            return $"{Message} at {LogTime}";
        }
    }
}
