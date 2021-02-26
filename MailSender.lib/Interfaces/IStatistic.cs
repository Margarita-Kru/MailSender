using System;

namespace MailSender.lib.Interfaces
{
    public interface IStatistic
    {
        int SendedMailsCount { get; }
        void MailSended();
        int SendersCount { get; }
        int RecipientsCount { get; }
        TimeSpan UpTime { get; }
    }
}
