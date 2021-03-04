using MailSender.Models.Base;
using System;

namespace MailSender.Models
{
    public class Recipient : Entity
    {
        public string _Name;
            public string Name
        {
            get => _Name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Не задано имя пользователя!");
                _Name = value;
            }
        }
        public string Address { get; set; }
    }
}
