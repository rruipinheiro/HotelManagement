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

    public partial class _Reservas : Window {

        private int idQuartoSelect;

        public _Reservas(int idQuartoSelect) {

            this.idQuartoSelect = idQuartoSelect;

            InitializeComponent();

            for(int i = 0; i < GestaoHotel.getClientesSemReserva().Count; i++) {
                comboboxListaClientes.Items.Add(GestaoHotel.getClientesSemReserva()[i].Nome);
            }

            tipoQuarto.Content = GestaoHotel.getQuartosNaoOcupados()[idQuartoSelect].TipoQuarto;
            numero.Content = GestaoHotel.getQuartosNaoOcupados()[idQuartoSelect].Numero;
            piso.Content = GestaoHotel.getQuartosNaoOcupados()[idQuartoSelect].Piso;
            designer.Content = GestaoHotel.getQuartosNaoOcupados()[idQuartoSelect].getDesigner();

            if(GestaoHotel.getQuartosNaoOcupados()[idQuartoSelect].TipoQuarto != "Premium") {
                _designer.Content = "";
                designer.Content = "";
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

        private void reserva(object sender, RoutedEventArgs e) {

            int totalReserva = (GestaoHotel.getReservas().Count) + 1;
            int idQuarto = GestaoHotel.getQuartosNaoOcupados()[idQuartoSelect].Id;
            int idCliente = GestaoHotel.getClientesSemReserva()[comboboxListaClientes.Items.IndexOf(comboboxListaClientes.SelectedItem) - 1].Id;
            double precoNoite = GestaoHotel.getQuartosNaoOcupados()[idQuartoSelect].Preco;
            double preco = getPrecoByData(precoNoite, dataFim.SelectedDate.Value.Date.ToShortDateString(), dataInicio.SelectedDate.Value.Date.ToShortDateString());

            if(GestaoHotel.getClienteByUid(idCliente).Idquarto > 0) {
                MessageBox.Show("O cliente ja tem uma reserva no hotel!");
            } else {

                GestaoHotel.getReservas().Add(new Reserva(totalReserva, idQuarto, idCliente, dataInicio.SelectedDate.Value.Date.ToShortDateString(), dataFim.SelectedDate.Value.Date.ToShortDateString(), preco));

                GestaoHotel.getClienteByUid(idCliente).Idquarto = idQuarto;
                GestaoHotel.getQuartoById(idQuarto).Ocupado = true;

                this.Close();
            }

        }

        public double getPrecoByData(double preco, string dataFim, string dataInicio) {
            return preco * GestaoHotel.getNumberOfDays(dataFim, dataInicio);
        }

    }

}
