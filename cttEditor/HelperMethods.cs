using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cttEditor
{
    public static class HelperMethods
    {
        public static string SimplifyWhiteSpaces(string line)
        {
            return Regex.Replace(line, @"\s+", " ");
        }
    }
}
