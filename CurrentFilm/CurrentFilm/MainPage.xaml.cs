using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;  
namespace CurrentFilm
{

    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            SetTitleBar();
            this.InitializeComponent();
            myFrame.Navigate(typeof(RecentFilm));
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (recentFilm.IsSelected)
            {
                myFrame.Navigate(typeof(RecentFilm));
                navigationTextBlock.Text = "正在热映";
            }
            else if (comingFilm.IsSelected)
            {
                myFrame.Navigate(typeof(ComingFilm));
                navigationTextBlock.Text = "即将上映";
            }
        }

        private void homeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;            
        }
        private static void SetTitleBar()
        {
            var coreTitleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Color.FromArgb(0, 0, 159, 255);
            titleBar.ButtonBackgroundColor = Color.FromArgb(0, 0, 159, 255);
            coreTitleBar.ExtendViewIntoTitleBar = false;
            titleBar.ButtonForegroundColor = Colors.White;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(myFrame.CanGoBack)
            {
                myFrame.GoBack();
            }
        }
    }
}
