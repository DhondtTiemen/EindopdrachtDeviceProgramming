using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eindopdracht.Models
{
    public class FavoriteCircuit
    {

        public Favorites[] favorites { get; set; }

        public class Favorites
        {
            public string id { get; set; }
            public string circuitId { get; set; }
        }

    }
}
