using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class Reserva : INotifyPropertyChanged {

        ObservableCollection<Fatura> faturas = new ObservableCollection<Fatura>();

        private int id;
        private int idQuarto;
        private int uid;
        private string dataInicio;
        private string dataFim;
        private double preco;

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
        public int IdQuarto {
            get => idQuarto;
            set {
                OnPropertyChanged("IdQuarto");
                idQuarto = value;
            }
        }
        public int Uid {
            get => uid;
            set {
                OnPropertyChanged("Id");
                uid = value;
            }
        }
        public string DataInicio {
            get => dataInicio;
            set {
                OnPropertyChanged("DataInicio");
                dataInicio = value;
            }
        }
        public string DataFim {
            get => dataFim;
            set {
                OnPropertyChanged("DataFim");
                dataFim = value;
            }
        }
        public double Preco {
            get => preco;
            set {
                OnPropertyChanged("Preco");
                preco = value;
            }
        }

        public Reserva(int id, int idQuarto, int uid, string dataInicio, string dataFim, double preco) {
            this.id = id;
            this.idQuarto = idQuarto;
            this.uid = uid;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.preco = preco + GestaoHotel.getTotalConsumosById(id);
        }

        public ObservableCollection<Fatura> getFaturas() {
            return faturas;
        }

        public override string ToString() {
            return id + ", " + idQuarto + ", " + uid + ", " + dataInicio + ", " + dataFim + ", " + preco;
        }

    }

}
