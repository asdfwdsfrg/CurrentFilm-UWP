using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
namespace CurrentFilm
{
    public sealed partial class Movie : Page
    {
        public Movie()
        { 
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string movieSource = e.Parameter as string;
            mediaPlayer.Source = new System.Uri(movieSource);
            AdaptiveMediaSourceCreationResult result = await AdaptiveMediaSource.CreateFromUriAsync(new System.Uri(movieSource,UriKind.Absolute));
            if(result.Status == AdaptiveMediaSourceCreationStatus.Success)
            {
                var astream = result.MediaSource;
                var ttmSource = TimedTextSource.CreateFromUri(new Uri(movieSource));
                var mediaSource = MediaSource.CreateFromAdaptiveMediaSource(astream);
                mediaSource.ExternalTimedTextSources.Add(ttmSource);
                var mediaElement = new MediaPlaybackItem(mediaSource);
                mediaPlayer.SetPlaybackSource(mediaElement);
                movieLoadingRing.IsActive = false;
            }              
        }
        
    }
}
