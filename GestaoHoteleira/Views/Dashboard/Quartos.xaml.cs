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

namespace GestaoHoteleira.Views.Dashboard {

    public partial class Quartos : UserControl {

        public Quartos() {

            InitializeComponent();

            dashListQuartos.ItemsSource = GestaoHotel.getQuartos();

        }

        private void showQuartoInfo(object sender, RoutedEventArgs e) {
            if(dashListQuartos.SelectedIndex >= 0) {
                new QuartoInfo(dashListQuartos.SelectedIndex).Show();
            }
        }

    }

}
