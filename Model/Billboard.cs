using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Kylosov.Model
{
    public class Billboard
    {
        public int ID { get; set; }
        public int CinemaID { get; set; }
        public int MovieID { get; set; }
        public DateTime SessionTime { get; set; }
        public int TicketPrice { get; set; }

        public Billboard() { }

        public Billboard(int id, int cinemaID, int movieID, DateTime sessionTime, int ticketPrice)
        {
            ID = id;
            CinemaID = cinemaID;
            MovieID = movieID;
            SessionTime = sessionTime;
            TicketPrice = ticketPrice;
        }
    }

}
