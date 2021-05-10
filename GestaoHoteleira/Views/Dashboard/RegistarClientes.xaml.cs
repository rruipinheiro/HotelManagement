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
using System.Windows.Shapes;

namespace GestaoHoteleira.Views.Dashboard {

    public partial class RegistarClientes : Window {

        public RegistarClientes() {
            InitializeComponent();
        }

        private void MouseEvent_DragWindow(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void MouseEvent_CloseWindow(object sender, MouseButtonEventArgs e) {
            this.Close();
        }

        private void MouseEvent_MinimizeWindow(object sender, MouseButtonEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private int randomNumbers() {
            return new Random(100).Next(000000000, 999999999);
        }

        private void registarCliente(object sender, RoutedEventArgs e) {

            int idCliente = GestaoHotel.getClientes().Count + 1;
            int idMorada = GestaoHotel.getClientes()[0].getMorada().Count;

            GestaoHotel.getClientes().Add(
                new Cliente(idCliente,0,randomNumbers(), registarCliente_Nome.Text, registarCliente_Email.Text, Convert.ToInt32(registarCliente_Telefone.Text), Convert.ToInt32(registarCliente_NIF.Text))
            );

            GestaoHotel.getClientes()[idCliente - 1].getMorada().Add(new Morada(idMorada, idCliente, registarCliente_Pais.Text, registarCliente_Rua.Text, registarCliente_Destrito.Text, registarCliente_Freguesia.Text, Convert.ToInt32(registarCliente_CodigoPostal.Text)));

            this.Close();

        }

    }

}
