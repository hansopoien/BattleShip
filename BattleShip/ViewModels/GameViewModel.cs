using BattleShip.Commands;
using BattleShip.ViewModels.Base;
using BattleShip.Views.Boats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleShip.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        public PlayerViewModel Player1 { get; set; }
        public PlayerViewModel Player2 { get; set; }

        public ICommand RevealBoatCommand { get; }
        public ICommand RemoveShipCommand { get; }


        public ObservableCollection<Ship>? Harbour { get; private set; }
        public GameViewModel()
        {
            FillHarbour();
            Player1 = new HumanPlayerViewModel(Harbour);
            Player2 = new CpuPlayerViewModel(Harbour);
            RevealBoatCommand = new RelayCommand(execute: x => Player2.ExposeAllShips(), predicate: x=> Player1.HasAllShipsPosition());
            RemoveShipCommand = new RelayCommand(execute: x => RemoveShip((Ship)x));
        }

        private void RemoveShip(Ship ship) => Harbour.Remove(ship);
        

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
