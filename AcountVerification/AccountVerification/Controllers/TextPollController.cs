using AccountVerification.ApiClient;
using AccountVerification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountVerification.Controllers
{
    public class TextPollController : BaseController
    {
        // GET: TextPoll
        public ActionResult CreateTextPoll(CreateTextPollRequest model)
        {
         

            model.Categories = new SelectList(CommonUtility.categories, "catId", "catName").ToList<SelectListItem>();
           
            var filter = CommonUtility.filters;
            if (ModelState.IsValid)
            {
                model.catName = CommonUtility.categories.Where(c => c.catId == model.catId).FirstOrDefault().catName;
                System.DateTime today = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(30, 0, 0, model.lifeTimeInSeconds);
                System.DateTime expiryDate = today.Add(duration);
                model.expirationDate = expiryDate;
                //model.filterNameValue = new Filternamevalue[1];
                //model.filterNameValue[0] = new Filternamevalue { filterName = "Department", filterValue = "Department" };
                model = TextPollApiClient.CreateTextPoll(model);
                return View(model);
            }
            return View();
        }
    }
}