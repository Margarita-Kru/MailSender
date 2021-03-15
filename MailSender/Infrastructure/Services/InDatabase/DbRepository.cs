using MailSender.Data;
using MailSender.lib.Entities.Base;
using MailSender.lib.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MailSender.Infrastructure.Services.InDatabase
{
    public class DbRepository<T> : IRepository<T> where T : Entity
    {
        private readonly MailSenderDb _db;
        private DbSet<T> Set { get; }
        public DbRepository(MailSenderDb db)
        {
            _db = db;
            Set = db.Set<T>();
        }
        public int Add(T item)
        {
            Set.Add(item);
            _db.SaveChanges();
            return item.Id;
        }

        public IEnumerable<T> GetAll() => Set;

        public T GetbyId(int id) => Set.Find(id);
        public bool Remove(int id)
        {   
            var item = GetbyId(id);
            if (item is null) return false;
            Set.Remove(item);
            _db.SaveChanges();
            return true;
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
