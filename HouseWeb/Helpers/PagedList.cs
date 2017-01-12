using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseWeb.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PagedList(List<T> source, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = source.Count;
            this.TotalPages =(int)Math.Ceiling(TotalCount / (double)pageSize);
            this.AddRange(source.Skip((pageIndex - 1) * PageSize).Take(PageSize));
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}