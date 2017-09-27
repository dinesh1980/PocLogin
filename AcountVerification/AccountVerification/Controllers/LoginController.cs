using AccountVerification;
using AccountVerification.ApiClient;
using AccountVerification.Models;
using CommonModels;
using Login;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace AccountVerification.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {


        
        [HttpGet]
        public ActionResult Login()
        {

            return View();// Redirect("Index");
        }
        [HttpPost]
        public ActionResult Login(Login.LoginModels login)
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
                    FormsAuthentication.Authenticate(login.userName, login.password);
                    CommonUtility.loginDetails = response;
                    Session["username"] = response.displayName;
                    CommonUtility.categories = TextPollApiClient.GetCategoryResponse();
                    CommonUtility.filters = TextPollApiClient.GetAllFilterCategories();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("CustomError", response.Error);
                }
            }
            else
            {
                ModelState.AddModelError("CustomError", "Invalid Username/Password !!");
            }
            return View();
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
                model.userType = UserType.Normal;
                // model.newProfileContact.userId =  Guid.NewGuid().ToString();
                //var client = new RestClient(CommonUtility.ApirUrl + "Polls/Registration");
                //var request = new RestRequest(Method.POST);
                //// request.AddHeader("content-type", "application/json");
                RegistrationResponseModel regResponse = AccountRegistrationApiClient.Register(model);
                //request.AddJsonBody(model);
                ////System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
                //IRestResponse<RegistrationResponseModel> regResponse = client.Execute<RegistrationResponseModel>(request);
                //if (regResponse.StatusCode.ToString() == "OK")
                //{
                Session["UserName"] = model.newProfileContact.firstName + model.newProfileContact.lastName;
                return View("Login");


            }
            return View();
        }

        public ActionResult LoggOff()
        {
            CommonUtility.loginDetails = null;
            return RedirectToAction("Login");
        }

    }
}