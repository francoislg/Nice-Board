using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nice_Board.Core.Card
{
    public interface ICardProvider
    {
        Task Synchronize();
        IReadOnlyCollection<ICard> Cards { get; }
    }
}
