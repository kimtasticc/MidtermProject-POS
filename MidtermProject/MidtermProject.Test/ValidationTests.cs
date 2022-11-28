using System.Security.Cryptography.X509Certificates;

namespace MidtermProject.Test
{
    public class ValidationTests
    {
        //Validate User Quantity Input
        [Fact]
        public void ValidateQuantityInput_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateQuantityInput("5", out string response, out int userInputQty);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal(5, userInputQty);
        }
        [Fact]
        public void ValidateQuantityInput_WillReturnFalse_NegativeInt()
        {
            var validation = new Validation();

            var isValid = validation.ValidateQuantityInput("-5", out string response, out int userInputQty);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputQty);
        }
        [Fact]
        public void ValidateQuantityInput_WillReturnFalse_InvalidInput()
        {
            var validation = new Validation();

            var isValid = validation.ValidateQuantityInput("ABC", out string response, out int userInputQty);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputQty);
        }

        //Validate User Menu Input
        int menuSize = 2;

        [Fact]
        public void ValidateMenuSelectionInput_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateMenuSelectionInput("2", menuSize, out string response, out int userInputMenuSelection);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal(2, userInputMenuSelection);
        }
        [Fact]
        public void ValidateMenuSelectionInput_WillReturnFalse_OutOfRange()
        {
            var validation = new Validation();

            var isValid = validation.ValidateMenuSelectionInput("3", menuSize, out string response, out int userInputMenuSelection);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputMenuSelection);
        }
        [Fact]
        public void ValidateMenuSelectionInput_WillReturnFalse_OutOfRange_NegativeNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateMenuSelectionInput("-1", menuSize, out string response, out int userInputMenuSelection);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputMenuSelection);
        }
        [Fact]
        public void ValidateMenuSelectionInput_WillReturnFalse_InvalidInput_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateMenuSelectionInput("ABC", menuSize, out string response, out int userInputMenuSelection);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputMenuSelection);
        }

        //Validate Ordered Item Input
        List<int> items = new List<int>
            {
                201,
                202,
                203
            };

        [Fact]
        public void ValidateOrderedItemInput_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateOrderedItemInput("201", items, out string response, out int userInputOrderedItemOut);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal(201, userInputOrderedItemOut);
        }
        [Fact]
        public void ValidateOrderedItemInput_WillReturnFalse_OutOfRange()
        {
            var validation = new Validation();

            var isValid = validation.ValidateOrderedItemInput("204", items, out string response, out int userInputOrderedItemOut);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputOrderedItemOut);
        }
        [Fact]
        public void ValidateOrderedItemInput_WillReturnFalse_OutOfRange_NegativeNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateOrderedItemInput("-204", items, out string response, out int userInputOrderedItemOut);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputOrderedItemOut);
        }
        [Fact]
        public void ValidateOrderedItemInput_WillReturnFalse_InvalidInput_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateOrderedItemInput("2A0", items, out string response, out int userInputOrderedItemOut);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userInputOrderedItemOut);
        }

        //Validate Cash Transaction
        double grandTotal = 19.50;
        [Fact]
        public void ValidateCashTendered_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCashTendered("20", grandTotal, out string response, out double userCashInput);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal(20, userCashInput);
        }
        [Fact]
        public void ValidateCashTendered_WillReturnFalse_NotEnoughCash()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCashTendered("10", grandTotal, out string response, out double userCashInput);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(0.00, userCashInput);
        }
        [Fact]
        public void ValidateCashTendered_WillReturnFalse_InvalidInput_NegativeAmount()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCashTendered("-10", grandTotal, out string response, out double userCashInput);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(0.00, userCashInput);
        }
        [Fact]
        public void ValidateCashTendered_WillReturnFalse_InvalidInput_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCashTendered("A@3", grandTotal, out string response, out double userCashInput);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(0.00, userCashInput);
        }

        //Validate Credit Card Number
        string ccNumber16Digits = "1436856108631579";
        string ccNumber10Digits = "1689531725";
        string ccNumber20Digits = "15963148521037452169";
        string ccNumberNegative = "-1568543543";
        string ccNumberInvalid = "1ABCkjhaegt";

        [Fact]
        public void ValidateCreditCardNumber_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardNumber(ccNumber16Digits, out string response, out string userCreditCardNumberInputClean);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal("1436856108631579", userCreditCardNumberInputClean);
        }
        [Fact]
        public void ValidateCreditCardNumber_WillReturnFalse_LessThan16Digits()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardNumber(ccNumber10Digits, out string response, out string userCreditCardNumberInputClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCreditCardNumberInputClean);
        }
        [Fact]
        public void ValidateCreditCardNumber_WillReturnFalse_MoreThan16Digits()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardNumber(ccNumber20Digits, out string response, out string userCreditCardNumberInputClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCreditCardNumberInputClean);
        }
        [Fact]
        public void ValidateCreditCardNumber_WillReturnFalse_NegativeInput()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardNumber(ccNumberNegative, out string response, out string userCreditCardNumberInputClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCreditCardNumberInputClean);
        }
        [Fact]
        public void ValidateCreditCardNumber_WillReturnFalse_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardNumber(ccNumberInvalid, out string response, out string userCreditCardNumberInputClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCreditCardNumberInputClean);
        }
        //Validate Credit Card Expiration Date                        
        [Fact]
        public void ValidateCreditCardExpirationDate_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardExpirationDate("12/01/25", out string response, out DateTime userDateValue);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal(new DateTime(2025, 12, 01), userDateValue);
        }
        [Fact]
        public void ValidateCreditCardExpirationDate_WillReturnFalse_Expired()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardExpirationDate("12/01/20", out string response, out DateTime userDateValue);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(new DateTime(2020, 12, 01), userDateValue);
        }
        [Fact]
        public void ValidateCreditCardExpirationDate_WillReturnFalse_InvalidInput()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardExpirationDate("ABC", out string response, out DateTime userDateValue);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(new DateTime(0001, 01, 01), userDateValue);
        }
        //Validate Credit Card CVV Number
        [Fact]
        public void ValidateCreditCardCVVNumber_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardCVVNumber("132", out string response, out int userCreditCardCVVClean);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal(132, userCreditCardCVVClean);
        }
        [Fact]
        public void ValidateCreditCardCVVNumber_WillReturnFalse_DigitsGreaterThan3()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardCVVNumber("1324", out string response, out int userCreditCardCVVClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userCreditCardCVVClean);
        }
        [Fact]
        public void ValidateCreditCardCVVNumber_WillReturnFalse_DigitsLessThan3()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardCVVNumber("12", out string response, out int userCreditCardCVVClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userCreditCardCVVClean);
        }
        [Fact]
        public void ValidateCreditCardCVVNumber_WillReturnFalse_InvalidInput_NegativeAmount()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardCVVNumber("-132", out string response, out int userCreditCardCVVClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userCreditCardCVVClean);
        }
        [Fact]
        public void ValidateCreditCardCVVNumber_WillReturnFalse_InvalidInput_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCreditCardCVVNumber("ABC", out string response, out int userCreditCardCVVClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal(-1, userCreditCardCVVClean);
        }

        //Validate Check Number
        [Fact]
        public void ValidateCheckNumber_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckNumber("123", out string response, out string userCheckNumberClean);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal("123", userCheckNumberClean);
        }
        [Fact]
        public void ValidateCheckNumber_WillReturnFalse_DigitsLessThan1()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckNumber("", out string response, out string userCheckNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckNumberClean);
        }
        [Fact]
        public void ValidateCheckNumber_WillReturnFalse_InvalidInput_NegativeAmount()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckNumber("-123", out string response, out string userCheckNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckNumberClean);
        }
        [Fact]
        public void ValidateCheckNumber_WillReturnFalse_InvalidInput_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckNumber("ABC", out string response, out string userCheckNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckNumberClean);
        }

        //Validate Routing Number

        string ccRouting9Digits = "154873218";
        string ccRouting10Digits = "3648215049";
        string ccRouting8Digits = "12564327";
        string ccRoutingNegativeInput = "-13245687";
        string ccRoutingInvalidInput = "13agAg3$^";

        
        [Fact]
        public void ValidateCheckRoutingNumber_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckRoutingNumber(ccRouting9Digits, out string response, out string userCheckRoutingNumberClean);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal("154873218", userCheckRoutingNumberClean);
        }
        [Fact]
        public void ValidateCheckRoutingNumber_WillReturnFalse_DigitsLessThan9()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckRoutingNumber(ccRouting8Digits, out string response, out string userCheckRoutingNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckRoutingNumberClean);
        }
        [Fact]
        public void ValidateCheckRoutingNumber_WillReturnFalse_DigitsGreaterThan9()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckRoutingNumber(ccRouting10Digits, out string response, out string userCheckRoutingNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckRoutingNumberClean);
        }
        [Fact]
        public void ValidateCheckRoutingNumber_WillReturnFalse_InvalidInput_NegativeAmount()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckRoutingNumber(ccRoutingNegativeInput, out string response, out string userCheckRoutingNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckRoutingNumberClean);
        }
        [Fact]
        public void ValidateCheckRoutingNumber_WillReturnFalse_InvalidInput_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckRoutingNumber(ccRoutingInvalidInput, out string response, out string userCheckRoutingNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckRoutingNumberClean);
        }
                
        //Validate Account Number

        string ccAcct12Digits = "135486548634";
        string ccAcct18Digits = "453124851234516845";
        string ccAcct4Digits = "1256";
        string ccAcctNegativeInput = "-12348531596";
        string ccAcctInvalidInput = "13agAg3$^";

        [Fact]
        public void ValidateCheckAccountNumber_WillReturnTrue()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckAccountNumber(ccAcct12Digits, out string response, out string userCheckAccountNumberClean);

            Assert.True(isValid);
            Assert.Empty(response);
            Assert.Equal(ccAcct12Digits, userCheckAccountNumberClean);
        }
        [Fact]
        public void ValidateCheckAccountNumber_WillReturnFalse_DigitsLessThan5()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckAccountNumber(ccAcct4Digits, out string response, out string userCheckAccountNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckAccountNumberClean);
        }
        [Fact]
        public void ValidateCheckAccountNumber_WillReturnFalse_DigitsGreaterThan17()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckAccountNumber(ccAcct18Digits, out string response, out string userCheckAccountNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckAccountNumberClean);
        }
        [Fact]
        public void ValidateCheckAccountNumber_WillReturnFalse_InvalidInput_NegativeAmount()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckAccountNumber(ccAcctNegativeInput, out string response, out string userCheckAccountNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckAccountNumberClean);
        }
        [Fact]
        public void ValidateCheckAccountNumber_WillReturnFalse_InvalidInput_NotNumber()
        {
            var validation = new Validation();

            var isValid = validation.ValidateCheckAccountNumber(ccAcctInvalidInput, out string response, out string userCheckAccountNumberClean);

            Assert.False(isValid);
            Assert.NotEmpty(response);
            Assert.Equal("-1", userCheckAccountNumberClean);
        }
    }
}