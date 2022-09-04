using BattleShip.ViewModels.Base;
using BattleShip.Views.Boats;
using BattleShip.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BattleShip.ViewModels
{
    internal abstract class PlayerViewModel : BaseViewModel
    {
        public ObservableCollection<Ship> Ships { get; set; } = new ObservableCollection<Ship>();
        public ObservableCollection<OceanPieceComponent>? Ocean { get; private set; }
        
        const int battleFieldSize = 10;
        private readonly ObservableCollection<Ship> _fleet;

        public PlayerViewModel(ObservableCollection<Ship> fleet)
        {
            FillOcean();
            _fleet = fleet;
            FillOcean();
            FillShips();
        }

        private void FillShips()
        {
            foreach (var ship in _fleet)
            {
                Ships.Add(new Ship
                {
                    Size = ship.Size,
                });
            }
        }

        private void FillOcean()
        {
            Ocean = new ObservableCollection<OceanPieceComponent>();
            for (int x = 0; x < battleFieldSize; x++)
            {
                for (int y = 0; y < battleFieldSize; y++)
                {
                    var piece = new OceanPieceComponent()
                    {
                        Id = Ocean.Count,
                        X = x,
                        Y = y
                    };
                    Ocean.Add(piece);
                }
            }
        }

        public void ExposeAllShips()
        {
            foreach (var ship in Ships)
            {
                foreach (var point in ship.Coordinates)
                {
                    var piece = Ocean.First(o => o.X == point.X && o.Y == point.Y);
                    piece.OceanColor = Brushes.Gray;
                }
            }
        }

        public bool HasAllShipsPosition() => Ships.All(x => x.Coordinates.Count > 0);
    }
}
