using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPaymentStatus
{
    public class Transaction
    {
        public double amount { get; set; }
        public string transactionRef { get; set; }
        public string paymentDate { get; set; }
        public string paymentStatus { get; set; }
        public string statusMessage { get; set; }
    }
}
