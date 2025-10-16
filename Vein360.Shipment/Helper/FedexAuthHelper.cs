using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;

namespace Vein360.Shipment.Helper
{
    public interface IFedexAuthHelper
    {
        public string ApiUrl { get; }   
        public long AccountNumber { get; }
        Task<TokenDto> GetAccessTokenAsync();
    }

    public class FedexAuthHelper: IFedexAuthHelper
    {
        private readonly FedexCredential fedexCredential;
        public FedexAuthHelper(FedexCredential fedexCredential)
        {
            this.fedexCredential = fedexCredential;
        }

        public string ApiUrl => fedexCredential.ApiUrl;

        public long AccountNumber=> fedexCredential.AccountNumber;


        public  Task<TokenDto> GetAccessTokenAsync()
        {
            return AuthorizeAsync(fedexCredential.ClientId, fedexCredential.ClientSecret);
            
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
