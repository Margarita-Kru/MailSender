using MailSender.Infrastructure.Services.InMemory;
using MailSender.lib.Entities;
using System.Linq;
using Xunit;

namespace MailSender.Tests.Infrastructure.Services.InMemory
{
    public class MessageRepositoryTests
    {
        [Fact]
        public void GetAll_Test()
        {
            var repository = new MessagesRepository();
            var all = repository.GetAll();
            Assert.True(all.Any());
        }
        [Fact]
        public void Add_Test()
        {
            var repository = new MessagesRepository();
            var message = new Message
            {
                Title="Unit test message",
                Text="Text unit test"
            };
            var actual_id = repository.Add(message);
            var all = repository.GetAll().ToArray();
            Assert.Equal(actual_id, message.Id);
            //Assert.Contains(all, message);
        }
    }
}
