using Cinema_Kylosov.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Cinema_Kylosov.Pages
{
    /// <summary>
    /// Логика взаимодействия для CinemaPage.xaml
    /// </summary>
    public partial class CinemaPage : Page
    {
        CinemaContext cinema;

        public CinemaPage(CinemaContext x)
        {
            InitializeComponent();
            cinema = x;
            Name.Text = x.Name;
            Number_of_Halls.Text = $"{x.NumberOfHalls}";
            Number_of_Seats.Text = $"{x.NumberOfSeats}";

            foreach (BillboardContext f in MainWindow.main.AllBillboard.FindAll(f => f.CinemaID == x.ID))
                parent.Children.Add(new Element.BillboardItem(f));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            cinema.UpdateCinema(int.Parse(Number_of_Halls.Text), int.Parse(Number_of_Seats.Text));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.ClosePages();
        }


        private void NOH(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void NOS(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
