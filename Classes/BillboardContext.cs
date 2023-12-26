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
    public class BillboardContext : Billboard
    {
        public BillboardContext(int id, int cinemaID, int movieID, DateTime sessionTime, int ticketPrice) : base(id, cinemaID, movieID, sessionTime, ticketPrice)
        {

        }
        public static List<BillboardContext> AllBillboards()
        {
            List<BillboardContext> allBillboards = new List<BillboardContext>();

            MySqlConnection connection = Connection.OpenConnection();

            MySqlDataReader billboardQuery = Connection.Query("SELECT * FROM `Cinema`.`Billboard`", connection);

            while (billboardQuery.Read())
            {
                allBillboards.Add(new BillboardContext(
                    billboardQuery.GetInt32(0),
                    billboardQuery.GetInt32(1),
                    billboardQuery.GetInt32(2),
                    billboardQuery.GetDateTime(3),
                    billboardQuery.GetInt32(4)
                    ));
            }

            Connection.CloseConnection(connection);

            return allBillboards;
        }

        public void DeleteBillboard()
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM `Cinema`.`Billboard` WHERE ID = {ID}", connection);
            Connection.Query($"DELETE FROM `Cinema`.`Tickets` WHERE Billboard_ID = {ID}", connection);
            Connection.CloseConnection(connection);
        }

        public void UpdateBillboard(int cinemaID, int movieID, DateTime sessionTime, int ticketPrice)
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"UPDATE `Cinema`.`Billboard` SET CinemaID = {cinemaID}, MovieID = {movieID}, SessionTime = '{sessionTime.ToString("yyyy-MM-dd HH:mm:ss")}', TicketPrice = {ticketPrice} WHERE ID = {ID}", connection);
            Connection.CloseConnection(connection);
        }
    }
}
