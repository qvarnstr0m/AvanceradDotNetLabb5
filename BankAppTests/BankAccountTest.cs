using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamGrapeBankApp;

namespace BankAppTests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        [Description("To check that the GenerateAccountNumber is working ok do key")]
        [Owner("Martin")]
        [Priority(2)]
        [TestCategory("Unit Tests")]
        public void GenerateAccountNumber_Expect_AccountNumber_To_Be_In_Valid_Format()
        {
            //Given the valid format; 0211-1219 / regex: ^\d{4}-\d{4}$
            string pattern = @"^\d{4}-\d{4}$";

            //When the method is called
            string account = BankAccount.GenerateAccountNumber();

            //Expect the account number to match the valid format
            Assert.IsTrue(Regex.IsMatch(account, pattern));
        }
    }
}
