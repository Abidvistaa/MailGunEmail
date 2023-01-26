using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using RestSharp.Authenticators;
namespace MailGunEmailTest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmailTest();
        }

        private const string BaseUri = "https://api.mailgun.net/v3";
        private const string SenderDisplayName = "Abid MailGun";
        private const string SenderAddress = "ah@gulfstatesoftware.com";
        private const string RecieverAddress = "mahassan22300@gmail.com";
        private const string Subject = "This is mailgun a test";
        private void EmailTest()
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri(BaseUri),
                Authenticator = new HttpBasicAuthenticator("api", "Need_MailGun_Domain_Service_APIKey")
            };

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "Need_Domain", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", $"{SenderDisplayName} <{SenderAddress}>");

            request.AddParameter("to", RecieverAddress);

            request.AddParameter("subject", Subject);
            request.AddParameter("text", "Success!!! Testing Mailgun with Dotnet!");

            request.Method = Method.POST;
            client.Execute(request);
        }
    }
}