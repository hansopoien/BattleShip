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

        public ObservableCollection<Ship> Harbour { get; private set; }
        public GameViewModel()
        {
            FillHarbour();
        }

        private void FillHarbour()
        {
            Harbour = new ObservableCollection<Ship>()
            {
                new CruiserBoat(),
                new BattleshipBoat()
            };
        }
    }
}
