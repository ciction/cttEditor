using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cttEditor
{
    public abstract class PlanningEntity
    {
        public abstract void ParseCtt(string line);

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
