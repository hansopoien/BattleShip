using BattleShip.Commands;
using BattleShip.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleShip.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; set; }
        public ICommand ChangePageCommand { get; }
        public MainViewModel()
        {
            CurrentViewModel = new StartViewModel(this);
            ChangePageCommand = new RelayCommand(x => ChangePage());
        }

        private void ChangePage()
        {
            CurrentViewModel = new GameViewModel();
        }
    }
}
