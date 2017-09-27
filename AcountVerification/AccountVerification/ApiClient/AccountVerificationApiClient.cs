using AccountVerification.Models;
using CommonModels;
using Login;
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

        public static GeneralApiResponse SendEmailVerification(IVerificationResponse verificationModel, VerificationType type, string baseApiUrl, string emailAddress = "")
        {
            IRestResponse<GeneralApiResponse> response = null;
            LoginResponse loginResponse = CommonUtility.loginDetails;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("version", "1.0");
            request.AddHeader("userid", loginResponse.userId);
            request.AddHeader("token", loginResponse.token);
            var client = new RestClient();
            if (type == VerificationType.Email)
            {
                client.BaseUrl = new Uri(baseApiUrl + "Polls/VerifyEmail");
                request.AddParameter("id", Guid.NewGuid().ToString());
                response = client.Execute<GeneralApiResponse>(request);
            }
            if (type == VerificationType.ResendEmail)
            {
                ReSendVerifyEmailModel model = verificationModel as ReSendVerifyEmailModel; 
                client.BaseUrl = new Uri(baseApiUrl + "Polls/ReSendVerifyEmail");
                request.AddJsonBody(model);
                response = client.Execute<GeneralApiResponse>(request);
            }
            if (type == VerificationType.SMS)
            {
                SendVerificationCode model = verificationModel as SendVerificationCode;
                request.AddJsonBody(model);
                client.BaseUrl = new Uri(baseApiUrl + "Polls/ResendVerifyCode");
                System.IO.File.WriteAllText(@"D:\SMS.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
                response = client.Execute<GeneralApiResponse>(request);
            }
            if (type == VerificationType.Call)
            {
                SendVerificationCode model = verificationModel as SendVerificationCode;
                request.AddJsonBody(model);
                System.IO.File.WriteAllText(@"D:\Call.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
                client.BaseUrl = new Uri(baseApiUrl + "Polls/MakeCall");
                response = client.Execute<GeneralApiResponse>(request);
            }

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
            return new GeneralApiResponse();
        }

    }
    public enum VerificationType
    {
        Email,
        ResendEmail,
        SMS,
        Call
    }

}
