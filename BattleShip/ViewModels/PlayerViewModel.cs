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

        public PlayerViewModel()
        {
            FillOcean();
        }
        private void FillOcean()
        {
            Ocean = new ObservableCollection<OceanPieceComponent>();
            for (int x = 0; x < battleFieldSize; x++)
            {
                for (int y = 0; y < battleFieldSize; y++)
                {
                    var piece = new OceanPieceComponent();
                    //piece.OceanColor = Brushes.Red;
                    Ocean.Add(piece);
                }
            }
        }
    }
}
