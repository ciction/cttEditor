using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor
{
    public static class DatagridExtensions
    {
        public static String CellValue(this DataGridViewCell dataGridViewCell)
        {
            if(dataGridViewCell.Value == null)
                return null;
            return dataGridViewCell.Value.ToString();
        }
    }
}
