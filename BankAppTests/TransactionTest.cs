using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TeamGrapeBankApp;
using Transaction = TeamGrapeBankApp.Transaction;

namespace BankAppTests
{
    [TestClass]
    public class TransactionTest
    {
        [TestMethod]
        [Description("To check that the from account is not negative after a transaction")]
        [Owner("Martin")]
        [Priority(1)]
        [TestCategory("Unit Tests")]
        public void ProcessTransaction_Given_An_Amount_Expect_FromAccount_To_Be_Positive_After_Transfer() //BankAccount fromAccount, BankAccount toAccount, User fromOwner, User toOwner, decimal amount
        {
            //Given a transaction
            BankAccount fromAccount = new BankAccount("From Account", "1111-2222", "Billy", "SEK", 1000);
            BankAccount toAccount = new BankAccount("To Account", "1111-2222", "Billy", "SEK", 21000);
            User fromUser = new Customer(1, "billgates", "pass1", "Bill", "Gates", "Nygatan 26 31176 Falkenberg", "bill@microsoft.se", "+46702222222", false);
            User toUser = new Customer(2, "annasvensson", "pass2", "Anna", "Svensson", "Nygatan 26 31176 Falkenberg", "anna@svensson.se", "+46703333333", false);
            decimal amount = 1000;

            //When the transfer is made
            Transaction.ProcessTransaction(fromAccount, toAccount, fromUser, toUser, amount);

            //Expect the from bankaccount balance to be positive
            Assert.IsTrue(fromAccount.Balance >= 0);
        }
    }
}
