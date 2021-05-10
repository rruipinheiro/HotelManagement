using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    class Consumo {

        private int id;
        private string nome;
        private double preco;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double Preco { get => preco; set => preco = value; }

        public Consumo(int id, string nome, double preco) {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
        }

    }

}
