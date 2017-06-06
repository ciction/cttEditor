using System.Linq;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Room : PlanningEntity
    {
        //empty constructor
        public Room()
        {
            RoomName = null;
            RoomCapacity = 0;
        }
        //full constructor
        public Room(string roomName, int roomCapacity)
        {
            RoomName = roomName;
            RoomCapacity = roomCapacity;
        }
        //get room from database object by selected row in grid
        public static Room FromRow(DataGridView datagridView, int i)
        {
            //new curriculum with code
            string roomName = datagridView[0, i].CellValue();
            Room  room = EntityDataBase.Rooms.FirstOrDefault(r => r.RoomName == roomName);
            return room;
        }
        //check before adding if there are duplicates in the database
        public static void CheckDuplicatesInDatabase(DataGridView dataGridView, int rowIndex, string revertName)
        {
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