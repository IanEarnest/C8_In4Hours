using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesBusinessLogic.Entities
{
    class HardCodedIssues
    {
        List<IssueBase> allIssues = new List<IssueBase>();

        public List<IssueBase> Examples() 
        {
            allIssues = new List<IssueBase>() {
                new EngineeringIssue
                {
                    IssueID = 101,
                    IssueTitle = "Browser Issue for Web portal",
                    IssueDescription = "User is unable to load web site on IE.",
                    IssuePriority = Priority.P3,
                    IssueStatus = Status.Verified
                },
                new ServiceIssue
                {
                    IssueID = 102,
                    IssueTitle = "Need Customer Service Email",
                    IssueDescription = "User needs email IT support as the call waiting is quite long. ",
                    IssuePriority = Priority.P5,
                    IssueStatus = Status.Unconfirmed
                },
                new OperationalIssue
                {
                    IssueID = 103,
                    IssueTitle = "Shipping Service in not available on weekends",
                    IssueDescription = "Need to have some arrangements for shipping over weekends for running business 24X7",
                    IssuePriority = Priority.P1,
                    IssueStatus = Status.Assigned
                }};
            return allIssues;
        }


        public List<IssueBase> Examples(int numOfIssues) 
        {
            for (int i = 0; i < numOfIssues; i++)
            {
                allIssues.Add(
                    new EngineeringIssue
                    {
                        IssueID = 101 + i,
                        IssueTitle = "Browser Issue for Web portal",
                        IssueDescription = "User is unable to load web site on IE.",
                        IssuePriority = Priority.P3,
                        IssueStatus = Status.Verified
                    });
            }
            return allIssues;
        }
        /*
        List<IssueBase> allIssues = new List<IssueBase>()
        {
            new EngineeringIssue
            {
                IssueID = 101,
                IssueTitle = "Browser Issue for Web portal",
                IssueDescription = "User is unable to load web site on IE.",
                IssuePriority = Priority.P3,
                IssueStatus = Status.Verified
            },
            new ServiceIssue
            {
                IssueID = 102,
                IssueTitle = "Need Customer Service Email",
                IssueDescription = "User needs email IT support as the call waiting is quite long. ",
                IssuePriority = Priority.P5,
                IssueStatus = Status.Unconfirmed
            },
            new OperationalIssue
            {
                IssueID = 103,
                IssueTitle = "Shipping Service in not available on weekends",
                IssueDescription = "Need to have some arrangements for shipping over weekends for running business 24X7",
                IssuePriority = Priority.P1,
                IssueStatus = Status.Assigned
            }
        };*/
    }
}
