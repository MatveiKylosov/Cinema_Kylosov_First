using Cinema_Kylosov.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для BillboardPages.xaml
    /// </summary>
    public partial class BillboardPages : Page
    {
        Classes.BillboardContext billboard;
        public BillboardPages(Classes.BillboardContext b)
        {
            InitializeComponent();
            billboard = b;

            ID.Text = $"{b.ID}";
            Date.Text = $"{b.SessionTime.ToString("dd.MM.yyyy HH:mm")}";
            Price.Text = $"{b.TicketPrice}";
            
            foreach(MovieContext x in MainWindow.main.AllMovie)
                Movie.Items.Add(x.Name);

            Movie.SelectedItem = MainWindow.main.AllMovie.Find(x => x.ID == b.MovieID).Name;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DateTime date;
            bool isValid = DateTime.TryParseExact(Date.Text, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            if (isValid)
            {
                billboard.UpdateBillboard(MainWindow.main.AllMovie.Find(x => x.Name == Movie.SelectedItem.ToString()).ID, date, int.Parse(Price.Text));
                //добавление билетов
            }
            else
                MessageBox.Show($"Неправильный формат даты!");

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.GoBack();
        }

        private void Price_Change(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
