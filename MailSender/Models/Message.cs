using MailSender.Models.Base;

namespace MailSender.Models
{
    public class Message: Entity
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
