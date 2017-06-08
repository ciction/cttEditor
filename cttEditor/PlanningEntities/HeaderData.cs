using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor.PlanningEntities
{
    public enum Language { Dutch, English };

    class HeaderData
    {
        private Language _language;
        /*
            Name: EHB
            Language: NL
            StartDate: 04/06/2017
            Courses: 5
            TeacherGroupCount: 1
            Rooms: 3
            Days: 11
            Periods_per_day: 9
            Curricula: 2
            unavailable_courses: 2
            unavailable_curricula: 3
            unavailable_hours_all: 2
            unavailable_days_all: 1
            DependentCoursesCount: 1
         */

        public String PlanningName { get; set; }

        public Language Language
        {
            get { return _language; }
            set
            {
                _language = value;
            }
        }

        public DateTime StartDate { get; set; }
        public int CourseCount { get; set; }
        public int TeacherGroupCount { get; set; }
        public int RoomCount { get; set; }
        public int DaysCount { get; set; }
        public int PeriodsPerDay { get; set; }
        public int CurriculaCount { get; set; }
        public int UnavailableCoursesCount  { get; set; }
        public int UnavailableCurriculaCount  { get; set; }
        public int UnavailableHoursAllCount  { get; set; }
        public int UnavailableDaysAllCount  { get; set; }
        public int DependentCoursesCount  { get; set; }


        public HeaderData()
        {
        }

        public void SetLanguage(string languageCode)
        {
            switch (languageCode)
            {
                case "NL":
                    this.Language = Language.Dutch;
                    break;
                case "ENG":
                    this.Language = Language.English;
                    break;
                default:
                    this.Language = Language.English;
                    MessageBox.Show(
                        string.Format("Warning: language code <{0}> is not supported,\n the default language has been set to English ",languageCode), @"Unsuported language code");
                    break;

            }
        }

        public void SetStartDate(string dateString)
        {
            var dateTime = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.StartDate = dateTime;
        }

        public List<String> Print()
        {
            string lanuageCode = "";
            switch (Language)
            {
                case Language.Dutch:
                    lanuageCode = "NL";
                    break;
                case Language.English:
                    lanuageCode = "ENG";
                    break;
                default:
                    this.Language = Language.English;
                    MessageBox.Show(
                        string.Format("Warning: language code <{0}> is not supported,\n the default language has been set to English ", lanuageCode), @"Unsuported language code");
                    break;
            }

            TeacherGroupCount = EntityDataBase.TeacherGroups.Count(tg => tg.TeacherList.Count > 0);


            List<String> lines = new List<string>
            {
                "Name:" + " " + PlanningName,
                "Language:" + " " + lanuageCode,
                "StartDate:" + " " + StartDate.ToString("dd/MM/yyyy"),
                "Courses:" + " " + CourseCount,
                "TeacherGroupCount:" + " " + TeacherGroupCount,
                "Rooms:" + " " + RoomCount,
                "Days:" + " " + DaysCount,
                "Periods_per_day:" + " " + PeriodsPerDay,
                "Curricula:" + " " + CurriculaCount,
                "unavailable_courses:" + " " + UnavailableCoursesCount,
                "unavailable_curricula:" + " " + UnavailableCurriculaCount,
                "unavailable_hours_all:" + " " + UnavailableHoursAllCount,
                "unavailable_days_all:" + " " + UnavailableDaysAllCount,
                "DependentCourses:" + " " + DependentCoursesCount
            };

            return lines;
        }
    }               
}                   
                    