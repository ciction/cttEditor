using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Course : PlanningEntity
    {


        public string CourseCode { get; set; }
        public string TeacherCode { get; set; }
        public int LectureSize { get; set; }
        public int MinimumWorkingDays { get; set; }
        public int StudentSize { get; set; }
        public DateTime MinimumDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public int MaximumWorkingDays { get; set; }
        public bool IsPcNeeded { get; set; }
        public int HoursPerDay { get; set; }

        public Course()
        {
            CourseCode = null;
            TeacherCode = null;
            LectureSize = 0;
            MinimumWorkingDays = 0;
            StudentSize = 0;
        }

        public Course(string courseCode, string teacherCode, int lectureSize, int minimumWorkingDays, int studentSize)
        {
            CourseCode = courseCode;
            TeacherCode = teacherCode;
            LectureSize = lectureSize;
            MinimumWorkingDays = minimumWorkingDays;
            StudentSize = studentSize;
        }


        //*****************************************
        // DATABASE
        //*****************************************

        //get from database - simple
        public static Course FromDatabase(string courseCode)
        {
            return EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == courseCode);
        }

        //get from database - DataGridView
        public static Course FromDatabase(DataGridView datagridView, int i)
        {
            //new curriculum with code
            string courseCode = datagridView[0, i].CellValue();
            Course course = FromDatabase(courseCode);
            return course;
        }

        //get from database - listbox
        public static Course FromDatabase(ListBox listbox)
        {
            if (listbox.SelectedItem != null)
            {
                var courseCode = listbox.SelectedItem.ToString();
                return Course.FromDatabase(courseCode);
            }
            return null;
        }

        //database - chech duplicates moved to super
//        public static void CheckDuplicatesInGrid(DataGridView dataGridView, int rowIndex, string revertName)
//        {
//            if (rowIndex < 0) return;
//            string courseNameAfterUpdate = dataGridView[0, rowIndex].CellValue();
//            for (int i = 0; i < dataGridView.RowCount; i++)
//            {
//                if (dataGridView[0, i].CellValue() == courseNameAfterUpdate && i != rowIndex)
//                {
//                    EditorUtilities.ShowWarning(
//                        "Warning: Duplicate course names not allowed, reverting back to previous name");
//                    dataGridView[0, rowIndex].Value = revertName;
//                }
//            }
//        }



        //*****************************************
        // PARSER
        //*****************************************

        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);

            var i = 0;
            CourseCode = words[i++];
            HoursPerDay = CourseCode.EndsWith("_WK") ? 3 : 2;
            TeacherCode = words[i++];
            TeacherDatabase.TeacherCodes.Add(TeacherCode);
            LectureSize = int.Parse(words[i++]);
            MinimumWorkingDays = int.Parse(words[i++]);
            StudentSize = int.Parse(words[i++]);

            MinimumDate = ParseDate(words[i++], DateType.Minium);
            DeadlineDate = ParseDate(words[i++], DateType.Maximum);

            MaximumWorkingDays = ParseMaximumValue(words[i++]);

            if (words.Length >= 9)
            {
                IsPcNeeded = bool.Parse(words[i++]);
            }
            if (words.Length >= 10)
            {
                HoursPerDay = int.Parse(words[i++]);
            }
        }

        public override bool FillDataFromGridline(DataGridView dataGridView, int rowIndex)
        {
            var i = 0;
            CourseCode = dataGridView[i++, rowIndex].CellValue();
            HoursPerDay = CourseCode.EndsWith("_WK") ? 3 : 2;
            TeacherCode = dataGridView[i++, rowIndex].CellValue();
            LectureSize = int.Parse(dataGridView[i++, rowIndex].CellValue());
            MinimumWorkingDays = int.Parse(dataGridView[i++, rowIndex].CellValue());
            StudentSize = int.Parse(dataGridView[i++, rowIndex].CellValue());

            MinimumDate = ParseDate(dataGridView[i++, rowIndex].CellValue(),DateType.Minium);
            DeadlineDate = ParseDate(dataGridView[i++, rowIndex].CellValue(),DateType.Maximum);

            MaximumWorkingDays = ParseMaximumValue(dataGridView[i++, rowIndex].CellValue());

            if (dataGridView[i, rowIndex].CellValue() == null)
            {
                IsPcNeeded = false;
                i++;
            }
            else
            {
                IsPcNeeded = bool.Parse(dataGridView[i++, rowIndex].CellValue());
            }

            if (dataGridView[i, rowIndex].CellValue() != null)
                HoursPerDay = int.Parse(dataGridView[i++, rowIndex].CellValue());

            return true;

        }

       

        private static int ParseMaximumValue(string intString)
        {
            int value = int.MaxValue;
            if (!intString.Equals("/"))
            {
                value = int.Parse(intString);
            }
            return value;
        }



        //*****************************************
        // HELPERS
        //*****************************************

       

        public override bool IsValid()
        {
            if (CourseCode != null &&
                TeacherCode != null &&
                LectureSize != 0 &&
                MinimumWorkingDays != 0 &&
                StudentSize != 0)
                return true;
            return false;
        }


        public string Print()
        {
            var maximumWorkingDaysString = MaximumWorkingDays == int.MaxValue ? "/" : MaximumWorkingDays.ToString();
            var MinimumWorkingDaysString = MinimumWorkingDays < 1 ? "/" : MinimumWorkingDays.ToString();
            var minimumDateString = MinimumDate.Equals(DateTime.MinValue) ? "/" : MinimumDate.ToString("dd/MM/yyy");
            var deadlineDateString = DeadlineDate.Equals(DateTime.MaxValue) ? "/" : DeadlineDate.ToString("dd/MM/yyy");



            string line;
            line =
                CourseCode + "\t" + 
                TeacherCode + "\t" + "\t" + "\t" + "\t" +
                LectureSize + "\t" + "\t" +
                MinimumWorkingDaysString + "\t" + "\t" +
                StudentSize + "\t" + "\t" +
                minimumDateString + "\t" + "\t" +
                deadlineDateString + "\t" + "\t" +
                maximumWorkingDaysString + "\t" + "\t" +
                IsPcNeeded + "\t" + "\t" +
                HoursPerDay;

            return line;
        }



        //*****************************************
        // UI
        //*****************************************
        public void AddToDataGrid(DataGridView destinationGrid)
        {
            //convert minmium and maximum values to /
            var minimumDateString = MinimumDate == DateTime.MinValue ? "/" : MinimumDate.Date.ToString("d");
            var deadlineString = DeadlineDate == DateTime.MaxValue ? "/" : DeadlineDate.Date.ToString("d");
            var maxDays = MaximumWorkingDays == int.MaxValue ? "/" : MaximumWorkingDays.ToString();

            //add values to grid
            destinationGrid.Rows.Add(CourseCode, TeacherCode, LectureSize, MinimumWorkingDays, StudentSize, minimumDateString, deadlineString, maxDays, IsPcNeeded, HoursPerDay);
        }



        //*****************************************
        // COMPARE
        //*****************************************

        // compare based on courseName (for hashset and lists)
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            var other = obj as Course;
            return string.Equals(CourseCode, other.CourseCode);
        }

        public override int GetHashCode()
        {
            return CourseCode.GetHashCode();
        }
    }
}