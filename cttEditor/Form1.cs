using System;
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
        private readonly HeaderData _headerData = new HeaderData();
        private string _courseNameBeforeUpdate = "";


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
                                UpdateCurriculumCoursesUI();
                                break;
                            case "UNAVAILABILITY_COURSE:":
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
            var cells = CoursesdataGridView.Rows[rowIndex].Cells;

            var courseToDelete = new Course();
            courseToDelete.CourseCode = CoursesdataGridView[0, rowIndex].Value.ToString();
            if (EntityDataBase.Courses.Contains(courseToDelete))
            {
                EntityDataBase.Courses.Remove(courseToDelete);
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
            UpdateCurriculumCoursesUI();
            //todo update course count in curriculum gird
            //todo fix error on the list of avalable courses after a delete
        }

        //Rooms grid label

        private void RoomsdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RoomsCountLabel.Text = RoomsdataGridView.RowCount.ToString();
        }

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
        /// </summary>
        private void CoursesdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var nullableColumns = new List<int> { 8, 9 };
            var numericColumns = new List<int> { 2, 3, 4 };
            var dateColumns = new List<int> { 5, 6 };
            int rowIndex = e.RowIndex;


            //dataGridViewCellEventArgs
            if (rowIndex < 0)
                return;




            //revert course name if it already existed
            string courseNameAfterUpdate = CoursesdataGridView[0, rowIndex].CellValue();
            for (int i = 0; i < CoursesdataGridView.RowCount; i++)
            {
                if (CoursesdataGridView[0, i].CellValue() == courseNameAfterUpdate && i != rowIndex)
                {
                    //todo show error message
                    //                    throw new Exception("Error: Duplicate course name");
                    CoursesdataGridView[0, rowIndex].Value = _courseNameBeforeUpdate;
                }
            }


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
            var oldCourse = new Course();
            oldCourse.CourseCode = _courseNameBeforeUpdate;
            var newCourse = new Course();
            newCourse.ParseGridLine(CoursesdataGridView, rowIndex);
            
            if (newCourse.IsValid())
                {
                    EntityDataBase.Courses.Remove(oldCourse);
                    EntityDataBase.Courses.Add(newCourse);

                foreach (var curriculum in EntityDataBase.Curricula)
                {
                    curriculum.Courses.Remove(oldCourse);
                    curriculum.Courses.Add(newCourse);
                }
                        //Update the available courses for curricula (UI)
                        UpdateCurriculumCoursesUI();
                }
            
            //todo prevent adding the same course twice

            //todo update other grids (WIP)


        }




        //Parse DataBlock
        private void ParseDataBlock(int firstLine, int count, string file, AddPlanningEntityDelegate addPlanningEntity)
        {
            var lines = File.ReadLines(file).Skip(firstLine).Take(count).ToList();
            foreach (var line in lines)
                addPlanningEntity(line);
        }

        //addPlanningEntity Course
        private void AddCourse(string line)
        {
            var newCourse = new Course();
            newCourse.ParseCtt(line);
            EntityDataBase.Courses.Add(newCourse);
        }

        //addPlanningEntity Room
        private void AddRoom(string line)
        {
            var newRoom = new Room();
            newRoom.ParseCtt(line);
            EntityDataBase.Rooms.Add(newRoom);
        }

        //addPlanningEntity Curriculum
        private void AddCurriculum(string line)
        {
            var newCurriculum = new Curriculum();
            newCurriculum.ParseCtt(line);
            EntityDataBase.Curricula.Add(newCurriculum);
        }


        /// <summary>
        ///     Parse datablock partially to a datagrid
        /// </summary>
        /// <param name="lineItems">only take first n parameters per line</param>
        private void ParseBlockToDatagrid(int firstLine, int count, string file, DataGridView destinationGrid,
            int lineItems)
        {
            var lines = File.ReadLines(file).Skip(firstLine).Take(count).ToList();
            var simplifiedLine = "";
            foreach (var line in lines) 
            {
//                simplifiedLine = HelperMethods.SimplifyWhiteSpaces(line);
                var words = simplifiedLine.Split(new[] {" ", "\t"}, StringSplitOptions.None);
                var firstWords = words.Take(lineItems).ToArray();
                destinationGrid.Rows.Add(firstWords);
            }
        }

        private void CurriculaDataGridViewSelectionChanged(object sender, EventArgs e)
        {
            UpdateCurriculumCoursesUI();
        }

        /// <summary>
        /// UI: - Update the list of inactive courses for the current curriculum    (InactiveCoursesBox)
        ///     - Update the list of active courses for the current curriculum      (CourseListBox)
        /// </summary>
        public void UpdateCurriculumCoursesUI()
        {
            CourseListBox.Items.Clear();
            InactiveCoursesBox.Items.Clear();
            var selectedCurriculum = GetSelectedCuriculum();

            if (selectedCurriculum != null)
            {
                //Update UI  Curricula DataGridView coursecount
                var selectedRow = CurriculaDataGridView.CurrentCell.RowIndex;
                CurriculaDataGridView["CurriculumGrid_CourseCount", selectedRow].Value = selectedCurriculum.CourseCount;

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

        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            if (InactiveCoursesBox.SelectedItem != null)
            {
                var selectedCourse = GetSelectedInactiveCurriculumCourse();
                var selectedCurriculum = GetSelectedCuriculum();

                try
                {
                    selectedCurriculum.AddCourse(selectedCourse);
                    UpdateCurriculumCoursesUI();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void RemoveCourseButton_Click(object sender, EventArgs e)
        {
            var selectedCourse = GetSelectedActiveCurriculumCourse();
            if (selectedCourse == null)
                return;

            var selectedCurriculum = GetSelectedCuriculum();


            try
            {
                selectedCurriculum.RemoveCourse(selectedCourse);
                UpdateCurriculumCoursesUI();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private Course GetSelectedInactiveCurriculumCourse()
        {
            if (InactiveCoursesBox.SelectedItem != null)
            {
                var courseCode = InactiveCoursesBox.SelectedItem.ToString();

                //find Course by 
                  return EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == courseCode);
            }
            return null;
        }

        private Course GetSelectedActiveCurriculumCourse()
        {
            if (CourseListBox.SelectedItem != null)
            {
                var courseCode = CourseListBox.SelectedItem.ToString();
                return EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == courseCode);
            }
            return null;
        }
        /// <summary>
        /// Get the selected curriculum from the database, based on what is selected in the CurriculaDataGridView
        /// </summary>
        private Curriculum GetSelectedCuriculum()
        {
            if (CurriculaDataGridView.CurrentCell == null)
                return null;

            var selectedRow = CurriculaDataGridView.CurrentCell.RowIndex;
            if (selectedRow < EntityDataBase.Curricula.Count)
            {
                //                return EntityDataBase.Curricula[selectedRow];
                var selectedCurriculumCode  = CurriculaDataGridView[0, selectedRow].CellValue();
                return EntityDataBase.Curricula.Find(curriculum => curriculum.CurriculumCode == selectedCurriculumCode);
            }
            return null;
        }

        private Course GetSelectedCourse()
        {
            var rowIndex = CoursesdataGridView.CurrentCell.RowIndex;
            var selectedCourseCode = CoursesdataGridView[0, rowIndex].CellValue();
            return EntityDataBase.Courses.Find(course => course.CourseCode == selectedCourseCode);
        }

        //delegates
        private delegate void AddPlanningEntityDelegate(string line);

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //todo do save logic

            this.Close();
        }

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

    }
}