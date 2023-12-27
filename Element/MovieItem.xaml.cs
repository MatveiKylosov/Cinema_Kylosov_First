using Cinema_Kylosov.Classes;
using Cinema_Kylosov.Model;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
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
using System.Xml.Linq;

namespace Cinema_Kylosov.Element
{
    /// <summary>
    /// Логика взаимодействия для MovieItem.xaml
    /// </summary>
    public partial class MovieItem : UserControl
    {

        private bool flag = false;
        MovieContext Movie;
        List<TextBox> TB = new List<TextBox>();
        List<TextBlock> TBL = new List<TextBlock>();
        
        public MovieItem(MovieContext movieContext)
        {
            InitializeComponent();
            Movie = movieContext;

            Name.Text = movieContext.Name;
            Genre.Text = movieContext.Genre;
            Duration.Text = $"{movieContext.Duration}";

            TB.Add(TBName);
            TB.Add(TBGenre);
            TB.Add(TBDuration);

            TBL.Add(Name);
            TBL.Add(Genre);
            TBL.Add(Duration);
        }

        private void TextBoxDuration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Movie.DeleteMovie();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            if (!flag)
            {
                TBName.Text = Name.Text;
                TBGenre.Text = Genre.Text;
                TBDuration.Text = Duration.Text;

                TBName.Visibility = TBGenre.Visibility = TBDuration.Visibility = Visibility.Visible;
                Name.Visibility = Genre.Visibility = Duration.Visibility = Visibility.Hidden;
                Save.Content = "Сохранить";
            }
            else
            {
                Movie.UpdateMovie(TBName.Text, TBGenre.Text, int.Parse(TBDuration.Text));
                Name.Text = TBName.Text;
                Genre.Text = TBGenre.Text;
                Duration.Text = TBDuration.Text;

                TBName.Visibility = TBGenre.Visibility = TBDuration.Visibility = Visibility.Hidden;
                Name.Visibility = Genre.Visibility = Duration.Visibility = Visibility.Visible;
                Save.Content = "Изменить";
            }

            flag = !flag;
        }
    }
}
