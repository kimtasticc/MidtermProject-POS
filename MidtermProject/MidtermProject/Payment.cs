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
        public DateTime ExpDate { get; set; }
        public long CheckNum { get; set; }
        public long CheckAcctNum { get; set; }
        public long CheckRoutNum { get; set; }
        public double CashTotal { get; set; }
        public double GrandTotal { get; set; }                         

        Dictionary<string, double> items = new  Dictionary<string, double>();

        public Payment(double cashTendered)
        {
            CashTotal = cashTendered;
        }

        public Payment(string ccnum, int cvvNum, DateTime expDate )
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
            string last4 = CcNum.Substring(12);
            return $"Grand Circus CC XXXX{last4}";
        }

        public double Tax(double subtotal)
        {
            double taxRate = .06;
            double totalTaxPaid = subtotal * taxRate;
            return totalTaxPaid; 
        }

        public double CalculateChangeIfCash(double cashTotal, double total)
        {
            CashTotal = cashTotal;
            double change = cashTotal - total;
            return cashTotal;
        }
    }
}
