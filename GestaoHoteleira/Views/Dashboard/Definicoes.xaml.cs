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

    public partial class Definicoes : UserControl {

        public Definicoes() {

            InitializeComponent();

            for(int i = 0; i < GestaoHotel.getAdmins().Count; i++) {
                if(GestaoHotel.getAdmins()[i].Id == GestaoHotel.userIDSession) {
                    settingUsername.Text = GestaoHotel.getAdmins()[i].Username;
                    settingNome.Text = GestaoHotel.getAdmins()[i].Nome;
                    settingEmail.Text = GestaoHotel.getAdmins()[i].Email;
                    settingPassword.Password = GestaoHotel.getAdmins()[i].Password;
                    settingPasswordConfirmar.Password = GestaoHotel.getAdmins()[i].Password;
                    break;
                }
            }

        }

        private void changeSettings(object sender, RoutedEventArgs e) {

            if(settingPassword.Password == settingPasswordConfirmar.Password) {
                for(int i = 0; i < GestaoHotel.getAdmins().Count; i++) {
                    if(GestaoHotel.getAdmins()[i].Id == GestaoHotel.userIDSession) {
                        GestaoHotel.getAdmins()[i].Username = settingUsername.Text;
                        GestaoHotel.getAdmins()[i].Nome = settingNome.Text;
                        GestaoHotel.getAdmins()[i].Email = settingEmail.Text;
                        GestaoHotel.getAdmins()[i].Password = settingPassword.Password;
                        MessageBox.Show("Dados alterados com sucesso!");
                        Console.WriteLine(GestaoHotel.getAdmins()[i].ToString());
                        break;
                    }
                }
            } else {
                MessageBox.Show("As Passwords não coincidem!");
            }

        }

    }

}
