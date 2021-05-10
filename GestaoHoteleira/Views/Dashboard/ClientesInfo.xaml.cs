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

    public partial class ClientesInfo : Window {

        public ClientesInfo(int selectCliente) {
            
            InitializeComponent();

            infoCliente_Numero.Content = GestaoHotel.getClientes()[selectCliente].Numero;
            infoCliente_Nome.Content = GestaoHotel.getClientes()[selectCliente].Nome;
            infoCliente_Email.Content = GestaoHotel.getClientes()[selectCliente].Email;
            infoCliente_Telefone.Content = GestaoHotel.getClientes()[selectCliente].Telefone;
            infoCliente_NIF.Content = GestaoHotel.getClientes()[selectCliente].Nif;
            infoCliente_Pais.Content = GestaoHotel.getClientes()[selectCliente].getMorada()[0].Pais;
            infoCliente_Rua.Content = GestaoHotel.getClientes()[selectCliente].getMorada()[0].Rua;
            infoCliente_Destrito.Content = GestaoHotel.getClientes()[selectCliente].getMorada()[0].Destrito;
            infoCliente_Freguesia.Content = GestaoHotel.getClientes()[selectCliente].getMorada()[0].Freguesia;
            infoCliente_CodigoPostal.Content = GestaoHotel.getClientes()[selectCliente].getMorada()[0].CodigoPostal;

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

    }

}
