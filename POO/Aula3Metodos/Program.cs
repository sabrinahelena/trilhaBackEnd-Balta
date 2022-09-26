using System;

namespace Aula3Metodos
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var pagamento = new Pagamento(DateTime.Now);
            pagamento.Pagar("124124124");

            var pagamentoCartao = new PagamentoCartao(DateTime.Now);
            pagamentoCartao.Pagar("123142");
        }

        public class Pagamento
        {
            public Pagamento()
            {
                    
            }
            public Pagamento(DateTime Vencimento)// construtor
            {
                Console.WriteLine("Iniciando pagamento"); //Acontece toda vez que o objeto é iniciado, é instanciado (quando da o new)
            }
            public virtual void Pagar(string numero)
            {
                Console.WriteLine("Pagar");
            }

            public void Pagar(string numero, DateTime vencimento)
            {
                
            }
            
            //Dois métodos com assinaturas de método diferentes = sobrecarga de métodos. Isso pode acontecer, é muito comum.
        }

        public class PagamentoCartao : Pagamento
        {
            public PagamentoCartao(DateTime vencimento)
            {
                Console.WriteLine("Iniciando pagamento com cartão");
            }
            public override void Pagar(string numero) //sobrescrevendo o método
            {
                Console.WriteLine("Pagar cartão ");
            }
        }
    }
}