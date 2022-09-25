using System;

namespace Aula6Interfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // //Upcast: objeto filho para objeto pai
            // var pessoa = new Person("Sabrina");
            // var pessoaFisica = new Personal();
            // pessoa = pessoaFisica;
            // pessoa = new Personal(); 
            // pessoa = new Corporate();
            //
            // //Downcast
            //
            // var pessoaFisicaa = new Personal();
            // var pessoaJuridica = new Corporate();

            // pessoaFisicaa = (Personal)pessoa; //conversão explícita. 
            
            
            //Comparação de objetos

            var pessoaA = new Person("Sabrina Helena Ferreira");
            pessoaA.Id = 1;
            var pessoaB = new Person("Sabrina Helena Ferreira");
            pessoaB.Id = 1;
            
            Console.WriteLine(pessoaA.Equals(pessoaB)); //são referencias diferentes.
        }
        
        //UPCAST E DOWNCAST

        public class Person : IEquatable<Person>
        {
            public Person(string name)
            {
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }

            public bool Equals(Person other) //para comparar objetos
            {
                return Id == other.Id;
            }
        }

        public class Personal : Person
        {
            public Personal(string name, string cpf) : base(name)
            {
                CPF = cpf;
            }

            public string CPF { get; set; }
        }

        public class Corporate : Person
        {
            public Corporate(string name, string cnpj) : base(name)
            {
                CNPJ = cnpj;
            }

            public string CNPJ { get; set; }
        }
        
        
        
        //INTERFACE:

        public abstract class Payment : IPayment //essa classe nao pode ser instanciada, apenas herdada
        {
            public DateTime Vencimento { get; set; }
            public virtual void Pagar(double valor)
            {
                throw new NotImplementedException();
            }
        }

        public class PagamentoBoleto : Payment
        {
            public override void Pagar(double valor)
            {
                
            }
        }
        
        public class PagamentoCartaoCredito : Payment
        {
            public override void Pagar(double valor)
            {
                
            }
        }
        
        
        
        //interface definimos um contrato, como uma classe deve ser

        public interface IPayment //diz oque deve ser feito
        { 
            DateTime Vencimento { get; set; } //define que precisa dessa prorpeidade
            void Pagar(double valor);//terei que usar esse método 
        }
    }
}