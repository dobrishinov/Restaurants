using Restaurants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurants.Filter
{
    public class AdminAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext
    filterContext)
        {
            if (AuthenticationManager.LoggedUser==null || AuthenticationManager.LoggedUser.AdminStatus==false)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
            }
        }
    }
}