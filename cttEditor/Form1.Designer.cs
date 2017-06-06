using System;
using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CttPeriodsValue = new System.Windows.Forms.TextBox();
            this.CttDaysValue = new System.Windows.Forms.TextBox();
            this.CttPeriodsLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.languageLabel = new System.Windows.Forms.Label();
            this.CttDaysLabel = new System.Windows.Forms.Label();
            this.CttNameLabel = new System.Windows.Forms.Label();
            this.CttNameValue = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabTeachers = new System.Windows.Forms.TabPage();
            this.TeacherGroupslabel = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.TeacherGroup_TeacherGroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherGroup_TeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTeachers = new System.Windows.Forms.DataGridView();
            this.TeacherListTeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacherlabel = new System.Windows.Forms.Label();
            this.CoursesTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CoursesCountLabel = new System.Windows.Forms.Label();
            this.CoursesLabel = new System.Windows.Forms.Label();
            this.CoursesdataGridView = new System.Windows.Forms.DataGridView();
            this.CourseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LectureSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinWorkingDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minimumDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.needPc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoursPerDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pasteExcelCourse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConstraintsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timeslot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnavailableCoursesLabel = new System.Windows.Forms.Label();
            this.UnavailabilityCountLabel = new System.Windows.Forms.Label();
            this.CurriculumTab = new System.Windows.Forms.TabPage();
            this.Curricula = new System.Windows.Forms.GroupBox();
            this.InactiveCoursesBox = new System.Windows.Forms.ListBox();
            this.RemoveCourseButton = new System.Windows.Forms.Button();
            this.CourseListLabel = new System.Windows.Forms.Label();
            this.AddCourseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CourseListBox = new System.Windows.Forms.ListBox();
            this.CurriculaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurriculumGrid_CourseCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurriculaLabel = new System.Windows.Forms.Label();
            this.CurriculaCountLabel = new System.Windows.Forms.Label();
            this.RoomsTab = new System.Windows.Forms.TabPage();
            this.RoomsLabel = new System.Windows.Forms.Label();
            this.RoomsCountLabel = new System.Windows.Forms.Label();
            this.RoomsdataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBoxGeneral.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).BeginInit();
            this.CoursesTab.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConstraintsDataGridView)).BeginInit();
            this.CurriculumTab.SuspendLayout();
            this.Curricula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurriculaDataGridView)).BeginInit();
            this.RoomsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsdataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 644);
            this.panel1.TabIndex = 15;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.groupBoxGeneral, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.Tabs, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(50);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.88136F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.11864F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1096, 644);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Controls.Add(this.comboBoxLanguage);
            this.groupBoxGeneral.Controls.Add(this.startDateTimePicker);
            this.groupBoxGeneral.Controls.Add(this.CttPeriodsValue);
            this.groupBoxGeneral.Controls.Add(this.CttDaysValue);
            this.groupBoxGeneral.Controls.Add(this.CttPeriodsLabel);
            this.groupBoxGeneral.Controls.Add(this.StartDateLabel);
            this.groupBoxGeneral.Controls.Add(this.languageLabel);
            this.groupBoxGeneral.Controls.Add(this.CttDaysLabel);
            this.groupBoxGeneral.Controls.Add(this.CttNameLabel);
            this.groupBoxGeneral.Controls.Add(this.CttNameValue);
            this.groupBoxGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGeneral.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(1090, 133);
            this.groupBoxGeneral.TabIndex = 14;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "Nederlands",
            "English"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(78, 71);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguage.TabIndex = 13;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(72, 102);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(180, 20);
            this.startDateTimePicker.TabIndex = 13;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // CttPeriodsValue
            // 
            this.CttPeriodsValue.Location = new System.Drawing.Point(221, 39);
            this.CttPeriodsValue.Name = "CttPeriodsValue";
            this.CttPeriodsValue.Size = new System.Drawing.Size(31, 20);
            this.CttPeriodsValue.TabIndex = 7;
            this.CttPeriodsValue.Text = "0";
            this.CttPeriodsValue.TextChanged += new System.EventHandler(this.CttPeriodsValue_TextChanged);
            // 
            // CttDaysValue
            // 
            this.CttDaysValue.Location = new System.Drawing.Point(58, 39);
            this.CttDaysValue.Name = "CttDaysValue";
            this.CttDaysValue.Size = new System.Drawing.Size(68, 20);
            this.CttDaysValue.TabIndex = 7;
            this.CttDaysValue.Text = "0";
            this.CttDaysValue.TextChanged += new System.EventHandler(this.CttDaysValue_TextChanged);
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
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(14, 108);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartDateLabel.Size = new System.Drawing.Size(55, 13);
            this.StartDateLabel.TabIndex = 6;
            this.StartDateLabel.Text = "StartDate:";
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(14, 74);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(58, 13);
            this.languageLabel.TabIndex = 6;
            this.languageLabel.Text = "Language:";
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
            this.CttNameValue.TextChanged += new System.EventHandler(this.CttNameValue_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.exitButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 613);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 28);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(3, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Cancel";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(84, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabTeachers);
            this.Tabs.Controls.Add(this.CoursesTab);
            this.Tabs.Controls.Add(this.CurriculumTab);
            this.Tabs.Controls.Add(this.RoomsTab);
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(3, 142);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1090, 465);
            this.Tabs.TabIndex = 12;
            // 
            // tabTeachers
            // 
            this.tabTeachers.Controls.Add(this.TeacherGroupslabel);
            this.tabTeachers.Controls.Add(this.dataGridView2);
            this.tabTeachers.Controls.Add(this.dataGridViewTeachers);
            this.tabTeachers.Controls.Add(this.Teacherlabel);
            this.tabTeachers.Location = new System.Drawing.Point(4, 22);
            this.tabTeachers.Name = "tabTeachers";
            this.tabTeachers.Size = new System.Drawing.Size(1082, 439);
            this.tabTeachers.TabIndex = 3;
            this.tabTeachers.Text = "Teachers";
            this.tabTeachers.UseVisualStyleBackColor = true;
            // 
            // TeacherGroupslabel
            // 
            this.TeacherGroupslabel.AutoSize = true;
            this.TeacherGroupslabel.Location = new System.Drawing.Point(326, 7);
            this.TeacherGroupslabel.Name = "TeacherGroupslabel";
            this.TeacherGroupslabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TeacherGroupslabel.Size = new System.Drawing.Size(87, 13);
            this.TeacherGroupslabel.TabIndex = 6;
            this.TeacherGroupslabel.Text = "Teacher Groups:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeacherGroup_TeacherGroupCode,
            this.TeacherGroup_TeacherCode});
            this.dataGridView2.Location = new System.Drawing.Point(323, 23);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(327, 368);
            this.dataGridView2.TabIndex = 0;
            // 
            // TeacherGroup_TeacherGroupCode
            // 
            this.TeacherGroup_TeacherGroupCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeacherGroup_TeacherGroupCode.HeaderText = "GroupCode";
            this.TeacherGroup_TeacherGroupCode.Name = "TeacherGroup_TeacherGroupCode";
            // 
            // TeacherGroup_TeacherCode
            // 
            this.TeacherGroup_TeacherCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeacherGroup_TeacherCode.HeaderText = "TeacherCode";
            this.TeacherGroup_TeacherCode.Name = "TeacherGroup_TeacherCode";
            // 
            // dataGridViewTeachers
            // 
            this.dataGridViewTeachers.AllowUserToAddRows = false;
            this.dataGridViewTeachers.AllowUserToDeleteRows = false;
            this.dataGridViewTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeachers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeacherListTeacherCode});
            this.dataGridViewTeachers.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewTeachers.Name = "dataGridViewTeachers";
            this.dataGridViewTeachers.ReadOnly = true;
            this.dataGridViewTeachers.Size = new System.Drawing.Size(266, 363);
            this.dataGridViewTeachers.TabIndex = 0;
            // 
            // TeacherListTeacherCode
            // 
            this.TeacherListTeacherCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeacherListTeacherCode.HeaderText = "TeacherCode";
            this.TeacherListTeacherCode.Name = "TeacherListTeacherCode";
            this.TeacherListTeacherCode.ReadOnly = true;
            // 
            // Teacherlabel
            // 
            this.Teacherlabel.AutoSize = true;
            this.Teacherlabel.Location = new System.Drawing.Point(3, 7);
            this.Teacherlabel.Name = "Teacherlabel";
            this.Teacherlabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Teacherlabel.Size = new System.Drawing.Size(109, 13);
            this.Teacherlabel.TabIndex = 6;
            this.Teacherlabel.Text = "Teachers (View only):";
            // 
            // CoursesTab
            // 
            this.CoursesTab.Controls.Add(this.tableLayoutPanel3);
            this.CoursesTab.Location = new System.Drawing.Point(4, 22);
            this.CoursesTab.Name = "CoursesTab";
            this.CoursesTab.Padding = new System.Windows.Forms.Padding(3);
            this.CoursesTab.Size = new System.Drawing.Size(1082, 439);
            this.CoursesTab.TabIndex = 0;
            this.CoursesTab.Text = "Courses";
            this.CoursesTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.42494F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.57506F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1076, 433);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CoursesdataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pasteExcelCourse, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.93443F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1070, 220);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.CoursesCountLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.CoursesLabel, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(73, 13);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // CoursesCountLabel
            // 
            this.CoursesCountLabel.AutoSize = true;
            this.CoursesCountLabel.Location = new System.Drawing.Point(57, 0);
            this.CoursesCountLabel.Name = "CoursesCountLabel";
            this.CoursesCountLabel.Size = new System.Drawing.Size(13, 13);
            this.CoursesCountLabel.TabIndex = 1;
            this.CoursesCountLabel.Text = "0";
            // 
            // CoursesLabel
            // 
            this.CoursesLabel.AutoSize = true;
            this.CoursesLabel.Location = new System.Drawing.Point(3, 0);
            this.CoursesLabel.Name = "CoursesLabel";
            this.CoursesLabel.Size = new System.Drawing.Size(48, 13);
            this.CoursesLabel.TabIndex = 1;
            this.CoursesLabel.Text = "Courses:";
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
            this.StudentSize,
            this.minimumDate,
            this.deadline,
            this.maxDays,
            this.needPc,
            this.HoursPerDay});
            this.CoursesdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoursesdataGridView.Location = new System.Drawing.Point(3, 22);
            this.CoursesdataGridView.Name = "CoursesdataGridView";
            this.CoursesdataGridView.Size = new System.Drawing.Size(1064, 169);
            this.CoursesdataGridView.TabIndex = 0;
            this.CoursesdataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CoursesdataGridView_CellValidating);
            this.CoursesdataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CoursesdataGridView_CellValueChanged);
            // 
            // CourseCode
            // 
            this.CourseCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CourseCode.HeaderText = "CourseCode";
            this.CourseCode.Name = "CourseCode";
            // 
            // TeacherCode
            // 
            this.TeacherCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TeacherCode.HeaderText = "Teacher";
            this.TeacherCode.Name = "TeacherCode";
            this.TeacherCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LectureSize
            // 
            this.LectureSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LectureSize.HeaderText = "LectureSize";
            this.LectureSize.Name = "LectureSize";
            this.LectureSize.Width = 88;
            // 
            // MinWorkingDays
            // 
            this.MinWorkingDays.HeaderText = "MinWorkingDays";
            this.MinWorkingDays.Name = "MinWorkingDays";
            // 
            // StudentSize
            // 
            this.StudentSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.StudentSize.HeaderText = "StudentSize";
            this.StudentSize.Name = "StudentSize";
            this.StudentSize.Width = 89;
            // 
            // minimumDate
            // 
            this.minimumDate.HeaderText = "Minium Date";
            this.minimumDate.Name = "minimumDate";
            // 
            // deadline
            // 
            this.deadline.HeaderText = "Deadline";
            this.deadline.Name = "deadline";
            // 
            // maxDays
            // 
            this.maxDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.maxDays.HeaderText = "Max Days";
            this.maxDays.Name = "maxDays";
            this.maxDays.Width = 79;
            // 
            // needPc
            // 
            this.needPc.HeaderText = "Need PC";
            this.needPc.Name = "needPc";
            // 
            // HoursPerDay
            // 
            this.HoursPerDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.HoursPerDay.HeaderText = "Hours Per Day";
            this.HoursPerDay.Name = "HoursPerDay";
            this.HoursPerDay.Width = 101;
            // 
            // pasteExcelCourse
            // 
            this.pasteExcelCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pasteExcelCourse.AutoSize = true;
            this.pasteExcelCourse.Location = new System.Drawing.Point(927, 197);
            this.pasteExcelCourse.Name = "pasteExcelCourse";
            this.pasteExcelCourse.Size = new System.Drawing.Size(140, 20);
            this.pasteExcelCourse.TabIndex = 15;
            this.pasteExcelCourse.Text = "paste clipboard from excel";
            this.pasteExcelCourse.UseVisualStyleBackColor = true;
            this.pasteExcelCourse.Click += new System.EventHandler(this.pasteExcelCourse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConstraintsDataGridView);
            this.groupBox1.Controls.Add(this.UnavailableCoursesLabel);
            this.groupBox1.Controls.Add(this.UnavailabilityCountLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1070, 201);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // ConstraintsDataGridView
            // 
            this.ConstraintsDataGridView.AllowUserToOrderColumns = true;
            this.ConstraintsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConstraintsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Timeslot});
            this.ConstraintsDataGridView.Location = new System.Drawing.Point(6, 29);
            this.ConstraintsDataGridView.Name = "ConstraintsDataGridView";
            this.ConstraintsDataGridView.Size = new System.Drawing.Size(353, 145);
            this.ConstraintsDataGridView.TabIndex = 5;
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
            // UnavailableCoursesLabel
            // 
            this.UnavailableCoursesLabel.AutoSize = true;
            this.UnavailableCoursesLabel.Location = new System.Drawing.Point(6, 13);
            this.UnavailableCoursesLabel.Name = "UnavailableCoursesLabel";
            this.UnavailableCoursesLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UnavailableCoursesLabel.Size = new System.Drawing.Size(107, 13);
            this.UnavailableCoursesLabel.TabIndex = 7;
            this.UnavailableCoursesLabel.Text = "Unavailable  Courses";
            // 
            // UnavailabilityCountLabel
            // 
            this.UnavailabilityCountLabel.AutoSize = true;
            this.UnavailabilityCountLabel.Location = new System.Drawing.Point(139, 13);
            this.UnavailabilityCountLabel.Name = "UnavailabilityCountLabel";
            this.UnavailabilityCountLabel.Size = new System.Drawing.Size(13, 13);
            this.UnavailabilityCountLabel.TabIndex = 6;
            this.UnavailabilityCountLabel.Text = "0";
            // 
            // CurriculumTab
            // 
            this.CurriculumTab.Controls.Add(this.Curricula);
            this.CurriculumTab.Location = new System.Drawing.Point(4, 22);
            this.CurriculumTab.Name = "CurriculumTab";
            this.CurriculumTab.Padding = new System.Windows.Forms.Padding(3);
            this.CurriculumTab.Size = new System.Drawing.Size(1082, 439);
            this.CurriculumTab.TabIndex = 1;
            this.CurriculumTab.Text = "Curricula";
            this.CurriculumTab.UseVisualStyleBackColor = true;
            // 
            // Curricula
            // 
            this.Curricula.Controls.Add(this.InactiveCoursesBox);
            this.Curricula.Controls.Add(this.RemoveCourseButton);
            this.Curricula.Controls.Add(this.CourseListLabel);
            this.Curricula.Controls.Add(this.AddCourseButton);
            this.Curricula.Controls.Add(this.label1);
            this.Curricula.Controls.Add(this.CourseListBox);
            this.Curricula.Controls.Add(this.CurriculaDataGridView);
            this.Curricula.Controls.Add(this.CurriculaLabel);
            this.Curricula.Controls.Add(this.CurriculaCountLabel);
            this.Curricula.Location = new System.Drawing.Point(22, 16);
            this.Curricula.Name = "Curricula";
            this.Curricula.Size = new System.Drawing.Size(598, 177);
            this.Curricula.TabIndex = 11;
            this.Curricula.TabStop = false;
            this.Curricula.Text = "Curricula:";
            // 
            // InactiveCoursesBox
            // 
            this.InactiveCoursesBox.FormattingEnabled = true;
            this.InactiveCoursesBox.Location = new System.Drawing.Point(475, 31);
            this.InactiveCoursesBox.Name = "InactiveCoursesBox";
            this.InactiveCoursesBox.Size = new System.Drawing.Size(120, 134);
            this.InactiveCoursesBox.TabIndex = 11;
            // 
            // RemoveCourseButton
            // 
            this.RemoveCourseButton.Location = new System.Drawing.Point(379, 102);
            this.RemoveCourseButton.Name = "RemoveCourseButton";
            this.RemoveCourseButton.Size = new System.Drawing.Size(90, 23);
            this.RemoveCourseButton.TabIndex = 10;
            this.RemoveCourseButton.Text = "Remove";
            this.RemoveCourseButton.UseVisualStyleBackColor = true;
            this.RemoveCourseButton.Click += new System.EventHandler(this.RemoveCourseButton_Click);
            // 
            // CourseListLabel
            // 
            this.CourseListLabel.AutoSize = true;
            this.CourseListLabel.Location = new System.Drawing.Point(250, 15);
            this.CourseListLabel.Name = "CourseListLabel";
            this.CourseListLabel.Size = new System.Drawing.Size(59, 13);
            this.CourseListLabel.TabIndex = 1;
            this.CourseListLabel.Text = "CourseList:";
            // 
            // AddCourseButton
            // 
            this.AddCourseButton.Location = new System.Drawing.Point(379, 73);
            this.AddCourseButton.Name = "AddCourseButton";
            this.AddCourseButton.Size = new System.Drawing.Size(90, 23);
            this.AddCourseButton.TabIndex = 10;
            this.AddCourseButton.Text = "Add";
            this.AddCourseButton.UseVisualStyleBackColor = true;
            this.AddCourseButton.Click += new System.EventHandler(this.AddCourseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inactive courses:";
            // 
            // CourseListBox
            // 
            this.CourseListBox.FormattingEnabled = true;
            this.CourseListBox.Location = new System.Drawing.Point(253, 33);
            this.CourseListBox.Name = "CourseListBox";
            this.CourseListBox.Size = new System.Drawing.Size(120, 134);
            this.CourseListBox.TabIndex = 9;
            // 
            // CurriculaDataGridView
            // 
            this.CurriculaDataGridView.AllowUserToOrderColumns = true;
            this.CurriculaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurriculaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.CurriculumGrid_CourseCount});
            this.CurriculaDataGridView.Location = new System.Drawing.Point(6, 33);
            this.CurriculaDataGridView.Name = "CurriculaDataGridView";
            this.CurriculaDataGridView.Size = new System.Drawing.Size(244, 134);
            this.CurriculaDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "CurriculumCode";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // CurriculumGrid_CourseCount
            // 
            this.CurriculumGrid_CourseCount.HeaderText = "Course Count";
            this.CurriculumGrid_CourseCount.Name = "CurriculumGrid_CourseCount";
            this.CurriculumGrid_CourseCount.ReadOnly = true;
            // 
            // CurriculaLabel
            // 
            this.CurriculaLabel.AutoSize = true;
            this.CurriculaLabel.Location = new System.Drawing.Point(6, 17);
            this.CurriculaLabel.Name = "CurriculaLabel";
            this.CurriculaLabel.Size = new System.Drawing.Size(51, 13);
            this.CurriculaLabel.TabIndex = 1;
            this.CurriculaLabel.Text = "Curricula:";
            // 
            // CurriculaCountLabel
            // 
            this.CurriculaCountLabel.AutoSize = true;
            this.CurriculaCountLabel.Location = new System.Drawing.Point(63, 17);
            this.CurriculaCountLabel.Name = "CurriculaCountLabel";
            this.CurriculaCountLabel.Size = new System.Drawing.Size(13, 13);
            this.CurriculaCountLabel.TabIndex = 1;
            this.CurriculaCountLabel.Text = "0";
            // 
            // RoomsTab
            // 
            this.RoomsTab.Controls.Add(this.RoomsLabel);
            this.RoomsTab.Controls.Add(this.RoomsCountLabel);
            this.RoomsTab.Controls.Add(this.RoomsdataGridView);
            this.RoomsTab.Location = new System.Drawing.Point(4, 22);
            this.RoomsTab.Name = "RoomsTab";
            this.RoomsTab.Size = new System.Drawing.Size(1082, 439);
            this.RoomsTab.TabIndex = 2;
            this.RoomsTab.Text = "Rooms";
            this.RoomsTab.UseVisualStyleBackColor = true;
            // 
            // RoomsLabel
            // 
            this.RoomsLabel.AutoSize = true;
            this.RoomsLabel.Location = new System.Drawing.Point(5, 9);
            this.RoomsLabel.Name = "RoomsLabel";
            this.RoomsLabel.Size = new System.Drawing.Size(43, 13);
            this.RoomsLabel.TabIndex = 7;
            this.RoomsLabel.Text = "Rooms:";
            // 
            // RoomsCountLabel
            // 
            this.RoomsCountLabel.AutoSize = true;
            this.RoomsCountLabel.Location = new System.Drawing.Point(59, 9);
            this.RoomsCountLabel.Name = "RoomsCountLabel";
            this.RoomsCountLabel.Size = new System.Drawing.Size(13, 13);
            this.RoomsCountLabel.TabIndex = 6;
            this.RoomsCountLabel.Text = "0";
            // 
            // RoomsdataGridView
            // 
            this.RoomsdataGridView.AllowUserToOrderColumns = true;
            this.RoomsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomsdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.RoomsdataGridView.Location = new System.Drawing.Point(5, 25);
            this.RoomsdataGridView.Name = "RoomsdataGridView";
            this.RoomsdataGridView.Size = new System.Drawing.Size(264, 145);
            this.RoomsdataGridView.TabIndex = 5;
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1082, 439);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(154, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1136, 715);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "CTT Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.tabTeachers.ResumeLayout(false);
            this.tabTeachers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeachers)).EndInit();
            this.CoursesTab.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoursesdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConstraintsDataGridView)).EndInit();
            this.CurriculumTab.ResumeLayout(false);
            this.Curricula.ResumeLayout(false);
            this.Curricula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurriculaDataGridView)).EndInit();
            this.RoomsTab.ResumeLayout(false);
            this.RoomsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomsdataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBoxGeneral;
        private ComboBox comboBoxLanguage;
        private DateTimePicker startDateTimePicker;
        private TextBox CttPeriodsValue;
        private TextBox CttDaysValue;
        private Label CttPeriodsLabel;
        private Label StartDateLabel;
        private Label languageLabel;
        private Label CttDaysLabel;
        private Label CttNameLabel;
        private TextBox CttNameValue;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button exitButton;
        private Button saveButton;
        private TabControl Tabs;
        private TabPage tabTeachers;
        private Label TeacherGroupslabel;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn TeacherGroup_TeacherGroupCode;
        private DataGridViewTextBoxColumn TeacherGroup_TeacherCode;
        private DataGridView dataGridViewTeachers;
        private DataGridViewTextBoxColumn TeacherListTeacherCode;
        private Label Teacherlabel;
        private TabPage CoursesTab;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label CoursesCountLabel;
        private Label CoursesLabel;
        private DataGridView CoursesdataGridView;
        private GroupBox groupBox1;
        private DataGridView ConstraintsDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn Timeslot;
        private Label UnavailableCoursesLabel;
        private Label UnavailabilityCountLabel;
        private TabPage CurriculumTab;
        private GroupBox Curricula;
        private ListBox InactiveCoursesBox;
        private Button RemoveCourseButton;
        private Label CourseListLabel;
        private Button AddCourseButton;
        private Label label1;
        private ListBox CourseListBox;
        private DataGridView CurriculaDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn CurriculumGrid_CourseCount;
        private Label CurriculaLabel;
        private Label CurriculaCountLabel;
        private TabPage RoomsTab;
        private Label RoomsLabel;
        private Label RoomsCountLabel;
        private DataGridView RoomsdataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn CourseCode;
        private DataGridViewTextBoxColumn TeacherCode;
        private DataGridViewTextBoxColumn LectureSize;
        private DataGridViewTextBoxColumn MinWorkingDays;
        private DataGridViewTextBoxColumn StudentSize;
        private DataGridViewTextBoxColumn minimumDate;
        private DataGridViewTextBoxColumn deadline;
        private DataGridViewTextBoxColumn maxDays;
        private DataGridViewTextBoxColumn needPc;
        private DataGridViewTextBoxColumn HoursPerDay;
        private Button pasteExcelCourse;
    }
}

