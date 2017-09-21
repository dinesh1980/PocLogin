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

    public class LoginController : Controller
    {


        [HttpGet]
        public ActionResult Login()
        {

            return View();// Redirect("Index");
        }
        [HttpPost]
        public ActionResult Login(LoginRequestResponseViewModel login)
        {
            login.LoginRequest.deviceId = Guid.NewGuid().ToString();// "d4bc2ea4-1868-469b-a6c3-0f518e4f0218";
            login.LoginRequest.isPartner = false;
            Newdevice obj = new Newdevice();
            obj.deviceVersion = Request.Browser.Version;// "59.0.3071.115";
            obj.browserVersion = Request.Browser.Version;// "59.0.3071.115";
            obj.browserName = Request.Browser.Browser;// "Chrome";
            obj.browserUserAgent = Request.UserAgent;// "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 59.0.3071.115 Safari / 537.36";
            obj.snsType = "Web";
            obj.deviceName = "Win32";
            obj.devicePlatform = Request.Browser.Platform;// "Windows";
            obj.snsDeviceId = Guid.NewGuid().ToString();// "d4bc2ea4-1868-469b-a6c3-0f518e4f0218";
            login.LoginRequest.newDevice = obj;

            var client = new RestClient(CommonUtility.ApirUrl + "Polls/Login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("version", "1.0");

            request.AddJsonBody(login.LoginRequest);

            IRestResponse<LoginResponse> response = client.Execute<LoginResponse>(request);


            if (response.StatusCode.ToString() == "OK" && response.Data.userId != null)
            {
                ViewBag.LoggedInUserName = response.Data.displayName;
                LoginRequestResponseViewModel model = new LoginRequestResponseViewModel();
                model.LoginRequest = login.LoginRequest;
                model.LoginResponse = response.Data;
                return View(model);
            }          

            return View();
        }             

    }
}