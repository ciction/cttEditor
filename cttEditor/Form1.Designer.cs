namespace cttEditor
{
    partial class Form1
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
            this.CoursesdataGridView = new System.Windows.Forms.DataGridView();
            this.CourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LectureSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinWorkingDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoursesLabel = new System.Windows.Forms.Label();
            this.CoursesCountLabel = new System.Windows.Forms.Label();
            this.CttNameLabel = new System.Windows.Forms.Label();
            this.CttNameValue = new System.Windows.Forms.TextBox();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.CttDaysValue = new System.Windows.Forms.TextBox();
            this.CttDaysLabel = new System.Windows.Forms.Label();
            this.RoomsdataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomsCountLabel = new System.Windows.Forms.Label();
            this.RoomsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesdataGridView)).BeginInit();
            this.groupBoxGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CoursesdataGridView
            // 
            this.CoursesdataGridView.AllowUserToOrderColumns = true;
            this.CoursesdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoursesdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseCode,
            this.TeacherCode,
            this.LectureSize,
            this.MinWorkingDays,
            this.StudentSize});
            this.CoursesdataGridView.Location = new System.Drawing.Point(12, 141);
            this.CoursesdataGridView.Name = "CoursesdataGridView";
            this.CoursesdataGridView.Size = new System.Drawing.Size(543, 148);
            this.CoursesdataGridView.TabIndex = 0;
            this.CoursesdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoursesdataGridView_CellContentClick);
            this.CoursesdataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CoursesdataGridView_CellValidating);
            this.CoursesdataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoursesdataGridView_CellValueChanged);
            // 
            // CourseCode
            // 
            this.CourseCode.HeaderText = "CourseCode";
            this.CourseCode.Name = "CourseCode";
            // 
            // TeacherCode
            // 
            this.TeacherCode.HeaderText = "Teacher";
            this.TeacherCode.Name = "TeacherCode";
            // 
            // LectureSize
            // 
            this.LectureSize.HeaderText = "LectureSize";
            this.LectureSize.Name = "LectureSize";
            // 
            // MinWorkingDays
            // 
            this.MinWorkingDays.HeaderText = "MinWorkingDays";
            this.MinWorkingDays.Name = "MinWorkingDays";
            // 
            // StudentSize
            // 
            this.StudentSize.HeaderText = "StudentSize";
            this.StudentSize.Name = "StudentSize";
            // 
            // CoursesLabel
            // 
            this.CoursesLabel.AutoSize = true;
            this.CoursesLabel.Location = new System.Drawing.Point(12, 125);
            this.CoursesLabel.Name = "CoursesLabel";
            this.CoursesLabel.Size = new System.Drawing.Size(48, 13);
            this.CoursesLabel.TabIndex = 1;
            this.CoursesLabel.Text = "Courses:";
            // 
            // CoursesCountLabel
            // 
            this.CoursesCountLabel.AutoSize = true;
            this.CoursesCountLabel.Location = new System.Drawing.Point(66, 125);
            this.CoursesCountLabel.Name = "CoursesCountLabel";
            this.CoursesCountLabel.Size = new System.Drawing.Size(13, 13);
            this.CoursesCountLabel.TabIndex = 1;
            this.CoursesCountLabel.Text = "0";
            // 
            // CttNameLabel
            // 
            this.CttNameLabel.AutoSize = true;
            this.CttNameLabel.Location = new System.Drawing.Point(6, 16);
            this.CttNameLabel.Name = "CttNameLabel";
            this.CttNameLabel.Size = new System.Drawing.Size(38, 13);
            this.CttNameLabel.TabIndex = 2;
            this.CttNameLabel.Text = "Name:";
            // 
            // CttNameValue
            // 
            this.CttNameValue.Location = new System.Drawing.Point(50, 13);
            this.CttNameValue.Name = "CttNameValue";
            this.CttNameValue.Size = new System.Drawing.Size(100, 20);
            this.CttNameValue.TabIndex = 3;
            this.CttNameValue.Text = "test";
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Controls.Add(this.CttDaysValue);
            this.groupBoxGeneral.Controls.Add(this.CttDaysLabel);
            this.groupBoxGeneral.Controls.Add(this.CttNameLabel);
            this.groupBoxGeneral.Controls.Add(this.CttNameValue);
            this.groupBoxGeneral.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(200, 74);
            this.groupBoxGeneral.TabIndex = 4;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General";
            // 
            // CttDaysValue
            // 
            this.CttDaysValue.Location = new System.Drawing.Point(50, 40);
            this.CttDaysValue.Name = "CttDaysValue";
            this.CttDaysValue.Size = new System.Drawing.Size(100, 20);
            this.CttDaysValue.TabIndex = 7;
            this.CttDaysValue.Text = "0";
            // 
            // CttDaysLabel
            // 
            this.CttDaysLabel.AutoSize = true;
            this.CttDaysLabel.Location = new System.Drawing.Point(10, 43);
            this.CttDaysLabel.Name = "CttDaysLabel";
            this.CttDaysLabel.Size = new System.Drawing.Size(34, 13);
            this.CttDaysLabel.TabIndex = 6;
            this.CttDaysLabel.Text = "Days:";
            // 
            // RoomsdataGridView
            // 
            this.RoomsdataGridView.AllowUserToOrderColumns = true;
            this.RoomsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomsdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.RoomsdataGridView.Location = new System.Drawing.Point(12, 345);
            this.RoomsdataGridView.Name = "RoomsdataGridView";
            this.RoomsdataGridView.Size = new System.Drawing.Size(344, 145);
            this.RoomsdataGridView.TabIndex = 5;
            this.RoomsdataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomsdataGridView_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "RoomCode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Capacity";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // RoomsCountLabel
            // 
            this.RoomsCountLabel.AutoSize = true;
            this.RoomsCountLabel.Location = new System.Drawing.Point(66, 329);
            this.RoomsCountLabel.Name = "RoomsCountLabel";
            this.RoomsCountLabel.Size = new System.Drawing.Size(13, 13);
            this.RoomsCountLabel.TabIndex = 6;
            this.RoomsCountLabel.Text = "0";
            // 
            // RoomsLabel
            // 
            this.RoomsLabel.AutoSize = true;
            this.RoomsLabel.Location = new System.Drawing.Point(12, 329);
            this.RoomsLabel.Name = "RoomsLabel";
            this.RoomsLabel.Size = new System.Drawing.Size(43, 13);
            this.RoomsLabel.TabIndex = 7;
            this.RoomsLabel.Text = "Rooms:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 591);
            this.Controls.Add(this.RoomsdataGridView);
            this.Controls.Add(this.RoomsCountLabel);
            this.Controls.Add(this.RoomsLabel);
            this.Controls.Add(this.groupBoxGeneral);
            this.Controls.Add(this.CoursesdataGridView);
            this.Controls.Add(this.CoursesCountLabel);
            this.Controls.Add(this.CoursesLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CoursesdataGridView)).EndInit();
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CoursesdataGridView;
        private System.Windows.Forms.Label CoursesLabel;
        private System.Windows.Forms.Label CoursesCountLabel;
        private System.Windows.Forms.Label CttNameLabel;
        private System.Windows.Forms.TextBox CttNameValue;
        private System.Windows.Forms.GroupBox groupBoxGeneral;
        private System.Windows.Forms.TextBox CttDaysValue;
        private System.Windows.Forms.Label CttDaysLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn LectureSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinWorkingDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentSize;
        private System.Windows.Forms.DataGridView RoomsdataGridView;
        private System.Windows.Forms.Label RoomsCountLabel;
        private System.Windows.Forms.Label RoomsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}

