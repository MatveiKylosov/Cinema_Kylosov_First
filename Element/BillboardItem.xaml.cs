using Cinema_Kylosov.Classes;
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

namespace Cinema_Kylosov.Element
{
    /// <summary>
    /// Логика взаимодействия для BillboardItem.xaml
    /// </summary>
    public partial class BillboardItem : UserControl
    {
        BillboardContext billboard;
        public BillboardItem(BillboardContext x)
        {
            InitializeComponent();
            billboard = x;

            ID.Text = $"{x.ID}";
            Movie.Text = $"{MainWindow.main.AllMovie.Find(f => f.ID == x.MovieID).Name}";
            Time.Text = $"{x.SessionTime.ToString("dd.MM.yyy HH:mm")}";
            Tickets.Text = $"{MainWindow.main.AllTicket.FindAll(f => x.ID == f.BillboardID).Count}";
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.OpenPages(new Pages.BillboardPages(billboard));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            billboard.DeleteBillboard();
        }
    }
}
