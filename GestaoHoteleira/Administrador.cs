using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class Administrador : INotifyPropertyChanged {

        private int id;
        private int uid;
        private string username;
        private string nome;
        private string email;
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Id { get => id; set => id = value; }
        public int Uid { get => uid; set => uid = value; }
        public string Username { get => username; set => username = value; }
        public string Nome {
            get => nome;
            set {
                OnPropertyChanged("Nome");
                nome = value;
            }
        }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public Administrador(int id, int uid, string username, string nome, string email, string password) {
            this.id = id;
            this.uid = uid;
            this.username = username;
            this.nome = nome;
            this.email = email;
            this.password = password;
        }

        public override string ToString() {
            return id + ", " + uid + ", " + username + ", " + nome + ", " + email + ", " + password;
        }

    }

}
