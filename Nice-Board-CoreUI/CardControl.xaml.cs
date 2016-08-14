using Nice_Board.Core.Card;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Nice_Board_CoreUI
{
    public sealed partial class CardControl : UserControl
    {
        protected readonly ICard Card;

        public CardControl(ICard p_Card)
        {
            Card = p_Card;
            Title.Text = Card.Title;
            Description.Text = Card.Description;
            SetColor(Card.Color);

            this.InitializeComponent();
        }

        protected void SetColor(Color p_Color)
        {
            GradientStopCollection gradientStopCollection = new GradientStopCollection();
            gradientStopCollection.Add(new GradientStop() { Color = Colors.White, Offset = 0 });
            gradientStopCollection.Add(new GradientStop() { Color = p_Color, Offset = 0.8 });
            LinearGradientBrush gradientBrush = new LinearGradientBrush(gradientStopCollection, 0);
            Grid.Background = gradientBrush;
        }
    }
}
