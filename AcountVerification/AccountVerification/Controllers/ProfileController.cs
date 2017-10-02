using Login;
using Newtonsoft.Json;


using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountVerification.Models;
using AccountVerification.ApiClient;

namespace AccountVerification.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("GetProfile");
        }

        public ActionResult ViewProfile(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                UserProfileResponse userprofile = UserProfileApiClient.GetUserProfile(userId);

                return View(userprofile);
            }

            return View();



        }


        [HttpGet]
        [Route("GetProfile/{UserId}", Name = "EditProfile")]
        public ActionResult GetProfile(string UserId)
        {
            if (!string.IsNullOrEmpty(UserId))
            {
                UserProfileResponse userprofile = UserProfileApiClient.GetUserProfile(UserId);

                return View("UpdateProfile", userprofile);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(UserProfileResponse model)
        {
            if (ModelState.IsValid)
            {

                //LoginResponse userdetails = Session["UserDetails"] as LoginResponse;
                //var client = new RestClient(CommonUtility.ApirUrl + "Polls/UpdateProfile");
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("UserId", userdetails.userId);
                //request.AddHeader("token", userdetails.token);
                //request.AddJsonBody(model);
                //System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
                //IRestResponse æ = client.Execute(request);
                string error = String.Empty;
                UserProfileResponse updatedProfile = UserProfileApiClient.UpdateProfile(model, ref error);
                if (string.IsNullOrEmpty(error))
                    return View(updatedProfile);
                else
                {
                    ModelState.AddModelError("CustomError", error);
                }
            }

            return View();
        }


    }
}