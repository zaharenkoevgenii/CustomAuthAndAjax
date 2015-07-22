using System;
using System.Globalization;
using System.Text;
using System.Web.Mvc;
using qweMVC.Models;

namespace qweMVC.Utilities.Helpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pagingInfo,Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (var i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.MergeAttribute("data-ajax", "true");
                tag.MergeAttribute("data-ajax-method", "GET");
                tag.MergeAttribute("data-ajax-mode", "replace");
                tag.MergeAttribute("data-ajax-update", "#targetList");
                tag.MergeAttribute("data-ajax-success", "answer");
                tag.InnerHtml = i.ToString(CultureInfo.InvariantCulture);
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("mybutton2");
                result.Append(tag);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}