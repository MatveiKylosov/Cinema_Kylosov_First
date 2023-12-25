﻿using Cinema_Kylosov.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingBD;

namespace Cinema_Kylosov.Classes
{
    public class CinemaContext : Cinema
    {
        public CinemaContext(int id, string name, int numberOfHalls, int numberOfSeats) : base(id, name, numberOfHalls, numberOfSeats)
        {

        }
        public static List<CinemaContext> AllCinemas()
        {
            List<CinemaContext> allCinemas = new List<CinemaContext>();

            MySqlConnection connection = Connection.OpenConnection();

            MySqlDataReader cinemaQuery = Connection.Query("SELECT * FROM `Cinema`.`Cinemas`", connection);

            while (cinemaQuery.Read())
            {
                allCinemas.Add(new CinemaContext(
                    cinemaQuery.GetInt32(0),
                    cinemaQuery.GetString(1),
                    cinemaQuery.GetInt32(2),
                    cinemaQuery.GetInt32(3)
                    ));
            }

            Connection.CloseConnection(connection);

            return allCinemas;
        }
    }

}
