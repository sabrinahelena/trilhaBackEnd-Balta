using System;
using ContentContext;

namespace SubscriptionContext
{
    public class Subscription : Base
    {
        public Plan Plan { get; set; } //toda assinatura precisa de um plano
        public DateTime? EndDate { get; set; }
        public bool IsInactive => EndDate <= DateTime.Now;
    }
}