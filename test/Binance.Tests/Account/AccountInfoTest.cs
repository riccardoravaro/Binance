﻿using System;
using System.Linq;
using Binance.Account;
using Binance.Api;
using Xunit;

namespace Binance.Tests.Account
{
    public class AccountInfoTest
    {
        [Fact]
        public void Throws()
        {
            var user = new BinanceApiUser("api-key");
            var commissions = new AccountCommissions(10, 10, 0, 0);
            var status = new AccountStatus(true, true, true);

            Assert.Throws<ArgumentNullException>("user", () => new AccountInfo(null, commissions, status));
            Assert.Throws<ArgumentNullException>("commissions", () => new AccountInfo(user, null, status));
            Assert.Throws<ArgumentNullException>("status", () => new AccountInfo(user, commissions, null));
        }

        [Fact]
        public void Properties()
        {
            var user = new BinanceApiUser("api-key");
            var commissions = new AccountCommissions(10, 10, 0, 0);
            var status = new AccountStatus(true, true, true);
            var balances = new[] { new AccountBalance("BTC", 0.1m, 0.2m) };

            var account = new AccountInfo(user, commissions, status);

            Assert.Equal(commissions, account.Commissions);
            Assert.Equal(status, account.Status);
            Assert.NotNull(account.Balances);
            Assert.Empty(account.Balances);

            account = new AccountInfo(user, commissions, status, balances);

            Assert.Equal(commissions, account.Commissions);
            Assert.Equal(status, account.Status);
            Assert.NotNull(account.Balances);
            Assert.NotEmpty(account.Balances);
            Assert.Equal(balances[0].Asset, account.Balances.First().Asset);
        }
    }
}
