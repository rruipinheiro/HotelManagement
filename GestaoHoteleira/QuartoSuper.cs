using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class QuartoSuper : QuartoBasic, INotifyPropertyChanged {

        List<double> consumos = new List<double>();

        public QuartoSuper(int id, int numero, int piso, bool ocupado) : base(id, numero, piso, ocupado) {}

        public List<double> getConsumos() {
            return consumos;
        }

        public double getTotalConsumos() {

            double soma = 0;

            for(int i = 0; i < getConsumos().Count; i++) {
                soma += getConsumos()[i];
            }
            return soma;
        }

        public override double getPreco() {
            return base.getPreco() * 1.1 + getTotalConsumos();
        }

        public override string tipo() {
            return "Super";
        }

    }

}
