using Newtonsoft.Json;
using POC.common;
using POC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("GetProfile");
        }

        //[HttpGet]
        //public ActionResult GetProfile()
        //{
        //    return View();
        //}
        [HttpGet]
        [Route("GetProfile/{UserId}",  Name = "EditProfile")]
        public ActionResult UpdateProfile(string UserId)
        {
            if (!string.IsNullOrEmpty(UserId))
            {             
                GetPublicProfileRequest obj = new GetPublicProfileRequest();
                obj.id = UserId;
                obj.viewAll = true;
                var client = new RestClient(CommonUtility.ApirUrl + "PublicPoll/ViewPublicProfile");
                var request = new RestRequest(Method.POST);
                request.AddJsonBody(obj);
                request.AddHeader("content-type", "application/json");
                IRestResponse<ViewProfileModel> response = client.Execute<ViewProfileModel>(request);
                ViewProfileModel profile = new Models.ViewProfileModel();
                if (response.StatusCode.ToString() == "OK")
                {
                    // profile = response.Data;
                    profile = JsonConvert.DeserializeObject<ViewProfileModel>(response.Content);
                    System.IO.File.WriteAllText(@"D:\ProfileResponse.json", Newtonsoft.Json.JsonConvert.SerializeObject(profile));
                    if (profile.gender == "M")
                    {
                        profile.gender = "Male";
                    }
                    if (profile.gender == "F")
                    {
                        profile.gender = "Female";
                    }
                }
                return View("UpdateProfile", profile);
            }
            else
            {
                return View();
            }
        }
        public ActionResult UpdateProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProfile(ViewProfileModel model)
        {
            if (ModelState.IsValid)
            {

                LoginResponse userdetails = Session["UserDetails"] as LoginResponse;
                var client = new RestClient(CommonUtility.ApirUrl + "Polls/UpdateProfile");
                var request = new RestRequest(Method.POST);
                request.AddHeader("UserId", userdetails.userId);
                request.AddHeader("token", userdetails.token);
                request.AddJsonBody(model);
                System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
                IRestResponse æ = client.Execute(request);

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ProfileContact()
        {
            return View();
        }
    }
}