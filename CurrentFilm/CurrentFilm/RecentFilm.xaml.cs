using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CurrentFilm.Services;
using System.Collections.Generic;
using CurrentFilm.Models;
using System.Threading.Tasks;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CurrentFilm
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class RecentFilm : Page
    {
        private RecentFilmCollection films;
        public RecentFilm()
        {
            this.InitializeComponent();
            films = new RecentFilmCollection();
            films.OnLoadMoreStarted += DataLoading;
            films.OnLoadMoreCompleted += DataLoaded;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(FilmDetails),e.ClickedItem);
        }
        public void DataLoading()
        {
            recentFilmLoadingRing.IsActive = true;
        }
        public void DataLoaded()
        {
            recentFilmLoadingRing.IsActive = false;
        }
    }
}
