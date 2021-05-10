using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class Cliente : INotifyPropertyChanged {

        List<Morada> morada = new List<Morada>();

        private int id;
        private int idquarto;
        private int numero;
        private string nome;
        private string email;
        private int telefone;
        private int nif;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Id {
            get => id;
            set {
                OnPropertyChanged("Id");
                id = value;
            }
        }
        public int Idquarto {
            get => idquarto;
            set {
                OnPropertyChanged("Idquarto");
                idquarto = value;
            }
        }
        public int Numero {
            get => numero;
            set {
                OnPropertyChanged("Numero");
                numero = value;
            }
        }
        public string Nome {
            get => nome;
            set {
                OnPropertyChanged("Nome");
                nome = value;
            }
        }
        public string Email {
            get => email;
            set {
                OnPropertyChanged("Email");
                email = value;
            }
        }
        public int Telefone {
            get => telefone;
            set {
                OnPropertyChanged("Telefone");
                telefone = value;
            }
        }
        public int Nif {
            get => nif;
            set {
                OnPropertyChanged("Nif");
                nif = value;
            }
        }

        public Cliente(int id, int idquarto, int numero, string nome, string email, int telefone, int nif) {
            this.id = id;
            this.idquarto = idquarto;
            this.numero = numero;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.nif = nif;
        }

        public List<Morada> getMorada() {
            return morada;
        }

        public override string ToString() {
            return id + ", " + idquarto + ", " + numero + ", " + nome + ", " + email + ", " + telefone + ", " + nif;
        }

    }

}
