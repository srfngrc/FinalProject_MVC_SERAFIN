using System.Web;
using System.Web.Mvc;

namespace FinalProject_MVCapp_SERAFIN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
