using System.Linq;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public class Curriculum : PlanningEntity
    {

        public Curriculum()
        {
            InitCoursesListener();
        }

        public Curriculum(string curriculumCode, int courseCount)
        {
            CurriculumCode = curriculumCode;
            CourseCount = courseCount;
            InitCoursesListener();
        }
        
        //make a curriculum with only a name
        private Curriculum(string curriculumCode)
        {
            CurriculumCode = curriculumCode;
        }
        
        //get from database - simple
        public static Curriculum FromDatabase(string curriculumCode)
        {
            return  EntityDataBase.Curricula.FirstOrDefault(c => c.CurriculumCode == curriculumCode);
        }

        //get from database - DataGridView
        public static Curriculum FromDatabase(DataGridView datagridView, int i = -1)
        {
            if (i == -1)
                if (datagridView.CurrentRow != null) i = datagridView.CurrentRow.Index;

            if (i == -1) return null;
            //new curriculum with code
                string curriculumCode = datagridView[0, i].CellValue();
                Curriculum curriculum = FromDatabase(curriculumCode);
                return curriculum;
        }

        private void InitCoursesListener()
        {
            Courses.OnRemove += (sender, args) =>
            {
                if(CourseCount > 0)
                    CourseCount = Courses.Count - 1;
            };

            Courses.OnAdd += (sender, args) =>
            {
                CourseCount = Courses.Count + 1;
            };
        }

        public string CurriculumCode { get; set; }
        public int CourseCount { get; set; }
        public EventTriggeringList<Course> Courses { get; } = new EventTriggeringList<Course>();

        public override void ParseCtt(string line)
        {
            var words = GetStringData(line);
            var i = 0;
            CurriculumCode = words[i++];
            CourseCount = int.Parse(words[i++]);

            var courses = words.Skip(2).ToArray();
            foreach (var course in courses)
            {
                //find course with CourseCode
                var newCourse = EntityDataBase.Courses.FirstOrDefault(c => c.CourseCode == course);
                Courses.Add(newCourse);
            }
        }

        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(CurriculumCode, CourseCount);
        }

        public bool AddCourse(Course course)
        {
            if (Courses.Contains(course))
                return false;

            Courses.Add(course);
//            ++CourseCount;
            return true;
        }

        public bool RemoveCourse(Course course)
        {
            Courses.Remove(course);
//            --CourseCount;
            return true;
        }

        // compare based on name (for hashset and lists)
        protected bool Equals(Curriculum other)
        {
            return string.Equals(CurriculumCode, other.CurriculumCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Curriculum) obj);
        }

        public override int GetHashCode()
        {
            return (CurriculumCode != null ? CurriculumCode.GetHashCode() : 0);
        }
    }
}