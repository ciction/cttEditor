using System;
using System.Globalization;
using System.Windows.Forms;

namespace cttEditor
{
    public class Course : PlanningEntity
    {
        public enum DateType{Maximum,Minium};

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

        //ABAP_Objects S.Weemaels 5 1 5
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


        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(CourseCode, TeacherCode, LectureSize, MinimumWorkingDays, StudentSize);
        }

        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);

            var i = 0;
            CourseCode = words[i++];
            if (CourseCode.EndsWith("_WK"))
            {
                HoursPerDay = 3;
            }
            else
            {
                HoursPerDay = 2;
            }
            TeacherCode = words[i++];
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

        private DateTime ParseDate(string dateString, DateType dateType)
        {
            DateTime dateTime = new DateTime();

            if (!dateString.Equals("/"))
            {
                dateTime = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                //                set default value
                if (dateType == DateType.Maximum)
                {
                    dateTime = DateTime.MaxValue;
                }
            }
            return dateTime;
        }

        private int ParseMaximumValue(string intString)
        {
            int value = int.MaxValue;
            if (!intString.Equals("/"))
            {
                value = int.Parse(intString);
            }
            return value;
        }



        public bool IsValid()
        {
            if (CourseCode != null &&
                TeacherCode != null &&
                LectureSize != 0 &&
                MinimumWorkingDays != 0 &&
                StudentSize != 0)
                return true;
            return false;
        }


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