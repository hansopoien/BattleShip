using BattleShip.Enums;
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

namespace BattleShip.Views.Components
{
    /// <summary>
    /// Interaction logic for OceanPieceComponent.xaml
    /// </summary>
    public partial class OceanPieceComponent : UserControl
    {





        public Status CurrentStatus
        {
            get { return (Status)GetValue(CurrentStatusProperty); }
            set { SetValue(CurrentStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentStatusProperty =
            DependencyProperty.Register("CurrentStatus", typeof(Status), typeof(OceanPieceComponent), new PropertyMetadata(Status.Untested));




        public int X
        {
            get { return (int)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(int), typeof(OceanPieceComponent), new PropertyMetadata(0));



        public int Y
        {
            get { return (int)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(int), typeof(OceanPieceComponent), new PropertyMetadata(0));



        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(OceanPieceComponent), new PropertyMetadata(0));


        public SolidColorBrush OceanColor
        {
            get { return (SolidColorBrush)GetValue(OceanColorProperty); }
            set { SetValue(OceanColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OceanColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OceanColorProperty =
            DependencyProperty.Register("OceanColor", typeof(SolidColorBrush), typeof(OceanPieceComponent), new PropertyMetadata(Brushes.Pink));


        public OceanPieceComponent()
        {
            InitializeComponent();
        }
    }
}
