using System.Collections.Generic;
using System.Linq;
using ContentContext;
using NotificationContext;

namespace SubscriptionContext
{
    public class Student : Base
    {
        public Student()
        {
            Subscriptions = new List<Subscription>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
        
        public IList<Subscription> Subscriptions { get; set; }

        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive); //se tiver assinatura ativa

        public void CreateSubscription(Subscription sub)
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", "O aluno já tem assinatura ativa"));
                
            }
            Subscriptions.Add(sub);
        }
    }
}