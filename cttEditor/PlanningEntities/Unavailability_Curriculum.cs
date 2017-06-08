using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Unavailability_Curriculum: PlanningEntity
    {
        public Curriculum Curriculum { get; set; }
        public DateTime DateTime { get; set; }
        public int Timeslot { get; set; }

        public Unavailability_Curriculum()
        {
        }

        //get from database - simple
        public static Unavailability_Curriculum FromDatabase(string curriculumName, string dateString, int timeSlot)
        {
            var curriculum = PlanningEntities.Curriculum.FromDatabase(curriculumName);
            dateString = EditorUtilities.CleanDateFormat(dateString);
            var date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return EntityDataBase.Unavailability_CurriculumConstraints.FirstOrDefault(
                constraint => Equals(constraint.DateTime, date) &&
                              Equals(constraint.Curriculum, curriculum) &&
                              constraint.Timeslot == timeSlot
                );
        }

        //get from database - DataGridView
        public static Unavailability_Curriculum FromDatabase(DataGridView datagridView, int i = -1)
        {
            if (i == -1)
                if (datagridView.CurrentRow != null) i = datagridView.CurrentRow.Index;
            if (i == -1) return null;

            if (datagridView[0, i].CellValue() == null || datagridView[1, i].CellValue() == null ||
                datagridView[2, i].CellValue() == null)
                return null;

            //new Unavailability_Course
            string courseCode = datagridView[0, i].CellValue();
            string dateString = datagridView[1, i].CellValue();
            int timeSlot = int.Parse(datagridView[2, i].CellValue());
            Unavailability_Curriculum unavailabilityCurriculum= Unavailability_Curriculum.FromDatabase(courseCode,dateString,timeSlot);
            return unavailabilityCurriculum;
        }

        public static Unavailability_Curriculum FromDatabase(Unavailability_Curriculum other)
        {
           return  FromDatabase(other.Curriculum.CurriculumCode, other.DateTime.Date.ToString("d"), other.Timeslot);
        }

        public bool DeleteFromDatabase()
        {
            if (EntityDataBase.Unavailability_CurriculumConstraints.Contains(this))
            {
                EntityDataBase.Unavailability_CurriculumConstraints.Remove(this);
                return true;
            }
            EditorUtilities.ShowError(string.Format("Unavailability_Course <{0}> does not exist", this.ToString()));
            throw new Exception(string.Format("Unavailability_Course <{0}> does not exist", this.ToString()));
            return false;
        }


        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);
            var i = 0;
            //get course
            var curriculum = PlanningEntities.Curriculum.FromDatabase(words[i++]);
            if(curriculum == null)
                throw new NullReferenceException("Error: curriculum not found");
            Curriculum = curriculum;

            //get date
            DateTime = ParseDate(words[i++], DateType.Exact);

            //timeslot
            Timeslot = int.Parse(words[i++]);
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(Curriculum.CurriculumCode, DateTime.Date.ToString("dd/MM/yyyy"), Timeslot);
        }

        public override bool FillDataFromGridline(DataGridView dataGridView, int rowIndex)
        {
            //check if the line data is valid
            const int columns = 3;
            for (int column = 0; column < columns; column++)
            {
                if(dataGridView[column, rowIndex].CellValue() == null)
                    return false;
            }

            var i = 0;
            var curriculum = Curriculum.FromDatabase(dataGridView[i++, rowIndex].CellValue());
            if (curriculum == null)
            {
                EditorUtilities.ShowWarning(
                    "Error: Curriculum not found");
                return false;
            }
            //get course
            Curriculum = curriculum;

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

        protected bool Equals(Unavailability_Curriculum other)
        {
            return Equals(Curriculum, other.Curriculum) && DateTime.Equals(other.DateTime) && Timeslot == other.Timeslot;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Unavailability_Curriculum) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Curriculum != null ? Curriculum.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ Timeslot;
                return hashCode;
            }
        }

        public string Print()
        {
            string line;
            line =
                Curriculum.CurriculumCode + "\t" +
                DateTime.ToString("dd/MM/yyyy") + "\t" +
                Timeslot;

            return line;
        }
    }
}
