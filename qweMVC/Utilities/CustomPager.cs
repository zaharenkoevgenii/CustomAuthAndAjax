using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qweMVC.Utilities
{
    public class CustomPager<T>
    {
        public CustomPager (List<T> items,int curPage,int pageSize )
        {
            CurrentPage = curPage;
            PageCapacity = pageSize;
            Items = items;
            PagesNumber = items.Count%pageSize == 0 ? items.Count/pageSize : items.Count/pageSize + 1;
        }
        public int PagesNumber { get; set; }
        public int CurrentPage { get; set; }
        public int PageCapacity { get; set; }
        public List<T> Items { get; set; }

    }
}