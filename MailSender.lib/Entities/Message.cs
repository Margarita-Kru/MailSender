using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Message: Entity
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
