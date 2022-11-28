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
        public bool ValidateQuantityInput(string userInputQtyRaw, out string quantityValidationResponse, out int userInputQty)
        {
            string userInputQtyCleaned = userInputQtyRaw.Trim();
            try
            {
                userInputQty = Convert.ToInt32(userInputQtyCleaned);
                if (userInputQty >= 1)
                {
                    quantityValidationResponse = "";
                    return true;
                }
                else
                {
                    quantityValidationResponse = "Sorry your quantity cannot be zero, please try again.";
                    return false;
                }
            }
            catch
            {
                quantityValidationResponse = "Sorry that was not a valid input, please try again";
                userInputQty = -1;
                return false;
            }
        }
        public bool ValidateMenuSelectionInput(string userInputMenuSelectionRaw, int maxMenuOptionNumber, out string menuSelectionValidationResponse, out int userInputMenuSelection)
        {
            string userInputMenuSelectionCleaned = userInputMenuSelectionRaw.Trim();
            try
            {
                userInputMenuSelection = Convert.ToInt32(userInputMenuSelectionCleaned);
                if (userInputMenuSelection >= 1 && userInputMenuSelection <= maxMenuOptionNumber)
                {
                    menuSelectionValidationResponse = "";
                    return true;
                }
                else
                {
                    menuSelectionValidationResponse = "Sorry your is out of range, please try again.";
                    return false;
                }
            }
            catch
            {
                menuSelectionValidationResponse = "Sorry that was not a valid input, please try again";
                userInputMenuSelection = -1;
                return false;
            }
        }
        public bool ValidateOrderedItemInput(string userInputOrderedItemRaw, List<int> itemIds,  out string menuOrderedItemValidationResponse, out int userInputOrderedItemOut)
        {
            string userInputOrderedItemCleaned = userInputOrderedItemRaw.Trim();
            try
            {
                int userInputOrderedItem = Convert.ToInt32(userInputOrderedItemCleaned);
                
                foreach(int itemId in itemIds)
                {
                    if(itemId == userInputOrderedItem)
                    {
                        menuOrderedItemValidationResponse = "";
                        userInputOrderedItemOut = userInputOrderedItem;
                        return true;
                    }                    
                }
                menuOrderedItemValidationResponse = "Sorry your is out of range, please try again.";
                userInputOrderedItemOut = -1;
                return false;
            }
            catch
            {
                menuOrderedItemValidationResponse = "Sorry that was not a valid input, please try again";
                userInputOrderedItemOut = -1;
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
            DateTime today = DateTime.Now;
            if (DateTime.TryParse(userCreditCardExpirationDateRaw, out dateValue))
            {
                if (dateValue <= DateTime.Now)
                {
                    validateCreditCardExpirationDateResponse = "Your credit card is expired, please try again.";
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
        public bool ValidateCreditCardCVVNumber(string userCreditCardCVVRaw, out string validateCreditCardCVVNumberResponse, out int userCreditCardCVVClean)
        {
            string userCreditCardCVV = userCreditCardCVVRaw.Trim();
            if(userCreditCardCVV.Length == 3)
            {
                try
                {
                    int userCreditCardCVVInt = Convert.ToInt32(userCreditCardCVV);
                    if (userCreditCardCVVInt > 0)
                    {
                        validateCreditCardCVVNumberResponse = "";
                        userCreditCardCVVClean = userCreditCardCVVInt;
                        return true;
                    }
                    else
                    {
                        validateCreditCardCVVNumberResponse = "Sorry that was not a valid input, please try again";
                        userCreditCardCVVClean = -1;
                        return false;
                    }
                }
                catch
                {
                    validateCreditCardCVVNumberResponse = "CVV must only contain numbers, please try again";
                    userCreditCardCVVClean = -1;
                    return false;
                }
            }
            else
            {
                validateCreditCardCVVNumberResponse = "Sorry that was not a valid input, please try again";
                userCreditCardCVVClean = -1;
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
                    if(userCheckNumberInt > 0)
                    {
                        validateCheckNumberResponse = "";
                        userCheckNumberClean = userCheckNumber;
                        return true;
                    }
                    else
                    {
                        validateCheckNumberResponse = "You must enter a valid check number to continue";
                        userCheckNumberClean = "";
                        return false;
                    }
                }
                catch
                {
                    validateCheckNumberResponse = "Check number must only contain numbers, please try again";
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
                    if(userCheckRoutingNumberInt > 0)
                    {
                        validateCheckRoutingNumberResponse = "";
                        userCheckRoutingNumberClean = userCheckRoutingNumber;
                        return true;
                    }
                    else
                    {
                        validateCheckRoutingNumberResponse = "You must enter a valid routing number to continue";
                        userCheckRoutingNumberClean = "";
                        return false;
                    }
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
                    if(userCheckAccountNumberInt > 0)
                    {
                        validateCheckAccountNumberResponse = "";
                        userCheckAccountNumberClean = userCheckAccountNumber;
                        return true;
                    }
                    else
                    {
                        validateCheckAccountNumberResponse = "You must enter a valid account number to continue";
                        userCheckAccountNumberClean = "";
                        return false;
                    }
                }
                catch
                {
                    validateCheckAccountNumberResponse = "Account number must only contain numbers, please try again";
                    userCheckAccountNumberClean = "";
                    return false;
                }
            }
            else
            {
                validateCheckAccountNumberResponse = "You must enter a valid account number to continue";
                userCheckAccountNumberClean = "";
                return false;
            }
        }
    }
}
