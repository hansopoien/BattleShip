using BattleShip.Enums;
using BattleShip.Views.Boats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace BattleShip.ViewModels
{
    internal class CpuPlayerViewModel : PlayerViewModel
    {
        public CpuPlayerViewModel(ObservableCollection<Ship> fleet) : base(fleet)
        {
            PlaceShipRandomly();
            //ExposeAllShips();
        }
        private static readonly Random random = new();
        private static int battleFieldSize = 10;
        private void PlaceShipRandomly()
        {
            bool shipIsAdded;
            foreach (var ship in Ships)
            {
                ship.Direction = GetRandomDirection();
                do
                {
                    var point = GetRandomOceanPoint();
                    if (IsOutOfBounds(point, ship.Size))
                    {
                        shipIsAdded = false;
                    }
                    else
                    {
                        shipIsAdded = PlaceShipInOcean(ship, point);
                    }
                } while (!shipIsAdded);
            }
        }
        private static DirectionEnum GetRandomDirection()
        {
            int magicNumber = random.Next(2);
            return (DirectionEnum)magicNumber;
        }

        private static Point GetRandomOceanPoint()
        {
            return new Point(random.Next(battleFieldSize) + 1, random.Next(battleFieldSize) + 1);
        }

        private static bool IsOutOfBounds(Point point, int size)
        {
            size -= 1;
            return point.X + size > battleFieldSize || point.Y + size > battleFieldSize;
        }

        private bool PlaceShipInOcean(Ship ship, Point point)
        {
            var coordinates = CalculateShipMargin(ship, point);
            if (HasSufficentSpace(coordinates))
            {
                ship.SetCoordinates(point);
                return true;
            }
            return false;
        }

        private static List<Point> CalculateShipMargin(Ship ship, Point startPoint)
        {
            var xCoordinates = new List<int>();
            var yCoordinates = new List<int>();
            var coordinates = new List<Point>();
            switch (ship.Direction)
            {
                case DirectionEnum.Horizontal:
                    xCoordinates = Enumerable.Range(startPoint.X - 1, ship.Size + 2).ToList();
                    yCoordinates = Enumerable.Range(startPoint.Y - 1, 3).ToList();
                    break;
                case DirectionEnum.Vertical:
                    xCoordinates = Enumerable.Range(startPoint.X - 1, 3).ToList();
                    yCoordinates = Enumerable.Range(startPoint.Y - 1, ship.Size + 2).ToList();
                    break;
                default:
                    break;
            }
            Point point;
            foreach (var x in xCoordinates)
            {
                foreach (var y in yCoordinates)
                {
                    point = new Point(x, y);
                    coordinates.Add(point);
                }
            }
            return coordinates;
        }

        private bool HasSufficentSpace(List<Point> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                foreach (var ship in Ships)
                {
                    if (IsPointOccupied(coordinate, ship))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool IsPointOccupied(Point coordinate, Ship ship)
        {
            return ship.Coordinates
                .Where(s => s.X == coordinate.X && s.Y == coordinate.Y)
                .Any();
        }
    }
}
