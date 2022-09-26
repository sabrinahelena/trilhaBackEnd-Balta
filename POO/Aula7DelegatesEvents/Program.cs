using System;

namespace Aula7DelegatesEvents
{
    public class Program
    {

        static void RealizarPagamento(double valor)
        {
            Console.WriteLine($"Pago o valor de  {valor}");
        }
        public static void Main(string[] args)
        {
            
            //Delegates
            var pagar = new Pagamento.Pagar(RealizarPagamento); //está apontando para o pagamento, pagar e delegando a responsa dele
            pagar(200.25);
            
            //Events
            
            var room = new Room(3);
            room.RoomSoldOut += OnRoomSoldOut; //delegate
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();


        }

        static void OnRoomSoldOut(object sender, EventArgs e)
        {
            Console.WriteLine("Sala lotada! ");
        }
        
        

        public class Pagamento
        {
            public delegate void Pagar(double valor); //Não vou fazer esse método aqui, e sim delegando para fora
        }

        public class Room
        {
            public Room(int seats)
            {
                Seats = seats;
                seatsInUse = 0;
            }

            private int seatsInUse = 0;
            public int Seats { get; set; }

            public void ReserveSeat()
            {
                seatsInUse++;
                if (seatsInUse >= Seats)
                {
                    //Evento fechado!
                    OnRoomSoldOut(EventArgs.Empty);
                }
                else
                {
                    Console.WriteLine("Assendo reservado! ");
                }
            }

            public event EventHandler RoomSoldOut; //declarar evento

            protected virtual void OnRoomSoldOut(EventArgs e) //método que manipula o evento
            {
                EventHandler handler = RoomSoldOut;
                handler?.Invoke(this, e);
            }

        }
    }
}