using BattleShip.Views.Boats;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.ViewModels
{
    internal class HumanPlayerViewModel : PlayerViewModel
    {
        public HumanPlayerViewModel(ObservableCollection<Ship> fleet) : base(fleet)
        {
        }
    }
}
