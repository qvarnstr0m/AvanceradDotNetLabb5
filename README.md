# Avacerad .NET Labb 5
## Unit tests with MSUnit on old project. 
The first step in ensuring that the system works as expected is to carefully plan the testing approach. To do this, I have identified three critical business components in the code that I believe should be thoroughly tested:

+ ReturnMonthlyInterest Method: This method calculates the monthly interest. Any errors in this calculation could impact the financial operations of the customers, so it is important to ensure that the interest is correctly calculated. Changes in this method should be tracked with unit tests.
+ ProcessTransaction Method: This method processes the transactions between accounts. Since this includes critical operations like money transfers, it is essential to ensure that the balance of the "from" account is not negative after the transaction since this would make it possible to transfer money that does not exist. There is an if-statement for this but this could be modified or removed.
+ GenerateAccountNumber Method: This method is responsible for generating account numbers for our customers. The account number should adhere to a specific format (ex. 0211-1219), and any deviation from this format could cause significant issues for account tracking and identification.

## Test Methods
I have implemented unit tests for these critical components to verify their correct operation:

+ ReturnMonthlyInterest_Expect_Interest_To_Be_41_666666666666666666666666667: This test method checks that the ReturnMonthlyInterest method is correctly calculating and returning the monthly interest, given a loan duration (in months) and an amount.

+ ProcessTransaction_Given_An_Amount_Expect_FromAccount_To_Be_Positive_After_Transfer: This test ensures that after a transaction, the balance in the account from which the transaction is made is not negative. The test method generates a transaction between two accounts and asserts that the balance of the 'from' account remains positive after the transaction.

+ GenerateAccountNumber_Expect_AccountNumber_To_Be_In_Valid_Format: This test verifies that the GenerateAccountNumber method produces account numbers in the expected format. The method generates an account number and checks that it matches the required format using a regular expression.  
  
By testing these critical components, we are ensuring the reliability and integrity of our system, making sure that it performs its core business operations as expected.
