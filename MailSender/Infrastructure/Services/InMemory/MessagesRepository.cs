using MailSender.Models;
using System.Linq;

namespace MailSender.Infrastructure.Services.InMemory
{
    class MessagesRepository : RepositoryInMemory<Message>
    {
        public MessagesRepository() : base(Enumerable.Range(1, 10)
            .Select(i => new Message
            {
                Id = i,
                Text = $"Текст сообщения - {i}",
                Title = $"Заголовок сообщения - {i}",
            }))
        { }
        public override void Update(Message item)
        {
            var db_item = GetbyId(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;
            db_item.Text = item.Text;
            db_item.Title = item.Title;
        }
    }
}
