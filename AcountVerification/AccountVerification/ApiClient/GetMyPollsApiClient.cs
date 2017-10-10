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
    public static class GetMyPollsApiClient
    {
        public static IEnumerable<GetMyPoll> GetMyPolls()
        {
            GetMyPollsModel pollsparameter = new GetMyPollsModel();
            pollsparameter.pageSize = 20;
            pollsparameter.pageNumber = 1;

            var client = new RestClient(WebConfigurationManager.AppSettings["APiUrl"] + "Polls/GetMyPolls");
            var request = new RestRequest(Method.POST);
            LoginResponse loginResponse = CommonUtility.loginDetails;
            request.AddHeader("userid", loginResponse.userId);
            request.AddHeader("token", loginResponse.token);
            request.AddJsonBody(pollsparameter);
            //System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
            IRestResponse<List<GetMyPoll>> response = client.Execute<List<GetMyPoll>>(request);
            if (response.StatusCode.ToString().ToUpper() == "OK")
                return response.Data;
            else
                return new List<GetMyPoll>();

        }
    }
}