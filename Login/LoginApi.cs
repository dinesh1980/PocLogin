using CommonModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Login
{
    public static class LoginApi
    {
        public static LoginResponse PollsLogin(LoginModels login)
        {
            var client = new RestClient(WebConfigurationManager.AppSettings["APiUrl"] + "Polls/Login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("version", "1.0");
            request.AddJsonBody(login);
            IRestResponse<LoginResponse> response = client.Execute<LoginResponse>(request);

            if (response.StatusCode.ToString() == "OK" && response.Data.userId != null)
            {
                return response.Data;
            }
            else
            {
                return response.Data;
            }
        }
    }
}
