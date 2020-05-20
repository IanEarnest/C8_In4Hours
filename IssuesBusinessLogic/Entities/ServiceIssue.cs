using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesBusinessLogic.Entities
{
    public class ServiceIssue : IssueBase
    {
        protected internal override string ResolveIssue()
        {
            return $"Service Issue - {this.IssueID} has been resolved.";
        }
    }
}
