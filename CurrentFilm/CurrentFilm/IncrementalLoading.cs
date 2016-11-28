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
            //{
            //    try
            //    {
            //        // 加载开始事件
            //        if (this.OnLoadMoreStarted != null)
            //        {
            //            this.OnLoadMoreStarted(count);
            //        }
            //        // 加载完成事件
            //        if (this.OnLoadMoreCompleted != null)
            //        {
            //            this.OnLoadMoreCompleted(items == null ? 0 : items.Count);
            //        }

            //        return new LoadMoreItemsResult { Count = items == null ? 0 : (uint)items.Count };
            //    }
            //    finally
            //    {
            //        _busy = false;
            //    }
            //}


            /// <summary>
            /// 将新项目添加进来，之所以是virtual的是为了方便特殊要求，比如不重复之类的
            /// </summary>
            protected virtual void AddItems(IList<T> items)
            {
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        this.Add(item);
                    }
                }
            }

            protected bool _busy = false;
        }
}
