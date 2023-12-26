using Cinema_Kylosov.Classes;
using Cinema_Kylosov.Element;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Cinema_Kylosov
{
    public partial class MainWindow : Window
    {
        public List<CinemaContext> AllCinema;
        public List<MovieContext> AllMovie;
        public List<BillboardContext> AllBillboard;
        public List<TicketContext> AllTicket;

        static public MainWindow main;

        public MainWindow()
        {
            InitializeComponent();
            main = this;
            UpdateLists();
            CreateView();
        }
    
    public void UpdateLists()
        {
            AllCinema = CinemaContext.AllCinemas();
            AllMovie = MovieContext.AllMovies();
            AllBillboard = BillboardContext.AllBillboards();
            AllTicket = TicketContext.AllTickets();
        }

        public void CreateView()
        {
            parent.Children.Clear();
            foreach (var x in AllCinema)
                parent.Children.Add(new Element.CinemaItem(x));
            //Возможность добавления нового кинотеатра
        }

        public void OpenPages(Page page)
        {
            frame.Navigate(page);

            frame.Visibility = Visibility.Visible;
        }

        public void ClosePages()
        {
            NamePage.Content = "Кинотеатры";
            frame.Visibility = Visibility.Hidden;
        }
    }
}
