using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShip.Views.Boats
{
    /// <summary>
    /// Interaction logic for CruiserBoat.xaml
    /// </summary>
    public partial class CruiserBoat : Ship
    {
        public CruiserBoat()
        {
            InitializeComponent();
            Size = 3;
        }
    }
}
