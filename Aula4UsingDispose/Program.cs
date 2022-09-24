using System;

namespace Aula4UsingDispose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var xPagamento = new Pagamento();
            xPagamento.Dispose();

            //Para garantir o dispose, é melhor usar using, pois a chance de escolher o dispose é alta.

            using (var pagamento = new Pagamento()) //Isso aqui permite iniciar, processar e deletar (disposable).
            {
                Console.WriteLine("Processando pagamento");
            }
        }

        public class Pagamento : IDisposable
        {
            //Garbage collector (coletor de lixo)
            // Ele olha os objetos que não estão sendo utilizados e retira da memória.
            //Temos que pensar em criar e destruir esse objeto. Algo deve acontecer quando cria e deleta.
            //Precisamos de algo para fechar conexões.
            
            //Assim como existem construtores para criar, deve existir algo para deletar.
            
            public Pagamento()
            {
                    Console.WriteLine("Iniciando pagamento");
            }


            public void Dispose()
            {
                Console.WriteLine("Finalizei meu pagamento. ");
            }
        }
    }
}