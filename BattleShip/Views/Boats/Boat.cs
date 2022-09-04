using BattleShip.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BattleShip.Views.Boats
{
    public class Ship : UserControl
    {
        public Ship()
        {
            this.MouseMove += Ship_MouseMove;
            Coordinates = new ObservableCollection<System.Drawing.Point>();
        }


        public Point StartPoint
        {
            get { return (Point)GetValue(StartPointProperty); }
            set { SetValue(StartPointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartPoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartPointProperty =
            DependencyProperty.Register("StartPoint", typeof(Point), typeof(Ship), new PropertyMetadata(null));



        public ObservableCollection<System.Drawing.Point> Coordinates
        {
            get { return (ObservableCollection<System.Drawing.Point>)GetValue(CoordinatesProperty); }
            set { SetValue(CoordinatesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoordinatesProperty =
            DependencyProperty.Register("MyProperty", typeof(ObservableCollection<System.Drawing.Point>), typeof(Ship), new PropertyMetadata(null));



        public DirectionEnum Direction
        {
            get { return (DirectionEnum)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Direction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(DirectionEnum), typeof(Ship), new PropertyMetadata(null));



        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(Ship), new PropertyMetadata(0,
                new PropertyChangedCallback(OnSizeSet)));

        private static void OnSizeSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var boat = d as Ship;
            boat.Width = (int)e.NewValue * 50;
            boat.HorizontalAlignment = HorizontalAlignment.Left;
        }
        protected void Ship_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(this, new DataObject(DataFormats.Serializable, this), DragDropEffects.Move);
            }
        }

        public void SetCoordinates(System.Drawing.Point startPoint)
        {
            int x = startPoint.X;
            int y = startPoint.Y;
            switch (Direction)
            {
                case DirectionEnum.Horizontal:
                    for (int i = 0; i < Size; i++)
                    {

                        var point = new System.Drawing.Point(x, y);
                        Coordinates.Add(point);
                        x++;
                    }
                    break;
                case DirectionEnum.Vertical:
                    for (int i = 0; i < Size; i++)
                    {

                        var point = new System.Drawing.Point(x, y);
                        Coordinates.Add(point);
                        y++;
                    }
                    break;
            }

        }
    }
}
