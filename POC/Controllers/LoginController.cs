using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login;
using CommonModels;

namespace POC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Logins

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModels login)
        {
            if (ModelState.IsValid)
            {
                login.deviceId = Guid.NewGuid().ToString();// "d4bc2ea4-1868-469b-a6c3-0f518e4f0218";
                login.isPartner = false;
                Newdevice obj = new Newdevice();
                obj.deviceVersion = Request.Browser.Version;// "59.0.3071.115";
                obj.browserVersion = Request.Browser.Version;// "59.0.3071.115";
                obj.browserName = Request.Browser.Browser;// "Chrome";
                obj.browserUserAgent = Request.UserAgent;// "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 59.0.3071.115 Safari / 537.36";
                obj.snsType = "Web";
                obj.deviceName = "Win32";
                obj.devicePlatform = Request.Browser.Platform;// "Windows";
                obj.snsDeviceId = Guid.NewGuid().ToString();// "d4bc2ea4-1868-469b-a6c3-0f518e4f0218";
                login.newDevice = obj;
                LoginResponse response = new LoginResponse();
                response = LoginApi.PollsLogin(login);
                if (response.userId != null)
                {
                    Session["UserDetails"] = response;
                    Session["username"] = response.displayName;
                    //  LoggedInUserDetails.Username = response.displayName;
                    return RedirectToAction("Welcome");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Username/Password !!");
            }
            return View();
        }
    }
}