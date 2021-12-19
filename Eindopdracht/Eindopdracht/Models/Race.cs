using System;
using System.Collections.Generic;
using System.Text;

namespace Eindopdracht.Models
{
    public class Race
    {
        public string season { get; set; }
        public string round { get; set; }
        public string url { get; set; }
        public string raceName { get; set; }
        public Circuit Circuit { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public Result[] Results { get; set; }

        //Calculated Property
        public string localTime
        {
            get
            {
                time = this.time;
                string timeZString = time.Substring(0, 8);
                DateTime datetimeTimeZ = Convert.ToDateTime(timeZString);
                DateTime datetimeLocal = datetimeTimeZ.ToUniversalTime();
                string localString = Convert.ToString(datetimeLocal);
                string timeResult = localString.Substring(0, 8);
                return timeResult;
            }
        }

        //Methods, ToString()
        public override string ToString()
        {
            return this.Circuit.circuitName;
        }
    }
}
