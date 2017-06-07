using System.Linq;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Room : PlanningEntity
    {
        public string RoomName { get; set; }
        public int RoomCapacity { get; set; }
        public int PcCount { get; set; }

        //empty constructor
        public Room()
        {
            RoomName = null;
            RoomCapacity = 0;
            PcCount = 0;
        }
        //full constructor
        public Room(string roomName, int roomCapacity, int pcCount)
        {
            RoomName = roomName;
            RoomCapacity = roomCapacity;
            PcCount = pcCount;
        }

        //get from database - simple
        public static Room FromDatabase(string roomName)
        {
            return EntityDataBase.Rooms.FirstOrDefault(r => r.RoomName == roomName);
        }

        //get from database - DataGridView
        public static Room FromDatabase(DataGridView datagridView, int i = -1)
        {
            if (i == -1)
                if (datagridView.CurrentRow != null) i = datagridView.CurrentRow.Index;
            if (i == -1) return null;
            //new room with code
            string roomName = datagridView[0, i].CellValue();
            Room room = Room.FromDatabase(roomName);
            return room;
        }



        //check before adding if there are duplicates in the database
        public static void CheckDuplicatesInDatabase(DataGridView dataGridView, int rowIndex, string revertName)
        {
            if (rowIndex < 0) return;
            string roomNameAfterUpdate = dataGridView[0, rowIndex].CellValue();
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (dataGridView[0, i].CellValue() == roomNameAfterUpdate && i != rowIndex)
                {
                    EditorUtilities.ShowWarning(
                        "Warning: Duplicate room names ar not allowed, reverting back to previous name");
                    dataGridView[0, rowIndex].Value = revertName;
                }
            }
        }



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

        public override bool FillDataFromGridline(DataGridView dataGridView, int rowIndex)
        {
            var i = 0;
            RoomName = dataGridView[i++, rowIndex].CellValue();
                RoomCapacity = int.Parse(dataGridView[i++, rowIndex].CellValue());


            if (dataGridView[i, rowIndex].CellValue() == null)
            {
                PcCount = 0;
            }
            else
            {
                PcCount = int.Parse(dataGridView[i++, rowIndex].CellValue());

            }

            return true;
        }

        public override bool IsValid()
        {
            if (RoomName != null &&
                RoomCapacity != 0)
                return true;
            return false;
        }

        protected bool Equals(Room other)
        {
            return string.Equals(RoomName, other.RoomName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Room) obj);
        }

        public override int GetHashCode()
        {
            return (RoomName != null ? RoomName.GetHashCode() : 0);
        }

        public string Print()
        {
            var line = RoomName + "\t" + "\t" +
                          RoomCapacity + "\t" + "\t" +
                          PcCount;
            return line;
        }
    }
}