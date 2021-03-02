using System;
using Xunit;
using WalletApp;

namespace WalletApp_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var w = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            
        }
    }
}
