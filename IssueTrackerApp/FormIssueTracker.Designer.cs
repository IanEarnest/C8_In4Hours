namespace IssueTrackerApp
{
    partial class FormIssueTracker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbPriorityList = new System.Windows.Forms.ComboBox();
            this.btnResolve = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btmNew = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtIssueDesc = new System.Windows.Forms.TextBox();
            this.txtIssueTitle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstLogs = new System.Windows.Forms.ListBox();
            this.dgrdIssues = new System.Windows.Forms.DataGridView();
            this.IssueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuePriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelIssueID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdIssues)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "Wait";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonWait_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(61, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 22);
            this.button2.TabIndex = 1;
            this.button2.Text = "Wait (async)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonWaitAsync_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Issue ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Issue Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Issue Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Priority:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(115, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelIssueID);
            this.groupBox1.Controls.Add(this.cmbPriorityList);
            this.groupBox1.Controls.Add(this.btnResolve);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btmNew);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.txtIssueDesc);
            this.groupBox1.Controls.Add(this.txtIssueTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 282);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add/ Edit Issue";
            // 
            // cmbPriorityList
            // 
            this.cmbPriorityList.FormattingEnabled = true;
            this.cmbPriorityList.Location = new System.Drawing.Point(187, 162);
            this.cmbPriorityList.Name = "cmbPriorityList";
            this.cmbPriorityList.Size = new System.Drawing.Size(121, 24);
            this.cmbPriorityList.TabIndex = 15;
            // 
            // btnResolve
            // 
            this.btnResolve.Location = new System.Drawing.Point(350, 252);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(75, 23);
            this.btnResolve.TabIndex = 14;
            this.btnResolve.Text = "Resolve";
            this.btnResolve.UseVisualStyleBackColor = true;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(268, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btmNew
            // 
            this.btmNew.Location = new System.Drawing.Point(186, 252);
            this.btmNew.Name = "btmNew";
            this.btmNew.Size = new System.Drawing.Size(75, 23);
            this.btmNew.TabIndex = 12;
            this.btmNew.Text = "New";
            this.btmNew.UseVisualStyleBackColor = true;
            this.btmNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(187, 222);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.TabIndex = 11;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(187, 192);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbStatus.TabIndex = 10;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtIssueDesc
            // 
            this.txtIssueDesc.Location = new System.Drawing.Point(187, 82);
            this.txtIssueDesc.Multiline = true;
            this.txtIssueDesc.Name = "txtIssueDesc";
            this.txtIssueDesc.Size = new System.Drawing.Size(366, 74);
            this.txtIssueDesc.TabIndex = 9;
            this.txtIssueDesc.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtIssueTitle
            // 
            this.txtIssueTitle.Location = new System.Drawing.Point(187, 53);
            this.txtIssueTitle.Name = "txtIssueTitle";
            this.txtIssueTitle.Size = new System.Drawing.Size(366, 22);
            this.txtIssueTitle.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstLogs);
            this.groupBox2.Location = new System.Drawing.Point(614, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 282);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Detail";
            // 
            // lstLogs
            // 
            this.lstLogs.FormattingEnabled = true;
            this.lstLogs.ItemHeight = 16;
            this.lstLogs.Location = new System.Drawing.Point(6, 22);
            this.lstLogs.Name = "lstLogs";
            this.lstLogs.Size = new System.Drawing.Size(492, 244);
            this.lstLogs.TabIndex = 1;
            // 
            // dgrdIssues
            // 
            this.dgrdIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdIssues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IssueID,
            this.IssueTitle,
            this.IssueDescription,
            this.IssuePriority,
            this.IssueStatus});
            this.dgrdIssues.Location = new System.Drawing.Point(12, 353);
            this.dgrdIssues.Name = "dgrdIssues";
            this.dgrdIssues.RowHeadersWidth = 51;
            this.dgrdIssues.RowTemplate.Height = 24;
            this.dgrdIssues.Size = new System.Drawing.Size(1106, 354);
            this.dgrdIssues.TabIndex = 0;
            this.dgrdIssues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgrdIssues.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgrdIssues_CellStateChanged);
            this.dgrdIssues.SelectionChanged += new System.EventHandler(this.dgrdIssues_SelectionChanged);
            // 
            // IssueID
            // 
            this.IssueID.DataPropertyName = "IssueID";
            this.IssueID.HeaderText = "Issue ID";
            this.IssueID.MinimumWidth = 6;
            this.IssueID.Name = "IssueID";
            this.IssueID.Width = 125;
            // 
            // IssueTitle
            // 
            this.IssueTitle.DataPropertyName = "IssueTitle";
            this.IssueTitle.HeaderText = "Title";
            this.IssueTitle.MinimumWidth = 6;
            this.IssueTitle.Name = "IssueTitle";
            this.IssueTitle.Width = 125;
            // 
            // IssueDescription
            // 
            this.IssueDescription.DataPropertyName = "IssueDescription";
            this.IssueDescription.HeaderText = "Description";
            this.IssueDescription.MinimumWidth = 6;
            this.IssueDescription.Name = "IssueDescription";
            this.IssueDescription.Width = 125;
            // 
            // IssuePriority
            // 
            this.IssuePriority.DataPropertyName = "IssuePriority";
            this.IssuePriority.HeaderText = "Priority";
            this.IssuePriority.MinimumWidth = 6;
            this.IssuePriority.Name = "IssuePriority";
            this.IssuePriority.Width = 125;
            // 
            // IssueStatus
            // 
            this.IssueStatus.DataPropertyName = "IssueStatus";
            this.IssueStatus.HeaderText = "Status";
            this.IssueStatus.MinimumWidth = 6;
            this.IssueStatus.Name = "IssueStatus";
            this.IssueStatus.Width = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "All Issues:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1043, 330);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(223, 12);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(97, 26);
            this.btnLog.TabIndex = 12;
            this.btnLog.Text = "Autofill";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(362, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 26);
            this.button3.TabIndex = 13;
            this.button3.Text = "New form";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelIssueID
            // 
            this.labelIssueID.AutoSize = true;
            this.labelIssueID.Location = new System.Drawing.Point(184, 24);
            this.labelIssueID.Name = "labelIssueID";
            this.labelIssueID.Size = new System.Drawing.Size(0, 17);
            this.labelIssueID.TabIndex = 16;
            // 
            // FormIssueTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 719);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgrdIssues);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormIssueTracker";
            this.Text = "Issue Tracker App";
            this.Load += new System.EventHandler(this.FormIssueTracker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdIssues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstLogs;
        private System.Windows.Forms.ComboBox cmbPriorityList;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btmNew;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtIssueDesc;
        private System.Windows.Forms.TextBox txtIssueTitle;
        private System.Windows.Forms.DataGridView dgrdIssues;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuePriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueStatus;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelIssueID;
    }
}

