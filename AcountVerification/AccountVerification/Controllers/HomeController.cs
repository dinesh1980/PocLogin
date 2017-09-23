using AccountVerification.ApiClient;
using AccountVerification.Models;
using Login;
using System.Web.Mvc;

namespace AccountVerification.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ButtonText = "SendEmail";
            return View();
        }
        public ActionResult SendVerificationEmail()
        {
            ViewBag.ButtonText = "ResendEmail";
            LoginResponse loginResponse = CommonUtility.loginDetails;

            EmailSendStatusResponse emailResponse = AccountVerificationApiClient.SendEmailVerification(loginResponse.userId, loginResponse.token, VerificationType.Email, CommonUtility.ApirUrl);

            if (emailResponse.Error == null)
            {
                return View("Index", new AccountVerification.Models.EmailSendStatusResponse() { status = emailResponse.status, statusMessage = emailResponse.statusMessage });
            }
            else
            {
                ModelState.AddModelError("CustomError", emailResponse.Error.message+" :"+ emailResponse.statusMessage);
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
    }
}