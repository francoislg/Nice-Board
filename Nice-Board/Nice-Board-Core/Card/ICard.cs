using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace Nice_Board.Core.Card
{
    public interface ICard
    {
        string User { get; }
        DateTime? CreationDate { get; }
        DateTime? ModifiedDate { get; }
        UserControl Control { get; }
    }
}
