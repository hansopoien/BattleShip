using BattleShip.Models;
using BattleShip.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public PlayerViewModel Player1 { get; set; } = new HumanPlayerViewModel();
        public PlayerViewModel Player2 { get; set; } = new HumanPlayerViewModel();

        public GameViewModel()
        {
            var ship = new ShipModel(size: 3);
            ship.SetCordinates(startPoint: new System.Drawing.Point(1, 1));
        }
    }
}
