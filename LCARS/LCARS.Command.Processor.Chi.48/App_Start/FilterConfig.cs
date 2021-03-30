using System.Web;
using System.Web.Mvc;

namespace LCARS.Command.Processor.Chi._48
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
