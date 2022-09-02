using BattleShip.Enums;
using BattleShip.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Models
{
    internal class ShipModel : BaseViewModel
    {
        public ObservableCollection<Point> Coordinates { get; private set; } = new ObservableCollection<Point>();
        public int Size { get; }
        public DirectionEnum Direction { get; private set; } = DirectionEnum.Horizontal;

        public ShipModel(int size)
        {
            Size = size;
        }

        public void SetCordinates(Point startPoint)
        {
            int x = startPoint.X;
            int y = startPoint.Y;
            switch (Direction)
            {
                case DirectionEnum.Horizontal:
                    for (int i = 0; i < Size; i++)
                    {
                        
                        Point point = new Point(x, y);
                        Coordinates.Add(point);
                        x++;
                    }
                    break;
                case DirectionEnum.Vertical:
                    for (int i = 0; i < Size; i++)
                    {
                        
                        Point point = new Point(x, y);
                        Coordinates.Add(point);
                        y++;
                    }
                    break;
            }
            
        }
    }
}
