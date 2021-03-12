using MailSender.Models.Base;
using System;
using System.ComponentModel;

namespace MailSender.Models
{
    public class Recipient : Entity, IDataErrorInfo
    {
        public string _Name;

        public string this[string columnName] => throw new NotImplementedException();

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

        string IDataErrorInfo.Error => null;
        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch(PropertyName)
                {
                    default: return null;
                    case nameof(Name):
                        var name = Name;
                        if (name is null) return "Имя не может быть пустой строкой";
                        if (name.Length<3) return "Длина имени должна быть больше 3 символов";
                        if (name.Length> 20) return "Длина имени не может быть больше 20 символов";
                        return null;
                }
            }
        }
    }
}
