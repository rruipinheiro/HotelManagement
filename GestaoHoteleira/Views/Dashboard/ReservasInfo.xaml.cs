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

    public partial class ReservasInfo : Window {

        private int selectReserva;

        public ReservasInfo(int selectReserva) {

            this.selectReserva = selectReserva;

            InitializeComponent();

            infoReserva_NumeroQuarto.Content = GestaoHotel.getReservas()[selectReserva].IdQuarto;
            infoReserva_NomeCliente.Content = GestaoHotel.getClienteByReservaId(GestaoHotel.getReservas()[selectReserva].Id).Nome;
            infoReserva_NumeroCliente.Content = GestaoHotel.getClienteByReservaId(GestaoHotel.getReservas()[selectReserva].Id).Id;
            infoReserva_DataInicio.Content = GestaoHotel.getReservas()[selectReserva].DataInicio;
            infoReserva_DataFim.Content = GestaoHotel.getReservas()[selectReserva].DataFim;
            infoQuarto_Preco.Content = Convert.ToString(GestaoHotel.getReservas()[selectReserva].Preco);

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

        private void cancelarReserva(object sender, RoutedEventArgs e) {
            GestaoHotel.getClienteByReservaId(GestaoHotel.getReservas()[selectReserva].Id).Idquarto = 0;
            GestaoHotel.getQuartoByReservaId(GestaoHotel.getReservas()[selectReserva].Id).Ocupado = false;
            GestaoHotel.getReservas().RemoveAt(selectReserva);
            MessageBox.Show("Reseva cancelada com sucessso!");
            this.Close();
        }

        private void finalizarReserva(object sender, RoutedEventArgs e) {

            int totalFatura = (GestaoHotel.getFaturas().Count) + 1;
            int idReserva = GestaoHotel.getReservas()[selectReserva].Id;
            double valorTotal = GestaoHotel.getReservas()[selectReserva].Preco;
            string datafim = GestaoHotel.getReservas()[selectReserva].DataFim;

            if(!GestaoHotel.CheckFaturaAlreadyExistsByIdReserva(idReserva)) {

                GestaoHotel.getClienteByReservaId(GestaoHotel.getReservas()[selectReserva].Id).Idquarto = 0;
                GestaoHotel.getQuartoByReservaId(GestaoHotel.getReservas()[selectReserva].Id).Ocupado = false;
                GestaoHotel.setFaturasByIdReserva(idReserva).Add(new Fatura(totalFatura, idReserva, valorTotal, datafim));

                MessageBox.Show("Reserva finalizada com sucesso ! \nFatura gerada com sucesso!");

                this.Close();

            } else {
                MessageBox.Show("Já foi gerada uma fatura para esta reserva!");
            }

        }

    }

}
