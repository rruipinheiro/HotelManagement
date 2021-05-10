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

namespace GestaoHoteleira {

    public partial class MainWindow : Window {

        public bool checkLogin(string username, string password) {

            for(int i = 0; i < GestaoHotel.getAdmins().Count; i++) {
                if(GestaoHotel.getAdmins()[i].Username == username && password == GestaoHotel.getAdmins()[i].Password) {
                    GestaoHotel.userIDSession = GestaoHotel.getAdmins()[i].Id;
                    return true;
                }
            }

            return false;

        }

        public MainWindow() {

            GestaoHotel.preencher();

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

        private void Button_Click(object sender, RoutedEventArgs e) {

            string adminUsername = inputLoginUsername.Text;
            string adminPassword = inputLoginPassword.Password;

            if(adminUsername != "" && adminPassword != "") {
                if(checkLogin(adminUsername, adminPassword)) {
                    new Dashboard().Show();
                    this.Close();
                } else {
                    MessageBox.Show("Dados errados!");
                }
            } else {
                MessageBox.Show("Numero ou Password não preenchidos!");
            }

        }

    }

}
