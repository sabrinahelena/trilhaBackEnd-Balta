using System;
using NotificationContext;

namespace ContentContext
{
    public abstract class Base : Notifiable

    {
        public Base()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}