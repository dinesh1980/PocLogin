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
        public ActionResult CreateTextPoll()
        {
            CreateViewBagPropertyForCategory();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTextPoll(CreateTextPollRequest model)
        {
            CreateViewBagPropertyForCategory();
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

        public ActionResult CreateBestTextPoll()
        {
            CreateViewBagPropertyForCategory();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBestTextPoll(CreateBestTextPoll model)
        {
            CreateViewBagPropertyForCategory();

           // var filter = CommonUtility.filters;
            if (ModelState.IsValid)
            {
                model.catName = CommonUtility.categories.Where(c => c.catId == model.catId).FirstOrDefault().catName;
                System.DateTime today = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(30, 0, 0, model.lifeTimeInSeconds);
                System.DateTime expiryDate = today.Add(duration);
                model.expirationDate = expiryDate;
                //model.filterNameValue = new Filternamevalue[1];
                //model.filterNameValue[0] = new Filternamevalue { filterName = "Department", filterValue = "Department" };
                model = TextPollApiClient.CreateBestTextPoll(model);
                return View(model);
            }
            return View();
        }


        public ActionResult CreateSingleImagePoll()
        {
            CreateViewBagPropertyForCategory();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSingleImagePoll(CreateSingleImagePollRequest model)
        {
            CreateViewBagPropertyForCategory();

            // var filter = CommonUtility.filters;
            if (ModelState.IsValid)
            {
                model.catName = CommonUtility.categories.Where(c => c.catId == model.catId).FirstOrDefault().catName;
                System.DateTime today = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(30, 0, 0, model.lifeTimeInSeconds);
                System.DateTime expiryDate = today.Add(duration);
                model.expirationDate = expiryDate;
                //model.filterNameValue = new Filternamevalue[1];
                //model.filterNameValue[0] = new Filternamevalue { filterName = "Department", filterValue = "Department" };
                model = TextPollApiClient.CreateSingleImagePoll(model);
                return View(model);
            }
            return View();
        }


        public ActionResult CreateBestImagePoll()
        {
            CreateViewBagPropertyForCategory();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBestImagePoll(CreateSingleImagePollRequest model)
        {
            CreateViewBagPropertyForCategory();

            // var filter = CommonUtility.filters;
            if (ModelState.IsValid)
            {
                model.catName = CommonUtility.categories.Where(c => c.catId == model.catId).FirstOrDefault().catName;
                System.DateTime today = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(30, 0, 0, model.lifeTimeInSeconds);
                System.DateTime expiryDate = today.Add(duration);
                model.expirationDate = expiryDate;
                //model.filterNameValue = new Filternamevalue[1];
                //model.filterNameValue[0] = new Filternamevalue { filterName = "Department", filterValue = "Department" };
                model = TextPollApiClient.CreateSingleImagePoll(model);
                return View(model);
            }
            return View();
        }



        private void CreateViewBagPropertyForCategory()
        {
            ViewBag.Categories = new SelectList(CommonUtility.categories, "catId", "catName", CommonUtility.categories.FirstOrDefault().catId).ToList<SelectListItem>();
        }
    }
}