using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GestaoHoteleira {

    class GestaoHotel : IGestaoHotel {

        // Guarda o id o adminstrador
        public static int userIDSession;

        // Cria e iniciliza as listas
        static List<Administrador> admins = new List<Administrador>();
        static ObservableCollection<QuartoBasic> quartos = new ObservableCollection<QuartoBasic>();
        static ObservableCollection<Cliente> clientes = new ObservableCollection<Cliente>();
        static ObservableCollection<Reserva> reservas = new ObservableCollection<Reserva>();
        static ObservableCollection<Consumo> consumos = new ObservableCollection<Consumo>();

        /***************************************** Critérios Mínimos *****************************************/

        // Preenche as listas para testar a aplicação
        public static void preencher() {

            admins.Add(new Administrador(1, 123456789, "user1", "Rui Pinheiro1", "user1@hotmail.com", "123"));
            admins.Add(new Administrador(2, 123456789, "user2", "Rui Pinheiro2", "user2@hotmail.com", "123"));
            admins.Add(new Administrador(3, 123456789, "user3", "Rui Pinheiro3", "user3@hotmail.com", "123"));
            admins.Add(new Administrador(4, 123456789, "user4", "Rui Pinheiro4", "user4@hotmail.com", "123"));

            quartos.Add(new QuartoBasic(1, 1, 1, true));
            quartos.Add(new QuartoBasic(2, 2, 2, false));
            quartos.Add(new QuartoBasic(3, 3, 3, true));
            quartos.Add(new QuartoSuper(4, 4, 2, true));
            quartos.Add(new QuartoSuper(5, 5, 2, false));
            quartos.Add(new QuartoSuper(6, 6, 3, false));
            quartos.Add(new QuartoPremium(7, 7, 1, false, "Rui Pinheiro1"));
            quartos.Add(new QuartoPremium(8, 8, 1, true, "Rui Pinheiro2"));
            quartos.Add(new QuartoPremium(9, 9, 3, false, "Rui Pinheiro3"));

            clientes.Add(new Cliente(1,1,43244, "Rui Pinheiro1", "user@hotmail.com1", 912323233, 86426282));
            clientes.Add(new Cliente(2,0,13233, "Rui Pinheiro2", "user@hotmail.com2", 912323233, 86426282));
            clientes.Add(new Cliente(3,3,12334, "Rui Pinheiro3", "user@hotmail.com3", 912323233, 86426282));
            clientes.Add(new Cliente(4,0,56646, "Rui Pinheiro4", "user@hotmail.com4", 912323233, 86426282));
            clientes.Add(new Cliente(5,4,65465, "Rui Pinheiro5", "user@hotmail.com5", 912323233, 86426282));
            clientes.Add(new Cliente(6,0,87545, "Rui Pinheiro6", "user@hotmail.com6", 912323233, 86426282));
            clientes.Add(new Cliente(7,8,34345, "Rui Pinheiro7", "user@hotmail.com7", 912323233, 86426282));
            clientes.Add(new Cliente(8,0,34345, "Rui Pinheiro8", "user@hotmail.com8", 912323233, 86426282));

            clientes[0].getMorada().Add(new Morada(1, 1, "Portugal1", "Rua1", "Destrito1", "Freguesia1", 11111));
            clientes[1].getMorada().Add(new Morada(2, 2, "Portugal2", "Rua2", "Destrito2", "Freguesia2", 22222));
            clientes[2].getMorada().Add(new Morada(3, 3, "Portugal3", "Rua3", "Destrito3", "Freguesia3", 33333));
            clientes[3].getMorada().Add(new Morada(4, 4, "Portugal4", "Rua4", "Destrito4", "Freguesia4", 44444));
            clientes[4].getMorada().Add(new Morada(5, 5, "Portugal5", "Rua5", "Destrito5", "Freguesia5", 55555));
            clientes[5].getMorada().Add(new Morada(6, 6, "Portugal6", "Rua6", "Destrito6", "Freguesia6", 66666));
            clientes[6].getMorada().Add(new Morada(7, 7, "Portugal7", "Rua7", "Destrito7", "Freguesia7", 77777));
            clientes[7].getMorada().Add(new Morada(8, 8, "Portugal8", "Rua8", "Destrito8", "Freguesia8", 88888));

            reservas.Add(new Reserva(1, 1, 1, "01/02/2018", "03/02/2018", 100));
            reservas.Add(new Reserva(2, 3, 3, "01/02/2018", "02/03/2018", 100));
            reservas.Add(new Reserva(3, 4, 5, "01/02/2018", "02/03/2018", 110));
            reservas.Add(new Reserva(4, 8, 7, "01/02/2018", "02/03/2018", 100));

            consumos.Add(new Consumo(1, "Cola1", 10));
            consumos.Add(new Consumo(2, "Cola2", 20));
            consumos.Add(new Consumo(3, "Cola3", 30));
            consumos.Add(new Consumo(4, "Cola4", 40));
            consumos.Add(new Consumo(5, "Cola5", 50));

            /**reservas[0].getFaturas().Add(new Fatura(1, 1, 200, "02/02/2018"));
            reservas[1].getFaturas().Add(new Fatura(2, 2, 200, "05/03/2018"));
            reservas[2].getFaturas().Add(new Fatura(3, 3, 200, "06/02/2018"));
            reservas[3].getFaturas().Add(new Fatura(4, 4, 200, "03/02/2018"));**/

        }

        public bool ocupado(int piso, int nQuarto) {
            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i].Piso == piso && quartos[i].Numero == nQuarto && quartos[i].Ocupado) {
                    return true;
                }
            }
            return false;
        }

        public double valorConsumos(int piso, int nQuarto) {
            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i] is QuartoSuper && quartos[i].Piso == piso && quartos[i].Numero == nQuarto) {
                    QuartoSuper super = (QuartoSuper)quartos[i];
                    return super.getTotalConsumos();
                }
            }
            return -1;
        }

        public double precoQuarto(int piso, int nQuarto, int noite) {
            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i].Piso == piso && quartos[i].Numero == nQuarto) {
                    return quartos[i].Preco * noite;
                }
            }
            return -1;
        }

        public double precoMaisCaro() {

            double max = quartos[0].Preco;
            int index = 0;

            for(int i = 1; i < quartos.Count; i++) {
                if(quartos[i].Preco >= max) {
                    max = quartos[i].Preco;
                }
            }
            return quartos[index].Preco;
        }

        public int quartosLivres() {

            int count = 0;

            for(int i = 0; i < quartos.Count; i++) {
                if(!quartos[i].Ocupado) {
                    count++;
                }
            }

            return count;

        }

        public List<QuartoPremium> quartosDesigner(string designer) {

            List<QuartoPremium> newList = new List<QuartoPremium>();

            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i] is QuartoPremium && quartos[i].getDesigner() == designer) {
                    QuartoPremium premium = (QuartoPremium)quartos[i];
                    newList.Add(premium);
                }
            }
            return newList;
        }

        public List<QuartoSuper> quartosConsumosSuperiorA(double consumo) {

            List<QuartoSuper> newList = new List<QuartoSuper>();

            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i] is QuartoSuper) {
                    QuartoSuper super = (QuartoSuper)quartos[i];
                    if(super.getTotalConsumos() > consumo) {
                        newList.Add(super);
                    }
                }
            }
            return newList;
        }

        public Dictionary<string, int> quartosPorTipo() {

            Dictionary<string, int> dic = new Dictionary<string, int>();

            for(int i = 0; i < quartos.Count; i++) {
                if(!dic.ContainsKey(quartos[i].TipoQuarto)) {
                    dic.Add(quartos[i].TipoQuarto, quartos[i].Numero);
                }
            }
            return dic;
        }
        /***************************************** END Critérios *****************************************/

        // Retorna a lista de Administradores
        public static List<Administrador> getAdmins() {
            return admins;
        }

        // Retorna a lista de Quartos
        public static ObservableCollection<QuartoBasic> getQuartos() {
            return quartos;
        }

        // Retorna a lista de Quarto que não estão ocupados
        public static ObservableCollection<QuartoBasic> getQuartosNaoOcupados() {

            ObservableCollection<QuartoBasic> quartosNaoOcupados = new ObservableCollection<QuartoBasic>();

            for(int i = 0; i < quartos.Count; i++) {
                if(!quartos[i].Ocupado) {
                    quartosNaoOcupados.Add(quartos[i]);
                }
            }

            return quartosNaoOcupados;

        }

        // Retorna a lista de Clientes
        public static ObservableCollection<Cliente> getClientes() {
            return clientes;
        }

        // Retorna a lista de Reservas
        public static ObservableCollection<Reserva> getReservas() {
            return reservas;
        }

        // Retorna a lista de Consumos
        public static ObservableCollection<Consumo> getConsumos() {
            return consumos;
        }

        // Retorna a lista de Consumos
        public static List<double> getConsumosById(int idQuarto) {
            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i] is QuartoSuper && quartos[i].Id == idQuarto) {
                    QuartoSuper super = (QuartoSuper)quartos[i];

                    return super.getConsumos();

                }

            }
            return null;
        }

        // Retorna a lista de Consumos
        public static double getTotalConsumosById(int idQuarto) {
            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i] is QuartoSuper && quartos[i].Id == idQuarto) {
                    QuartoSuper super = (QuartoSuper)quartos[i];

                    return super.getTotalConsumos();

                }
            }
            return 0;
        }

        /**public static ObservableCollection<Consumo> getConsumosById(int idQuarto) {
            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i] is QuartoSuper) {
                    
                }
            }
        }**/

        // Retorna a lista de faturas
        public static ObservableCollection<Fatura> getFaturas() {

            ObservableCollection<Fatura> faturas = new ObservableCollection<Fatura>();

            for(int i = 0; i < reservas.Count; i++) {
                for(int j = 0; j < reservas[i].getFaturas().Count; j++) {
                    faturas.Add(reservas[i].getFaturas()[j]);
                }
            }

            return faturas;

        }

        // Retorna o total das faturas
        public static int getNumberOfFaturas() {
#pragma warning disable CS0162 // Unreachable code detected
            for (int i = 0; i < reservas.Count; i++) {
#pragma warning restore CS0162 // Unreachable code detected
                return reservas[i].getFaturas().Count;
            }
            return 0;
        }

        // Retorna a lista de faturas pelo IdReserva
        public static ObservableCollection<Fatura> setFaturasByIdReserva(int idReserva) {

            for(int i = 0; i < reservas.Count; i++) {
                if(reservas[i].Id == idReserva) {
                    return reservas[i].getFaturas();
                }
            }

            return null;

        }

        // Retorna o usename do administrador logado
        public static string getUsername() {

            for(int i = 0; i < admins.Count; i++) {
                if(admins[i].Id == userIDSession) {
                    return admins[i].Nome;
                }
            }

            return null;

        }

        // Retorna o numero de quartos disponiveis
        public static int getQuartosDisponiveis() {

            int count = 0;

            for(int i = 0; i < quartos.Count; i++) {
                if(!quartos[i].Ocupado) {
                    count++;
                }
            }

            return count;

        }

        // Retorna lista dos quartos ocupados
        public static List<QuartoBasic> getQuartosSuperOcupados() {

            List<QuartoBasic> quartosOcupados = new List<QuartoBasic>();

            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i] is QuartoSuper) {
                    if(quartos[i].Ocupado) {
                        quartosOcupados.Add(quartos[i]);
                    }
                }
            }

            return quartosOcupados;

        }
        
        // Retorna o numero total de quartos
        public static int getTotalQuartos() {
            return quartos.Count;
        }

        // Retorna o numero total de clientes
        public static int getTotalClientes() {
            return clientes.Count;
        }

        // Retorna o Cliente que não tem reservas
        public static List<Cliente> getClientesSemReserva() {

            List<Cliente> clientesSemReserva = new List<Cliente>();

            for(int i = 0; i < clientes.Count; i++) {
                if(clientes[i].Idquarto == 0) {
                    clientesSemReserva.Add(clientes[i]);
                }
            }

            return clientesSemReserva;

        }

        // Retorna o Cliente através do numero de Utilizador
        public static Cliente getClienteByUid(int uid) {

            for(int i = 0; i < clientes.Count; i++) {
                if(clientes[i].Id == uid) {
                    return clientes[i];
                }
            }

            return null;

        }

        // Retorna o Cliente através do numero do Id Quarto
        public static Cliente getClienteByQuartoId(int idQuarto) {

            for(int i = 0; i < clientes.Count; i++) {
                if(clientes[i].Idquarto == idQuarto) {
                    return clientes[i];
                }
            }

            return null;

        }

        // Retorna o Quarto através do Id do Quarto
        public static QuartoBasic getQuartoById(int idQuarto) {
            for(int i = 0; i < quartos.Count; i++) {
                if(quartos[i].Id == idQuarto) {
                    return quartos[i];
                }
            }

            return null;

        }

        // Retorna Cliente by Reserva Id
        public static Cliente getClienteByReservaId(int idReserva) {

            for(int i = 0; i < reservas.Count; i++) {
                for(int j = 0; j < clientes.Count; j++) {
                    if(reservas[i].Id == idReserva && clientes[j].Id == reservas[i].Uid) {
                        return clientes[j];
                    }
                }
            }

            return null;

        }

        // Retorna Quarto by Reserva Id
        public static QuartoBasic getQuartoByReservaId(int idReserva) {

            for(int i = 0; i < reservas.Count; i++) {
                for(int j = 0; j < quartos.Count; j++) {
                    if(reservas[i].Id == idReserva && quartos[j].Id == reservas[i].IdQuarto) {
                        return quartos[j];
                    }
                }
            }

            return null;

        }

        // Retorna Reserva by Quarto Id
        public static Reserva geReservaByQuartoId(int idQuarto) {

            for(int i = 0; i < quartos.Count; i++) {
                for(int j = 0; j < reservas.Count; j++) {
                    if(quartos[i].Id == idQuarto && reservas[j].IdQuarto == quartos[i].Id) {
                        return reservas[j];
                    }
                }
            }

            return null;

        }

        // Retorna Cliente by Fatura Id
        public static Cliente getClienteByFaturaId(int idFatura) {

            for(int i = 0; i < getFaturas().Count; i++) {
                for(int j = 0; j < reservas.Count; j++) {
                    for(int k = 0; k < clientes.Count; k++) {
                        if(getFaturas()[i].Id == idFatura && getFaturas()[i].NReservas == reservas[j].Id && reservas[j].Uid == clientes[k].Id) {
                            return clientes[k];
                        }
                    }
                }
            }

            return null;

        }

        // Retorna Quarto by Fatura Id
        public static QuartoBasic getQuartoByFaturaId(int idFatura) {

            for(int i = 0; i < getFaturas().Count; i++) {
                for(int j = 0; j < reservas.Count; j++) {
                    for(int k = 0; k < quartos.Count; k++) {
                        if(getFaturas()[i].Id == idFatura && getFaturas()[i].NReservas == reservas[j].Id && reservas[j].IdQuarto == quartos[k].Id) {
                            return quartos[k];
                        }
                    }
                }
            }

            return null;

        }

        // Check se a fatura já existe através do Id
        public static bool CheckFaturaAlreadyExistsByIdReserva(int idReserva) {

            for(int i = 0; i < reservas.Count; i++) {
                for(int j = 0; j < reservas[i].getFaturas().Count; j++) {
                    if(reservas[i].getFaturas()[j].NReservas == idReserva) {
                        return true;
                    }
                }
            }

            return false;

        }

        // Retorna o numero de dias da diferença das datas
        public static int getNumberOfDays(string dataFim, string dataInicio) {
            TimeSpan date = Convert.ToDateTime(dataFim) - Convert.ToDateTime(dataInicio);
            return date.Days;
        }

    }

}
