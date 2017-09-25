using AccountVerification.ApiClient;
using AccountVerification.Models;
using Login;
using System.Web.Mvc;

namespace AccountVerification.Controllers
{
    // [Authorize]
    public class HomeController :BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("LoadVerificationTypeView", new { type = "Email" });
        }


        //[HttpPost]
        //public ActionResult SendVerificationEmail(AccountVerificationRequestResponseViewModel request)
        //{
        //    ViewBag.ButtonText = "ResendEmail";
        //    LoginResponse loginResponse = CommonUtility.loginDetails;

        //    AccountVerificationResponse emailResponse = AccountVerificationApiClient.SendEmailVerification(loginResponse.userId, loginResponse.token, "Email", CommonUtility.ApirUrl);

        //    if (emailResponse.Error == null)
        //    {
        //        request.accountVerificationResponse = emailResponse;
        //        // return View("Index", new AccountVerification.Models.AccountVerificationResponse() { status = emailResponse.status, statusMessage = emailResponse.statusMessage });
        //        return View("Index", request);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("CustomError", emailResponse.Error.message + " :" + emailResponse.statusMessage);
        //    }
        //    return View();
        //}

        public ActionResult LoadVerificationTypeView(string type)
        {
            if (type == VerificationType.Email.ToString())
            {
                return View("EmailVerification");

            }
            else if (type == VerificationType.ResendEmail.ToString())
            {
                return View("ResendEmailVerification");
            }
            else if (type == VerificationType.SMS.ToString())
            {
                return View("ResendVerificationCodeViaSMS");
            }
            else if (type == VerificationType.Call.ToString())
            {
                return View("ResendVerificationCodeViaCall");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailVerification(AccountVerificationResponse requstResponse)
        {
            requstResponse = AccountVerificationApiClient.SendEmailVerification(null, VerificationType.Email, CommonUtility.ApirUrl);
            ViewBag.Response = requstResponse;
            return View("EmailVerification", requstResponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResendEmailVerification(ReSendVerifyEmailModel requstResponse)
        {
            LoginResponse loginResponse = CommonUtility.loginDetails;
            requstResponse.response = AccountVerificationApiClient.SendEmailVerification(requstResponse, VerificationType.ResendEmail, CommonUtility.ApirUrl, requstResponse.EmailAddress);
            return View("ResendEmailVerification", requstResponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResendVerificationCodeViaSMS(SendVerificationCode requstResponse)
        {
            LoginResponse loginResponse = CommonUtility.loginDetails;
            requstResponse.response = AccountVerificationApiClient.SendEmailVerification(requstResponse, VerificationType.SMS, CommonUtility.ApirUrl, "");
            return View("ResendVerificationCodeViaSMS", requstResponse);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResendVerificationCodeViaCall(SendVerificationCode requstResponse)
        {
            LoginResponse loginResponse = CommonUtility.loginDetails;
            requstResponse.response = AccountVerificationApiClient.SendEmailVerification(requstResponse, VerificationType.Call, CommonUtility.ApirUrl, "");
            return View("ResendVerificationCodeViaCall", requstResponse);
        }

       
    }
}