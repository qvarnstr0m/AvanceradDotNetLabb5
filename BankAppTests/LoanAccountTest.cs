using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGrapeBankApp;

namespace BankAppTests
{
    [TestClass]
    public class LoanAccountTest
    {
        [TestMethod]
        [Description("To check that the ReturnMonthlyInterest method is returning the right monthly interest")]
        [Owner("Martin")]
        [Priority(1)]
        [TestCategory("Unit Tests")]
        public void ReturnMonthlyInterest_Expect_Interest_To_Be_41_666666666666666666666666667()
        {
            //Given the total months of 24 that the loan is set to, and the amount of 10000
            int months = 24;
            decimal amount = 10000;

            //When the method is called
            decimal monthlyInterest = LoanAccount.ReturnMonthlyInterest(months, amount);

            //Expect the monthly interest to be 41,666666666666666666666666667
            Assert.IsTrue(monthlyInterest == 41.666666666666666666666666667m);
        }
    }
}
