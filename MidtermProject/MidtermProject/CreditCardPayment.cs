using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    public class CreditCardPayment : Payment
    {
        public int CreditCardNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int CVV { get; set; }

    }
}
