using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthTest.ViewModels;

namespace UserAuthTest.Filters
{
    public class AdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Students"
                && filterContext.ActionDescriptor.ActionName == "Delete"
                && UserVM.FilterAdmin())
            {
                // acess granted
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(new { controller = "Students", action = "Index" }));
            }
            
        }
    }
}