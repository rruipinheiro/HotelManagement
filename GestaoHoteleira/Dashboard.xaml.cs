using System.Windows;
using System.Windows.Input;
using GestaoHoteleira.Views.Dashboard;

namespace GestaoHoteleira {

    public partial class Dashboard : Window {

        public Dashboard() {

            InitializeComponent();

            usernameLabel.Content = GestaoHotel.getUsername();

            Router.Children.Add(new Home());

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

        private void dashHome(object sender, RoutedEventArgs e) {
            Router.Children.Clear();
            Router.Children.Add(new Home());
        }

        private void dashReservas(object sender, RoutedEventArgs e) {
            Router.Children.Clear();
            Router.Children.Add(new Reservas());
        }

        private void dashClientes(object sender, RoutedEventArgs e) {
            Router.Children.Clear();
            Router.Children.Add(new Clientes());
        }

        private void dashQuartos(object sender, RoutedEventArgs e) {
            Router.Children.Clear();
            Router.Children.Add(new Quartos());
        }

        private void dashConsumos(object sender, RoutedEventArgs e) {
            Router.Children.Clear();
            Router.Children.Add(new Consumos());
        }

        private void dashDefinicoes(object sender, RoutedEventArgs e) {
            Router.Children.Clear();
            Router.Children.Add(new Definicoes());
        }

        private void dashFaturas(object sender, RoutedEventArgs e) {
            Router.Children.Clear();
            Router.Children.Add(new Faturas());
        }

    }

}
