using CurrentFilm;
using Windows.UI.Xaml.Controls;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace CurrentFilm
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ComingFilm : Page
    {
        private ComingFilmCollection comingFilms;        
        public ComingFilm()
        {
            comingFilms = new ComingFilmCollection();
            comingFilms.OnLoadMoreStarted += DataLoading;
            comingFilms.OnLoadMoreCompleted += DataLoaded;
            this.InitializeComponent();
        }
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(FilmDetails), e.ClickedItem);
        }
        public void DataLoading()
        {
            comingFilmLoadingRing.IsActive = true;
        }
        public void DataLoaded()
        {
            comingFilmLoadingRing.IsActive = false;
        }
    }
}