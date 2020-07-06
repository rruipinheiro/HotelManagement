using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class Fatura : INotifyPropertyChanged {

        private int id;
        private int nReservas;
        private double valorTotal;
        private string data;

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
        public int NReservas {
            get => nReservas;
            set {
                OnPropertyChanged("NReservas");
                nReservas = value;
            }
        }
        public double ValorTotal {
            get => valorTotal;
            set {
                OnPropertyChanged("ValorTotal");
                valorTotal = value;
            }
        }
        public string Data {
            get => data;
            set {
                OnPropertyChanged("Data");
                data = value;
            }
        }

        public Fatura(int id, int nReservas, double valorTotal, string data) {
            this.id = id;
            this.nReservas = nReservas;
            this.valorTotal = valorTotal;
            this.data = data;
        }

        public override string ToString() {
            return id + ", " + nReservas + ", " + valorTotal + ", " + data;
        }

    }

}
