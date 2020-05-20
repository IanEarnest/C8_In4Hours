using System;
using System.Collections.Generic;
using System.Text;

namespace C8_In4Hours
{
    /// <summary>
    /// Section 6 = 
    /// Section 6: Project 1
    /// Win Form Project in C#
    ///   6.1 Requirement, design
    ///   6.2 UI, controls, buttons
    ///   6.3 Business Logic Implementation, Architecture, OOP
    ///   6.4 Events in Win Form Project
    /// </summary>
    class Section6
    {
        /* Notes
        A
         */
        
        /// <summary> Prints "Hello World!"
        /// </summary>
        public void PrintHello()
        {
            Console.WriteLine("S6 Hello World!");
        }

           
       
       
       
       

        //Win Form Project in C#
        //   6.1 Requirement, design
        public void Lesson6_1()
        {
            //Issue Tracker App
            //Add / Edit Issue Section
            /*
               	Issue ID	    TextBox     101
               	Issue Title	    TextBox     "My problem"
               	Issue Desc	    TextBox     "This is..."           (multiline)
               	Priority	    ComboBox	Low, Medium, High
               	Status		    ComboBox	Open, InProgress, Closed 
               	Type		  	ComboBox	Engineering, Operational, Service
               	Buttons         - New, Save, Resolve
           */
            //Log Detail Section (list box)
            // "Service issue - 102 has been resolved at 2/24/2019 6:02:41"
            //All Issues Section (in a data grid)
            //	Issue ID, Title, Description, Priority, Status
            //	Buttons         - Load


            //Steps
	        //1. Design UI
	        //2. Create Class Library Project - IssuesBusinessLogic
	        //3. Create folder Entities
		       // Create Classes:
			      //  Enum Status (Open, InProgress, Closed)
			      //  Enum Priority (Low, Medium, High)
			      //  (IssueBase inherited by OperationalIssue/ ServiceIssue/ EngineeringIssue)
                  //  (OperationalIssue... - override ResolveIssue())
			      //  Abstract Class - IssueBase
					    //    IssueID           int
					    //    IssueTitle        string
					    //    IssueDesc         string
					    //    IssueStatus       Status
					    //    IssuePriority     Priority
					    //    String            ResolveIssue() Abstract Method   //return string
	        //4. Interface IssueBizContract (implemented by IssuesBiz)
			      //  GetAllIssues    List<IssueBase>
			      //  GetAllIssueType List<string> 
			      //  string          GetIssueTypes   (IssueBase issue);
			      //  List<Status>    GetAllStatus    ();
			      //  List<Priority>  GetAllPriority  ();
			      //  int             AddIssue        (IssueBase issue);
			      //  int             UpdateIssue     (IssueBase issue);
			      //  void            ResolveIssue    (IssueBase issue);
			      //  CloseIssue?
         //   5. IssueTrackerInfrastructure (LogHleper, LogDetail)
        }
        //   6.2 UI, controls, buttons
        public void Lesson6_2()
        {
            // Video
        }
        //   6.3 Business Logic Implementation, Architecture, OOP
        public void Lesson6_3()
        {
            //   Solution:
            //       Form App                IssueTrackerApp
            //       Class Library Project   IssuesBusinessLogic             IssueBizContract, IssuesBiz
            //       ...                                                    +(Entities) EngineeringIssue, IssueBase, OperationalIssue, Priority, ServiceIssue, Status
            //       Class Library Project   IssueTrackerInfrastructure      LogHelper, LogDetail

            //   References:
            //       IssueTrackerApp references Both
            //       IssuesBusinessLogic references IssueTrackerInfrastructure

            // write down methods of each class

            // IssueTrackerApp
            //      FormIssueTracker()
            //      FormIssueTracker_Load
            //      dgrdIssues_SelectionChanged
            //      btnNew_Click...
            // IssuesBusinessLogic
            //      Priority
            //      Status
            //      IssueBizContract
            //      IssuesBiz
            //      IssueBase
            //      EngineeringIssue
            //      OperationalIssue
            //      ServiceIssue
            // IssueTrackerInfrastructure
            //      LogHelper 
            //          _logs               List            <LogDetail>         ?    static
            //          LogUpdated          EventHandler    <List<LogDetail>>
            //          void                LogInfo         (string msg)        //_logs.Add(new LogDetail...
            //          List<LogDetail>     GetAllLogInfo()                     //return _logs
            //          void                ResolveIssue    (IssueBase issue);
            //      LogDetail
            //          Message     string      property
            //          LogTime     DateTime    property
            //          string      ToString    ()          Override         return $"{Message} at {LogTime}";        
        }
        //   6.4 Events in Win Form Project
        public void Lesson6_4()
        {
        //tips - formLoadEvent, cmbPriority - DropdownStyle - dropdown property
        //Datagrid = Columns - Issue ID, Title, Description, Priority, Status (Set each DataPropertyName)

        //Improvements - EngineeringIssue... Into 1 class (IssueClasses)
        //	 	Enums into 1 class (EnumClass)
        //	Add tests
        //	Data is in memory list, use persistan storage/ file?
        //		IS.StreamWriter, searilaize, BinaryFormatter
        //		SQL Server Compact or lightweight database
        //      https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-3.0/182eeyhh(v=vs.85)?redirectedfrom=MSDN
        //      XMLSerializer
        //      https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?redirectedfrom=MSDN&view=netcore-3.1
        //      Serialize
        //      https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-3.0/szzyf24s%28v%3dvs.85%29
        }
    }
}
