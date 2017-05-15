using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace cttEditor
{
    public partial class Form1 : Form
    {
        private readonly List<Course> _courses = new List<Course>();
        private readonly List<Room> _rooms = new List<Room>();
        private int _courseCount;
        private int _periodsPerDay;
        private int _roomCount;


        public Form1()
        {
            InitializeComponent();
            ReadCtt(
                @"C:\Users\Christophe\Documents\programming\bachelorproef\ctt_editor\cttEditor\cttEditor\digx_opgesplitst.ctt");

            //init fields
            CoursesCountLabel.Text = (CoursesdataGridView.RowCount - 1).ToString();

            //this.CoursesdataGridView.Rows.Add("five", "six", "seven", "eight");
            //temp comment
        }


        //Course grid label
        private void CoursesdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CoursesCountLabel.Text = CoursesdataGridView.RowCount.ToString();
        }

        //Rooms grid label
        private void RoomsdataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RoomsCountLabel.Text = RoomsdataGridView.RowCount.ToString();
        }

        private void CoursesdataGridView_CellValidating(object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex > 1) // 1 should be your column index
            {
                int i;

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("please enter a numeric value", "Data not numeric", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }


        private void ReadCtt(string file)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (var sr = new StreamReader(file))
                {
                    string line;
                    var linenumber = 1;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        //words on the current line
                        var words = line.Split(' ');
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
                                CoursesCountLabel.Text = _courseCount.ToString();
                                break;
                            case "Rooms:":
                                _roomCount = int.Parse(words[1]);
                                RoomsCountLabel.Text = _roomCount.ToString();
                                break;
                            case "Periods_per_day:":
                                _periodsPerDay = int.Parse(words[1]);
                                CttPeriodsValue.Text = words[1];
                                break;
                            case "COURSES:":
                                ParseDataBlock(linenumber, _courseCount, file, AddCourse);
                                foreach (var course in _courses)
                                    course.AddToDataGrid(CoursesdataGridView);
                                break;
                            case "ROOMS:":
                                ParseDataBlock(linenumber, _roomCount, file, AddRoom);
                                foreach (var room in _rooms)
                                    room.AddToDataGrid(RoomsdataGridView);
                                break;
                            case "CURRICULA:":
//                                parseBlockToDatagrid(linenumber, 2, file, this.CurriculadataGridView, 2);
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


        //Parse DataBlock
        private void ParseDataBlock(int firstLine, int count, string file, AddPlanningEntityDelegate addPlanningEntity)
        {
            var lines = File.ReadLines(file).Skip(firstLine).Take(count).ToList();
            foreach (var line in lines)
                addPlanningEntity(line);
        }

        //addPlanningEntity Course
        private void AddCourse(string line)
        {
            var newCourse = new Course();
            newCourse.ParseCtt(line);
            _courses.Add(newCourse);
        }

        //addPlanningEntity Course
        private void AddRoom(string line)
        {
            var newRoom = new Room();
            newRoom.ParseCtt(line);
            _rooms.Add(newRoom);
        }


        /// <summary>
        ///     Parse datablock partially to a datagrid
        /// </summary>
        /// <param name="lineItems">only take first n parameters per line</param>
        private void parseBlockToDatagrid(int firstLine, int count, string file, DataGridView destinationGrid,
            int lineItems)
        {
            var lines = File.ReadLines(file).Skip(firstLine).Take(count).ToList();
            var simplifiedLine = "";
            foreach (var line in lines)
            {
//                simplifiedLine = HelperMethods.SimplifyWhiteSpaces(line);
                var words = simplifiedLine.Split(new[] {" ", "\t"}, StringSplitOptions.None);
                var firstWords = words.Take(lineItems).ToArray();
                destinationGrid.Rows.Add(firstWords);
            }
        }

        //delegates
        private delegate void AddPlanningEntityDelegate(string line);
    }
}