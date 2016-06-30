using System;
using System.Collections.Generic;
using Nice_Board.Core.Card;

namespace Nice_Board.GoogleCalendar.Provider
{
    public class GoogleCalendarCardProvider : IGoogleCalendarCardProvider
    {
        public GoogleCalendarCardProvider()
        {

        }

        public IList<ICard> FetchCards
        {
            get
            {
                return new List<ICard>();
            }
        }
    }
}
