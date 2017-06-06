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

            //new Unavailability_Course
            string courseCode = datagridView[0, i].CellValue();
            string dateString = datagridView[1, i].CellValue();
            int timeSlot = int.Parse(datagridView[2, i].CellValue());
            Unavailability_Course room = Unavailability_Course.FromDatabase(courseCode,dateString,timeSlot);
            return room;
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
            destinationGrid.Rows.Add(Course.CourseCode, DateTime.Date.ToString("d"), Timeslot);
        }

        public override void FillDataFromGridline(DataGridView dataGridView, int rowIndex)
        {
            throw new NotImplementedException();
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
