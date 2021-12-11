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
        //public string localTime
        //{
        //    get
        //    {
        //        time = this.time;
        //        string timeZString = time.Substring(6);
        //        DateTime timeZTime = Convert.ToDateTime(timeZString);
        //        DateTime localTime = Convert.ToDateTime(timeZTime).ToLocalTime();
        //        string localTimeString = Convert.ToString(localTime);
        //        return localTimeString;
        //    }
        //}

        //Methods, ToString()
        public override string ToString()
        {
            return this.Circuit.circuitName;
        }
    }
}
