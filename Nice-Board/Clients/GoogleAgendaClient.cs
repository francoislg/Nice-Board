using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Nice_Board.Configuration.ConfigurationModels;
using System;
using System.Threading;

namespace Nice_Board.Clients
{
    public class GoogleAgendaClient
    {
        private static string ApplicationName = "Google Calendar API .NET Quickstart";

        private GoogleClient GoogleClient;

        public GoogleAgendaClient(GoogleClient GoogleClient)
        {
            this.GoogleClient = GoogleClient;
            GoogleClient.AddScope(CalendarService.Scope.CalendarReadonly);
        }

        public async void Synchronize()
        {
            string access_token = await GoogleClient.GetAccessToken();

            CalendarService service = new CalendarService(new BaseClientService.Initializer()
            {
                ApiKey = access_token,
                ApplicationName = ApplicationName
            });
        }
    }
}
