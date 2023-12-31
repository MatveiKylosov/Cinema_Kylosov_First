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
    public class MovieContext : Movie
    {
        public MovieContext(int id, string name, string genre, int duration) : base(id, name, genre, duration)
        {

        }
        public static List<MovieContext> AllMovies()
        {
            List<MovieContext> allMovies = new List<MovieContext>();

            MySqlConnection connection = Connection.OpenConnection();

            MySqlDataReader movieQuery = Connection.Query("SELECT * FROM `Cinema`.`Movies`", connection);

            while (movieQuery.Read())
            {
                allMovies.Add(new MovieContext(
                    movieQuery.GetInt32(0),
                    movieQuery.GetString(1),
                    movieQuery.GetString(2),
                    movieQuery.GetInt32(3)
                    ));
            }

            Connection.CloseConnection(connection);

            return allMovies;
        }

        public void DeleteMovie()
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM `Cinema`.`Movies` WHERE ID = {ID}", connection);
            Connection.CloseConnection(connection);
        }

        public void UpdateMovie(string name, string genre, int duration)
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"UPDATE `Cinema`.`Movies` SET Name = '{name}', Genre = '{genre}', Duration = {duration} WHERE ID = {ID}", connection);
            Connection.CloseConnection(connection);
        }
    }

}
