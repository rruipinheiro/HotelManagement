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
using GestaoHoteleira;

namespace GestaoHoteleira.Views.Dashboard {

    public partial class Reservas : UserControl {

        public Reservas() {

            InitializeComponent();

            dashListReservas.ItemsSource = GestaoHotel.getQuartosNaoOcupados();

        }

        private void reserva(object sender, RoutedEventArgs e) {
            if(dashListReservas.SelectedIndex >= 0) {
                new _Reservas(dashListReservas.SelectedIndex).Show();
            } else {
                MessageBox.Show("Tem que selecionar um quarto!");
            }
        }

    }

}
