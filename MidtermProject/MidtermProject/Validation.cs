using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    public class Validation
    {
        public bool ValidateYesNoInput(string userInputRaw, out string yesNoValidationResponse, out string userInput)
        {
            userInput = userInputRaw.Trim().ToLower();
            if (userInput.Contains("y") || userInput.Contains("n"))
            {
                yesNoValidationResponse = "";
                return true;
            }
            else
            {
                yesNoValidationResponse = "Sorry that was not a valid input, please try again.";
                return false;
            }
        }

        //Pay with cash
        public bool ValidateCashTendered(string userCashInputRaw, double userCartTotalSum, out string validateCashTenderedResponse, out double userCashInput)
        {
            try
            {
                string userCashInputCleaned = userCashInputRaw.Trim();
                userCashInput = Convert.ToDouble(userCashInputCleaned);
                if (userCashInput >= userCartTotalSum)
                {
                    validateCashTenderedResponse = "";
                    return true;
                }
                else
                {
                    validateCashTenderedResponse = "Sorry that was not enough to cover your bill.";
                    return false;
                }
            }
            catch
            {
                validateCashTenderedResponse = "Sorry that was not a valid input, please try again";
                userCashInput = 0.00;
                return false;
            }
        }

        //Pay with CC
        public bool ValidateCreditCardNumber(string userCreditCardNumberInputRaw, out string validateCreditCardNumberResponse, out string userCreditCardNumberInputClean)
        {
            try
            {
                userCreditCardNumberInputClean = userCreditCardNumberInputRaw.Trim();
                if (userCreditCardNumberInputClean.Length == 16)
                {
                    long userCreditCardNumber = Convert.ToInt64(userCreditCardNumberInputClean);
                    validateCreditCardNumberResponse = "";
                    return true;
                }
                else
                {
                    validateCreditCardNumberResponse = "Sorry that was not a valid input, please try again";
                    return false;
                }

            }
            catch
            {
                userCreditCardNumberInputClean = "";
                validateCreditCardNumberResponse = "Sorry that was not a valid input, please try again";
                return false;
            }
        }
        public bool ValidateCreditCardExpirationDate(string userCreditCardExpirationDateRaw, out string validateCreditCardExpirationDateResponse, out DateTime userDateValue)
        {
            DateTime dateValue;

            if (DateTime.TryParse(userCreditCardExpirationDateRaw, out dateValue))
            {
                if (dateValue < DateTime.Now)
                {
                    validateCreditCardExpirationDateResponse = "Your credit card is expired, please use a different payment.";
                    userDateValue = dateValue;
                    return false;
                }
                else
                {
                    validateCreditCardExpirationDateResponse = "";
                    userDateValue = dateValue;
                    return true;
                }
            }
            else
            {
                validateCreditCardExpirationDateResponse = "You have entered an invalid date, please try again.";
                userDateValue = dateValue;
                return false;
            }
        }
        public bool ValidateCreditCardCVVNumber(string userCreditCardCVVRaw, out string validateCreditCardCVVNumberResponse, out string userCreditCardCVVClean)
        {
            string userCreditCardCVV = userCreditCardCVVRaw.Trim();
            if(userCreditCardCVV.Length == 3)
            {
                try
                {
                    int userCreditCardCVVInt = Convert.ToInt32(userCreditCardCVV);
                    validateCreditCardCVVNumberResponse = "";
                    userCreditCardCVVClean = userCreditCardCVV;
                    return true;
                }
                catch
                {
                    validateCreditCardCVVNumberResponse = "CVV must only contain numbers, please try again";
                    userCreditCardCVVClean = "";
                    return false;
                }
            }
            else
            {
                validateCreditCardCVVNumberResponse = "Sorry that was not a valid input, please try again";
                userCreditCardCVVClean = "";
                return false;
            }
        }

        //Pay with check
                
        public bool ValidateCheckNumber(string userCheckNumberRaw, out string validateCheckNumberResponse, out string userCheckNumberClean)
        {
            string userCheckNumber = userCheckNumberRaw.Trim();
            if (userCheckNumber.Length >= 1)
            {
                try
                {
                    int userCheckNumberInt = Convert.ToInt32(userCheckNumber);
                    validateCheckNumberResponse = "";
                    userCheckNumberClean = userCheckNumber;
                    return true;
                }
                catch
                {
                    validateCheckNumberResponse = "CVV must only contain numbers, please try again";
                    userCheckNumberClean = "";
                    return false;
                }
            }
            else
            {
                validateCheckNumberResponse = "You must enter a valid check number to continue";
                userCheckNumberClean = "";
                return false;
            }
        }
        public bool ValidateCheckRoutingNumber(string userCheckRoutingNumberRaw, out string validateCheckRoutingNumberResponse, out string userCheckRoutingNumberClean)
        {
            string userCheckRoutingNumber = userCheckRoutingNumberRaw.Trim();
            if (userCheckRoutingNumber.Length == 9)
            {
                try
                {
                    int userCheckRoutingNumberInt = Convert.ToInt32(userCheckRoutingNumber);
                    validateCheckRoutingNumberResponse = "";
                    userCheckRoutingNumberClean = userCheckRoutingNumber;
                    return true;
                }
                catch
                {
                    validateCheckRoutingNumberResponse = "Routing number must only contain numbers, please try again";
                    userCheckRoutingNumberClean = "";
                    return false;
                }
            }
            else
            {
                validateCheckRoutingNumberResponse = "You must enter a valid routing number to continue";
                userCheckRoutingNumberClean = "";
                return false;
            }
        }
        public bool ValidateCheckAccountNumber(string userCheckAccountNumberRaw, out string validateCheckAccountNumberResponse, out string userCheckAccountNumberClean)
        {
            string userCheckAccountNumber = userCheckAccountNumberRaw.Trim();
            if (userCheckAccountNumber.Length >= 5 && userCheckAccountNumber.Length <= 17)
            {
                try
                {
                    int userCheckAccountNumberInt = Convert.ToInt32(userCheckAccountNumber);
                    validateCheckAccountNumberResponse = "";
                    userCheckAccountNumberClean = userCheckAccountNumber;
                    return true;
                }
                catch
                {
                    validateCheckAccountNumberResponse = "Routing number must only contain numbers, please try again";
                    userCheckAccountNumberClean = "";
                    return false;
                }
            }
            else
            {
                validateCheckAccountNumberResponse = "You must enter a valid routing number to continue";
                userCheckAccountNumberClean = "";
                return false;
            }
        }
    }
}
