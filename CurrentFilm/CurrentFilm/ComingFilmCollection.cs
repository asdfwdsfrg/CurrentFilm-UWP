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
    class ComingFilmCollection: IncrementalLoadingColllection<Models.Subject>
    {
        private int _total;
        private int _current;
        public delegate void LoadMoreStarted();
        public delegate void LoadMoreCompleted();

        public event LoadMoreStarted OnLoadMoreStarted;
        public event LoadMoreCompleted OnLoadMoreCompleted;
        public ComingFilmCollection()
        {
            this.HasMoreItems = true;
            _current = 0;
        }
        protected override async Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, int count)
        {
            this.OnLoadMoreStarted();
            Models.Film data = new Film();
            count = 6;
            data = await Services.HttpServices.GetComingFilmAsync(_current, count);
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
    }
}
