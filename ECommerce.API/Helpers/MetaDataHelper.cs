using Azure;
using System.Runtime.CompilerServices;

namespace ECommerce.API.Helpers
{
    public static class MetaDataHelper
    {
        public static int TotalCount { get; set; }
        public static int PageSize { get; set; }
        public static int CurrentPage { get; set; }
        public static int TotalPages { get; set; }

        public static void InsertingPaginationParams(int Total, int RecordsPerPage, int Page, int TotalPage)
        {
            TotalCount = Total;
            PageSize= RecordsPerPage;
            CurrentPage = Page;
            TotalPages = TotalPage;
        }

        public static void ResponseHeaders(this HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("TotalPages", MetaDataHelper.TotalPages.ToString());
            httpContext.Response.Headers.Add("CurrentPage", MetaDataHelper.CurrentPage.ToString());
        }
    }
}
