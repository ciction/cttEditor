using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Unavailability_Hours_All: PlanningEntity
    {
        public DateTime DateTime { get; set; }
        public int Timeslot { get; set; }

        public Unavailability_Hours_All()
        {
        }

        //get from database - simple
        public static Unavailability_Hours_All FromDatabase(string dateString, int timeSlot)
        {
            dateString = EditorUtilities.CleanDateFormat(dateString);
            var date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return EntityDataBase.Unavailability_HoursAllConstraints.FirstOrDefault(
                constraint => Equals(constraint.DateTime, date) &&
                              constraint.Timeslot == timeSlot
                );
        }

        //get from database - DataGridView
        public static Unavailability_Hours_All FromDatabase(DataGridView datagridView, int i = -1)
        {
            if (i == -1)
                if (datagridView.CurrentRow != null) i = datagridView.CurrentRow.Index;
            if (i == -1) return null;

            if (datagridView[0, i].CellValue() == null || datagridView[1, i].CellValue() == null)
                return null;

            //new Unavailability_Hours_All
            string dateString = datagridView[0, i].CellValue();
            int timeSlot = int.Parse(datagridView[1, i].CellValue());
            Unavailability_Hours_All unavailabilityHoursAll = Unavailability_Hours_All.FromDatabase(dateString,timeSlot);
            return unavailabilityHoursAll;
        }

        public static Unavailability_Hours_All FromDatabase(Unavailability_Hours_All other)
        {
           return  FromDatabase(other.DateTime.Date.ToString("d"), other.Timeslot);
        }

        public bool DeleteFromDatabase()
        {
            if (EntityDataBase.Unavailability_HoursAllConstraints.Contains(this))
            {
                EntityDataBase.Unavailability_HoursAllConstraints.Remove(this);
                return true;
            }
            EditorUtilities.ShowError(string.Format("Unavailability_Hours_All <{0}> does not exist", this.ToString()));
            throw new Exception(string.Format("Unavailability_Hours_All <{0}> does not exist", this.ToString()));
            return false;
        }


        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);
            var i = 0;
            //get date
            DateTime = ParseDate(words[i++], DateType.Exact);

            //timeslot
            Timeslot = int.Parse(words[i++]);
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(DateTime.Date.ToString("dd/MM/yyyy"), Timeslot);
        }

        public override bool FillDataFromGridline(DataGridView dataGridView, int rowIndex)
        {
            //check if the line data is valid
            const int columns = 2;
            for (int column = 0; column < columns; column++)
            {
                if(dataGridView[column, rowIndex].CellValue() == null)
                    return false;
            }

            var i = 0;

            //get date
            DateTime = ParseDate(dataGridView[i++, rowIndex].CellValue(), DateType.Exact);

            //timeslot
            Timeslot = int.Parse(dataGridView[i++, rowIndex].CellValue());

            return true;

        }


        

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        protected bool Equals(Unavailability_Hours_All other)
        {
            return DateTime.Equals(other.DateTime) && Timeslot == other.Timeslot;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Unavailability_Hours_All) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (DateTime.GetHashCode() * 397) ^ Timeslot;
            }
        }

        public string Print()
        {
            string line;
            line =
                DateTime.ToString("dd/MM/yyyy") + "\t" +
                Timeslot;

            return line;
        }
    }
}
