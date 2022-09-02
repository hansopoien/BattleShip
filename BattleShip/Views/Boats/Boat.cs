using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BattleShip.Views.Boats
{
    public class Boat : UserControl
    {
        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(Boat), new PropertyMetadata(0,
                new PropertyChangedCallback(OnSizeSet)));

        private static void OnSizeSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var boat = d as Boat;
            boat.Width = (int)e.NewValue * 50;
            boat.HorizontalAlignment = HorizontalAlignment.Left;
        }
    }
}
