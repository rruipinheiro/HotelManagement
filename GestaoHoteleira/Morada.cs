namespace GestaoHoteleira
{

    class Morada {

        private int id;
        private int uid;
        private string pais;
        private string destrito;
        private string freguesia;
        private int codigoPostal;

        public int Id { get => id; set => id = value; }
        public int Uid { get => uid; set => uid = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Rua { get; set; }
        public string Destrito { get => destrito; set => destrito = value; }
        public string Freguesia { get => freguesia; set => freguesia = value; }
        public int CodigoPostal { get => codigoPostal; set => codigoPostal = value; }

        public Morada(int id, int uid, string pais, string rua, string destrito, string freguesia, int codigoPostal) {
            this.id = id;
            this.uid = uid;
            this.pais = pais;
            this.Rua = rua;
            this.destrito = destrito;
            this.freguesia = freguesia;
            this.codigoPostal = codigoPostal;
        }

        public override string ToString() {
            return Rua + " " + codigoPostal + " " + freguesia + " " + destrito + " " + pais;
        }

    }

}
