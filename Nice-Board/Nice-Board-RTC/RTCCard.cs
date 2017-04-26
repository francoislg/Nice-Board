using Nice_Board.Core.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Nice_Board_RTC
{
    public class RTCCard : ICard
    {
        public RTCCard()
        {
        }

        public string User => "any";

        public string Description => "Something somethinf";

        public string Title => "Testing";

        public Color Color => Colors.Red;

        public DateTime CreationDate => throw new NotImplementedException();

        public DateTime ModifiedDate => throw new NotImplementedException();
    }
}
