using TesteTennis.Service;
using TesteTennis.Service.Builder;

namespace TestTennis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //executando com game mockado
            MatchBuilder.NewInstance().BuildGame();

            //executando com game via arquivo (criar arquivo e alterar o caminho, caso necessário. Exemplo de arquivo em CrossCutting/Utils)
            //FileMatchBuilder.NewInstance().BuildGame("C:\\teste\\game.txt");
        }
    }
}