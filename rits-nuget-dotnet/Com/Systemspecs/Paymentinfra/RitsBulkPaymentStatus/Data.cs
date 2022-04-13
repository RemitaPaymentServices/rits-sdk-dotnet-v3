using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPaymentStatus
{
    public class Data
    {
        public string batchRef { get; set; }
        public double totalAmount { get; set; }
        public double feeAmount { get; set; }
        public string authorizationId { get; set; }
        public string transactionDate { get; set; }
        public string transactionDescription { get; set; }
        public string sourceAccount { get; set; }
        public string currency { get; set; }
        public string paymentStatus { get; set; }
        public List<Transaction> transactions { get; set; }

    }
}
