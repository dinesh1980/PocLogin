using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountVerification.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CommonUtility.loginDetails == null)
                filterContext.HttpContext.Response.Redirect("~/Login");

        }
    }
}