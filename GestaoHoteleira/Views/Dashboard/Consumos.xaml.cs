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

    public partial class Consumos : UserControl {

        public Consumos() {

            InitializeComponent();

            dashListConsumos.ItemsSource = GestaoHotel.getConsumos();

        }

        private void adiconarConsumos(object sender, RoutedEventArgs e) {
            if(dashListConsumos.SelectedIndex >= 0) {
                new AdicionarConsumos(dashListConsumos.SelectedIndex).Show();
            }
        }

    }

}
