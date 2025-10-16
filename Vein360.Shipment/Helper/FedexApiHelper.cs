using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;

namespace Vein360.Shipment.Helper
{
    public interface IFedexApiHelper
    {
        public long AccountNumber { get; }
        public string ApiUrl { get; }
        Task<string> GetAccessTokenAsync();
    }

    public class FedexApiHelper : IFedexApiHelper
    {
        private readonly FedexCredential fedexCredential;

        public FedexApiHelper(FedexCredential fedexCredential)
        {
            this.fedexCredential = fedexCredential;
        }

        public long AccountNumber => fedexCredential.AccountNumber;
        public string ApiUrl => fedexCredential.ApiUrl;

        public async Task<string> GetAccessTokenAsync()
        {
            var token = await AuthorizeAsync(fedexCredential.ClientId, fedexCredential.ClientSecret);
            return token.access_token;
        }

        private async Task<TokenDto> AuthorizeAsync(string clientId, string clientSecret)
        {
            try
            {

                var data = new Dictionary<string, string>{
                                {"grant_type", "client_credentials"},
                                {"client_id", clientId},
                                {"client_secret", clientSecret} };


                var client = new HttpClient { BaseAddress = new Uri(fedexCredential.ApiUrl) };

                var response = await client.PostAsync("/oauth/token", new FormUrlEncodedContent(data));

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<TokenDto>(content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
