using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using System.Collections.ObjectModel;
using Windows.Foundation;
using System.Threading;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CurrentFilm
{
        public abstract class IncrementalLoadingColllection<T> : ObservableCollection<T>, ISupportIncrementalLoading
        {
            public bool HasMoreItems
            {
                  get;set;
            }

            public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
            {
                return AsyncInfo.Run((c) => LoadMoreItemsAsync(c, (int)count));
            }

             protected abstract Task<LoadMoreItemsResult> LoadMoreItemsAsync(CancellationToken c, int count);
          protected bool _busy = false;
        }
}
