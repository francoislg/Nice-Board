using System.Collections.Generic;

namespace Nice_Board.Core.Card
{
    public interface ICardProvider
    {
        IList<ICard> FetchCards { get; }
    }
}
