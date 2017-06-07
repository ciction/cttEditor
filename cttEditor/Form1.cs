﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using cttEditor.PlanningEntities;

namespace cttEditor
{
    public partial class Form1 : Form
    {
        //members
        private readonly HeaderData _headerData = new HeaderData();
        private string _courseNameBeforeUpdate = "";
        private string _roomNameBeforeUpdate = "";
        private string _curriculumNameBeforeUpdate = "";
        private Unavailability_Course _oldUnavailabilityCourse = null;

        //delegate members
        private delegate void AddPlanningEntityDelegate(string line);

        public Form1()
        {
            InitializeComponent();
            
            //Console.WriteLine(Directory.GetCurrentDirectory());
            //ReadCtt(@"C:\Users\Christophe\Documents\programming\bachelorproef\ctt_editor\cttEditor\cttEditor\digx_opgesplitst.ctt");
            ReadCtt(@"digx_opgesplitst.ctt");

            //init fields
            CoursesCountLabel.Text = (CoursesdataGridView.RowCount - 1).ToString();

            //this.CoursesdataGridView.Rows.Add("five", "six", "seven", "eight");
            //temp comment
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //*************************************************
        // PARSING
        //*************************************************

        /// <summary>
        /// Parse input file
        /// </summary>
        /// <param name="file"></param>
        private void ReadCtt(string file)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (var sr = new StreamReader(file))
                {
                    string line;
                    var linenumber = 1;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        //words on the current line
                        var words = line.Split(' ');
                        switch (words[0])
                        {
                            case "Name:":
                                _headerData.PlanningName = words[1];
                                CttNameValue.Text = _headerData.PlanningName;
                                break;
                            case "Language:":
                                _headerData.SetLanguage(words[1]);
                                if (_headerData.Language == Language.Dutch)
                                {
                                    comboBoxLanguage.SelectedIndex = 0;
                                }
                                if (_headerData.Language == Language.English)
                                {
                                    comboBoxLanguage.SelectedIndex = 1;
                                }

                                break;
                            case "StartDate:":
                                _headerData.SetStartDate(words[1]);
                                startDateTimePicker.Value = _headerData.StartDate;
                                break;
                            case "Courses:":
                                _headerData.CourseCount = int.Parse(words[1]);
                                CoursesCountLabel.Text = _headerData.CourseCount.ToString();
                                break;
                            case "TeacherGroupCount:":
                                _headerData.TeacherGroupCount = int.Parse(words[1]);
                                break;
                            case "Rooms:":
                                _headerData.RoomCount = int.Parse(words[1]);
                                RoomsCountLabel.Text = _headerData.RoomCount.ToString();
                                break;
                            case "Days:":
                                _headerData.DaysCount = int.Parse(words[1]);
                                CttDaysValue.Text = _headerData.DaysCount.ToString();
                                break;
                            case "Periods_per_day:":
                                _headerData.PeriodsPerDay = int.Parse(words[1]);
                                CttPeriodsValue.Text = _headerData.PeriodsPerDay.ToString();
                                break;
                            case "Curricula:":
                                _headerData.CurriculaCount = int.Parse(words[1]);
                                CurriculaCountLabel.Text = _headerData.CurriculaCount.ToString();
                                break;
                            case "unavailable_courses:":
                                _headerData.UnavailableCoursesCount = int.Parse(words[1]);
                                UnavailabilityCountLabel.Text = _headerData.UnavailableCoursesCount.ToString();
                                break;
                            case "unavailable_curricula:":
                                _headerData.UnavailableCurriculaCount = int.Parse(words[1]);
                                break;
                            case "unavailable_hours_all:":
                                _headerData.UnavailableHoursAllCount = int.Parse(words[1]);
                                break;
                            case "unavailable_days_all:":
                                _headerData.UnavailableDaysAllCount = int.Parse(words[1]);
                                break;
                            case "DependentCourses:":
                                _headerData.DependentCoursesCount = int.Parse(words[1]);
                                break;


                            //blocks
                            case "COURSES:":
                                //add rooms to database
                                ParseDataBlock(linenumber + 1, _headerData.CourseCount, file, AddCourse);
                                //set UI
                                //update teacher tab first from imported courses
                                foreach (var teacher in TeacherDatabase.TeacherCodes)
                                {
                                    dataGridViewTeachers.Rows.Add(teacher);
                                }
                                foreach (var course in EntityDataBase.Courses)
                                {
                                    course.AddToDataGrid(CoursesdataGridView);
                                }

                                break;
                            case "TEACHER_GROUPS:":
                                break;
                            case "ROOMS:":
                                //add rooms to database
                                ParseDataBlock(linenumber + 1, _headerData.RoomCount, file, AddRoom);
                                //set UI
                                foreach (var room in EntityDataBase.Rooms)
                                    room.AddToDataGrid(RoomsdataGridView);
                                break;
                            case "CURRICULA:":
                                //add curricula to database
                                ParseDataBlock(linenumber + 1, _headerData.CurriculaCount, file, AddCurriculum);
                                //set UI
                                foreach (var curriculum in EntityDataBase.Curricula)
                                    curriculum.AddToDataGrid(CurriculaDataGridView);
                                CourseListBox.Items.Clear();
                                CourseListBox.Items.Add(EntityDataBase.Curricula[0].CourseCount);
                                UpdateCurriculumCoursesUi();
                                break;
                            case "UNAVAILABILITY_COURSE:":
                                ParseDataBlock(linenumber + 1, _headerData.CurriculaCount, file, AddunavailabilityCourse);
                                foreach (var unavailabilityCourse in EntityDataBase.Unavailability_CourseConstraints)
                                        unavailabilityCourse.AddToDataGrid(ConstraintsDataGridView);
                                break;
                            case "UNAVAILABILITY_CURRICULUM:":
                                break;
                            case "UNAVAILABLE_HOURS_ALL:":
                                break;
                            case "UNAVAILABLE_DAYS_ALL:":
                                break;
                            case "DEPENDENCIES:":
                                break;
                            default:
                                break;
                        }
                        //Console.WriteLine(line);
                        ++linenumber;
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        //Parse DataBlock
        private void ParseDataBlock(int firstLine, int count, string file, AddPlanningEntityDelegate addPlanningEntity)
        {
            var lines = File.ReadLines(file).Skip(firstLine).Take(count).ToList();
            foreach (var line in lines)
                addPlanningEntity(line);
        }

        //Parse DataBlock - addPlanningEntity Course
        private void AddCourse(string line)
        {
            var newCourse = new Course();
            newCourse.ParseCtt(line);
            EntityDataBase.Courses.Add(newCourse);
        }

        //Parse DataBlock - addPlanningEntity Room
        private void AddRoom(string line)
        {
            var newRoom = new Room();
            newRoom.ParseCtt(line);
            EntityDataBase.Rooms.Add(newRoom);
        }

        //Parse DataBlock - addPlanningEntity Curriculum
        private void AddCurriculum(string line)
        {
            var newCurriculum = new Curriculum();
            newCurriculum.ParseCtt(line);
            EntityDataBase.Curricula.Add(newCurriculum);
        }

        //Parse DataBlock - UNAVAILABILITY_COURSE
        private void AddunavailabilityCourse(string line)
        {
            var newUnavailabilityCourse = new Unavailability_Course();
            newUnavailabilityCourse.ParseCtt(line);
            EntityDataBase.Unavailability_CourseConstraints.Add(newUnavailabilityCourse);
        }



        //*************************************************
        // UPDATING HEADER FIELDS
        //*************************************************

        /// <summary>
        /// Change Scehdule title
        /// </summary>
        private void CttNameValue_TextChanged(object sender, EventArgs e)
        {
            _headerData.PlanningName = CttNameValue.Text;
        }

        /// <summary>
        /// Change Scehdule DayCount
        /// </summary>
        private void CttDaysValue_TextChanged(object sender, EventArgs e)
        {
            _headerData.DaysCount = int.Parse(CttDaysValue.Text);
        }

        private void CttPeriodsValue_TextChanged(object sender, EventArgs e)
        {
            _headerData.PeriodsPerDay = int.Parse(CttPeriodsValue.Text);
        }

        /// <summary>
        /// Change language
        /// </summary>
        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string selectedLanguage = comboBoxLanguage.SelectedItem.ToString();

            if (selectedLanguage == "Nederlands")
            {
                _headerData.SetLanguage("NL");
            }
            else if (selectedLanguage == "English")
            {
                _headerData.SetLanguage("ENG");
            }
        }

        /// <summary>
        /// Change startDate
        /// </summary>
        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _headerData.StartDate = startDateTimePicker.Value;
        }



        //*************************************************
        // COURSES:     GRID
        //*************************************************

        /// <summary>
        /// editing courses, save old course name before each update
        /// </summary>
        private void CoursesdataGridView_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            _courseNameBeforeUpdate = CoursesdataGridView[0, e.RowIndex].CellValue();
        }


        /// <summary>
        /// Course grid
        /// when changing the courses in te grid
        ///  - update the course count
        ///  - update the courses list for curricula
        ///  - only save the lines to the database when they contain a valid course
        /// </summary>
        private void CoursesdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var nullableColumns = new List<int> { 8, 9 };
            var numericColumns = new List<int> { 2, 3, 4 };
            var dateColumns = new List<int> { 5, 6 };
            int rowIndex = e.RowIndex;

            if (rowIndex < 0)
                return;

            //revert course name if it already existed
            PlanningEntity.CheckDuplicatesInGrid(CoursesdataGridView,rowIndex,_courseNameBeforeUpdate);
           


            var cellValue = CoursesdataGridView[e.ColumnIndex, rowIndex].Value;
            //check null fields
            if (cellValue == null && nullableColumns.IndexOf(e.ColumnIndex) == -1)
            {
                MessageBox.Show(@"This field cannot be empty", @"Data not complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //check numeric fields
            if (numericColumns.IndexOf(e.ColumnIndex) != -1)
            {
                if(cellValue != null)
                    EditorUtilities.CheckIfValidNumber_message(cellValue.ToString());
            }
            //check date fields
            if (dateColumns.IndexOf(e.ColumnIndex) != -1)
            {
                if (cellValue != null)
                    EditorUtilities.CheckIfValidDate_message(cellValue.ToString());
            }


            //todo check whole row and add course
            for (int i = 0; i < CoursesdataGridView.ColumnCount; i++)
            {
                //check null fields
                if (CoursesdataGridView[i, rowIndex].Value == null && nullableColumns.IndexOf(i) == -1)
                        return;
                //check numeric fields
                if (numericColumns.IndexOf(i) != -1)
                {
                    if (!EditorUtilities.IsNumberValid(CoursesdataGridView[i, rowIndex].Value.ToString()))
                        return;
                }

                //check date fields
                if (dateColumns.IndexOf(i) != -1)
                {
                    if (!EditorUtilities.IsDateValid(CoursesdataGridView[i, rowIndex].Value.ToString()))
                        return;
                }


            }

            //after checks
            var oldCourse = Course.FromDatabase(_courseNameBeforeUpdate);
            var newCourse = new Course();
            newCourse.FillDataFromGridline(CoursesdataGridView, rowIndex);
            
            if (newCourse.IsValid())
                {
                    EntityDataBase.Courses.Remove(oldCourse);
                    EntityDataBase.Courses.Add(newCourse);

                   

                foreach (var curriculum in EntityDataBase.Curricula)
                {
                    curriculum.Courses.Remove(oldCourse);
                    curriculum.Courses.Add(newCourse);
                }
                //Update UI
                _headerData.CourseCount = EntityDataBase.Courses.Count;
                CoursesCountLabel.Text = _headerData.CourseCount.ToString();
                UpdateCurriculumCoursesUi();
                }
            
        }

        /// <summary>
        /// Course grid
        /// when a row gets deleted: remove that course from existing curricula
        /// update the UI 
        /// </summary>
        private void CoursesdataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int rowIndex = e.Row.Index;
            if (rowIndex < 0)
                return;

           var courseToDelete = Course.FromDatabase(CoursesdataGridView, rowIndex);
            if (EntityDataBase.Courses.Contains(courseToDelete))
            {
                EntityDataBase.Courses.Remove(courseToDelete);
                _headerData.CourseCount = EntityDataBase.Courses.Count;
                CoursesCountLabel.Text = _headerData.CourseCount.ToString();

                foreach (var curriculum in EntityDataBase.Curricula)
                {
                    curriculum.Courses.Remove(courseToDelete);
                }
            }
            else
            {
                EditorUtilities.ShowError(string.Format("Course <{0}> does not exist", courseToDelete.CourseCode));
                throw new Exception(string.Format("Course <{0}> does not exist", courseToDelete.CourseCode));
            }
            //update UI
            UpdateCurriculumCoursesUi();
        }



        //*************************************************
        // CURRICULA:     GRID
        //*************************************************


        /// <summary>
        /// editing curriculum, save old name before each update
        /// </summary>
        private void CurriculaDataGridView_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            _curriculumNameBeforeUpdate = CurriculaDataGridView[0, e.RowIndex].CellValue();
        }

        /// <summary>
        /// editing curriculum
        /// </summary>
        private void CurriculaDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var numericColumns = new List<int> { 1 };
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;

            var dataGridView = CurriculaDataGridView;

            //revert course name if it already existed
            PlanningEntity.CheckDuplicatesInGrid(dataGridView, rowIndex, _curriculumNameBeforeUpdate);

            //check null fields
            if (dataGridView[0, rowIndex].Value == null)
                return;



            //after checks
//            var oldCurriculum = Curriculum.FromDatabase(_curriculumNameBeforeUpdate);
            var newCurriculum = new Curriculum();
            newCurriculum.FillDataFromGridline(dataGridView, rowIndex);

            if (newCurriculum.IsValid())
            {
//                EntityDataBase.Curricula.Remove(oldCurriculum);

                if (Curriculum.FromDatabase(newCurriculum.CurriculumCode) == null)
                     EntityDataBase.Curricula.Add(newCurriculum);

                _headerData.CurriculaCount = EntityDataBase.Curricula.Count;
                CurriculaCountLabel.Text = _headerData.CurriculaCount.ToString();
            }

     

        }

        /// <summary>
        /// delete curriculum row
        /// </summary>
        /// </summary>
        private void CurriculaDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int rowIndex = e.Row.Index;
            if (rowIndex < 0)
                return;
            DataGridView dataGridView = CurriculaDataGridView;

            var curriculumToDelete = Curriculum.FromDatabase(dataGridView, rowIndex);
            if (EntityDataBase.Curricula.Contains(curriculumToDelete))
            {
                EntityDataBase.Curricula.Remove(curriculumToDelete);
                _headerData.CurriculaCount = EntityDataBase.Curricula.Count;
                CurriculaCountLabel.Text = _headerData.CurriculaCount.ToString();
            }
            else
            {
                EditorUtilities.ShowError(string.Format("Curriculum <{0}> does not exist", curriculumToDelete.CurriculumCode));
                throw new Exception(string.Format("Curriculum <{0}> does not exist", curriculumToDelete.CurriculumCode));
            }
            //update UI
            UpdateCurriculumCoursesUi();
        }




        //UpdateCurriculumCoursesUi on selection changed
        private void CurriculaDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateCurriculumCoursesUi();
        }

        /// <summary>
        /// UI: - Update course count for all curricula
        ///     - Update the inactive courses list (InactiveCoursesBox)
        ///     - Update the active courses list   (CourseListBox)
        /// </summary>
        public void UpdateCurriculumCoursesUi()
        {
            CourseListBox.Items.Clear();
            InactiveCoursesBox.Items.Clear();

            for (int i = 0; i < CurriculaDataGridView.RowCount-1; i++)
            {
                Curriculum tempCurriculum;
                if ((tempCurriculum = Curriculum.FromDatabase(CurriculaDataGridView, i)) != null)
                    CurriculaDataGridView["CurriculumGrid_CourseCount", i].Value = tempCurriculum.CourseCount;
            }

            var selectedCurriculum = Curriculum.FromDatabase(CurriculaDataGridView);
            if (selectedCurriculum != null)
            {
                //Update UI Active course listbox
                foreach (var course in selectedCurriculum.Courses)
                    CourseListBox.Items.Add(course.CourseCode);

                //Update UI Inactive course listbox
                var inactiveCourses = EntityDataBase.Courses.Except(selectedCurriculum.Courses).ToArray();
                foreach (var course in inactiveCourses)
                    InactiveCoursesBox.Items.Add(course.CourseCode);
            }
            else
            {
                foreach (var course in EntityDataBase.Courses)
                    InactiveCoursesBox.Items.Add(course.CourseCode);
            }
        }

        /// Add course to curriculum
        /// </summary>
        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            var selectedCourse = Course.FromDatabase(InactiveCoursesBox);
            if (selectedCourse == null) return;

            var selectedCurriculum = Curriculum.FromDatabase(CurriculaDataGridView);
            try
            {
                selectedCurriculum.AddCourse(selectedCourse);
                UpdateCurriculumCoursesUi();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        /// <summary>
        /// Remove course from curriculum
        /// </summary>
        private void RemoveCourseButton_Click(object sender, EventArgs e)
        {
            var selectedCourse = Course.FromDatabase(CourseListBox);
            if (selectedCourse == null) return;

            var selectedCurriculum = Curriculum.FromDatabase(CurriculaDataGridView);
            try
            {
                selectedCurriculum.RemoveCourse(selectedCourse);
                UpdateCurriculumCoursesUi();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }



        //*************************************************
        // ROOMS:     GRID
        //*************************************************

        /// <summary>
        /// editing room, save old room name before each update
        /// </summary>
        private void RoomsdataGridView_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            _roomNameBeforeUpdate = RoomsdataGridView[0, e.RowIndex].CellValue();
        }

        /// <summary>
        /// editing room
        /// </summary>
        private void RoomsdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;

            //revert course name if it already existed
            Room.CheckDuplicatesInDatabase(RoomsdataGridView, rowIndex, _roomNameBeforeUpdate);

            //check if name is not null
            if (RoomsdataGridView[0, rowIndex].Value == null)
                return;
            if (RoomsdataGridView[1, rowIndex].Value == null)
                RoomsdataGridView[1, rowIndex].Value = 1;

            //after checks
            var oldRoom = Room.FromDatabase(_roomNameBeforeUpdate);
            var newRoom = new Room();
            newRoom.FillDataFromGridline(RoomsdataGridView, rowIndex);


            if (newRoom.IsValid())
            {
                EntityDataBase.Rooms.Remove(oldRoom);
                if (Room.FromDatabase(newRoom.RoomName) == null)
                    EntityDataBase.Rooms.Add(newRoom);


                _headerData.RoomCount = EntityDataBase.Rooms.Count;
                RoomsCountLabel.Text = _headerData.RoomCount.ToString();
            }

        }


        /// <summary>
        /// delete room row
        /// </summary>
        /// </summary>
        private void RoomsdataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int rowIndex = e.Row.Index;
            if (rowIndex < 0)
                return;
            DataGridView dataGridView = RoomsdataGridView;

            var roomToDelete = Room.FromDatabase(dataGridView, rowIndex);
            if (EntityDataBase.Rooms.Contains(roomToDelete))
            {
                EntityDataBase.Rooms.Remove(roomToDelete);
                _headerData.RoomCount = EntityDataBase.Rooms.Count;
                RoomsCountLabel.Text = _headerData.RoomCount.ToString();
            }
            else
            {
                EditorUtilities.ShowError(string.Format("Room <{0}> does not exist", roomToDelete.RoomName));
                throw new Exception(string.Format("Room <{0}> does not exist", roomToDelete.RoomName));
            }
            //update UI
            UpdateCurriculumCoursesUi();
        }


        //*************************************************
        // UNAVAILABILITY_COURSE:     GRID
        //*************************************************
        private void ConstraintsDataGridView_SelectionChanged(object sender,
            EventArgs eventArgs)
        {
            DataGridView dataGridView = ConstraintsDataGridView;
            if (dataGridView.CurrentRow != null)
            {
                int rowIndex = dataGridView.CurrentRow.Index;
                _oldUnavailabilityCourse = Unavailability_Course.FromDatabase(dataGridView, rowIndex);
            }
        }

        /// <summary>
        /// editing room
        /// </summary>
        private void ConstraintsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;

            DataGridView dataGridView = ConstraintsDataGridView;

            //clean date
            dataGridView[1, rowIndex].Value = EditorUtilities.CleanDateFormat(dataGridView[1, rowIndex].CellValue());

            //revert course name if it already existed
            if (_oldUnavailabilityCourse != null)
            {
                if (Unavailability_Course.DuplicatesInGrid(dataGridView, rowIndex,
                    _oldUnavailabilityCourse.Course.CourseCode, 3,
                    "Warning: Duplicate Unavailability_Courses not allowed, reverting back to previous state"))
                {
                    dataGridView[1, rowIndex].Value = _oldUnavailabilityCourse.DateTime.Date.ToString("d");
                    dataGridView[2, rowIndex].Value = _oldUnavailabilityCourse.Timeslot;
                    return;
                }
            }
            else
            {
                if (Unavailability_Course.DuplicatesInGrid(dataGridView, rowIndex,"", 3,
                    "Warning: Duplicate Unavailability_Courses not allowed, reverting back to previous state"))
                {
                    return;
                }
            }
           

            //after checks
            Unavailability_Course newUnavailabilityCourse = new Unavailability_Course();
            if (!newUnavailabilityCourse.FillDataFromGridline(dataGridView, rowIndex))
            {
                if(_oldUnavailabilityCourse != null)
                    dataGridView[0, rowIndex].Value = _oldUnavailabilityCourse.Course.CourseCode;
                return;
            }




            //            if (Unavailability_Course.FromDatabase() == null)
            if (EntityDataBase.Unavailability_CourseConstraints.IndexOf(newUnavailabilityCourse) == -1)
            {
                if(_oldUnavailabilityCourse != null)
                    EntityDataBase.Unavailability_CourseConstraints.Remove(_oldUnavailabilityCourse);
                EntityDataBase.Unavailability_CourseConstraints.Add(newUnavailabilityCourse);
            }


            _headerData.UnavailableCoursesCount = EntityDataBase.Unavailability_CourseConstraints.Count;
                UnavailabilityCountLabel.Text = _headerData.UnavailableCoursesCount.ToString();

        }

        //delete
        private void ConstraintsDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int rowIndex = e.Row.Index;
            if (rowIndex < 0)
                return;
            DataGridView dataGridView = ConstraintsDataGridView;

            var unavailabilityCourseToDelete = Unavailability_Course.FromDatabase(dataGridView, rowIndex);
            if (unavailabilityCourseToDelete.DeleteFromDatabase())
            {
                //update UI
                _headerData.UnavailableCoursesCount = EntityDataBase.Unavailability_CourseConstraints.Count;
                UnavailabilityCountLabel.Text = _headerData.UnavailableCoursesCount.ToString();
            }
            
        }


        //*************************************************
        // COPY PASTE EXCEL
        //*************************************************
        private void pasteExcelCourse_Click(object sender, EventArgs e)
        {
            PasteFromExcel(CoursesdataGridView);
        }

        private void PasteFromExcel(DataGridView dataGridView)
        {
            dataGridView.Focus();
            int selectedRowIndex = dataGridView.CurrentCell.RowIndex;
            dataGridView.CurrentCell = dataGridView[0, selectedRowIndex];

            string s = Clipboard.GetText();
            string[] lines = s.Replace("\n", "").Split('\r');
            Array.Resize(ref lines, lines.Length - 1);

            if (lines.Length >= dataGridView.RowCount - selectedRowIndex)
            {
                dataGridView.Rows.Add(lines.Length - (dataGridView.RowCount - selectedRowIndex) + 1);
            }


            string[] fields;
            int row = dataGridView.CurrentCell.RowIndex;
            int column = 0;
            foreach (string l in lines)
            {
                fields = l.Split('\t');
                foreach (string f in fields)
                {
                    if (column >= dataGridView.ColumnCount)
                        continue;
                    if (row >= dataGridView.RowCount)
                        continue;
                    dataGridView[column++, row].Value = f;
                }

                row++;
                column = 0;
            }

        }


        //*************************************************
        // SAVE / EXIT
        //*************************************************
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<String> lines = new List<string>();
            lines.AddRange(_headerData.Print());
            lines.Add("");
            lines.AddRange(EntityDataBase.Print());
            lines.Add("");
            lines.Add("END.");
            System.IO.File.WriteAllLines(@"result.ctt", lines);


            this.Close();
        }
    }
}