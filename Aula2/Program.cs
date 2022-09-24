using System;

namespace Aula2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pagamento = new Pagamento();
            pagamento.numeroBoleto = "12ee3456";
            pagamento.DataPagamento = DateTime.Parse("01-12-2024");
            Console.Write("Hello World");

        }

        public class Pagamento
        {
            public string numeroBoleto;
            private DateTime _dataPagamento;

            public DateTime DataPagamento
            {
                get
                {
                    Console.WriteLine("Lendo valor");
                    return _dataPagamento;
                } //permite interagir com o valor
                set
                {
                    Console.WriteLine("Atribuindo valor");
                    _dataPagamento = value;
                }
            }
        }
    }
}