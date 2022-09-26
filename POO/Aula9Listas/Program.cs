using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula9Listas
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //IEnumerable<Payment> paymentsB = new List<Payment>(); //lista de leitura.
            IList<Payment> paymentsA = new List<Payment>(); //Consegue fazer mais coisas com a lista, como adicionar.
            paymentsA.Add(new Payment(1));
            paymentsA.Add(new Payment(2));
            paymentsA.Add(new Payment(3));
            paymentsA.Add(new Payment(4));

            var paidPaymentos = new List<Payment>();
            paidPaymentos.AddRange((paymentsA));

            var p = paymentsA.Where(i => i.Id == 1);
            var pF = paymentsA.FirstOrDefault(x => x.Id == 1);

            var exists = paymentsA.Any(x => x.Id == 2);
            Console.WriteLine(exists);

            paymentsA.AsEnumerable(); //assim como um enumerable pode ser convertido para tolist, toarray...
            
            






            foreach (var payment in paymentsA)
            {
                Console.WriteLine(payment.Id);
            }
            

        }
    }

    public class Payment
    {
        public int Id { get; set; }

        public Payment(int id)
        {
            Id = id;
        }
    }
}