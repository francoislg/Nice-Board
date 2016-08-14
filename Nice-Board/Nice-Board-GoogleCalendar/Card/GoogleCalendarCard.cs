using Nice_Board.Core.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Nice_Board.GoogleCalendar.Card
{
    public class GoogleCalendarCard : ICard
    {
        public Color Color
        {
            get
            {
                return Colors.Blue;
            }
        }

        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
    }
}
