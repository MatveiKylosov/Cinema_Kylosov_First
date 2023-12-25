using Cinema_Kylosov.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingBD;

namespace Cinema_Kylosov.Classes
{
    public class TicketContext : Ticket
    {
        public TicketContext(int id, int billboardID) : base(id, billboardID)
        {

        }
        public static List<TicketContext> AllTickets()
        {
            List<TicketContext> allTickets = new List<TicketContext>();

            MySqlConnection connection = Connection.OpenConnection();

            MySqlDataReader ticketQuery = Connection.Query("SELECT * FROM `Cinema`.`Tickets`", connection);

            while (ticketQuery.Read())
            {
                allTickets.Add(new TicketContext(
                    ticketQuery.GetInt32(0),
                    ticketQuery.GetInt32(1)
                    ));
            }

            Connection.CloseConnection(connection);

            return allTickets;
        }
    }
}
