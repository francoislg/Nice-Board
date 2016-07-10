using System.Collections.Generic;
using System.Linq;
using Nice_Board.Core.Card;

namespace Nice_Board.Core.Sorter
{
    public class SortByCreationDate : ICardSorter
    {
        public IList<ICard> Sort(IList<ICard> cards)
        {
            return cards.OrderBy(card => card.CreationDate).ToList();
        }
    }
}
