using AccountVerification.Models;
using RestSharp;
using System.Web.Configuration;

namespace AccountVerification.ApiClient
{
    public static class AccountRegistrationApiClient
    {
        public static RegistrationResponseModel Register(RegisterRequestViewModel model)
        {
            var client = new RestClient(WebConfigurationManager.AppSettings["APiUrl"] + "Polls/Registration");
            var request = new RestRequest(Method.POST);
            // request.AddHeader("content-type", "application/json");

            request.AddJsonBody(model);
            //System.IO.File.WriteAllText(@"D:\path1.json", Newtonsoft.Json.JsonConvert.SerializeObject(model));
            IRestResponse<RegistrationResponseModel> response = client.Execute<RegistrationResponseModel>(request);
            if (response.StatusCode.ToString().ToUpper() == "OK")
                return response.Data;
            else
                return new RegistrationResponseModel();

        }

    }
}
