using System;
using Xunit;
using WalletApp;
using System.Collections.Generic;

namespace WalletApp_Tests
{

    public class UnitTest1
    {
        [Fact]
        public void addTransaction_CurrentValue_100and30_130returned ()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            DateTime dateTime = new DateTime(2020, 04, 12, 15, 0, 0, 0);
            Transaction transaction = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            int expected = 130;

            //act
            wallet.add_transaction(transaction);

            //assert
            Assert.Equal(expected, wallet.CurrentValue);
        }

        [Fact]
        public void addTransactionWithAnotherCurrency_840returned()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            DateTime dateTime = new DateTime(2020, 04, 12, 15, 0, 0, 0);
            Transaction transaction = new Transaction(30, Currencies.USD, category, dateTime, "some transaction");
            int expected = 940;

            //act
            wallet.add_transaction(transaction);

            //assert
            Assert.Equal(expected, wallet.CurrentValue);
        }

        [Fact]
        public void addTransaction_TransactionList_Test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            DateTime dateTime = new DateTime(2020, 04, 12, 15, 0, 0, 0);
            Transaction transaction = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            List<Transaction> expected = new List<Transaction>() { transaction };

            //act
            wallet.add_transaction(transaction);

            //assert
            Assert.Equal<Transaction>(expected, wallet.Transactions);
        }

        [Fact]
        public void addTransaction_notValidCategory_Test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category2 = new Category("Food", "mmm yammy", "some path", "color");
            DateTime dateTime = DateTime.Now;
            List<Transaction> expected = new List<Transaction>() {};
            //act
            wallet.add_transaction(30, Currencies.UAH, category2, dateTime);

            //assert
            Assert.Equal<Transaction>(expected, wallet.Transactions);
        }


        [Fact]
        public void removeTransaction_Test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            DateTime dateTime = new DateTime(2020, 04, 12, 15, 0, 0, 0);
            DateTime dateTime1 = DateTime.Now;
            Transaction transaction1 = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            Transaction transaction2 = new Transaction(150, Currencies.UAH, tranCategory, dateTime1, "some transaction");
            List<Transaction> expected = new List<Transaction>() { transaction2 };

            //act
            wallet.add_category(tranCategory);

            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.remove_transaction(transaction1);

            //assert
            Assert.Equal<Transaction>(expected, wallet.Transactions);
        }

        

        [Fact]
        public void add_category_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category tranCategory = new Category( "Transport",  "traveling",  "blue",  "icon_path");
            Category foodCategory = new Category("Food", "eating", "yellow", "icon_path");
            DateTime dateTime = DateTime.Now;
            Transaction transaction = new Transaction(30, Currencies.UAH, tranCategory, dateTime, "some transaction");
            List<Category> expected = new List<Category>() { wallet.Categories[0], tranCategory, foodCategory };

            //act
            wallet.add_category(tranCategory);
            wallet.add_category(foodCategory);

            wallet.add_transaction(transaction);
            wallet.add_category(foodCategory);

            //assert

            Assert.Equal<Category>(expected, wallet.Categories);
        }

        [Fact]
        public void remove_category_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Category foodCategory = new Category("Food", "eating", "yellow", "icon_path");
            List<Category> expected = new List<Category>() { wallet.Categories[0], foodCategory };

            //act
            wallet.add_category(tranCategory);
            wallet.add_category(foodCategory);

            wallet.add_category(tranCategory);
            wallet.add_category(foodCategory);
            wallet.remove_category(tranCategory);

            //assert

            Assert.Equal<Category>(expected, wallet.Categories);
        }

        [Fact]
        public void edit_transaction_value_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            DateTime dateTime = DateTime.Now;
            Transaction transaction1 = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            Transaction transaction2 = new Transaction(150, Currencies.UAH, tranCategory, dateTime, "some transaction");
            Transaction transaction3 = new Transaction(300, Currencies.UAH, category, dateTime, "some transaction");
            int expected = 450;

            //act
            wallet.add_category(tranCategory);

            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_value(1, 450);

            //assert
            Assert.Equal(expected, wallet.Transactions[1].Value);
        }

        //TODO: correct editing currency(what to do with wallent then?)
        [Fact]
        public void edit_transaction_currency_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            DateTime dateTime = DateTime.Now;
            Transaction transaction1 = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            Transaction transaction2 = new Transaction(150, Currencies.UAH, tranCategory, dateTime, "some transaction");
            Transaction transaction3 = new Transaction(300, Currencies.UAH, category, dateTime, "some transaction");
            Currencies expectedCurrency = Currencies.USD;
            double expectedValue = 10.71;

            //act
            wallet.add_category(tranCategory);

            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_currency(2, Currencies.USD);

            //assert
            Assert.Equal(expectedCurrency, wallet.Transactions[2].Currency);
            Assert.Equal(expectedValue, wallet.Transactions[2].Value);
        }

        [Fact]
        public void edit_transaction_category_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category tranCategory = new Category("Transport", "traveling", "icon_path", "blue");
            Category foodCategory = new Category("Food", "eating", "icon_path", "yellow");
            Category beautyCategory = new Category("Beauty", "self care", "icon_path", "pink");
            DateTime dateTime = DateTime.Now;
            Transaction transaction1 = new Transaction(30, Currencies.UAH, tranCategory, dateTime, "some transaction");
            Transaction transaction2 = new Transaction(150, Currencies.UAH, foodCategory, dateTime, "some transaction");
            Transaction transaction3 = new Transaction(300, Currencies.UAH, beautyCategory, dateTime, "some transaction");
            Category expected = foodCategory;

            //act
            wallet.add_category(tranCategory);
            wallet.add_category(foodCategory);
            wallet.add_category(beautyCategory);

            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_category(2, foodCategory);

            //assert
            Assert.Equal(expected, wallet.Transactions[2].Category);
        }

        [Fact]
        public void edit_transaction_description_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            DateTime dateTime = DateTime.Now;
            Transaction transaction1 = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            Transaction transaction2 = new Transaction(150, Currencies.UAH, tranCategory, dateTime, "some transaction");
            Transaction transaction3 = new Transaction(300, Currencies.UAH, category, dateTime, "some transaction");
            string expected = "Transaction's new description";


            //act
            wallet.add_category(tranCategory);

            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_description(2, "Transaction's new description");

            //assert
            Assert.Equal(expected, wallet.Transactions[2].Description);
        }


        [Fact]
        public void edit_transaction_date_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Category category = wallet.Categories[0];
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            DateTime dateTime = DateTime.Now;
            Transaction transaction1 = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            Transaction transaction2 = new Transaction(150, Currencies.UAH, tranCategory, dateTime, "some transaction");
            Transaction transaction3 = new Transaction(300, Currencies.UAH, category, dateTime, "some transaction");
            DateTime expected = new DateTime(2020,11,26, 16, 45, 00);


            //act
            wallet.add_category(tranCategory);

            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_date(2, new DateTime(2020, 11, 26, 16, 45, 00));

            //assert
            Assert.Equal(expected, wallet.Transactions[2].Date);
        }


        [Fact]
        public void user_adding_wallet_test()
        {
            //arrange
            User user = new User("Andew", "Livin", "andewlivin@gmail.com");
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Wallet wallet2 = new Wallet("secondWallet", Currencies.UAH, 100, "even better wallet");
            List<Wallet> expected = new List<Wallet>() { wallet, wallet2 };


            //act
            user.addWallet(wallet);
            user.addWallet(wallet2);

            //assert
           Assert.Equal<Wallet>(expected, user.Wallets);
        }



        [Fact]
        public void user_removing_wallet_test()
        {
            //arrange
            User user = new User("Andew", "Livin", "andewlivin@gmail.com");
            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Wallet wallet2 = new Wallet("secondWallet", Currencies.UAH, 100, "even better wallet");
            List<Wallet> expected = new List<Wallet>() { wallet2 };


            //act
            user.addWallet(wallet);
            user.addWallet(wallet2);
            user.removeWallet(wallet);

            //assert
            Assert.Equal<Wallet>(expected, user.Wallets);
        }



        [Fact]
        public void invitingUserToWaller_test()
        {
            //arrange
            User user1 = new User("Andew", "Livin", "andewlivin@gmail.com");
            User user2 = new User("Maria", "Kozyrenko", "mariaa@gmail.com");

            Wallet wallet = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Wallet wallet2 = new Wallet("secondWallet", Currencies.UAH, 100, "even better wallet");

            List<Wallet> expected = new List<Wallet>() { wallet };


            //act
            user1.addWallet(wallet);
            user1.addWallet(wallet2);
            user1.inviteUserToWallet(user2, wallet);

            //assert
            Assert.Equal<Wallet>(expected, user2.Wallets);
        }

        [Fact]
        public void addingTransactionByNewUser_test()
        {
            //arrange
            User user1 = new User("Andew", "Livin", "andewlivin@gmail.com");
            User user2 = new User("Maria", "Kozyrenko", "mariaa@gmail.com");

            Wallet wallet1 = new Wallet("firstWallet", Currencies.UAH, 100, "cool wallet");
            Wallet wallet2 = new Wallet("secondWallet", Currencies.UAH, 100, "even better wallet");


            Category category = wallet1.Categories[0];
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");

            DateTime dateTime = DateTime.Now;
            Transaction transaction1 = new Transaction(30, Currencies.UAH, category, dateTime, "some transaction");
            Transaction transaction2 = new Transaction(150, Currencies.UAH, tranCategory, dateTime, "some transaction");
            Transaction transaction3 = new Transaction(300, Currencies.UAH, category, dateTime, "some transaction");
            Transaction transaction4 = new Transaction(125, Currencies.UAH, category, dateTime, "some transaction");



            List<Wallet> expectedWalletList = new List<Wallet>() { wallet1 };
            List<Transaction> expectedTransactionList = new List<Transaction>() { transaction1, transaction2, transaction3, transaction4};

            //act
            user1.addWallet(wallet1);
            user1.addWallet(wallet2);

            wallet1.add_category(tranCategory);  

            wallet1.add_transaction(transaction1);
            wallet1.add_transaction(transaction2);
            wallet1.add_transaction(transaction3);

            user1.inviteUserToWallet(user2, wallet1);

            user1.getMyWalletByName("firstWallet").add_transaction(transaction4);
            //assert
            Assert.Equal<Wallet>(expectedWalletList, user2.Wallets);
            Assert.Equal<Transaction>(expectedTransactionList, user1.getMyWalletByName("firstWallet").Transactions);
            Assert.Equal<Transaction>(expectedTransactionList, user2.getMyWalletByName("firstWallet").Transactions);

        }
    }
}
