using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cttEditor
{

    class Room: PlanningEntity
    {
        public string RoomName { get; set; }
        public int RoomCapacity { get; set; }

        public Room()
        {
            RoomName = null;
            RoomCapacity = 0;
        }

        public Room(string roomName, int roomCapacity)
        {
            RoomName = roomName;
            RoomCapacity = roomCapacity;
        }

        public override void ParseCtt(string line)
        {
//            var simplifiedLine = HelperMethods.SimplifyWhiteSpaces(line);
//            var words = simplifiedLine.Split(new[] { " ", "\t" }, StringSplitOptions.None);
//
//            var i = 0;
//            CourseCode = words[i++];
//            TeacherCode = words[i++];
//            LectureSize = int.Parse(words[i++]);
//            MinimumWorkingDays = int.Parse(words[i++]);
//            StudentSize = int.Parse(words[i++]);
        }
    }

}
