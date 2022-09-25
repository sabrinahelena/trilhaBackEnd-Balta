namespace Aula8Generics
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person();
            var context = new DataContext<Person, Payment, Subscription>();
            context.Save(person);
            
        }
        
    }
//Generics. Nosso datacontext salva informações, mas não é preciso fazer um save para cada informação se podemos fazer genérico;
    public class DataContext<T, U, V> where T : Person// isso significa que T só pode ser do tipo classe person
    {
        public void Save(T entity)
        {
            
        }

        public void Save(U entity)
        {
            
        }

        public void Save(V entity)
        {
            
        }
    }

    public class Person
    {
        
    }

    public class Payment
    {
        
    }

    public class Subscription
    {
        
    }
}