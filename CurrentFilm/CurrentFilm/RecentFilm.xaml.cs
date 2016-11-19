using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CurrentFilm.Services;
using System.Collections.Generic;
using CurrentFilm.Models;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CurrentFilm
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class RecentFilm : Page
    {
        private ObservableCollection<Models.Subject> films;
        public RecentFilm()
        {
            this.InitializeComponent();
            recentFilmLoadingRing.IsActive = true;
            films = new ObservableCollection<Models.Subject>();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CoordinateString longAndLat = await LocationService.GetLoction();
            Dictionary<string, string> paramaters = new Dictionary<string, string>();
            paramaters.Add("city",await LocationService.GetCity());
            paramaters.Add("count", "40");
            string uri = UriBuilder.BuildUri(Models.ApiUri.doubanRecentFilmApiUri, paramaters);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            string x = await Service.UriRequest.SendGetRequestAsync(uri);
            Models.Film data = Service.JsonToObject.DataContract<Models.Film>(x);
            foreach(var a in data.subjects)
            {
                films.Add(a);
            }
            recentFilmLoadingRing.IsActive = false;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(FilmDetails),e.ClickedItem);
        }
    }
}
