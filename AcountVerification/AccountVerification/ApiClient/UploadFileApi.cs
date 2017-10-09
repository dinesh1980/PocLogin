using AccountVerification.Models.UploadFile;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountVerification.ApiClient
{
    public class UploadFileApi
    {

        public static FileObject GetUploadFile()
        {

            var client = new RestClient(CommonUtility.ApirUrl + "Polls/UploadFile?accessKey=" + CommonUtility.loginDetails.secretAccessKey + "&isProfilePic=true");
            var request = new RestRequest(Method.POST);           
            //request.AddHeader("accessKey", CommonUtility.loginDetails.secretAccessKey);
            //request.AddHeader("isProfilePic", "true");
            request.AddHeader("UserId", CommonUtility.loginDetails.userId);
            request.AddHeader("token", CommonUtility.loginDetails.token);
            //request.AddJsonBody(model);
           //  System.IO.File.WriteAllText(@"D:\request.json", Newtonsoft.Json.JsonConvert.SerializeObject(request));
            IRestResponse<FileObject> updatedProfileResponse = client.Execute<FileObject>(request);
          //  System.IO.File.WriteAllText(@"D:\response.json", Newtonsoft.Json.JsonConvert.SerializeObject(updatedProfileResponse.Content));
            if (updatedProfileResponse.StatusCode.ToString().ToUpper() == "OK")
            {
                return updatedProfileResponse.Data;
            }
            else
            {
                return new FileObject();
            }

        }
    }
}