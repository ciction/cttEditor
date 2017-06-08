using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public abstract class PlanningEntity
    {
        public enum DateType { Maximum, Minium, Exact };

        public abstract void ParseCtt(string line);
        public abstract bool FillDataFromGridline(DataGridView dataGridView, int rowIndex);
        public abstract bool IsValid();

        //Grid - check duplicates
        public static void CheckDuplicatesInGrid(DataGridView dataGridView, int rowIndex, string revertName)
        {
            if (rowIndex < 0) return;
            string nameAfterUpdate = dataGridView[0, rowIndex].CellValue();
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                if (dataGridView[0, i].CellValue() == nameAfterUpdate && i != rowIndex)
                {
                    EditorUtilities.ShowWarning(
                        "Warning: Duplicate course names not allowed, reverting back to previous name");
                    dataGridView[0, rowIndex].Value = revertName;
                }
            }
        }

        //Grid - check duplicates
        public static bool DuplicatesInGrid(DataGridView dataGridView, int rowIndex, string revertName, int keys, string message)
        {
            //compare first X  keyfields of current row, with whole table

            if (rowIndex < 0) return false;
            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                int sameKeys = 0;
                for (int j = 0; j < keys; j++)
                {
                    if (i == rowIndex) continue;
                    if (dataGridView[0, i].CellValue() == null) continue;
                    if ( dataGridView[j, i].CellValue().Equals(dataGridView[j, rowIndex].CellValue()))
                        ++sameKeys;
                }
                if (sameKeys >= keys )
                {
                    EditorUtilities.ShowWarning(message);
                    for (int j = 0; j < keys; j++)
                    {
                        dataGridView[j, rowIndex].Value = revertName ?? "";
                        return true;
                    }
                }
            }
            return false;
        }


        protected DateTime ParseDate(string dateString, DateType dateType)
        {
            DateTime dateTime = new DateTime();

            if (!dateString.Equals("/"))
            {
                dateString = EditorUtilities.CleanDateFormat(dateString);
                dateTime = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                switch (dateType)
                {
                    case DateType.Exact:
                        throw new ArgumentException("/ is not allowed here, (must be an exact value)");
                    case DateType.Minium:
                        //default is already the minimum date
                        break;
                    case DateType.Maximum:
                        dateTime = DateTime.MaxValue;
                        break;
                }
                //set default value
            }
            return dateTime;
        }

        protected static string SimplifyWhiteSpaces(string line)
        {
            return Regex.Replace(line, @"\s+", " ");
        }


        protected string[] GetStringData(string line)
        {
            var simplifiedLine = SimplifyWhiteSpaces(line);
            return simplifiedLine.Split(new[] {" ", "\t"}, StringSplitOptions.None);
        }

        public override string ToString()
        {
            var output = GetType().Name + ": { \n";
            var properties = GetType().GetProperties();
            
            foreach (var property in properties)
                output += "\t\"" + property.Name + "\":" + "\"" + property.GetValue(this, null) + "\"\n";
            output += "}\n";

            return output;
        }
    }
}