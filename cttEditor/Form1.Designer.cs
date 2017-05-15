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
            this.CttPeriodsValue = new System.Windows.Forms.TextBox();
            this.CttDaysValue = new System.Windows.Forms.TextBox();
            this.CttPeriodsLabel = new System.Windows.Forms.Label();
            this.CttDaysLabel = new System.Windows.Forms.Label();
            this.RoomsdataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomsCountLabel = new System.Windows.Forms.Label();
            this.RoomsLabel = new System.Windows.Forms.Label();
            this.CurriculaLabel = new System.Windows.Forms.Label();
            this.CurriculaCountLabel = new System.Windows.Forms.Label();
            this.CurriculadataGridView = new System.Windows.Forms.DataGridView();
            this.UnavailabilityLabel = new System.Windows.Forms.Label();
            this.UnavailabilityCountLabel = new System.Windows.Forms.Label();
            this.ConstraintsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timeslot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseListBox = new System.Windows.Forms.ListBox();
            this.CourseListLabel = new System.Windows.Forms.Label();
            this.AddCourseButton = new System.Windows.Forms.Button();
            this.RemoveCourseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesdataGridView)).BeginInit();
            this.groupBoxGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurriculadataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConstraintsDataGridView)).BeginInit();
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
            this.CoursesdataGridView.Location = new System.Drawing.Point(12, 103);
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
            this.CoursesLabel.Location = new System.Drawing.Point(12, 87);
            this.CoursesLabel.Name = "CoursesLabel";
            this.CoursesLabel.Size = new System.Drawing.Size(48, 13);
            this.CoursesLabel.TabIndex = 1;
            this.CoursesLabel.Text = "Courses:";
            // 
            // CoursesCountLabel
            // 
            this.CoursesCountLabel.AutoSize = true;
            this.CoursesCountLabel.Location = new System.Drawing.Point(66, 87);
            this.CoursesCountLabel.Name = "CoursesCountLabel";
            this.CoursesCountLabel.Size = new System.Drawing.Size(13, 13);
            this.CoursesCountLabel.TabIndex = 1;
            this.CoursesCountLabel.Text = "0";
            // 
            // CttNameLabel
            // 
            this.CttNameLabel.AutoSize = true;
            this.CttNameLabel.Location = new System.Drawing.Point(14, 16);
            this.CttNameLabel.Name = "CttNameLabel";
            this.CttNameLabel.Size = new System.Drawing.Size(38, 13);
            this.CttNameLabel.TabIndex = 2;
            this.CttNameLabel.Text = "Name:";
            // 
            // CttNameValue
            // 
            this.CttNameValue.Location = new System.Drawing.Point(58, 13);
            this.CttNameValue.Name = "CttNameValue";
            this.CttNameValue.Size = new System.Drawing.Size(95, 20);
            this.CttNameValue.TabIndex = 3;
            this.CttNameValue.Text = "test";
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Controls.Add(this.CttPeriodsValue);
            this.groupBoxGeneral.Controls.Add(this.CttDaysValue);
            this.groupBoxGeneral.Controls.Add(this.CttPeriodsLabel);
            this.groupBoxGeneral.Controls.Add(this.CttDaysLabel);
            this.groupBoxGeneral.Controls.Add(this.CttNameLabel);
            this.groupBoxGeneral.Controls.Add(this.CttNameValue);
            this.groupBoxGeneral.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(273, 72);
            this.groupBoxGeneral.TabIndex = 4;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General";
            // 
            // CttPeriodsValue
            // 
            this.CttPeriodsValue.Location = new System.Drawing.Point(221, 39);
            this.CttPeriodsValue.Name = "CttPeriodsValue";
            this.CttPeriodsValue.Size = new System.Drawing.Size(31, 20);
            this.CttPeriodsValue.TabIndex = 7;
            this.CttPeriodsValue.Text = "0";
            // 
            // CttDaysValue
            // 
            this.CttDaysValue.Location = new System.Drawing.Point(58, 39);
            this.CttDaysValue.Name = "CttDaysValue";
            this.CttDaysValue.Size = new System.Drawing.Size(68, 20);
            this.CttDaysValue.TabIndex = 7;
            this.CttDaysValue.Text = "0";
            // 
            // CttPeriodsLabel
            // 
            this.CttPeriodsLabel.AutoSize = true;
            this.CttPeriodsLabel.Location = new System.Drawing.Point(132, 42);
            this.CttPeriodsLabel.Name = "CttPeriodsLabel";
            this.CttPeriodsLabel.Size = new System.Drawing.Size(83, 13);
            this.CttPeriodsLabel.TabIndex = 6;
            this.CttPeriodsLabel.Text = "Periods per day:";
            // 
            // CttDaysLabel
            // 
            this.CttDaysLabel.AutoSize = true;
            this.CttDaysLabel.Location = new System.Drawing.Point(14, 43);
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
            this.RoomsdataGridView.Location = new System.Drawing.Point(12, 434);
            this.RoomsdataGridView.Name = "RoomsdataGridView";
            this.RoomsdataGridView.Size = new System.Drawing.Size(215, 145);
            this.RoomsdataGridView.TabIndex = 5;
            this.RoomsdataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomsdataGridView_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 5F;
            this.dataGridViewTextBoxColumn1.HeaderText = "RoomCode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Capacity";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // RoomsCountLabel
            // 
            this.RoomsCountLabel.AutoSize = true;
            this.RoomsCountLabel.Location = new System.Drawing.Point(66, 418);
            this.RoomsCountLabel.Name = "RoomsCountLabel";
            this.RoomsCountLabel.Size = new System.Drawing.Size(13, 13);
            this.RoomsCountLabel.TabIndex = 6;
            this.RoomsCountLabel.Text = "0";
            // 
            // RoomsLabel
            // 
            this.RoomsLabel.AutoSize = true;
            this.RoomsLabel.Location = new System.Drawing.Point(12, 418);
            this.RoomsLabel.Name = "RoomsLabel";
            this.RoomsLabel.Size = new System.Drawing.Size(43, 13);
            this.RoomsLabel.TabIndex = 7;
            this.RoomsLabel.Text = "Rooms:";
            // 
            // CurriculaLabel
            // 
            this.CurriculaLabel.AutoSize = true;
            this.CurriculaLabel.Location = new System.Drawing.Point(12, 256);
            this.CurriculaLabel.Name = "CurriculaLabel";
            this.CurriculaLabel.Size = new System.Drawing.Size(51, 13);
            this.CurriculaLabel.TabIndex = 1;
            this.CurriculaLabel.Text = "Curricula:";
            // 
            // CurriculaCountLabel
            // 
            this.CurriculaCountLabel.AutoSize = true;
            this.CurriculaCountLabel.Location = new System.Drawing.Point(66, 256);
            this.CurriculaCountLabel.Name = "CurriculaCountLabel";
            this.CurriculaCountLabel.Size = new System.Drawing.Size(13, 13);
            this.CurriculaCountLabel.TabIndex = 1;
            this.CurriculaCountLabel.Text = "0";
            // 
            // CurriculadataGridView
            // 
            this.CurriculadataGridView.AllowUserToOrderColumns = true;
            this.CurriculadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurriculadataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn7});
            this.CurriculadataGridView.Location = new System.Drawing.Point(12, 272);
            this.CurriculadataGridView.Name = "CurriculadataGridView";
            this.CurriculadataGridView.Size = new System.Drawing.Size(244, 132);
            this.CurriculadataGridView.TabIndex = 0;
            this.CurriculadataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoursesdataGridView_CellContentClick);
            this.CurriculadataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CoursesdataGridView_CellValidating);
            this.CurriculadataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoursesdataGridView_CellValueChanged);
            // 
            // UnavailabilityLabel
            // 
            this.UnavailabilityLabel.AutoSize = true;
            this.UnavailabilityLabel.Location = new System.Drawing.Point(262, 418);
            this.UnavailabilityLabel.Name = "UnavailabilityLabel";
            this.UnavailabilityLabel.Size = new System.Drawing.Size(127, 13);
            this.UnavailabilityLabel.TabIndex = 7;
            this.UnavailabilityLabel.Text = "Unavailability Constraints:";
            // 
            // UnavailabilityCountLabel
            // 
            this.UnavailabilityCountLabel.AutoSize = true;
            this.UnavailabilityCountLabel.Location = new System.Drawing.Point(395, 418);
            this.UnavailabilityCountLabel.Name = "UnavailabilityCountLabel";
            this.UnavailabilityCountLabel.Size = new System.Drawing.Size(13, 13);
            this.UnavailabilityCountLabel.TabIndex = 6;
            this.UnavailabilityCountLabel.Text = "0";
            // 
            // ConstraintsDataGridView
            // 
            this.ConstraintsDataGridView.AllowUserToOrderColumns = true;
            this.ConstraintsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConstraintsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Timeslot});
            this.ConstraintsDataGridView.Location = new System.Drawing.Point(262, 434);
            this.ConstraintsDataGridView.Name = "ConstraintsDataGridView";
            this.ConstraintsDataGridView.Size = new System.Drawing.Size(293, 145);
            this.ConstraintsDataGridView.TabIndex = 5;
            this.ConstraintsDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomsdataGridView_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 5F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Coursecode";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Day";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // Timeslot
            // 
            this.Timeslot.HeaderText = "Timeslot";
            this.Timeslot.Name = "Timeslot";
            this.Timeslot.Width = 60;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(480, 594);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "CurriculumCode";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Course Count";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // CourseListBox
            // 
            this.CourseListBox.FormattingEnabled = true;
            this.CourseListBox.Items.AddRange(new object[] {
            "jksdqg",
            "kjsdg",
            "lkjsdmg",
            ""});
            this.CourseListBox.Location = new System.Drawing.Point(269, 272);
            this.CourseListBox.Name = "CourseListBox";
            this.CourseListBox.Size = new System.Drawing.Size(120, 134);
            this.CourseListBox.TabIndex = 9;
            // 
            // CourseListLabel
            // 
            this.CourseListLabel.AutoSize = true;
            this.CourseListLabel.Location = new System.Drawing.Point(266, 254);
            this.CourseListLabel.Name = "CourseListLabel";
            this.CourseListLabel.Size = new System.Drawing.Size(59, 13);
            this.CourseListLabel.TabIndex = 1;
            this.CourseListLabel.Text = "CourseList:";
            // 
            // AddCourseButton
            // 
            this.AddCourseButton.Location = new System.Drawing.Point(395, 354);
            this.AddCourseButton.Name = "AddCourseButton";
            this.AddCourseButton.Size = new System.Drawing.Size(90, 23);
            this.AddCourseButton.TabIndex = 10;
            this.AddCourseButton.Text = "Add course";
            this.AddCourseButton.UseVisualStyleBackColor = true;
            // 
            // RemoveCourseButton
            // 
            this.RemoveCourseButton.Location = new System.Drawing.Point(395, 383);
            this.RemoveCourseButton.Name = "RemoveCourseButton";
            this.RemoveCourseButton.Size = new System.Drawing.Size(90, 23);
            this.RemoveCourseButton.TabIndex = 10;
            this.RemoveCourseButton.Text = "Remove course";
            this.RemoveCourseButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 629);
            this.Controls.Add(this.RemoveCourseButton);
            this.Controls.Add(this.AddCourseButton);
            this.Controls.Add(this.CourseListBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ConstraintsDataGridView);
            this.Controls.Add(this.RoomsdataGridView);
            this.Controls.Add(this.UnavailabilityCountLabel);
            this.Controls.Add(this.RoomsCountLabel);
            this.Controls.Add(this.UnavailabilityLabel);
            this.Controls.Add(this.RoomsLabel);
            this.Controls.Add(this.groupBoxGeneral);
            this.Controls.Add(this.CurriculadataGridView);
            this.Controls.Add(this.CurriculaCountLabel);
            this.Controls.Add(this.CoursesdataGridView);
            this.Controls.Add(this.CourseListLabel);
            this.Controls.Add(this.CurriculaLabel);
            this.Controls.Add(this.CoursesCountLabel);
            this.Controls.Add(this.CoursesLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CoursesdataGridView)).EndInit();
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurriculadataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConstraintsDataGridView)).EndInit();
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
        private System.Windows.Forms.TextBox CttPeriodsValue;
        private System.Windows.Forms.Label CttPeriodsLabel;
        private System.Windows.Forms.Label CurriculaLabel;
        private System.Windows.Forms.Label CurriculaCountLabel;
        private System.Windows.Forms.DataGridView CurriculadataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label UnavailabilityLabel;
        private System.Windows.Forms.Label UnavailabilityCountLabel;
        private System.Windows.Forms.DataGridView ConstraintsDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timeslot;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ListBox CourseListBox;
        private System.Windows.Forms.Label CourseListLabel;
        private System.Windows.Forms.Button AddCourseButton;
        private System.Windows.Forms.Button RemoveCourseButton;
    }
}

