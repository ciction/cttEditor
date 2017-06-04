using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using cttEditor.PlanningEntities;

namespace cttEditor
{
    public partial class Form1 : Form
    {
        private readonly HeaderData _headerData = new HeaderData();
     


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
        /// Course grid
        /// when changing the courses in te grid
        ///  - update the course count
        ///  - update the courses list for curricula
        /// </summary>
        private void CoursesdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CoursesCountLabel.Text = CoursesdataGridView.RowCount.ToString();
            if(e.RowIndex < 0)
                return;

            //try to create a course from all columns
            if (CoursesdataGridView[0, e.RowIndex].Value != null &&
                CoursesdataGridView[1, e.RowIndex].Value != null &&
                CoursesdataGridView[2, e.RowIndex].Value != null &&
                CoursesdataGridView[3, e.RowIndex].Value != null &&
                CoursesdataGridView[4, e.RowIndex].Value != null)
            {
                var newCourse = new Course();
                newCourse.CourseCode = CoursesdataGridView[0, e.RowIndex].Value.ToString();
                newCourse.TeacherCode = CoursesdataGridView[1, e.RowIndex].Value.ToString();
                newCourse.LectureSize = int.Parse(CoursesdataGridView[2, e.RowIndex].Value.ToString());
                newCourse.MinimumWorkingDays = int.Parse(CoursesdataGridView[3, e.RowIndex].Value.ToString());
                newCourse.StudentSize = int.Parse(CoursesdataGridView[4, e.RowIndex].Value.ToString());

                //add course to the 
                if (newCourse.IsValid())
                {
                    if (!EntityDataBase.Courses.Contains(newCourse))
                    {
                        EntityDataBase.Courses.Add(newCourse);
                        //Update the available courses for curricula (UI)
                        UpdateCurriculumCourses();
                    }
                }

                //todo prevent adding the same course twice

                //todo update other grids (WIP)
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
            courseToDelete.TeacherCode = CoursesdataGridView[1, rowIndex].Value.ToString();
            courseToDelete.LectureSize = int.Parse(CoursesdataGridView[2, rowIndex].Value.ToString());
            courseToDelete.MinimumWorkingDays = int.Parse(CoursesdataGridView[3, rowIndex].Value.ToString());
            courseToDelete.StudentSize = int.Parse(CoursesdataGridView[4, rowIndex].Value.ToString());
            
            EntityDataBase.Courses.Remove(courseToDelete);

            foreach (var curriculum in EntityDataBase.Curricula)
            {
                curriculum.Courses.Remove(courseToDelete);
            }
            //update UI
            UpdateCurriculumCourses();
            //todo update course count in curriculum gird
            //todo fix error on the list of avalable courses after a delete
        }

        //Rooms grid label
        private void RoomsdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RoomsCountLabel.Text = RoomsdataGridView.RowCount.ToString();
        }

        //editing courses
        //when finished entering a value in the grid
        private void CoursesdataGridView_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex > 1) // 1 should be your column index
            {
                var i = 0;

                if (e.FormattedValue.ToString().Length <= 0)
                    return;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show(@"please enter a numeric value", @"Data not numeric", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
           
        }


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
                                break;
                            case "StartDate:":
                                _headerData.SetStartDate(words[1]);
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
                                //skip first info line and parse data
                                ParseDataBlock(linenumber+1, _headerData.CourseCount, file, AddCourse);
                                foreach (var course in EntityDataBase.Courses)
                                    course.AddToDataGrid(CoursesdataGridView);
                                break;
                            case "TEACHER_GROUPS:":
                                break;
                            case "ROOMS:":
                                ParseDataBlock(linenumber+1, _headerData.RoomCount, file, AddRoom);
                                foreach (var room in EntityDataBase.Rooms)
                                    room.AddToDataGrid(RoomsdataGridView);
                                break;
                            case "CURRICULA:":
                                ParseDataBlock(linenumber+1, _headerData.CurriculaCount, file, AddCurriculum);
                                foreach (var curriculum in EntityDataBase.Curricula)
                                    curriculum.AddToDataGrid(CurriculadataGridView);
                                //                                EntityDataBase.Curricula[0].CourseCount;
                                CourseListBox.Items.Clear();
//                                CourseListBox.Items.Add(EntityDataBase.Curricula[0].CourseCount);
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

        private void CurriculadataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateCurriculumCourses();
        }

        /// <summary>
        /// UI: - Update the list of inactive courses for the current curriculum    (InactiveCoursesBox)
        ///     - Update the list of active courses for the current curriculum      (CourseListBox)
        /// </summary>
        public void UpdateCurriculumCourses()
        {
            CourseListBox.Items.Clear();
            InactiveCoursesBox.Items.Clear();
            var selectedCurriculum = GetSelectedCuriculum();

            if (selectedCurriculum != null)
            {
                var selectedRow = CurriculadataGridView.CurrentCell.RowIndex;
                CurriculadataGridView["CurriculumGrid_CourseCount", selectedRow].Value = selectedCurriculum.CourseCount;

                var inactiveCourses = EntityDataBase.Courses.Except(selectedCurriculum.Courses).ToArray();

                //Update Active course listbox
                foreach (var course in selectedCurriculum.Courses)
                    CourseListBox.Items.Add(course.CourseCode);

                //Update Inactive course listbox
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
                var selectedCourse = GetSelectedInactiveCourse();
                var selectedCurriculum = GetSelectedCuriculum();

                try
                {
                    selectedCurriculum.AddCourse(selectedCourse);
                    UpdateCurriculumCourses();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }

        private void RemoveCourseButton_Click(object sender, EventArgs e)
        {
            var selectedCourse = GetSelectedActiveCourse();
            if (selectedCourse == null)
                return;

            var selectedCurriculum = GetSelectedCuriculum();


            try
            {
                selectedCurriculum.RemoveCourse(selectedCourse);
                UpdateCurriculumCourses();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private Course GetSelectedInactiveCourse()
        {
            if (InactiveCoursesBox.SelectedItem != null)
            {
                var courseCode = InactiveCoursesBox.SelectedItem.ToString();

                //find Course by 
                  return EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == courseCode);
            }
            return null;
        }

        private Course GetSelectedActiveCourse()
        {
            if (CourseListBox.SelectedItem != null)
            {
                var courseCode = CourseListBox.SelectedItem.ToString();
                return EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == courseCode);
            }
            return null;
        }

        private Curriculum GetSelectedCuriculum()
        {
            var selectedRow = CurriculadataGridView.CurrentCell.RowIndex;
            if (selectedRow < EntityDataBase.Curricula.Count)
            {
                //                return EntityDataBase.Curricula[selectedRow];
                List<Curriculum> Curricula = EntityDataBase.Curricula.ToList();
                return Curricula[selectedRow];
            }
            return null;
        }

        //delegates
        private delegate void AddPlanningEntityDelegate(string line);


       
    }
}