using System.Windows.Forms;

namespace cttEditor
{
    internal class Room : PlanningEntity
    {
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

        public string RoomName { get; set; }
        public int RoomCapacity { get; set; }

        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);

            var i = 0;
            RoomName = words[i++];
            RoomCapacity = int.Parse(words[i++]);
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(RoomName, RoomCapacity);
        }

    }
}