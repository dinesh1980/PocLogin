﻿using POC.common;
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
            return RedirectToAction("Register");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                Newdevice obj = new Newdevice();
                obj.deviceVersion = Request.Browser.Version;// "59.0.3071.115";
                obj.browserVersion = Request.Browser.Version;// "59.0.3071.115";
                obj.browserName = Request.Browser.Browser;// "Chrome";
                obj.browserUserAgent = Request.UserAgent;// "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 59.0.3071.115 Safari / 537.36";
                obj.snsType = "Web";
                obj.deviceName = "Win32";
                obj.devicePlatform = Request.Browser.Platform;// "Windows";
                obj.snsDeviceId = Guid.NewGuid().ToString();// "d4bc2ea4-1868-469b-a6c3-0f518e4f0218";
                model.newDevice = obj;
               // model.id = Guid.NewGuid().ToString();
                model.newProfileContact.ownerId = Guid.NewGuid().ToString();
               // model.newProfileContact.userId =  Guid.NewGuid().ToString();
                var client = new RestClient(CommonUtility.ApirUrl + "Polls/Registration");
                var request = new RestRequest(Method.POST);
               // request.AddHeader("content-type", "application/json");
                
                request.AddJsonBody(model);
                //System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
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