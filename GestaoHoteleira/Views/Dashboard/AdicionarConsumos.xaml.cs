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

    public partial class AdicionarConsumos : Window {

        private int idConsumoSelect;

        public AdicionarConsumos(int idConsumoSelect) {

            this.idConsumoSelect = idConsumoSelect;

            InitializeComponent();

            for(int i = 0; i < GestaoHotel.getQuartosSuperOcupados().Count; i++) {
                comboboxListaQuartosDisponiveis.Items.Add(GestaoHotel.getQuartosSuperOcupados()[i].Id);
            }

            consumoProduto.Content = GestaoHotel.getConsumos()[idConsumoSelect].Nome;
            consumoPreco.Content = GestaoHotel.getConsumos()[idConsumoSelect].Preco;

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

        private void adicionarConsumo(object sender, RoutedEventArgs e) {

            int idQuarto = GestaoHotel.getQuartosSuperOcupados()[comboboxListaQuartosDisponiveis.Items.IndexOf(comboboxListaQuartosDisponiveis.SelectedItem) - 1].Id;
            int totalConsumos = GestaoHotel.getConsumosById(idQuarto).Count;
            string nome = GestaoHotel.getConsumos()[idConsumoSelect].Nome;
            double preco = GestaoHotel.getConsumos()[idConsumoSelect].Preco;

            GestaoHotel.getConsumosById(idQuarto).Add(preco);
            GestaoHotel.getQuartoById(idQuarto).Preco += preco;
            GestaoHotel.geReservaByQuartoId(idQuarto).Preco += preco;

            this.Close();

        }

    }

}
