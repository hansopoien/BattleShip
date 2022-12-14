using BattleShip.Commands;
using BattleShip.Dtos;
using BattleShip.Enums;
using BattleShip.ViewModels.Base;
using BattleShip.Views.Boats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
        public ICommand PlaceShipCommand { get; }
        public ICommand OceanClickedCommand { get; }



        public ObservableCollection<Ship>? Harbour { get; private set; }
        public GameViewModel()
        {
            FillHarbour();
            Player1 = new HumanPlayerViewModel(Harbour);
            Player2 = new CpuPlayerViewModel(Harbour);
            RevealBoatCommand = new RelayCommand(execute: x => Player2.ExposeAllShips(), predicate: x=> Player1.HasAllShipsPosition());
            RemoveShipCommand = new RelayCommand(execute: x => RemoveShip((Ship)x));
            PlaceShipCommand = new RelayCommand(execute: x => PlaceShip((ShipDto)x));
            OceanClickedCommand = new RelayCommand(execute: x => MakeAttack(x));

        }

        private void MakeAttack(object x)
        {
            var piece = Player2.Ocean.First(o => o.Id == (int)x);
            var attackPoint = new Point(piece.X, piece.Y);
            var result = Player2.UnderAttack(attackPoint);
            piece.CurrentStatus = result;
            PlaySound(result);
        }

        private void PlaySound(Status result)
        {
            var sound = new SoundPlayer();


            switch (result)
            {
                case Status.Miss:
                    sound.Stream = Properties.Resources.miss_wav;
                    break;
                case Status.Hit:
                    sound.Stream = Properties.Resources.hit_wav;
                    break;
                //case Status.Sunk:
                //    break;
                //case Status.Untested:
                //    break;
                //default:
                //    break;
            }
            sound.Play();
        }

        private void PlaceShip(ShipDto x)
        {

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
