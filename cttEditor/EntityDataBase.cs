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
    }
}
