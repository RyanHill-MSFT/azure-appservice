﻿using System.Web;
using System.Web.Mvc;

namespace LCARS.Console.Interface.Chi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
