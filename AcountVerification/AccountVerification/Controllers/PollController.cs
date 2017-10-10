using AccountVerification.ApiClient;
using AccountVerification.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountVerification.Controllers
{
    public class PollController : Controller
    {
        // GET: Poll
        public ActionResult GetPollResult(GeyMyPollRequest poll)
        {
            var data = GetPollResultApiClient.GetPollResults(poll);
            return View(data);
        }

        public ActionResult GetMyPoll()
        {
            var data = GetMyPollsApiClient.GetMyPolls();
            return View(data);
        }
    }
}