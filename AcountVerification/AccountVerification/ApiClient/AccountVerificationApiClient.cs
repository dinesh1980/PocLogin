using AccountVerification.Models;
using CommonModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.ApiClient
{
    public class AccountVerificationApiClient
    {
        public static object ConfigurationManager { get; private set; }

        public static EmailSendStatusResponse SendEmailVerification(string userid, string usertoken, VerificationType type, string baseApiUrl)
        {

            // var apirUrl=  ConfigurationManager.AppSettings["ApiUrl"].ToString()
            var client = new RestClient();
            if (type == VerificationType.Email)
            {
                client.BaseUrl = new Uri(baseApiUrl + "Polls/VerifyEmail");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("version", "1.0");
                request.AddHeader("userid", userid);
                request.AddHeader("token", usertoken);
                request.AddParameter("id", Guid.NewGuid().ToString());

                IRestResponse<EmailSendStatusResponse> response = client.Execute<EmailSendStatusResponse>(request);


                if (response.StatusCode.ToString().ToUpper() == "OK")
                {
                    return response.Data;
                }
                else
                {
                    ErrorDetails errordetail = JsonConvert.DeserializeObject<ErrorDetails>(response.Content);
                    response.Data.Error = errordetail;
                    return response.Data;
                }
              
            }
            return new EmailSendStatusResponse();

        }
    }
    public enum VerificationType
    {
        Email,
        SMS,
        Call
    }

}
