using IssuesBusinessLogic.Entities;
using IssuesTrackerInfrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesBusinessLogic
{
    public class IssuesBiz : IssueBizContract
    {
        // Also Priority, also GetIssueType() cases
        //List<string> allIssueTypes = new List<string>()
        //   {
        //       "Operational",
        //       "Service",
        //       "Engineering"
        //   };


        List<IssueBase> allIssues = new List<IssueBase>();
        //Log Helper Class object.
        private LogHelper _objLogHelper;
        public IssuesBiz(LogHelper logHelper)
        {
            _objLogHelper = logHelper;
            //Initial Data
            //3 hardcoded issues
            //allIssues = new HardCodedIssues().Examples();
            Load();
            //MyFile.Save("Hello world");
            //string MyString = MyFile.Load();
        }

        
        public IssuesBiz(LogHelper logHelper, int numOfIssues)
        {
            _objLogHelper = logHelper;
            //Initial Data
            //# hardcoded issues
            allIssues = new HardCodedIssues().Examples(numOfIssues);
        }

        //Method to Add new Issue
        public int AddIssue(IssueBase issue)
        {
            // DO I NEED TO CHECK RESOLVED WHEN ADDED?
            if (issue.IssueStatus == Status.Resolved)
                issue.isIssueResolved = true;

            allIssues.Add(issue);
            //SortIssues(); // need this?, new issue is always last and has highest number


            // ? why if statement
            //Log this infomation.
            if (issue.IssueTitle.Length > 15)
                _objLogHelper.LogInfo($"{issue.IssueTitle.Substring(0, 15)} ... Added.");
            else
                _objLogHelper.LogInfo($"{issue.IssueTitle} ... Added.");

            Save();
            return issue.IssueID;
        }

        // Save in ResolveIssue, RemoveIssue, AddIssue, SortIssues, UpdateIssue, 
        // Load in GetAllIssues, 
        public void Load()
        {
            allIssues = new List<IssueBase>(MyFile.Load());
        }
        public void Save()
        {
            MyFile.Save(allIssues);
        }
        public void LoadBackup()
        {
            allIssues = new List<IssueBase>(MyFile.LoadBackup());
        }
        public void SaveBackup()
        {
            MyFile.SaveBackup(allIssues);
        }

        /// <summary>
        /// Method to Resolve the issue
        /// </summary>
        /// <param name="issue"></param>
        public void ResolveIssue(IssueBase issue)
        {
            issue.isIssueResolved = true;
            issue.IssueStatus = Status.Resolved; // can put in each "ServiceIssue"...
            string message = issue.ResolveIssue();
            _objLogHelper.LogInfo(message);
            Save();
        }
        /// <summary>
        /// Remove issue - 
        /// </summary>
        /// <param name="issue"></param>
        public void RemoveIssue(IssueBase issue)
        {
            allIssues.Remove(issue);
            string message = $"{issue.IssueID} - has been removed from the database.";//issue.RemoveIssue();
            _objLogHelper.LogInfo(message);
            Save();
        }

        /// <summary>
        /// Method to GetAllIssues
        /// </summary>
        /// <returns></returns>
        public List<IssueBase> GetAllIssues()
        {
            Load();
            return allIssues;
        }

        public void SortIssues()
        {
            try
            {
                //allIssues.Sort();
                allIssues = allIssues.OrderBy(o => o.IssueID).ToList();
            }
            catch (Exception)
            {
                _objLogHelper.LogInfo($"Sort failed");
            }
            Save();
        }

        /// <summary>
        /// Method to Get All Issue Types
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllIssueTypes()
        {
            List<string> allIssueTypes = new List<string>()
            {
                "Operational",
                "Service",
                "Engineering"
            };

            return allIssueTypes;
        }

        /// <summary>
        /// Method to get all issue priorities.
        /// </summary>
        /// <returns></returns>
        public List<Priority> GetAllPriority()
        {
            List<Priority> allPriorities = new List<Priority>()
            {
                //foreach (enum in Priority)
                Priority.P5,
                Priority.P4,
                Priority.P3,
                Priority.P2,
                Priority.P1,
            };

            return allPriorities;
        }

        /// <summary>
        /// Method to get All Issue Status
        /// </summary>
        /// <returns></returns>
        public List<Status> GetAllStatus()
        {
            List<Status> allStatus = new List<Status>()
            {
                Status.Unconfirmed,
                Status.New,
                Status.Assigned,
                Status.Resolved,
                Status.Verified,
                Status.Reopen,
                Status.Closed
            };

            return allStatus;
        }

        /// <summary>
        /// Method to Update an issue
        /// </summary>
        /// <param name="updatedIssue"></param>
        /// <returns></returns>
        public int UpdateIssue(IssueBase updatedIssue)
        {
            //Find the issue from the list, remove it and add the updated issue again to the list.
            foreach (var issue in allIssues)
            {
                if (issue.IssueID == updatedIssue.IssueID)
                {
                    allIssues.Remove(issue);//Remove Item from the list.
                    break;
                }
                
            }

            if (updatedIssue.isIssueResolved == true || updatedIssue.IssueStatus == Status.Resolved) // from table
            {
                updatedIssue.IssueStatus = Status.Resolved;
                updatedIssue.isIssueResolved = true;
            }
            else
            {
                //updatedIssue.IssueStatus = Status.Unconfirmed;
                //updatedIssue.isIssueResolved = false;
            }
                

            allIssues.Add(updatedIssue);
            SortIssues();

            //Log this information
            if (updatedIssue.IssueTitle.Length > 15)
                _objLogHelper.LogInfo($"{updatedIssue.IssueTitle.Substring(0, 15)} ... updated.");
            else
                _objLogHelper.LogInfo($"{updatedIssue.IssueTitle} ... updated.");

            Save();
            return updatedIssue.IssueID;
        }

        //Method to return Issue Type for an issue object.
        public string GetIssueType(IssueBase issue)
        {
            string type = issue.GetType().Name;
            string result = "";
            switch (type)
            {
                case "EngineeringIssue":
                    result = "Engineering";
                    break;
                case "OperationalIssue":
                    result = "Operational";
                    break;
                case "ServiceIssue":
                    result = "Service";
                    break;
                default:
                    break;
            }
            return result;
        }

        public bool GetIsIssueResolved(IssueBase issue)
        {
            return issue.isIssueResolved;
        }
    }
}
