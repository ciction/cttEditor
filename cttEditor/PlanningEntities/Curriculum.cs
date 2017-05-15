using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cttEditor
{
    public class Curriculum : PlanningEntity
    {
        public string CurriculumCode { get; set; }
        public int CourseCount { get; set; }
        public List<Course> Courses { get; } = new List<Course>();

        public Curriculum()
        {
        }

        public Curriculum(string curriculumCode, int courseCount)
        {
            CurriculumCode = curriculumCode;
            CourseCount = courseCount;
        }

        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);

            var i = 0;
            CurriculumCode = words[i++];
            CourseCount = int.Parse(words[i++]);
            var courses = words.Skip(2).ToArray();
            foreach (string course in courses)
            {

                //find course with CourseCode
                int index = EntityDataBase.Courses.IndexOf(EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == course));
                Course newCourse = EntityDataBase.Courses[index];
                Courses.Add(newCourse);
            }
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(CurriculumCode, CourseCount);
        }

        public bool AddCourse(Course course)
        {
            if (Courses.Contains(course))
                return false;

            Courses.Add(course);
            return true;
        }

    }
}