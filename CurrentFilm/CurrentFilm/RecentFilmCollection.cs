using System.Threading.Tasks;
using CurrentFilm.Models;
using System.Threading;
using Windows.UI.Xaml.Data;

namespace CurrentFilm
{
    class  RecentFilmCollection : IncrementalLoadingColllection<Models.Subject>
    {
        private int _total;
        private int _current;
        public delegate void LoadMoreStarted();
        public delegate void LoadMoreCompleted();

        public event LoadMoreStarted OnLoadMoreStarted;
        public event LoadMoreCompleted OnLoadMoreCompleted;
        public RecentFilmCollection()
        {
            this.HasMoreItems = true;
            _current = 0;            
        }
        protected override async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, int count)
        {
            this.OnLoadMoreStarted();
            Models.Film data = new Film();
            count = 6;
            data = await Services.HttpServices.GetRecentFilmAsync(_current, count);
            _total = data.total;
            _current += count;
            foreach(var a in data.subjects)
            {
                this.Add(a);
            }
            if(_current >= _total)
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
  