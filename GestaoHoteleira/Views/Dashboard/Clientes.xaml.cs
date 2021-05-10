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

    public partial class Clientes : UserControl {

        public Clientes() {

            InitializeComponent();

            dashListClientes.ItemsSource = GestaoHotel.getClientes();

        }

        private void showClientesInfo(object sender, MouseButtonEventArgs e) {

            if(dashListClientes.SelectedIndex >= 0) {
                new ClientesInfo(dashListClientes.SelectedIndex).Show();
            }

        }

        private void registarCliente(object sender, RoutedEventArgs e) {
            new RegistarClientes().Show();
        }

    }

}
