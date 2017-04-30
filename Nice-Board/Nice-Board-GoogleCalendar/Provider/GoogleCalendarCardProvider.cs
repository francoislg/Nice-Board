using System;
using System.Collections.Generic;
using Nice_Board.Core.Card;
using Nice_Board.GoogleCalendar.Client; 
using System.Threading.Tasks;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System.Linq;
using Nice_Board.GoogleCalendar.Card;
using static Google.Apis.Calendar.v3.EventsResource;

namespace Nice_Board.GoogleCalendar.Provider
{
    public class GoogleCalendarCardProvider : IGoogleCalendarCardProvider
    {
        private readonly GoogleCalendarClient Client;

        public GoogleCalendarCardProvider(GoogleCalendarClient p_Client)
        {
            Client = p_Client;
            Cards = new List<ICard>();
        }

        public IReadOnlyCollection<ICard> Cards { get; private set; }

        public async Task Synchronize()
        {
            CalendarService service = await Client.GetCalendarService();
            ICollection<CalendarListEntry> entries = service.CalendarList.List().Execute().Items;

            ListRequest eventsListRequest = service.Events.List("primary");
            eventsListRequest.MaxResults = 10;
            eventsListRequest.OrderBy = ListRequest.OrderByEnum.Updated;

            Events events = await eventsListRequest.ExecuteAsync();
            Cards = events.Items.Select(ev => new GoogleCalendarCard()
            {
                CreationDate = ev.Created,
                ModifiedDate = ev.Updated,
                EventName = ev.Summary,
                User = ev.Organizer.DisplayName
            }).Take(10).ToList();
        }
    }
}
