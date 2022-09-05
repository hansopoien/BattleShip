using BattleShip.Views.Boats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Dtos
{
    internal class ShipDto
    {
        public Ship Ship { get; set; }
        public Point Point { get; set; }

        public ShipDto(Ship ship, Point point)
        {
            Ship = ship;
            Point = point;
        }

    }
}
