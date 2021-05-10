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

    public partial class FaturasInfo : Window {

        private int selectFatura;

        public FaturasInfo(int selectFatura) {

            this.selectFatura = selectFatura;

            InitializeComponent();

            infoFaturas_NomeCliente.Content = GestaoHotel.getClienteByFaturaId(GestaoHotel.getFaturas()[selectFatura].Id).Nome;
            infoFaturas_NIFCliente.Content = GestaoHotel.getClienteByFaturaId(GestaoHotel.getFaturas()[selectFatura].Id).Nif;
            infoFaturas_MoradaCliente.Content = GestaoHotel.getClienteByFaturaId(GestaoHotel.getFaturas()[selectFatura].Id).getMorada()[0].ToString();
            infoFaturas_NumeroFatura.Content = GestaoHotel.getFaturas()[selectFatura].Id;
            infoFaturas_TipoQuarto.Content = GestaoHotel.getQuartoByFaturaId(GestaoHotel.getFaturas()[selectFatura].Id).TipoQuarto;
            infoFaturas_Preco.Content = Convert.ToString(GestaoHotel.getQuartoByFaturaId(GestaoHotel.getFaturas()[selectFatura].Id).Preco);

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
