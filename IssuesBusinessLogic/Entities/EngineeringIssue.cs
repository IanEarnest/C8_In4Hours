using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesBusinessLogic.Entities
{
    public class EngineeringIssue : IssueBase
    {
        protected internal override string ResolveIssue()
        {
            return $"Engineering Issue - {this.IssueID} has been resolved.";
        }
    }
}
