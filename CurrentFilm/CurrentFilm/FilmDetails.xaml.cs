using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CurrentFilm.Models;
using CurrentFilm.Services;
using Windows.UI.Xaml.Navigation;
using CurrentFilm.Service;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System;

namespace CurrentFilm
{
    public sealed partial class FilmDetails : Page
    {
        private string movieSource = "";
        private CommentsCollection commentsList;
        private ReviewsCollection reviewsList;
        Subject parameters { get; set; }
        private string key = "apikey=0b2bdeda43b5688921839c8ecb20399b";
        Models.FilmDetails subjectData { get; set; }
        Models.Comment comment { get { return this.DataContext as Models.Comment; } }
        

        public FilmDetails()
        {           
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            parameters = e.Parameter as Subject;          
            string subjectUrl = "https://api.douban.com/v2/movie/subject/";
            subjectUrl += parameters.id;
            string commentsUrl = subjectUrl + "/comments?" + key;
            string reviewsUrl = subjectUrl + "/reviews?" + key;
            reviewsList = new ReviewsCollection(reviewsUrl);
            commentsList = new CommentsCollection(commentsUrl);
            string subjectStream = await HttpServices.SendGetRequestAsync(subjectUrl);
            subjectData = JsonToObject.DataContract<Models.FilmDetails>(subjectStream);             
            Summary.Text = "    " + subjectData.summary;                 
            foreach(var a in parameters.pubdates)
            {
                Pubdate.Text += "/" + a;
            }
            filmDetailsLoadingRing.IsActive = false;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string movieUrl = "https://m.douban.com/movie/subject/";
            movieUrl += parameters.id;
            movieSource += await GetMovie(movieUrl);
            this.Frame.Navigate(typeof(Movie),movieSource);
        }
        private static async Task<string> GetMovie(string movieUrl)
        {
            string pattern1 = "/movie/trailer.*[0-9]\"";
            string pattern2 = "http.*.mp4";
            string temp = await HttpServices.SendGetRequestAsync(movieUrl);
            string regular = RegexService.RegexAdapt(pattern1, temp);
            movieUrl = movieUrl.Remove(20);
            movieUrl += regular.Remove(regular.LastIndexOf("\""));
            temp = await HttpServices.SendGetRequestAsync(movieUrl);
            regular = RegexService.RegexAdapt(pattern2, temp);
            return regular;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Reviews), e.ClickedItem);
        }
    }
}
