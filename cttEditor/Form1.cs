using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor
{
    public partial class Form1 : Form
    {
        private int _courseCount = 0;

        public Form1()
        {
            InitializeComponent();
            ReadCtt(@"C:\Users\Christophe\Documents\programming\bachelorproef\ctt_editor\cttEditor\cttEditor\digx_opgesplitst.ctt");

            //init fields
            CoursesCountLabel.Text = (CoursesdataGridView.RowCount - 1).ToString();

                //this.CoursesdataGridView.Rows.Add("five", "six", "seven", "eight");
                //temp comment

        }

        private void CoursesdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void CoursesdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CoursesCountLabel.Text = CoursesdataGridView.RowCount.ToString();
        }

        private void RoomsdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RoomsCountLabel.Text = RoomsdataGridView.RowCount.ToString();
        }

        private void CoursesdataGridView_CellValidating(object sender,
                                           DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex > 1 ) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("please enter a numeric value", "Data not numeric", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // the input is numeric 
                }
            }
        }


        private void ReadCtt(string file)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    int linenumber = 1;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        //words on the current line
                        string[] words = line.Split(' ');
                        switch (words[0])
                        {
                            case "Name:":
                                CttNameValue.Text = words[1];
                                break;
                            case "Days:":
                                CttDaysValue.Text = words[1];
                                break;
                            case "Courses:":
                                _courseCount = int.Parse(words[1]);
                                break;
                            case "COURSES:":
                                parseCourses(linenumber, file);
                                break;
                            default:
                                break;
                        }
                        //Console.WriteLine(line);
                        ++linenumber;
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void parseCourses(int lineNumber, string file)
        {
            var lines = File.ReadLines(file).Skip(lineNumber).Take(_courseCount).ToList<String>();
            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                string[] words = line.Split(' ');
                this.CoursesdataGridView.Rows.Add(words[0], words[1], words[2], words[3], words[4]);
            }

        }
    }
}
