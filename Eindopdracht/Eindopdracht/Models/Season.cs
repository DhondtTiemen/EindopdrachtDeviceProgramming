using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Eindopdracht.Models
{
    public class Season
    {
        public string season { get; set; }

        public override string ToString()
        {
            return Convert.ToString(this.season);
        }
    }
}
