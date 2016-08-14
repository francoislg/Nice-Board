using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Nice_Board.Core.Card
{
    public interface ICard
    {
        string User { get; }
        string Description { get; }
        string Title { get; }
        Color Color { get; }
        DateTime CreationDate { get; }
        DateTime ModifiedDate { get; }
    }
}
