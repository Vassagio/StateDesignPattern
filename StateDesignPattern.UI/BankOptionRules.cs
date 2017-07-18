using System;
using System.Collections.Generic;
using StateDesignPattern.Core;
using StateDesignPattern.UI.BankingOptions;

namespace StateDesignPattern.UI {
    public static class BankOptionRules {
        public static BankOptions Create(Account account) {
            return new BankOptions(new List<IBankOption> {
                new DepositOption(account),
                new WithdrawOption(account),
                new FreezeOption(account),
                new VerifiedOption(account),
                new CloseOption(account),
                new ExitOption()
            });
        }

        public static IReadOnlyDictionary<BankOptionStatus, Action<Action>> Test(Account account)
        {
            return new Dictionary<BankOptionStatus, Action<Action>> {
                [BankOptionStatus.Open().Deposit()] = (action) => new DepositOption(account).Execute(),
                [BankOptionStatus.Open().Withdraw()] = (action) => new WithdrawOption(account).Execute(),
                [BankOptionStatus.Open().Freeze()] = (action) => new FreezeOption(account).Execute(),
                [BankOptionStatus.Open().Verify()] = (action) => new VerifiedOption(account).Execute(),
                [BankOptionStatus.Open().Close()] = (action) => new CloseOption(account).Execute(),
                [BankOptionStatus.Open().Exit()] = (action) => new ExitOption().Execute(),
            };
        }
        


    }
}