using System;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Nice_Board.Core.Models;

namespace Nice_Board.Clients.Google
{
    public class GoogleClient
    {
        private IList<string> Scopes;
        private GoogleConfigurationModel Config;
        private HttpClient Client;
        private string DeviceCode;
        private GetAccessTokenResponse LastToken;

        public GoogleClient(GoogleConfigurationModel config)
        {
            this.Config = config;
            Scopes = new List<string>();
            Client = new HttpClient();
        }

        public void AddScope(string Scope)
        {
            Scopes.Add(Scope);
        }

        public async Task<string> GetUserCode()
        {
            DeviceAuthorizationResponse response = await SendPost<DeviceAuthorizationResponse>("https://accounts.google.com/o/oauth2/device/code", new Dictionary<string, string> {
                { "client_id", Config.ClientId },
                { "scope", string.Join(" ", Scopes) }
            });
            DeviceCode = response.device_code;
            return response.user_code;
        }

        public async Task<bool> HasAuthorization()
        {
            GetAccessTokenResponse response = await GetAccessTokenResponse();
            bool valid = string.IsNullOrEmpty(response.error);
            if (valid)
            {
                LastToken = response;
            }
            return valid;
        }

        public async Task<string> GetAccessToken()
        {
            if(LastToken == null)
            {
                await HasAuthorization();
            }
            return LastToken.access_token;
        }

        private async Task<GetAccessTokenResponse> GetAccessTokenResponse()
        {
            return await SendPost<GetAccessTokenResponse>("https://www.googleapis.com/oauth2/v4/token", new Dictionary<string, string> {
                { "client_id", Config.ClientId },
                { "client_secret", Config.ClientSecret },
                { "code", DeviceCode },
                { "grant_type", "http://oauth.net/grant_type/device/1.0" }
            });
        }

        private async Task<T> SendPost<T>(string url, IDictionary<string, string> content)
        {
            HttpResponseMessage message = await Client.PostAsync(url, new FormUrlEncodedContent(content));
            string response = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
