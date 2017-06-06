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
        public static HashSet<Room> Rooms = new HashSet<Room>();
        public static List<Curriculum> Curricula = new List<Curriculum>();
    }
}
