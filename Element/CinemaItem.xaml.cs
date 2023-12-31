﻿using Cinema_Kylosov.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkingBD;

namespace Cinema_Kylosov.Element
{
    /// <summary>
    /// Логика взаимодействия для CinemaItem.xaml
    /// </summary>
    public partial class CinemaItem : UserControl
    {
        CinemaContext cinema;
        public CinemaItem(CinemaContext x)
        {
            InitializeComponent();
            cinema = x;
            Name.Text = x.Name;
            Number_of_Halls.Text = $"{x.NumberOfHalls}";
            Number_of_Seats.Text = $"{x.NumberOfSeats}";
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.OpenPages(new Pages.CinemaPage(cinema));

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            cinema.DeleteCinema();
            MainWindow.main.UpdateLists();
            MainWindow.main.CreateView();
        }
    }
}
