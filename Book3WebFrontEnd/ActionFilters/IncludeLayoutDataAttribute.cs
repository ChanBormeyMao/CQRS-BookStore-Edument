using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book3WebFrontEnd.ActionFilters
{
    public class IncludeLayoutDataAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                var bag = (filterContext.Result as ViewResult).ViewBag;
                bag.Books = StaticData.Books;
                bag.Users = StaticData.Users;
                bag.Reservatons = StaticData.Reservations;
            }
        }
    }
}