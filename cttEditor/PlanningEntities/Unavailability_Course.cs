using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Unavailability_Course: PlanningEntity
    {
        public Course Course { get; set; }
        public DateTime DateTime { get; set; }
        public int Timeslot { get; set; }

        public Unavailability_Course()
        {
        }

        //get from database - simple
        public static Unavailability_Course FromDatabase(string courseName, string dateString, int timeSlot)
        {
            var course = PlanningEntities.Course.FromDatabase(courseName);
            dateString = EditorUtilities.CleanDateFormat(dateString);
            var date = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return EntityDataBase.Unavailability_CourseConstraints.FirstOrDefault(
                constraint => Equals(constraint.DateTime, date) &&
                              Equals(constraint.Course, course) &&
                              constraint.Timeslot == timeSlot
                );
        }

        //get from database - DataGridView
        public static Unavailability_Course FromDatabase(DataGridView datagridView, int i = -1)
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
            Unavailability_Course unavailabilityCourse = Unavailability_Course.FromDatabase(courseCode,dateString,timeSlot);
            return unavailabilityCourse;
        }

        public static Unavailability_Course FromDatabase(Unavailability_Course other)
        {
           return  FromDatabase(other.Course.CourseCode, other.DateTime.Date.ToString("d"), other.Timeslot);
        }

        public bool DeleteFromDatabase()
        {
            if (EntityDataBase.Unavailability_CourseConstraints.Contains(this))
            {
                EntityDataBase.Unavailability_CourseConstraints.Remove(this);
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
            var course = PlanningEntities.Course.FromDatabase(words[i++]);
            if(course == null)
                throw new NullReferenceException("Error: Course not found");
            Course = course;

            //get date
            DateTime = ParseDate(words[i++], DateType.Exact);

            //timeslot
            Timeslot = int.Parse(words[i++]);
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(Course.CourseCode, DateTime.Date.ToString("dd/MM/yyyy"), Timeslot);
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
            var course = Course.FromDatabase(dataGridView[i++, rowIndex].CellValue());
            if (course == null)
            {
                EditorUtilities.ShowWarning(
                    "Error: Course not found");
                return false;
            }
            //get course
            Course = course;

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

        protected bool Equals(Unavailability_Course other)
        {
            return Equals(Course, other.Course) && DateTime.Equals(other.DateTime) && Timeslot == other.Timeslot;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Unavailability_Course) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Course != null ? Course.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ Timeslot;
                return hashCode;
            }
        }

        public string Print()
        {
            string line;
            line =
                Course.CourseCode + "\t" +
                DateTime.ToString("dd/MM/yyyy") + "\t" +
                Timeslot;

            return line;
        }
    }
}
