using Nice_Board.GoogleClient;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using System;
using System.Threading;

namespace Nice_Board.GoogleCalendar.Client
{
    public class GoogleAgendaClient
    {
        private static string ApplicationName = "Google Calendar API .NET Quickstart";

        private GoogleRestClient GoogleClient;

        public GoogleAgendaClient(GoogleRestClient GoogleClient)
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
