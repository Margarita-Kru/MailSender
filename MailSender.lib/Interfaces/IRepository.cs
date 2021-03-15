using MailSender.lib.Entities.Base;
using System.Collections.Generic;

namespace MailSender.lib.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetbyId(int Id);
        int Add(T item);
        void Update(T item);
        bool Remove(int Id);
    }
}
