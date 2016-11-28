using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CurrentFilm
{
    class CommentsCollection : IncrementalLoadingColllection<Models.Comment>
    {      
            private int _total;
            private int _current;
            public delegate void LoadMoreStarted();
            public delegate void LoadMoreCompleted();

            public event LoadMoreStarted OnLoadMoreStarted;
            public event LoadMoreCompleted OnLoadMoreCompleted;
            public CommentsCollection()
            {
                this.HasMoreItems = true;
                _current = 0;
            }
            protected override async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, int count)
            {
                this.OnLoadMoreStarted();
                Models.
                count = 6;
                data = await Services.HttpServices.GetRecentFilmAsync(_current, count);
                _total = data.total;
                _current += count;
                foreach (var a in data.subjects)
                {
                    this.Add(a);
                }
                if (_current >= _total)
                {
                    HasMoreItems = false;
                }
                this.OnLoadMoreCompleted();
                return new LoadMoreItemsResult { Count = (uint)this.Count };
            }

            private void RecentFilmCollection_OnLoadMoreStarted(uint count)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
