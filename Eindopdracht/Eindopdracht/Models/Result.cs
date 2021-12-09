using System;
using System.Collections.Generic;
using System.Text;

namespace Eindopdracht.Models
{
    public class Result
    {
        public string number { get; set; }
        public string position { get; set; }
        public string positionText { get; set; }
        public string points { get; set; }
        public Driver Driver { get; set; }
        public Constructor Constructor { get; set; }
        public string grid { get; set; }
        public string laps { get; set; }
        public string status { get; set; }
        public Time Time { get; set; }

        //Methods, ToString()
        public override string ToString()
        {
            return this.number + ": " + this.Driver.givenName;
        }
    }
}
