using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPF_LoginForm
{
    /// <summary>
    /// Interaction logic for SearchUC.xaml
    /// </summary>
    /// 

    public partial class SearchUC : UserControl,INotifyPropertyChanged
    {

        private string _poster;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Poster
        {
            get { return this._poster; }
            set
            {
                if (!string.Equals(this._poster, value))
                {
                    this._poster = value;
                    this.OnPropertyChanged();
                }
            }
        }


        public SearchUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SendRequest request = new SendRequest();
            if(searchedtxtb.Text.Length>1)
            {
                Poster = request.GetPoster(searchedtxtb.Text);
                Title.Text = request.GetTitle(searchedtxtb.Text);
                Genre.Content = request.GetGenre(searchedtxtb.Text);
                Plot.Text = request.GetPlot(searchedtxtb.Text);
            }
            addtofav.Visibility = Visibility.Visible;
        }

        private void addtofav_Click(object sender, RoutedEventArgs e)
        {
            var movie = new MovieUC();
            var fav = new FavoritesUC();
            SendRequest request = new SendRequest();
            if(searchedtxtb.Text.Length>1)
            {
                movie.Title.Content = request.GetTitle(searchedtxtb.Text); 
            }
            fav.MyPanel.Children.Add(movie);
        }
    }
}
