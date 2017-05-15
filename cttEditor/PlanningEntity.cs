using System;
using System.Text.RegularExpressions;

namespace cttEditor
{
    public abstract class PlanningEntity
    {
        public abstract void ParseCtt(string line);

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