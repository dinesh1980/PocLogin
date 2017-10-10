using AccountVerification.Models;
using Login;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AccountVerification.ApiClient
{
    public static class GetPollResultApiClient
    {
        public static List<GetPollResult> GetPollResults(int pollId)
        {   
          var client = new RestClient(WebConfigurationManager.AppSettings["APiUrl"] + "Polls/GetPollResult");
            var request = new RestRequest(Method.POST);
            LoginResponse loginResponse = CommonUtility.loginDetails;
            request.AddHeader("userid", loginResponse.userId);
            request.AddHeader("token", loginResponse.token);
            //System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
            IRestResponse<List<GetPollResult>> response = client.Execute<List<GetPollResult>>(request);
            if (response.StatusCode.ToString().ToUpper() == "OK")
                return response.Data;
            else
                return new List<GetPollResult>();

        }
    }
}