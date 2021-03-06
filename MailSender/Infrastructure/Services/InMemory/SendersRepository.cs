﻿using MailSender.Models;
using System.Linq;

namespace MailSender.Infrastructure.Services.InMemory
{
    class SendersRepository : RepositoryInMemory<Sender>
        {
            public SendersRepository() : base(Enumerable.Range(1, 10)
                .Select(i => new Sender
                {
                    Id = i,
                    Name = $"Имя-{i}",
                    Address = $"sender{i}@server.com",
                }))
            { }
            public override void Update(Sender item)
            {
                var db_item = GetbyId(item.Id);
                if (db_item is null || ReferenceEquals(db_item, item)) return;
                db_item.Name = item.Name;
                db_item.Address = item.Address;
            }
        }
}
