using System;

namespace Aula1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customer = new Cliente();
            customer.Name = "Sabrina";

            var pagamento = new Pagamento();
            pagamento.Vencimento = DateTime.Parse("2030-01-08");

            var pagamentoBoleto = new PagamentoBoleto();

            var pagamentoCartao = new PagamentoCartaoCredito();
            
            


        }
    }

    public class Cliente
    {
        public string Name { get; set; }
    }

    public class Pagamento //classe pai
    {
        //Propriedades: variáveis, características que o objeto tem
        public DateTime Vencimento { get; set; }
        
        
            
        //Métodos: funções
        public virtual void Pagar() //virtual permite ser escrito por cima
        {
        }


    }

    public class PagamentoBoleto : Pagamento
    {
        public string NumeroBoleto { get; set; }
        //Como estou herdando pagamento, não preciso implementar novamente os métodos.

        public override void Pagar()
        {
            //Regra boleto
        }
    }

    public class PagamentoCartaoCredito : Pagamento
    {
        public string Numero { get; set; }
        public override void Pagar()
        {
            ConsultarSaldoCartao("123456");
        }
        private void ConsultarSaldoCartao(string conta) //não faz sentido programas de fora chamar esse método, expor isso, ou seja, abstraímos do resto.
        {
            
        }
        
    }
}