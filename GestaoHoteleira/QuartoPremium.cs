using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class QuartoPremium : QuartoBasic, INotifyPropertyChanged {

        private string nomeDesigner; 

        public string NomeDesigner {
            get => nomeDesigner;
            set {
                OnPropertyChanged("NomeDesigner");
                nomeDesigner = value;
            }
        }

        public QuartoPremium(int id, int numero, int piso, bool ocupado, string nomeDesigner) : base(id, numero, piso, ocupado) {
            this.nomeDesigner = nomeDesigner;
        }



        public override string tipo() {
            return "Premium";
        }

        public override string getDesigner() {
            return nomeDesigner;
        }

    }

}
