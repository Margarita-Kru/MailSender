﻿using MailSender.Models;
using System.Linq;

namespace MailSender.Infrastructure.Services.InMemory
{
    class RecipientsRepository : RepositoryInMemory<Recipient>
    {
        public RecipientsRepository() : base(Enumerable.Range(1, 10)
            .Select(i => new Recipient
            {
                Id = i,
                Name = $"Имя-{i}",
                Address = $"recipient{i}@server.com",
            }))
        { }
        public override void Update(Recipient item)
        {
            var db_item = GetbyId(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;
            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }
    }
}
