using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Unavailability_Days_All: PlanningEntity
    {
        public DateTime DateTime { get; set; }

        public Unavailability_Days_All()
        {
        }

        //get from database - simple
        public static Unavailability_Days_All FromDatabase(string dateString)
        {
            dateString = EditorUtilities.CleanDateFormat(dateString);
            var date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return EntityDataBase.Unavailability_DaysAllConstraints.FirstOrDefault(
                constraint => Equals(constraint.DateTime, date));
        }

        //get from database - DataGridView
        public static Unavailability_Days_All FromDatabase(DataGridView datagridView, int i = -1)
        {
            if (i == -1)
                if (datagridView.CurrentRow != null) i = datagridView.CurrentRow.Index;
            if (i == -1) return null;

            if (datagridView[0, i].CellValue() == null)
                return null;

            //new Unavailability_Days_All
            string dateString = datagridView[0, i].CellValue();
            Unavailability_Days_All unavailabilityHoursAll = Unavailability_Days_All.FromDatabase(dateString);
            return unavailabilityHoursAll;
        }

        public static Unavailability_Days_All FromDatabase(Unavailability_Days_All other)
        {
           return  FromDatabase(other.DateTime.Date.ToString("d"));
        }

        public bool DeleteFromDatabase()
        {
            if (EntityDataBase.Unavailability_DaysAllConstraints.Contains(this))
            {
                EntityDataBase.Unavailability_DaysAllConstraints.Remove(this);
                return true;
            }
            EditorUtilities.ShowError(string.Format("Unavailability_Days_All <{0}> does not exist", this.ToString()));
            throw new Exception(string.Format("Unavailability_Days_All <{0}> does not exist", this.ToString()));
            return false;
        }


        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);
            var i = 0;
            //get date
            DateTime = ParseDate(words[i++], DateType.Exact);
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(DateTime.Date.ToString("dd/MM/yyyy"));
        }

        public override bool FillDataFromGridline(DataGridView dataGridView, int rowIndex)
        {
            //check if the line data is valid
            const int columns = 1;
            for (int column = 0; column < columns; column++)
            {
                if(dataGridView[column, rowIndex].CellValue() == null)
                    return false;
            }

            var i = 0;

            //get date
            DateTime = ParseDate(dataGridView[i++, rowIndex].CellValue(), DateType.Exact);

            return true;

        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }


        protected bool Equals(Unavailability_Days_All other)
        {
            return DateTime.Equals(other.DateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Unavailability_Days_All) obj);
        }

        public override int GetHashCode()
        {
            return DateTime.GetHashCode();
        }

        public string Print()
        {
            string line;
            line = DateTime.ToString("dd/MM/yyyy");

            return line;
        }
    }
}
