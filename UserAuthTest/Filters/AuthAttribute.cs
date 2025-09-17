using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthTest.ViewModels;

namespace UserAuthTest.Filters
{
    public class AuthAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Students" && UserVM.FilterAuth())
            {
                // access granted
            }
            else // access Denied
            {
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
               
            }
        }
    }
}