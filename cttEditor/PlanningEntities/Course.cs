using System;
using System.Windows.Forms;

namespace cttEditor
{
    public class Course : PlanningEntity, IEquatable<Course>
    {
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

        public bool Equals(Course other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(CourseCode, other.CourseCode);
        }


        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(CourseCode, TeacherCode, LectureSize, MinimumWorkingDays, StudentSize);
        }

        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);

            var i = 0;
            CourseCode = words[i++];
            TeacherCode = words[i++];
            LectureSize = int.Parse(words[i++]);
            MinimumWorkingDays = int.Parse(words[i++]);
            StudentSize = int.Parse(words[i++]);
        }

        public override bool Equals(object obj)
        {
            // Delegate...
            return Equals(obj as Course);
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
    }
}