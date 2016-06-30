using Nice_Board.Core.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nice_Board.GoogleCalendar.Card
{
    public class GoogleCalendarCard : ICard
    {
        public GoogleCalendarCard()
        {

        }

        public int Color
        {
            get
            {
                return 0;
            }
        }

        public DateTime CreationDate { get; private set; }
        public string Description { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public string Title { get; private set; }
        public string User { get; private set; }
    }
}
