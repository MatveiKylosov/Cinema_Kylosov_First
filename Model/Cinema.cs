using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Kylosov.Model
{
    public class Cinema
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfHalls { get; set; }
        public int NumberOfSeats { get; set; }

        public Cinema() { }

        public Cinema(int id, string name, int numberOfHalls, int numberOfSeats)
        {
            ID = id;
            Name = name;
            NumberOfHalls = numberOfHalls;
            NumberOfSeats = numberOfSeats;
        }
    }
}
