using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
        public class TeacherGroup
    {
        public string TeacherCode { get; set; }
        public List<TeacherGroup> TeacherList { get; set; }

        public TeacherGroup()
        {
            TeacherList = new List<TeacherGroup>();
        }

        public TeacherGroup(string teacherCode)
        {
            TeacherCode = teacherCode;
            TeacherList = new List<TeacherGroup>();
        }

        //get from database - simple
        public static TeacherGroup FromDatabase(string teachercode)
        {
            return EntityDataBase.TeacherGroups.FirstOrDefault(t => t.TeacherCode == teachercode);
        }

        //get from database - DataGridView
        public static TeacherGroup FromDatabase(DataGridView datagridView, int i = -1)
        {
            if (i == -1)
                if (datagridView.CurrentRow != null) i = datagridView.CurrentRow.Index;
            if (i == -1) return null;

            //new curriculum with code
            string teachercode = datagridView[0, i].CellValue();
            TeacherGroup teacherGroup = FromDatabase(teachercode);
            return teacherGroup;
        }

        //get from database - listbox
        public static TeacherGroup FromDatabase(ListBox listbox)
        {
            if (listbox.SelectedItem != null)
            {
                var teacherCode = listbox.SelectedItem.ToString();
                return TeacherGroup.FromDatabase(teacherCode);
            }
            return null;
        }

        public void AddTeacher(string teachercode)
        {
            TeacherGroup teacherGroup = EntityDataBase.TeacherGroups.FirstOrDefault(t => t.TeacherCode == teachercode);
            if(teacherGroup != null)
            this.TeacherList.Add(teacherGroup);
        }

        public void AddTeacher(TeacherGroup teacherGroup)
        {
            if (teacherGroup != null)
                this.TeacherList.Add(teacherGroup);
        }


        public void RemoveTeacher(string teachercode)
        {
            TeacherGroup teacherGroup = EntityDataBase.TeacherGroups.FirstOrDefault(t => t.TeacherCode == teachercode);
            if (teacherGroup != null)
            this.TeacherList.Remove(teacherGroup);
        }
        public void RemoveTeacher(TeacherGroup teacherGroup)
        {
            if (teacherGroup != null)
                this.TeacherList.Remove(teacherGroup);
        }


        public void AddToDataGrid(DataGridView destinationGrid)
        {
            destinationGrid.Rows.Add(TeacherCode);
        }


        public void UpdateDependencieListboxes(ListBox dependenciesListbox, ListBox InactiveDependenciesListBox)
        {

            foreach (var teacher in TeacherList)
            {
                
                dependenciesListbox.Items.Add(teacher.TeacherCode);
            }

            var otherTeachers =
                EntityDataBase.TeacherGroups.Where(tg => tg.TeacherList.Count == 0 && tg.TeacherCode != TeacherCode);
            otherTeachers = otherTeachers.Except(TeacherList).ToArray();
            foreach (var otherteacher in otherTeachers)
            {
                InactiveDependenciesListBox.Items.Add(otherteacher.TeacherCode);
            }
        }


        public override string ToString()
        {
            return TeacherCode;
        }

        protected bool Equals(TeacherGroup other)
        {
            return string.Equals(TeacherCode, other.TeacherCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TeacherGroup) obj);
        }

        public override int GetHashCode()
        {
            return (TeacherCode != null ? TeacherCode.GetHashCode() : 0);
        }

        public string Print()
        {
            string line = "";
            string teacherlistString = "";

            foreach (var teacher in TeacherList)
            {
                teacherlistString += teacher.TeacherCode + " ";
            }
            line =
                TeacherCode + "\t" + "\t" +
                teacherlistString;
            
          
            return line;
        }
    }
}
