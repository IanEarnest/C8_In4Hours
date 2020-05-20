using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueTrackerApp
{
    public partial class FormIssueTracker : Form
    {
        //private IssueBizContract _issueBiz; //IssueBusinessLogic Object
        //private LogHelper _logHelper; //LogHeler Object
        //private IssueBase issueToSave; //IssueBase object, it can point to OperationIssue, EngineeringIssue or ServiceIssue(Abstraction and Polymorphism)

        public FormIssueTracker()
        {
            InitializeComponent();
            //InitializeComponent();
            ////Initializing dependecies.
            //_logHelper = new LogHelper();
            //_issueBiz = new IssuesBiz(_logHelper);
            //_logHelper.LogUpdated += _logHelper_LogUpdated;
        }

        private void FormIssueTracker_Load(object sender, EventArgs e)
        {
            //cmbPriorityList.DataSource = _issueBiz.GetAllPriority(); //Binding Priorities Combo Box
            //cmbStatus.DataSource = _issueBiz.GetAllStatus(); //Binding Status Combo Box
            //cmbType.DataSource = _issueBiz.GetAllIssueTypes(); //Binding Issue Types Combo Box
            //btnResolve.Enabled = false; //Disabling Resolve Button
        }


        /// <summary>
        /// Event handler for LogUpdated event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void _logHelper_LogUpdated(object sender, List<LogDetail> e)
        //{
        //    lstLogs.DataSource = null;
        //    lstLogs.DataSource = e;
        //}

        /// <summary>
        /// DataGridView Selection changed event. This gets triggered when a row is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrdIssues_SelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if(dgrdIssues.SelectedRows.Count > 0)
            //    {
            //        int selectedIssueID;
            //        int.TryParse(dgrdIssues.SelectedRows[0].Cells[0].Value.ToString(), out selectedIssueID);

            //        //---- Get the Actual Issue object from All Issue List.
            //        List<IssueBase> allIssues = _issueBiz.GetAllIssues();
            //        foreach (var issue in allIssues)
            //        {
            //            if (issue.IssueID == selectedIssueID)
            //            {
            //                issueToSave = issue;
            //                break;
            //            }
            //        }

            //        //IssueToSave is now pointing to IssueBase object to update.

            //        //Populating Controls 
            //        txtIssueID.Text = issueToSave.IssueID.ToString();
            //        txtIssueTitle.Text = issueToSave.IssueTitle;
            //        txtIssueDesc.Text = issueToSave.IssueDescription;
            //        cmbPriorityList.SelectedItem = issueToSave.IssuePriority;
            //        cmbStatus.SelectedItem = issueToSave.IssueStatus;
            //        cmbType.SelectedItem = _issueBiz.GetIssueType(issueToSave);
            //        cmbType.Enabled = false;
            //        btnResolve.Enabled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logHelper.LogInfo($"Error Occured");
            //}
        }

        /// <summary>
        /// Clear all fields to Create a new Issue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            //issueToSave = null;
            //txtIssueID.Text = "";
            //txtIssueTitle.Text = "";
            //txtIssueDesc.Text = "";
            //cmbPriorityList.SelectedIndex = 0;
            //cmbStatus.SelectedIndex = 0;
            //cmbType.SelectedIndex = 0;
            //dgrdIssues.ClearSelection();
            //cmbType.Enabled = true;
            //btnResolve.Enabled = false;
        }
        
        /// <summary>
        /// Save - Adds a new issue or update existing issue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //bool newIssue = false;
            //string type = cmbType.SelectedItem.ToString(); //Get the issue type from Issue Type Combobox

            //if(issueToSave == null) //IssueToSave null means, we are creating a new Issue object.
            //{
            //    newIssue = true;
            //    switch (type)
            //    {
            //        case "Operational":
            //            issueToSave = new OperationalIssue();
            //            break;

            //        case "Service":
            //            issueToSave = new ServiceIssue();
            //            break;

            //        case "Engineering":
            //            issueToSave = new EngineeringIssue();
            //            break;

            //        default:
            //            break;
            //    }
            //}
            
            

            //int issueId;
            //int.TryParse(txtIssueID.Text, out issueId);

            //issueToSave.IssueID = issueId;
            //issueToSave.IssueTitle = txtIssueTitle.Text;
            //issueToSave.IssueDescription = txtIssueDesc.Text;
            //issueToSave.IssueTitle = txtIssueTitle.Text;

            //Priority issuePriority;
            //Enum.TryParse(cmbPriorityList.SelectedItem.ToString(), out issuePriority);
            //issueToSave.IssuePriority = issuePriority;

            //Status issueStatus;
            //Enum.TryParse(cmbStatus.SelectedItem.ToString(), out issueStatus);
            //issueToSave.IssueStatus = issueStatus;

            //if (newIssue)
            //{
            //    _issueBiz.AddIssue(issueToSave);
            //}
            //else
            //{
            //    _issueBiz.UpdateIssue(issueToSave);
            //}

            //LoadIssues();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadIssues();
        }

        /// <summary>
        /// Private method, loads all issues and refresh the DataGridView.
        /// </summary>
        private void LoadIssues()
        {
            //BindingSource source = new BindingSource();
            //source.DataSource = _issueBiz.GetAllIssues(); //Get All Issues from Business Logic Class.
            //dgrdIssues.DataSource = source; //Binding DataGridView
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            //Important: Every Issue has a ResolveIssue method, but we cannot call it because it is marked as internal.
            //We have to access it thrugh the Business Logic Class.

            //_issueBiz.ResolveIssue(issueToSave); //Calls the Resolve method on Business Logic Class.
        }



        // Section 5 - Async button
        int result = 0;
        private void buttonWait_Click(object sender, EventArgs e)
        {
            result = Calculate();
            MessageBox.Show($"Result : {result}");
        }

        private async void buttonWaitAsync_Click(object sender, EventArgs e)
        {
            // task int = int calculate
            Task<int> task = new Task<int>(Calculate);
            task.Start();
            result = await task;
            MessageBox.Show($"Result : {result}");
        }

        // Artificial wait
        private int Calculate()
        {
            int total = 40;
            System.Threading.Thread.Sleep(3000);
            return total;
        }
    }
}
