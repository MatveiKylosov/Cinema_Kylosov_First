using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Kylosov.Model
{
    public class Ticket
    {
        public int ID { get; set; }
        public int BillboardID { get; set; }

        public Ticket() { }

        public Ticket(int id, int billboardID)
        {
            ID = id;
            BillboardID = billboardID;
        }
    }
}
