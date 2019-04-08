using System;

namespace RichObject.Accounts
{
    public class Account
    {
        public Guid AccountId { get; }
        public string AccountName { get; }

        public Account(Guid accountId, string accountName)
        {
            AccountId = accountId;
            AccountName = accountName;
        }
    }
}