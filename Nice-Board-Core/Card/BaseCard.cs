using System;

namespace Nice_Board.Core.Card
{
    public struct BaseCard : ICard
    {
        public int Color { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
    }
}
