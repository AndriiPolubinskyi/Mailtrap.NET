using System.Text.Json;
using RestSharp;

namespace Mailtrap
{
    public class MailtrapSender
	{
		readonly string MailTrapBaseAddress = @"https://send.api.mailtrap.io/api/send";
		readonly string MailtrapToken = "51f0bf7bb7c5b9e46fc5cba922cde0f1";

		public async Task<RestResponse> SendAsync(MailtrapMessage message)
		{
            var json = JsonSerializer.Serialize(message);

            var client = new RestClient(MailTrapBaseAddress);
			var request = new RestRequest();

			request.AddHeader("Authorization", "Bearer " + MailtrapToken);
			request.AddHeader("Content-Type", "application/json");
			request.AddParameter("application/json", json, ParameterType.RequestBody);

			var response = await client.PostAsync(request);
			return response;
        }
	}
}

