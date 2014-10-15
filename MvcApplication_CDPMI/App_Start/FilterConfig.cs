using System.Web;
using System.Web.Mvc;

namespace MvcApplication_CDPMI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}