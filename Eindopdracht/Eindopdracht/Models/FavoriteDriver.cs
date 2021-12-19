using System;
using System.Collections.Generic;
using System.Text;

namespace Eindopdracht.Models
{
    public class FavoriteDriver
    {
        public Favorites[] favorites { get; set; }

        public class Favorites
        {
            public string id { get; set; }
            public string driverId { get; set; }
        }
    }
}
