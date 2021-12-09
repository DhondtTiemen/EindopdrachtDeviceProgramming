using System;
using System.Collections.Generic;
using System.Text;

namespace Eindopdracht.Models
{
    public class Circuit
    {
        public string circuitId { get; set; }
        public string url { get; set; }
        public string circuitName { get; set; }
        public CircuitLocation Location { get; set; }

        //Methods, ToString()
        public override string ToString()
        {
            return this.circuitName;
        }
    }
}
