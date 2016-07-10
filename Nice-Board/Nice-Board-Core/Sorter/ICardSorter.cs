using System.Collections.Generic;
using Nice_Board.Core.Card;

namespace Nice_Board.Core.Sorter
{
    public interface ICardSorter
    {
        IList<ICard> Sort(IList<ICard> cards);
    }
}
