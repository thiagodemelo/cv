using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new SemAutorizacaoFilter());
            //filters.Add(new LogErroFilter());
            //filters.Add(new AuthorizeAttribute());
            //filters.Add(new RequireHttpsAttribute());//acesso somento por https
        }
    }
}