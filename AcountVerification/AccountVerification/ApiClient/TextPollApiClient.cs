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
    public class TextPollApiClient
    {

        public static CreateTextPollRequest CreateTextPoll(CreateTextPollRequest requestObj)
        {

            IRestResponse<GeneralApiResponse> response = null;
            LoginResponse loginResponse = CommonUtility.loginDetails;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("version", "1.0");
            request.AddHeader("userid", loginResponse.userId);
            request.AddHeader("token", loginResponse.token);
            request.AddJsonBody(requestObj);
            var client = new RestClient();
            client.BaseUrl = new Uri(CommonUtility.ApirUrl + "Polls/CreateTextPoll");
            System.IO.File.WriteAllText(@"D:\TextPollReq.json", Newtonsoft.Json.JsonConvert.SerializeObject(requestObj));
            response = client.Execute<GeneralApiResponse>(request);

            System.IO.File.WriteAllText(@"D:\TetPollResponse.json", Newtonsoft.Json.JsonConvert.SerializeObject(response.Content));

            if (response.StatusCode.ToString().ToUpper() == "OK")
            {
                requestObj.Response = response.Data;
                return requestObj;
            }
            else
            {
                ErrorDetails errordetail = JsonConvert.DeserializeObject<ErrorDetails>(response.Content);
                response.Data.Error = errordetail;
                requestObj.Response = new GeneralApiResponse();
                requestObj.Response.Error = errordetail;
                return requestObj;
            }

        }
        public static CreateBestTextPoll CreateBestTextPoll(CreateBestTextPoll requestObj)
        {

            IRestResponse<GeneralApiResponse> response = null;
            LoginResponse loginResponse = CommonUtility.loginDetails;
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("version", "1.0");
            request.AddHeader("userid", loginResponse.userId);
            request.AddHeader("token", loginResponse.token);
            request.AddJsonBody(requestObj);
            var client = new RestClient();
            client.BaseUrl = new Uri(CommonUtility.ApirUrl + "Polls/CreateBestTextPoll");
            System.IO.File.WriteAllText(@"D:\BestTextPollReq.json", Newtonsoft.Json.JsonConvert.SerializeObject(requestObj));
            response = client.Execute<GeneralApiResponse>(request);

            System.IO.File.WriteAllText(@"D:\BestTextPollResponse.json", Newtonsoft.Json.JsonConvert.SerializeObject(response.Content));

            if (response.StatusCode.ToString().ToUpper() == "OK")
            {
                requestObj.Response = response.Data;
                return requestObj;
            }
            else
            {
                ErrorDetails errordetail = JsonConvert.DeserializeObject<ErrorDetails>(response.Content);
                response.Data.Error = errordetail;
                requestObj.Response = new GeneralApiResponse();
                requestObj.Response.Error = errordetail;
                return requestObj;
            }

        }

        public static List<GetAllFilterbyCategoryResponse> GetAllFilterCategories()
        {
            LoginResponse loginRespone = CommonUtility.loginDetails;
            var client = new RestClient(CommonUtility.ApirUrl + "Polls/GetAllFilterCategories");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("userid", loginRespone.userId);
            request.AddHeader("token", loginRespone.token);

            IRestResponse<List<GetAllFilterbyCategoryResponse>> response = client.Execute<List<GetAllFilterbyCategoryResponse>>(request);
            if (response.StatusCode.ToString() == "OK" && response.Data != null)
            {
                return response.Data;
            }
            else
            {
                return null;
            }
               
        }

        public static List<GetCategoriesResponse> GetCategoryResponse()
        {
            LoginResponse loginRespone = CommonUtility.loginDetails;
            var client_Categories = new RestClient(CommonUtility.ApirUrl + "Polls/GetCategories");
            var request_Categories = new RestRequest(Method.POST);
            request_Categories.AddHeader("content-type", "application/json");
            request_Categories.AddHeader("userid", loginRespone.userId);
            request_Categories.AddHeader("token", loginRespone.token);
            IRestResponse<List<GetCategoriesResponse>> response_Categories = client_Categories.Execute<List<GetCategoriesResponse>>(request_Categories);
            if (response_Categories.StatusCode.ToString() == "OK" && response_Categories.Data != null)
            {
                return response_Categories.Data;
            }
            else
            {
                return null;
            }
        }
    }
}