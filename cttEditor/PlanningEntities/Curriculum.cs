﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cttEditor
{
    public class Curriculum : PlanningEntity
    {
        public Curriculum()
        {
        }

        public Curriculum(string curriculumCode, int courseCount)
        {
            CurriculumCode = curriculumCode;
            CourseCount = courseCount;
        }

        public string CurriculumCode { get; set; }
        public int CourseCount { get; set; }
        public List<Course> Courses { get; } = new List<Course>();

        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);

            var i = 0;
            CurriculumCode = words[i++];
            CourseCount = int.Parse(words[i++]);
            var courses = words.Skip(2).ToArray();
            foreach (var course in courses)
            {
                //find course with CourseCode
                var index = EntityDataBase.Courses.IndexOf(
                    EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == course));
                var newCourse = EntityDataBase.Courses[index];
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
            ++CourseCount;
            return true;
        }

        public bool RemoveCourse(Course course)
        {
            Courses.Remove(course);
            --CourseCount;
            return true;
        }
    }
}