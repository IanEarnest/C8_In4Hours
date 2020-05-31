using IssuesBusinessLogic;
using IssuesBusinessLogic.Entities;
using IssuesTrackerInfrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueTrackerApp
{
    /*
    Buttons names
        btn_New     (event btnNew_click)
        btn_Save    
        btn_Resolve
        btn_Load
        cmbType
        cmbPriorityList
        cmbStatus

    txtIssueID
    txtIssueTitle
    txtIssueDesc
    lstLogs         Issues List
    dgrdIssues      Datagrid
     */

    public partial class FormIssueTracker : Form
    {
        private IssueBizContract _issueBiz; //IssueBusinessLogic Object
        private LogHelper _logHelper; //LogHeler Object
        private IssueBase issueToSave; //IssueBase object, it can point to OperationIssue, EngineeringIssue or ServiceIssue(Abstraction and Polymorphism)

        public FormIssueTracker()
        {
            InitializeComponent();
            ////Initializing dependecies.
            _logHelper = new LogHelper();
            _issueBiz = new IssuesBiz(_logHelper); //new IssuesBiz(_logHelper, 20);
            _logHelper.LogUpdated += _logHelper_LogUpdated;
        }

        private void FormIssueTracker_Load(object sender, EventArgs e)
        {
            cmbPriorityList.DataSource = _issueBiz.GetAllPriority(); //Binding Priorities Combo Box
            cmbStatus.DataSource = _issueBiz.GetAllStatus(); //Binding Status Combo Box
            cmbType.DataSource = _issueBiz.GetAllIssueTypes(); //Binding Issue Types Combo Box
            btnResolve.Enabled = false; //Disabling Resolve Button
        }


        /// <summary>
        /// Event handler for LogUpdated event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _logHelper_LogUpdated(object sender, List<LogDetail> e)
        {
            lstLogs.DataSource = null;
            lstLogs.DataSource = e;
        }

        /// <summary>
        /// DataGridView Selection changed event. This gets triggered when a row is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgrdIssues_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Create LoadIssueToEditor(row) method     IssueToSave (of type IssueBase)
                // Create PopulateControls (issue) method   IssueToSave (of type IssueBase)
                //LoadIssueToEditor calls PopulateControls (issue)
                // IssueToSave = LoadIssueToEditor(row);
                //                  PopulateControls

                //MessageBox.Show(dgrdIssues.SelectedRows[0].Cells[0].Value.ToString());

                // If a row is selected, load the issue on that row
                if (dgrdIssues.SelectedRows.Count > 0)
                {
                    LoadIssueToEditor();
                }
            }
            catch (Exception ex)
            {
                _logHelper.LogInfo($"Error Occured {ex}");
            }
        }

        private void LoadIssueToEditor(int row)
        {
            try
            {
                // Fails when Show Resolved false, issue hides before it can be loaded
                if (chkBoxShowResolved.Checked)
                {
                    dgrdIssues.ClearSelection();
                    dgrdIssues[0, row].OwningRow.Selected = true;
                    _logHelper.LogInfo($"Row: {row}");
                    //LoadIssueToEditor();
                }
            }
            catch (Exception ex)
            {
                _logHelper.LogInfo($"Error Occured {ex}");
            }
        }
        private void LoadIssueToEditor() // int row
        {
            try
            {
                int selectedIssueID;
                int.TryParse(dgrdIssues.SelectedRows[0].Cells[0].Value.ToString(), out selectedIssueID);

                //---- Get the Actual Issue object from All Issue List.
                // Go through all issues to find the issue on the row
                List<IssueBase> allIssues = _issueBiz.GetAllIssues();
                foreach (var issue in allIssues)
                {
                    if (issue.IssueID == selectedIssueID)
                    {
                        issueToSave = issue;
                        break;
                    }
                }

                //IssueToSave is now pointing to IssueBase object to update.

                //Populating Controls 
                labelIssueID.Text = issueToSave.IssueID.ToString(); // labelIssueID was txtIssueID
                txtIssueTitle.Text = issueToSave.IssueTitle;
                txtIssueDesc.Text = issueToSave.IssueDescription;
                cmbPriorityList.SelectedItem = issueToSave.IssuePriority;
                cmbStatus.SelectedItem = issueToSave.IssueStatus;
                cmbType.SelectedItem = _issueBiz.GetIssueType(issueToSave);
                cmbType.Enabled = false;
                btnResolve.Enabled = true;
            }
            catch (Exception ex)
            {
                _logHelper.LogInfo($"Error Occured {ex}");
            }
        }

        /// <summary>
        /// Clear all fields to Create a new Issue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            // New method - ClearIssueEdittorFields()
            // ClearIssueEdittorFields();
            // ClearSelection();

            issueToSave = null;
            labelIssueID.Text = "";
            txtIssueTitle.Text = "";
            txtIssueDesc.Text = "";
            cmbPriorityList.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            dgrdIssues.ClearSelection();
            // No selected cells
            //dgrdIssues.CurrentCell = dgrdIssues[columnName, row.Index]; //.Selected = true;
            //.Update(); .Refresh(); .ClearSelection(); .Focus();
            cmbType.Enabled = true;
            btnResolve.Enabled = false;
        }
        
        /// <summary>
        /// Save - Adds a new issue or update existing issue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save, if...
            // new method IssueTypeSelected();
            // issueToSave = IssueTypeSelected();
            // setIssueID()
            // saveIssue() // new/ existing
            // LoadIssues();

            //if title or description empty, disable save, display message
            if(txtIssueTitle.Text == "" || txtIssueDesc.Text == "")
            {
                _logHelper.LogInfo($"Issue Title or Description empty");
                MessageBox.Show("Issue Title and Issue Description are required", "Reminder");
                return;
            }
            

            bool newIssue = false;
            string type = cmbType.SelectedItem.ToString(); //Get the issue type from Issue Type Combobox

            if (issueToSave == null) //IssueToSave null means, we are creating a new Issue object.
            {
                newIssue = true;
                switch (type)
                {
                    case "Operational":
                        issueToSave = new OperationalIssue();
                        break;

                    case "Service":
                        issueToSave = new ServiceIssue();
                        break;

                    case "Engineering":
                        issueToSave = new EngineeringIssue();
                        break;

                    default:
                        break;
                }
            }




            // IssueID - Set to label if issue loaded or set to above largest ID number
            int issueID;

            // do not update if already set (parse from Label)
            if (labelIssueID.Text == "")
            {
                issueID = setIssueID(); // set to highest ID + 1
                labelIssueID.Text = issueID.ToString(); // Update table
            } 
            else {
                int.TryParse(labelIssueID.Text, out issueID);
            }



            //labelIssueID
            issueToSave.IssueID = issueID;

            issueToSave.IssueTitle = txtIssueTitle.Text;
            issueToSave.IssueDescription = txtIssueDesc.Text;

            Priority issuePriority;
            Enum.TryParse(cmbPriorityList.SelectedItem.ToString(), out issuePriority);
            issueToSave.IssuePriority = issuePriority;

            Status issueStatus;
            Enum.TryParse(cmbStatus.SelectedItem.ToString(), out issueStatus);
            issueToSave.IssueStatus = issueStatus;

            // check resolved changed when changing status
            if (issueStatus != Status.Resolved)
            {
                issueToSave.isIssueResolved = false;
            }

            if (newIssue)
            {
                _issueBiz.AddIssue(issueToSave);
            }
            else
            {
                _issueBiz.UpdateIssue(issueToSave);
            }

            //cmbType.Enabled = false;
            //btnResolve.Enabled = true;
            LoadIssues();
            //dgrdIssues.Update();
            //dgrdIssues.Refresh();
            //dgrdIssues.ClearSelection();
            //dgrdIssues.Focus();
            // No selected cells


            // Load this issue into 
            //dgrdIssues.CurrentCell = dgrdIssues. issueID;
            //dgrdIssues.Rows[1].Cells[1].Selected = true;
            // Loop through datagrid to find row with this issueID
            // then set that row as selected

            //dgrdIssues.Rows[0].Selected = false;

            // Go through DataGridView instead of _issueBiz because order may be different
            //_issueBiz.GetAllIssues
            string columnName = "IssueID";
            foreach (DataGridViewRow row in dgrdIssues.Rows)
            {
                //row.Selected = false;
                if (row.Cells[columnName].Value.ToString() == issueID.ToString())// row.Cells[columnIndex].Value != null && issueID == row.Cells[columnIndex].Value.ToString())
                {
                    Thread.Sleep(1000);
                    //dgrdIssues.SelectedRows[0].Cells[0].Value.ToString

                    // Select cell to move focus point - then
                    dgrdIssues.CurrentCell = dgrdIssues[columnName, row.Index]; //.Selected = true;
                    dgrdIssues.Rows[row.Index].Selected = true;
                    _logHelper.LogInfo($"issueID: {issueID} = Row: {row.Index}");
                }
            }
        }
        public int startingID = 101;
        private int setIssueID()
        {
            return setIssueID(0);
        }
        private int setIssueID(int issueID)
        {
            // Set issueID to Last ID + 1
            issueID = _issueBiz.GetAllIssues()[_issueBiz.GetAllIssues().Count - 1].IssueID + 1;
            return issueID;
        }
        // Unused method
        private int setIssueIDNotDuplicate(int issueID)
        {
            // Set IssueID - Check for duplicates, set as unused number (e.g. 101..2..3..5 = 104)
            issueID = startingID; // default
            List<IssueBase> allIssues = _issueBiz.GetAllIssues();
            int issuesCount = _issueBiz.GetAllIssues().Count();

            // Go through all issues to find duplicate
            // If not duplicate, continue
            for (int pos = 1; pos <= issuesCount; pos++) //bool unique = true; while (pos < issuesCount)
            {
                // if duplicate, change issueID
                if (issueID == allIssues[pos - 1].IssueID)
                {
                    issueID++;
                    pos = 1; // restart loop
                }
            }
            return issueID;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadIssues();
        }

        /// <summary>
        /// Private method, loads all issues and refresh the DataGridView.
        /// </summary>

        // Create new public _issueBiz.GetAllIssues() and then restore it in the else
        // binding means both sides changed?
        private void LoadIssues()
        {
            // CheckCheckBox()
            // setIssueList?

            BindingSource source = new BindingSource();
            // Seperate list for resolved issues
            
            // Order list
            //List<IssueBase> SortedList = new List<IssueBase>();
            //SortedList = SortedList.OrderBy(o => o.IssueID).ToList();
            _issueBiz.SortIssues();
            //SortedList = SortedList.OrderBy(o => o.IssueID).ToList();

            // if showResolved = true   // show all // Colour resolved
            if (chkBoxShowResolved.Checked)
            {
                // Show all (Assign DataGrid to issues)
                //List<IssueBase> allIssuesAndResolved = _issueBiz.GetAllIssues();//new List<IssueBase>(_issueBiz.GetAllIssues());

                source.DataSource = _issueBiz.GetAllIssues(); //Get All Issues from Business Logic Class.
                dgrdIssues.DataSource = source; //Binding DataGridView
                //dgrdIssues.ClearSelection();
                //SortedList = _issueBiz.GetAllIssues();

                //Colour resolved (yellow)
                string columnName = "IssueStatus";
                foreach (DataGridViewRow row in dgrdIssues.Rows)
                {
                    // If Status = Resolved
                    if (row.Cells[columnName].Value.ToString() == Status.Resolved.ToString())// row.Cells[columnIndex].Value != null && issueID == row.Cells[columnIndex].Value.ToString())
                    {
                        //Thread.Sleep(1000);
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        //RowPrePaint 
                        string myIssueID = dgrdIssues["IssueID", row.Index].Value.ToString();
                        _logHelper.LogInfo($"Row: {row.Index}, Issue: {dgrdIssues["IssueID", row.Index].Value} made Yellow . {myIssueID}");
                        
                    }
                    // Reset row colour? // what about add new issue as resolved?
                }
                
                //source.DataSource = allIssuesAndResolved; //Get All Issues from Business Logic Class.
                //dgrdIssues.DataSource = source; //Binding DataGridView
                //dgrdIssues.ClearSelection();
            }
            else
            {
                // if showResolved = false // show only not resolved
                // Need to assign to new list otherwise the main list gets changed aswell
                List<IssueBase> allIssuesNotResolved = new List<IssueBase>(_issueBiz.GetAllIssues());//_issueBiz.GetAllIssues());
                //allIssuesNotResolved = _issueBiz.GetAllIssues();

                try
                {
                    //List<IssueBase> tmpList = allIssuesNotResolved;
                    foreach (IssueBase issue in allIssuesNotResolved.ToList()) // .ToList stops Exception: Collection was modified; enumeration operation may not execute
                    {//?
                        if (issue.IssueStatus == Status.Resolved)
                        {
                            allIssuesNotResolved.Remove(issue); // Remove resolved issues from list
                        }
                    }
                    //dgrdIssues.DataSource = new BindingSource(allIssuesNotResolved, "dgrdIssues");

                    // Update here as changed an issue
                    source.DataSource = allIssuesNotResolved;
                    dgrdIssues.DataSource = source;
                    dgrdIssues.ClearSelection();
                }
                catch (Exception ex)
                {
                    _logHelper.LogInfo($"Error Occured {ex}");
                }
                //source.DataSource = allIssuesNotResolved;
                //SortedList = allIssuesNotResolved;
                //dgrdIssues.DataSource = source;
                //dgrdIssues.ClearSelection();
            }
            //_issueBiz.GetAllIssues()

            // Sort both lists
            
            
            //source.DataSource = SortedList;
            //dgrdIssues.DataSource = source;
            //dgrdIssues.ClearSelection();
            //dgrdIssues.Sort(dgrdIssues.Columns["IssueID"], direction:ListSortDirection.Ascending);
        }

        // Temp removes
        private void btnResolve_Click(object sender, EventArgs e)
        {
            //Important: Every Issue has a ResolveIssue method, but we cannot call it because it is marked as internal.
            //We have to access it thrugh the Business Logic Class.

            _issueBiz.ResolveIssue(issueToSave); //Calls the Resolve method on Business Logic Class.
            LoadIssueToEditor();
            LoadIssues();
        }
        // Shows/ hides from datagrid
        private void chkBoxShowResolved_CheckedChanged(object sender, EventArgs e)
        {
            // if checked, database show resolved = true
            _logHelper.LogInfo($"CheckBox: {chkBoxShowResolved.Checked}");
            LoadIssues();
        }
        // Deletes
        private void btnRemove_Click(object sender, EventArgs e)
        {
            _issueBiz.RemoveIssue(issueToSave);
            LoadIssues();
        }
        
        
        // Start new form on top of current
        private void btnNewForm_Click(object sender, EventArgs e)
        {
            // Exit current app to start new app?
            //this.Visible = false;
            //FormIssueTracker mySecondForm = new FormIssueTracker();
            //mySecondForm.Show();
            //mySecondForm.ShowDialog(); // opens as dialog (cannot access previous form)
            //this.Close();

            // ?Perhaps don't use a new thread
            Thread newThread = new Thread(delegate () 
            { 
                Application.Run(new FormIssueTracker()); 
            });

            newThread.Start();
            //this.Close();
        }

        // Debug/ Tools

        // Autofill
        private void btnAutofill_Click(object sender, EventArgs e)
        {
            /*
                issueToSave = null;
                labelIssueID.Text = "";
                txtIssueTitle.Text = "";
                txtIssueDesc.Text = "";
                cmbPriorityList.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;
                cmbType.SelectedIndex = 0;
                dgrdIssues.ClearSelection();
                cmbType.Enabled = true;
                btnResolve.Enabled = false;
            */
            btnNew_Click(sender, e);
            //_logHelper.GetAllLogInfo();
            //lstLogs.DataSource = _logHelper.GetAllLogInfo();
            //List<string> MyList = new List<string>() { "Log message", "Hello2" };
            //lstLogs.DataSource = null;
            //lstLogs.DataSource = MyList;
            string testString = "testString";
            int testInt = 1;
            //issueToSave = null;
            //txtIssueID.Text             = testInt.ToString();
            //labelIssueID.Text = "";
            txtIssueTitle.Text = testString;
            txtIssueDesc.Text = testString;
            cmbPriorityList.SelectedIndex = testInt;
            cmbStatus.SelectedIndex = testInt;
            cmbType.SelectedIndex = testInt;
            //dgrdIssues.ClearSelection();
            //cmbType.Enabled = true;
            //btnResolve.Enabled = false;
        }

        
        delegate void AutoClickDel(object sender, EventArgs e);
        private void btnNewIssue_Click(object sender, EventArgs e)
        {
            //load... and stuff
            _logHelper.LogInfo($"AutoClick running...");


            // Load, (New, AutoFill), 
            //PrintDel print = new PrintDel(MyPrintMethod);
            //AutoClickDel[] autoClickDel = { btnAutofill_Click, btnSave_Click};
            //AutoClickDel [] autoClickDel = new AutoClickDel[]  { btnAutofill_Click, btnSave_Click};
            AutoClickDel autoClickDel = btnLoad_Click;//, btnAutofill_Click, btnSave_Click;//{ btnAutofill_Click + btnSave_Click };
                                                                                        //autoClickDel += btnAutofill_Click;
                                                                                        //autoClickDel += btnSave_Click;
            autoClickDel += btnAutofill_Click;
            autoClickDel += btnSave_Click;
            //autoClickDel.Invoke(sender, e);

            Thread.Sleep(1000);
            // Load
            btnLoad_Click(sender, e);
            // New, AutoFill 
            btnAutofill_Click(sender, e);
            btnSave_Click(sender, e);
        }




        // Section 5 - Async button
        // Normal button
        int result = 0;
        private void buttonWait_Click(object sender, EventArgs e)
        {
            result = Calculate();
            MessageBox.Show($"Result : {result}");
        }

        // Async button
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

        bool isPressed = false;
        //cell value change
        private void dgrdIssues_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            //_logHelper.LogInfo($"CellStateChanged");
            try
            {
                //MessageBox.Show(dgrdIssues.SelectedRows[0].Cells[0].Value.ToString());
                if (dgrdIssues.SelectedRows.Count > 0)
                {
                    // If check box ticked, set Resolved

                    //string myColumn = "Resolved";

                    //DataGridViewCell myCell = dgrdIssues[myColumn, 0];
                    bool myBool = (bool)e.Cell.Value;
                    _logHelper.LogInfo($"Pressed: {myBool}, {sender}");
                    /*
                    // Resolved column
                    if (e.ColumnIndex == dgrdIssues.Columns[myColumn].Index)
                    {
                        _logHelper.LogInfo($"Pressed...column");


                        // if checkbox is true, issue resolved is true
                        // cell??
                        if (myCell.Value.ToString() == "True")
                        {
                            _logHelper.LogInfo($"True...?");
                            // issue resolved
                            isPressed = true;
                            ChangeIssue();
                        }
                        else if (myCell.Value.ToString() == "False")
                        {
                            _logHelper.LogInfo($"False...?");
                            // issue resolved
                            isPressed = false;
                            ChangeIssue();
                        }
                    }*/
                }
            }
            catch (Exception ex)
            {
                _logHelper.LogInfo($"Error Occured {ex}");
            }
        }
        private void ChangeIssue(int row)
        {
            //if (dgrdIssues.SelectedRows.Count > 0)
            
            // Get ID
            int selectedIssueID;
            int.TryParse(dgrdIssues["IssueID", row].Value.ToString(), out selectedIssueID);
            //int.TryParse(dgrdIssues.SelectedRows[0].Cells[0].Value.ToString(), out selectedIssueID);

            //---- Get the Actual Issue object from All Issue List.
            List<IssueBase> allIssues = new List<IssueBase>(_issueBiz.GetAllIssues());//_issueBiz.GetAllIssues();

            // look for by ID
            foreach (IssueBase issue in allIssues)
            {
                // find by ID
                if (issue.IssueID == selectedIssueID)
                {
                    // Set issue Resolved, set status, update
                    issue.isIssueResolved = isPressed;

                    // If not resolved but status shows resolved, make status unconfirmed
                    if (!isPressed && issue.IssueStatus == Status.Resolved)
                    {
                        issue.IssueStatus = Status.Unconfirmed;
                    }
                    // Update only one issue
                    _issueBiz.UpdateIssue(issue);
                    _logHelper.LogInfo($"Issue:");
                }
            }
            

            //Look for by row
            /*
            // set both resolved
            allIssues[row].isIssueResolved = isPressed;
            // check not resolved and status resolved before making unconfirmed
            if(!isPressed && allIssues[row].IssueStatus == Status.Resolved)
            {
                allIssues[row].IssueStatus = Status.Unconfirmed;
            }
            // Update only one issue
            _issueBiz.UpdateIssue(allIssues[row]);
            // Not updated??

            _logHelper.LogInfo($"Issue: {allIssues[row].IssueID}, Row: {row}, Pressed: {isPressed}, Status: {allIssues[row].IssueStatus}, Resolved: {allIssues[row].isIssueResolved}");
            // or
            */
            /*
            foreach (var issue in allIssues)
            {
                if (issue.IssueID == selectedIssueID)
                {
                    //issueToSave = issue;
                    issue.isIssueResolved = isPressed;
                    _issueBiz.UpdateIssue(issue);
                    break;
                }
            }*/
            //_logHelper.LogInfo($"U2 {row}");
            //LoadIssues();
        }

        private void dgrdIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //_logHelper.LogInfo($"CellContentClick");
        }

        private void dgrdIssues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if(_logHelper != null)
            //_logHelper.LogInfo($"CellValueChanged");
        }
        private void dgrdIssues_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            string myColumn = "Resolved";
            string selectableColumn = "IssueID";
            // On down click get value of box, on up click make the value opposite
            // switch Up with Down, then 
            if (e.ColumnIndex == dgrdIssues.Columns[myColumn].Index)
            {
                // Resolved bool change
                dgrdIssues[myColumn, e.RowIndex].Value = !myValue;
                isPressed = !myValue;
                ChangeIssue(e.RowIndex);
                LoadIssues(); // this moves column, changes selection NOT GOOD
                LoadIssueToEditor(e.RowIndex);

            }
            // When a cell in IssueID column selected, make row selected
            else if (e.ColumnIndex == dgrdIssues.Columns[selectableColumn].Index)
            {
                dgrdIssues[selectableColumn, e.RowIndex].OwningRow.Selected = true; // Only works in mouseup, doesn't select whole row in mousedown
            }
            //      Down (box is still empty but selected)
            // get value of checkbox, store and when mouse up set bool opposite
            // 
            //      Up (checkbox is changed (potentially))
            // Load table
        }
        bool myValue;
        private void dgrdIssues_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Still allow rows to be selectable
            //if (e.ColumnIndex > 0)
            //{
            
            string myColumn = "Resolved";

            // Resolved column
            if (e.ColumnIndex == dgrdIssues.Columns[myColumn].Index)
            {
                //LoadIssues(); // Has to update on click? // cell up
                // click anywhere to activate checkbox
                myValue = (bool)dgrdIssues[myColumn, e.RowIndex].Value;//dgrdIssues[myColumn, e.RowIndex].Value;
                var myInt = dgrdIssues["IssueID", e.RowIndex].Value;
                _logHelper.LogInfo($"CellMouseDown: ID {myInt}, Val: {myValue}");


                // if checkbox is true, issue resolved is true
                // cell??
                //if (myValue == true)//.ToString() == "True")
                //{
                //    _logHelper.LogInfo($"True...? {myInt}");
                //    // issue resolved
                //    isPressed = true;
                //    //ChangeIssue(e.RowIndex);
                //    //LoadIssues();
                //}
                //else if (myValue == false)//.ToString() == "False")
                //{
                //    _logHelper.LogInfo($"False...?");
                //    // issue resolved
                //    isPressed = false;
                //    //ChangeIssue(e.RowIndex);
                //    //LoadIssues();
                //}
                //_logHelper.LogInfo($"?...{myValue}, {myInt}");
                //isPressed = myValue;
                //ChangeIssue(e.RowIndex);
                //LoadIssues();
            }
        }

        private void ReLoadIssues_Click(object sender, EventArgs e)
        {
            //InitializeComponent();
            //////Initializing dependecies.
            //_logHelper = new LogHelper();
            //_issueBiz = new IssuesBiz(_logHelper); //new IssuesBiz(_logHelper, 20);
            //_logHelper.LogUpdated += _logHelper_LogUpdated;
        }

        private void btnSaveBackup_Click(object sender, EventArgs e)
        {
            _issueBiz.SaveBackup();
        }

        private void btnLoadBackup_Click(object sender, EventArgs e)
        {
            _issueBiz.LoadBackup();
            LoadIssues();
        }
        //public FormIssueTracker()
        //{
        //    InitializeComponent();
        //    ////Initializing dependecies.
        //    _logHelper = new LogHelper();
        //    _issueBiz = new IssuesBiz(_logHelper); //new IssuesBiz(_logHelper, 20);
        //    _logHelper.LogUpdated += _logHelper_LogUpdated;
        //}
    }
}
