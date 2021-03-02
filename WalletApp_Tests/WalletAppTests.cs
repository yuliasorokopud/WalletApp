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
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Transaction transaction = new Transaction(30, "UAH", category, "some transaction", "13.12.2002");
            int expected = 130;

            //act
            wallet.add_transaction(transaction);

            //assert
            Assert.Equal(expected, wallet.CurrentValue);
        }

        [Fact]
        public void addTransaction_TransactionList_Test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Transaction transaction = new Transaction(30, "UAH", category, "some transaction", "13.12.2002");
            List<Transaction> expected = new List<Transaction>() { transaction };

            //act
            wallet.add_transaction(transaction);

            //assert
            Assert.Equal<Transaction>(expected, wallet.Transactions);
        }


        [Fact]
        public void removeTransaction_Test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Transaction transaction1 = new Transaction(30, "UAH", category, "some transaction", "13.12.2002");
            Transaction transaction2 = new Transaction(150, "UAH", tranCategory, "some transaction", "13.12.2002");
            List<Transaction> expected = new List<Transaction>() { transaction2 };

            //act
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
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category tranCategory = new Category( "Transport",  "traveling",  "blue",  "icon_path");
            Category foodCategory = new Category("Food", "eating", "yellow", "icon_path");
            Transaction transaction = new Transaction(30, "UAH", tranCategory, "some transaction", "13.12.2002");
            List<Category> expected = new List<Category>() { tranCategory, foodCategory };

            //act
            wallet.add_transaction(transaction);
            wallet.add_category(foodCategory);

            //assert

            Assert.Equal<Category>(expected, wallet.Categories);
        }

        [Fact]
        public void remove_category_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Category foodCategory = new Category("Food", "eating", "yellow", "icon_path");
            List<Category> expected = new List<Category>() { foodCategory };

            //act
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
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Transaction transaction1 = new Transaction(30, "UAH", category, "some transaction", "13.12.2002");
            Transaction transaction2 = new Transaction(150, "UAH", tranCategory, "some transaction", "13.12.2002");
            Transaction transaction3 = new Transaction(300, "UAH", category, "some transaction", "13.12.2002");
            int expected = 450;

            //act
            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_value(1, 450);

            //assert
            Assert.Equal(expected, wallet.Transactions[1].Value);
        }

        [Fact]
        public void edit_transaction_currency_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Transaction transaction1 = new Transaction(30, "UAH", category, "some transaction", "13.12.2002");
            Transaction transaction2 = new Transaction(150, "USD", tranCategory, "some transaction", "13.12.2002");
            Transaction transaction3 = new Transaction(300, "EURO", category, "some transaction", "13.12.2002");
            string expected = "AED";

            //act
            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_currency(2, "AED");

            //assert
            Assert.Equal(expected, wallet.Transactions[2].Currency);
        }

        [Fact]
        public void edit_transaction_category_test()
        {
            //arrange
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Category foodCategory = new Category("Food", "eating", "yellow", "icon_path");
            Category beautyCategory = new Category("Beauty", "self care", "pink", "icon_path");
            Transaction transaction1 = new Transaction(30, "UAH", tranCategory, "some transaction", "13.12.2002");
            Transaction transaction2 = new Transaction(150, "USD", foodCategory, "some transaction", "13.12.2002");
            Transaction transaction3 = new Transaction(300, "EURO", beautyCategory, "some transaction", "13.12.2002");
            Category expected = foodCategory;

            //act
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
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Transaction transaction1 = new Transaction(30, "UAH", category, "some transaction", "13.12.2002");
            Transaction transaction2 = new Transaction(150, "USD", tranCategory, "some transaction", "13.12.2002");
            Transaction transaction3 = new Transaction(300, "EURO", category, "some transaction", "13.12.2002");
            string expected = "Transaction's new description";


            //act
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
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Category category = new Category();
            Category tranCategory = new Category("Transport", "traveling", "blue", "icon_path");
            Transaction transaction1 = new Transaction(30, "UAH", category, "some transaction", "13.12.2002");
            Transaction transaction2 = new Transaction(150, "USD", tranCategory, "some transaction", "24.12.2012");
            Transaction transaction3 = new Transaction(300, "EURO", category, "some transaction", "30.11.2020");
            string expected = "13.07.2021";


            //act
            wallet.add_transaction(transaction1);
            wallet.add_transaction(transaction2);
            wallet.add_transaction(transaction3);
            wallet.edit_transaction_date(2, "13.07.2021");

            //assert
            Assert.Equal(expected, wallet.Transactions[2].Date);
        }


        [Fact]
        public void user_adding_wallet_test()
        {
            //arrange
            User user = new User("Andew", "Livin", "andewlivin@gmail.com");
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Wallet wallet2 = new Wallet("secondWallet", "UAH", "even better wallet", 100);
            List<Wallet> expected = new List<Wallet>() { wallet, wallet2 };


            //act
            user.addWallet(wallet);
            user.addWallet(wallet2);

            //assert
           Assert.Equal<Wallet>(expected, user.Wallets);
        }



        [Fact]
        public void uiser_removing_wallet_test()
        {
            //arrange
            User user = new User("Andew", "Livin", "andewlivin@gmail.com");
            Wallet wallet = new Wallet("firstWallet", "UAH", "cool wallet", 100);
            Wallet wallet2 = new Wallet("secondWallet", "UAH", "even better wallet", 100);
            List<Wallet> expected = new List<Wallet>() { wallet2 };


            //act
            user.addWallet(wallet);
            user.addWallet(wallet2);
            user.removeWallet(wallet);

            //assert
            Assert.Equal<Wallet>(expected, user.Wallets);
        }


    }
}
