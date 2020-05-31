using IssuesBusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesBusinessLogic
{
    public interface IssueBizContract
    {
		List<IssueBase> GetAllIssues();
		void SortIssues();
		List<string> GetAllIssueTypes();
		string GetIssueType(IssueBase issue);
		List<Status> GetAllStatus();
		List<Priority> GetAllPriority();
		int AddIssue(IssueBase issue);
		int UpdateIssue(IssueBase issue);
		void ResolveIssue(IssueBase issue);
		void RemoveIssue(IssueBase issue);
		bool GetIsIssueResolved(IssueBase issue);
	}
}
