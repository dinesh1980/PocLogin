using Login;
using UpdateProfile.Models;
using RestSharp;
using System;
using UpdateProfile.common;
using CommonModels;
using Newtonsoft.Json;

namespace UpdateProfile.ApiClient
{
    public class UserProfileApiClient
    {

        public static UserProfileResponse GetUserProfile(string userId)
        {
            GetPublicProfileRequest obj = new GetPublicProfileRequest();
            obj.id = userId;
            obj.viewAll = true;
            var client = new RestClient(CommonUtility.ApirUrl + "PublicPoll/ViewPublicProfile");
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(obj);
            request.AddHeader("content-type", "application/json");
            IRestResponse<UserProfileResponse> response = client.Execute<UserProfileResponse>(request);
            UserProfileResponse profile = new Models.UserProfileResponse();
            if (response.StatusCode.ToString() == "OK")
            {
                // profile = response.Data;
                profile = JsonConvert.DeserializeObject<UserProfileResponse>(response.Content);
                //System.IO.File.WriteAllText(@"D:\ProfileResponse.json", Newtonsoft.Json.JsonConvert.SerializeObject(profile));
                if (profile.gender == "M")
                {
                    profile.gender = "Male";
                }
                if (profile.gender == "F")
                {
                    profile.gender = "Female";
                }
            }
            return profile;

        }
        public static UserProfileResponse UpdateProfile(UserProfileResponse model, ref string error)
        {
            LoginResponse userdetails = CommonUtility.loginDetails;
            var client = new RestClient(CommonUtility.ApirUrl + "Polls/UpdateProfile");
            var request = new RestRequest(Method.POST);
            request.AddHeader("UserId", CommonUtility.loginDetails.userId);
            request.AddHeader("token", CommonUtility.loginDetails.token);
            request.AddJsonBody(model);
            // System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
            IRestResponse<UserProfileUpdateResponse> updatedProfileResponse = client.Execute<UserProfileUpdateResponse>(request);

            if (updatedProfileResponse.StatusCode.ToString().ToUpper() == "OK")
            {
                return model;
            }
            else
            {
                ErrorDetails errordetail = JsonConvert.DeserializeObject<ErrorDetails>(updatedProfileResponse.Content);
                error =(String.IsNullOrEmpty(errordetail.AdditionalInformation)?"": errordetail.AdditionalInformation) + (String.IsNullOrEmpty(errordetail.message)?"": errordetail.message);
                return model;
            }

        }
    }
}