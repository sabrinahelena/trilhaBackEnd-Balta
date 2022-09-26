using System;

namespace Aula5Classes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Pagamento.Vencimento = DateTime.Today;
            Payment payment = new Payment();
            payment.PropriedadeA = 1;
            payment.PropriedadeB = 2; //consigo acessar as duas propriedades criadas em duas partial class
        }

        public static class Pagamento //não deve ser possivel instanciar, mas para uma classe como pagamento não tem como ser estática, pois não é sempre a mesma coisa.
        {
            // public Pagamento()
            // {
            //     
            // }

            public static DateTime Vencimento { get; set; } //as propriedades de uma classe estática tem que ser estática
        }

        public static class Settings //faz sentido colocar isso como static, pois é sempre a mesma informação.
        {
            public static string API_URL { get; set; }
        }

        public sealed class ConsultarSaldo //essas classes não podem ser herdadas, pois estão seladas.
        { 
            
        }
        
        
        
    }
}