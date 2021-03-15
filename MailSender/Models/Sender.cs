using MailSender.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MailSender.Models
{
    public class Sender : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
