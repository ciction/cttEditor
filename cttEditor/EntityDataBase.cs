using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cttEditor
{
    public static class EntityDataBase
    {
        public static HashSet<Course> Courses = new HashSet<Course>();
        public static HashSet<Room> Rooms = new HashSet<Room>();
        public static HashSet<Curriculum> Curricula = new HashSet<Curriculum>();
    }
}
