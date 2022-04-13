using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsSinglePaymentStatus
{
    public class Data
    {
        public string authorizationId { get; set; }
        public string transactionRef { get; set; }
        public int amount { get; set; }
        public double feeAmount { get; set; }
        public string paymentStatus { get; set; }
        public string transactionDescription { get; set; }
        public string transactionDate { get; set; }
        public string paymentDate { get; set; }
        public string currency { get; set; }
        public string destinationAccount { get; set; }
        public string destinationBankCode { get; set; }
        public string sourceAccount { get; set; }
        public string sourceBankCode { get; set; }
    }
}
