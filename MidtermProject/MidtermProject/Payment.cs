using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{


    public  class Payment
    {
        public string CcNum { get; set; }
        public int CvvNum { get; set; }
        public DateOnly ExpDate { get; set; }
        public long CheckNum { get; set; }
        public long CheckAcctNum { get; set; }
        public long CheckRoutNum { get; set; }
        public double CashTotal { get; set; }
        //public double Subtotal { get; set; }                         

        Dictionary<string, double> items = new  Dictionary<string, double>();

        public Payment(double cashTendered)
        {
            CashTotal = cashTendered; 
        }

        public Payment(string ccnum, int cvvNum, DateOnly expDate )
        {
            CcNum = ccnum;
            CvvNum = cvvNum;
            ExpDate = expDate;
        }

        public Payment(long checkNum, long checkAcctNum, long checkRoutNum)
        {
            CheckAcctNum = checkAcctNum;
            CheckRoutNum = checkRoutNum;
            CheckNum = checkNum;

        }

        public string Last4()
        {
            
            string last4 = CcNum.Substring(CcNum.Length - 12, 15);
            return $"Grand Circus CC XXXX{last4}";
          
        }

        public double Total()
        {
            return items.Values.Sum();
        }

        public double Tax(out double totalTaxPaid, double total)
        {
            
            //total = items.Values.Sum(); // total = subtotal
            double taxRate = .06;
            
            totalTaxPaid = total * taxRate; // totalTaxPaid = just the tax

            //double totalAfterTax = total + totalTaxPaid;

            return totalTaxPaid; // totalAfterTax; // totalAfterTax = grand total
            


        }


        public double CalculateChangeIfCash(double cashTotal, double total)
        {
            CashTotal = cashTotal;

            double change = cashTotal - total;
            return cashTotal;


        }

    }
}
