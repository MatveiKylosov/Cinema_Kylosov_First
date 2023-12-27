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

namespace Cinema_Kylosov.Pages
{
    /// <summary>
    /// Логика взаимодействия для BillboardPages.xaml
    /// </summary>
    public partial class BillboardPages : Page
    {
        public BillboardPages(Classes.BillboardContext b)
        {
            InitializeComponent();
            ID.Text = $"{b.ID}";
            Date.Text = $"{b.SessionTime.ToString("dd.MM.yyyy HH.mm")}";
            Price.Text = $"{b.TicketPrice}";
            foreach(MovieContext x in MainWindow.main.AllMovie)
                Movie.Items.Add(x.Name);
            
            
/*
            foreach (Classes.BillboardContext x in MainWindow.main.AllBillboard)
            {
                parent.Children.Add(new Element.);
            }*/
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
