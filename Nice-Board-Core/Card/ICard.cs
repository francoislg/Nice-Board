using System;

namespace Nice_Board.Core.Card
{
    public interface ICard
    {
        string User { get; }
        string Description { get; }
        string Title { get; }
        int Color { get; }
        DateTime CreationDate { get; }
        DateTime ModifiedDate { get; }
    }
}
