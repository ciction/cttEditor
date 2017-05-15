using System;
using System.Windows.Forms;

namespace cttEditor
{
    public class Course : IPlanningEntity
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


        public void ParseCtt(string line)
        {
            var simplifiedLine = HelperMethods.SimplifyWhiteSpaces(line);
            var words = simplifiedLine.Split(new[] {" ", "\t"}, StringSplitOptions.None);

            var i = 0;
            CourseCode = words[i++];
            TeacherCode = words[i++];
            LectureSize = int.Parse(words[i++]);
            MinimumWorkingDays = int.Parse(words[i++]);
            StudentSize = int.Parse(words[i++]);
        }

        public override string ToString()
        {
            var output = GetType().Name + ": { \n";
            var properties = GetType().GetProperties();


            foreach (var property in properties)
                output += "\t\"" + property.Name + "\":" + "\"" + property.GetValue(this, null) + "\"\n";
            output += "}\n";

            return output;
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(CourseCode, TeacherCode, LectureSize, MinimumWorkingDays, StudentSize);
        }
    }
}