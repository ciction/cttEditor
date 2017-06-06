using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cttEditor
{
    public static class EditorUtilities
    {
        private static string _regexPattern;

        public static bool IsNumberValid(string stringValue)
        {
            _regexPattern = @"^[0-9]+$";
            return Regex.IsMatch(stringValue, _regexPattern);
        }

        public static bool IsDateValid(string stringValue)
        {
            _regexPattern = @"^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[\/\-]\d{4}$|\/";
            return Regex.IsMatch(stringValue, _regexPattern);
        }


        public static void CheckIfValidNumber_message(string stringValue)
        {
            if (!IsNumberValid(stringValue))
            {
                MessageBox.Show(@"This field has to be numeric", @"Data invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void CheckIfValidDate_message(string stringValue)
        {
            _regexPattern = @"^(0?[1-9]|[12][0-9]|3[01])[\/](0?[1-9]|1[012])[\/\-]\d{4}$|\/";
            if (!IsDateValid(stringValue))
            {
                MessageBox.Show("This field is not a valid date format \n (dd/mm/yyyy)", @"Data invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static void ShowError(string message)
        {
             MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string CleanDateFormat(string datestring)
        {
            string missingDayZero = @"^([1-9])[\/](0?[1-9]|1[012])[\/\-]\d{4}$";
            if (Regex.IsMatch(datestring, missingDayZero))
            {
                datestring = "0" + datestring;
            }

            string missingMonthZero = @"^(0?[1-9]|[12][0-9]|3[01])[\/]([1-9])[\/\-]\d{4}$";
            if (Regex.IsMatch(datestring, missingMonthZero))
            {
                datestring = datestring.Insert(3, "0");
            }
            return datestring;
        }


    }
}
