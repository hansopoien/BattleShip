using BattleShip.Models;
using BattleShip.ViewModels.Base;
using BattleShip.Views.Boats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public PlayerViewModel Player1 { get; set; } = new HumanPlayerViewModel();
        public PlayerViewModel Player2 { get; set; } = new HumanPlayerViewModel();

        public ObservableCollection<Boat> Harbour { get; private set; }
        public GameViewModel()
        {
            FillHarbour();
        }

        private void FillHarbour()
        {
            Harbour = new ObservableCollection<Boat>()
            {
                new CruiserBoat(),
                new BattleshipBoat()
            };
        }
    }
}
