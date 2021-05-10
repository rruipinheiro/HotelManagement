using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class QuartoBasic : INotifyPropertyChanged {

        private int id;
        private int numero;
        private int piso;
        private bool ocupado;
        private double preco;
        private string tipoQuarto;
        private int nClientesQuarto;

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
                OnPropertyChanged("Codigo");
                id = value;
            }
        }
        public int Numero {
                get => id;
                set {
                    OnPropertyChanged("Codigo");
                    id = value;
                }
        }

        public int Piso {
            get => piso;
            set {
                OnPropertyChanged("Piso");
                piso = value;
            }
        }

        public bool Ocupado {
            get => ocupado;
            set {
                OnPropertyChanged("Ocupado");
                ocupado = value;
            }
        }
        public string TipoQuarto {
            get => tipoQuarto;
            set {
                OnPropertyChanged("TipoQuarto");
                tipoQuarto = value;
            }
        }

        public double Preco {
            get => preco;
            set {
                OnPropertyChanged("Preco");
                preco = value;
            }
        }

        public int NClientesQuarto { get => nClientesQuarto; set => nClientesQuarto = value; }

        public QuartoBasic(int id, int numero, int piso, bool ocupado) {
            this.id = id;
            this.numero = numero;
            this.piso = piso;
            this.ocupado = ocupado;
            Preco = getPreco();
            tipoQuarto = tipo();
        }

        virtual public double getPreco() {
            return 50;
        }

        virtual public string tipo() {
            return "Basic";
        }

        virtual public string getDesigner() {
            return "";
        }

    }

}
