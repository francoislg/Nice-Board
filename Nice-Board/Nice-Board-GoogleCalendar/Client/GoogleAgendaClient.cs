using Nice_Board.GoogleClient;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System.Threading.Tasks;
using Google.Apis.Http;
using System;

namespace Nice_Board.GoogleCalendar.Client
{
    public class GoogleCalendarClient
    {
        private static string ApplicationName = "Google Calendar API .NET Quickstart";

        private GoogleRestClient GoogleClient;

        public GoogleCalendarClient(GoogleRestClient GoogleClient)
        {
            this.GoogleClient = GoogleClient;
            GoogleClient.AddScope(CalendarService.Scope.CalendarReadonly);
        }

        public async Task<CalendarService> GetCalendarService()
        {
            string access_token = await GoogleClient.GetAccessToken();

            return new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = new Initializer(access_token),
                ApplicationName = ApplicationName
            });
        }

        private class Initializer : IConfigurableHttpClientInitializer
        {
            private readonly string AccessToken;

            public Initializer(string p_AccessToken)
            {
                AccessToken = p_AccessToken;
            }

            public void Initialize(ConfigurableHttpClient httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", AccessToken));
            }
        }
    }
}
