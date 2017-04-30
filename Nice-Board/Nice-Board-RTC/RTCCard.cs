using Nice_Board.Core.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace Nice_Board_RTC
{
    public class RTCCard : ICard
    {
        public string User => throw new NotImplementedException();

        public DateTime? CreationDate => throw new NotImplementedException();

        public DateTime? ModifiedDate => throw new NotImplementedException();

        public UserControl Control => throw new NotImplementedException();
    }
}
