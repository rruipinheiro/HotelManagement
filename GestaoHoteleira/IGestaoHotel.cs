using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHoteleira {

    interface IGestaoHotel {

        bool ocupado(int piso, int nQuarto);
        int quartosLivres();
        double valorConsumos(int piso, int nQuarto);
        double precoQuarto(int piso, int nQuarto, int noite);
        double precoMaisCaro();

        List<QuartoPremium> quartosDesigner(string designer);
        List<QuartoSuper> quartosConsumosSuperiorA(double consumo);

        Dictionary<string, int> quartosPorTipo();

    }

}
