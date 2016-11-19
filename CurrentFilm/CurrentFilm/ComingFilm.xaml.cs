using CurrentFilm.Models;
using CurrentFilm.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CurrentFilm
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ComingFilm : Page
    {
        private ObservableCollection<Models.Subject> comingFilms;
        public ComingFilm()
        {
            comingFilms = new ObservableCollection<Models.Subject>();
            this.InitializeComponent();
            comingFilmLoadingRing.IsActive = true;
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> paramaters = new Dictionary<string, string>();
            paramaters.Add("city", await LocationService.GetCity());
            string uri = Services.UriBuilder.BuildUri(Models.ApiUri.doubanComingFilmApiUri, paramaters);
            string x = await Service.UriRequest.SendGetRequestAsync(uri);
            Models.Film data = Service.JsonToObject.DataContract<Models.Film>(x);
            foreach (var a in data.subjects)
            {
                comingFilms.Add(a);
            }
            comingFilmLoadingRing.IsActive = false;
        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(FilmDetails), e.ClickedItem);
        }
    }
}