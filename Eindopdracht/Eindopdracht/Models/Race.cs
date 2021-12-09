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
        public Result[] Results { get; set; }

        //Methods, ToString()
        public override string ToString()
        {
            return this.Circuit.circuitName;
        }
    }
}
