using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cttEditor.PlanningEntities;

namespace cttEditor
{
    public static class EntityDataBase
    {
//        public static HashSet<Course> Courses = new HashSet<Course>();
        public static List<Course> Courses = new List<Course>();
        public static List<Room> Rooms = new List<Room>();
        public static List<Curriculum> Curricula = new List<Curriculum>();
        public static List<Unavailability_Course> Unavailability_CourseConstraints = new List<Unavailability_Course>();

        public static List<string> Print()
        {
            List<String> lines = new List<string>();
            lines.AddRange(PrintCourses());
            lines.Add("");
            lines.AddRange(PrintTEACHER_GROUPS());
            lines.Add("");
            lines.AddRange(PrintRooms());
            lines.Add("");
            lines.AddRange(PrintCurricula());
            lines.Add("");
            lines.AddRange(Print_UNAVAILABILITY_COURSE());
            lines.Add("");
            lines.AddRange(PrintUNAVAILABILITY_CURRICULUM());
            lines.Add("");
            lines.AddRange(Print_UNAVAILABLE_HOURS_ALL());
            lines.Add("");
            lines.AddRange(Print_UNAVAILABLE_DAYS_ALL());
            lines.Add("");
            lines.AddRange(Print_DEPENDENCIES());
            return lines;
        }

        private static List<string> PrintCourses()
        {
            List<String> lines = new List<string>();
            lines.Add("COURSES:");
            lines.Add(@"code            teacher                 count   minDays   students  minimumDate deadline    maxDays     needPc(optional)  HoursPerDay(optional but with pc)");
            foreach (var course in Courses)
            {
                lines.Add(course.Print());
            }
            return lines;
        }

        private static List<string> PrintTEACHER_GROUPS()
        {
            List<String> lines = new List<string>();
            lines.Add("TEACHER_GROUPS:");
            lines.Add(@"groupName                   teachers(n)");
            
            return lines;
        }

        private static List<string> PrintRooms()
        {
            List<String> lines = new List<string>();
            lines.Add("ROOMS:");
            lines.Add(@"RoomID  Capacity    PCcount");
            foreach (var room in Rooms)
            {
                lines.Add(room.Print());
            }
            return lines;
        }

        private static List<string> PrintCurricula()
        {
            List<String> lines = new List<string>();
            lines.Add("CURRICULA:");
            lines.Add(@"CurriculumID   #Courses     AllMemberCourses(n)");
            foreach (var curriculum in Curricula)
            {
                lines.Add(curriculum.Print());
            }
            return lines;
        }

        private static List<string> Print_UNAVAILABILITY_COURSE()
        {
            List<String> lines = new List<string>();
            lines.Add("UNAVAILABILITY_COURSE:");
            lines.Add(@"CourseID        Day(date)    Period");

            foreach (var Unavailability_CourseConstraint in Unavailability_CourseConstraints)
            {
                lines.Add(Unavailability_CourseConstraint.Print());
            }

            return lines;
        }

        private static List<string> PrintUNAVAILABILITY_CURRICULUM()
        {
            List<String> lines = new List<string>();
            lines.Add("UNAVAILABILITY_CURRICULUM:");
            lines.Add(@"CurriculumID        Day(date)   timeslot(optional)");
           
            return lines;
        }

        private static List<string> Print_UNAVAILABLE_HOURS_ALL()
        {
            List<String> lines = new List<string>();
            lines.Add("UNAVAILABLE_HOURS_ALL:");
            lines.Add(@"Day(date)    Period");
            return lines;
        }

        private static List<string> Print_UNAVAILABLE_DAYS_ALL()
        {
            List<String> lines = new List<string>();
            lines.Add("UNAVAILABLE_DAYS_ALL:");
            lines.Add(@"Day(date)");
            return lines;
        }

        private static List<string> Print_DEPENDENCIES()
        {
            List<String> lines = new List<string>();
            lines.Add("DEPENDENCIES:");
            lines.Add(@"dependentCourse     courseDependencies(n)");
            return lines;
        }
    }
}
