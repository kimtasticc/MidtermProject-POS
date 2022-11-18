using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{


    public abstract class Payment
    {
        public long CcNum { get; set; }
        public int CvvNum { get; set; }
        public DateOnly ExpDate { get; set; }
        public long CheckNum { get; set; }
        public long CheckAcctNum { get; set; }
        public long CheckRoutNum { get; set; }
        public double CashTotal { get; set; }

                         

        Dictionary<string, double> items = new  Dictionary<string, double>();

        public Payment(long ccnum, int cvvNum, DateOnly expDate )
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

        public double Total()
        {
            return items.Values.Sum();
        }

        public double Tax(out double taxAndPrice, out double total)
        {
            
            total = items.Values.Sum();
            double taxRate = .06;
            taxAndPrice = 1.06;
            double totalTaxPaid = total * taxRate;

            double totalAfterTax = total * taxAndPrice;

            return totalAfterTax;
            


        }

        public double CalculateGrandTotal(double taxAndPrice, double total)
        {
            return  total * taxAndPrice;

        }

        public double CalculateChangeIfCash(double cashTotal, double total)
        {
            CashTotal = cashTotal;

            double change = cashTotal - total;
            return cashTotal;


        }

    }
}
