using Nice_Board.Core.Card;
using Nice_Board_CoreUI;
using System;
using Windows.UI.Xaml.Controls;

namespace Nice_Board.GoogleCalendar.Card
{
    public class GoogleCalendarCard : ICard
    {
        private readonly Lazy<UserControl> ControlInstance;

        public GoogleCalendarCard()
        {
            ControlInstance = new Lazy<UserControl>(() => new CalendarCardControl(this));
        }

        public DateTime? CreationDate { get; set; }
        public UserControl Control {
            get { return ControlInstance.Value; }
        }
        public string EventName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string User { get; set; }
    }
}
