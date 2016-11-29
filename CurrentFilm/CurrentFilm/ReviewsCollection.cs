using CurrentFilm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CurrentFilm
{
    class ReviewsCollection : IncrementalLoadingColllection<Models.Review>
    {
        private int _total;
        private int _nextstart;
        private string url;
        private Models.Reviews data;
        public delegate void LoadMoreStarted();
        public delegate void LoadMoreCompleted();

        public event LoadMoreStarted OnLoadMoreStarted;
        public event LoadMoreCompleted OnLoadMoreCompleted;
        public ReviewsCollection(string url)
        {
            this.url = url;
            this.HasMoreItems = true;
            _nextstart = 0;
        }
        protected override async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, int count)
        {
            data = new Models.Reviews();
            count = 10;
            data = await Services.HttpServices.GetReviewsAsync(_nextstart, count, url);
            _total = data.total;
            _nextstart = data.next_start;
            foreach (var a in data.reviews)
            {
                this.Add(a);
            }
            if (_nextstart >= _total)
            {
                HasMoreItems = false;
            }
            return new LoadMoreItemsResult { Count = (uint)this.Count };
        }

        private void RecentFilmCollection_OnLoadMoreStarted(uint count)
        {
            throw new System.NotImplementedException();
        }
    }
}
