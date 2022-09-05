using BattleShip.Commands;
using BattleShip.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BattleShip.ViewModels
{
    internal class StartViewModel : BaseViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public StartViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            StartGameCommand = new RelayCommand(x => StartGame());
        }

        public ICommand StartGameCommand { get; }
        public StartViewModel()
        {
            
        }

        private void StartGame()
        {
            _mainViewModel.CurrentViewModel = new GameViewModel();
        }
    }
}
