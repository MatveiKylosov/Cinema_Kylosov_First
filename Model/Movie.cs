using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Kylosov.Model
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }

        public Movie() { }

        public Movie(int id, string name, string genre, int duration)
        {
            ID = id;
            Name = name;
            Genre = genre;
            Duration = duration;
        }
    }
}
