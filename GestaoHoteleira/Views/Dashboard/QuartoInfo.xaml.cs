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

    public partial class QuartoInfo : Window {

        private int selectQuarto;

        public QuartoInfo(int selectQuarto) {

            this.selectQuarto = selectQuarto;

            InitializeComponent();

            ocupado();

            infoQuarto_Numero.Content = GestaoHotel.getQuartos()[selectQuarto].Numero;
            infoQuarto_Piso.Content = GestaoHotel.getQuartos()[selectQuarto].Piso;
            infoQuarto_Designer.Content = GestaoHotel.getQuartos()[selectQuarto].getDesigner();
            infoQuarto_Preco.Content = Convert.ToString(GestaoHotel.getQuartos()[selectQuarto].Preco);
            infoQuarto_TipoQuarto.Content = GestaoHotel.getQuartos()[selectQuarto].TipoQuarto;

            if(GestaoHotel.getQuartos()[selectQuarto] is QuartoSuper && GestaoHotel.getQuartos()[selectQuarto].Ocupado) {
                infoQuarto_Extra.Content = GestaoHotel.getTotalConsumosById(GestaoHotel.getQuartos()[selectQuarto].Id);
                _infoQuarto_Designer.Content = "";
                infoQuarto_Designer.Content = "";
            } else if(GestaoHotel.getQuartos()[selectQuarto] is QuartoPremium) {
                _infoQuarto_Extra.Content = "";
                infoQuarto_Extra.Content = "";
            } else {
                _infoQuarto_Extra.Content = "";
                infoQuarto_Extra.Content = "";
                _infoQuarto_Designer.Content = "";
                infoQuarto_Designer.Content = "";
            }

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

        private void ocupado() {
            if(GestaoHotel.getQuartos()[selectQuarto].Ocupado) {

                int quartoID = GestaoHotel.getQuartos()[selectQuarto].Id;

                this.Width = 575;
                gridMain.Width = 575;
                gridButtons.Width = 575;
                _gridButtons.Margin = new Thickness(535, 0, 0, 0);

                infoQuarto_ClienteName.Content = GestaoHotel.getClienteByQuartoId(quartoID).Nome;
                infoQuarto_ClienteNumero.Content = GestaoHotel.getClienteByQuartoId(quartoID).Numero;

            } else {
                gridShowCliente.Visibility = Visibility.Collapsed;
            }

        }

    }

}
