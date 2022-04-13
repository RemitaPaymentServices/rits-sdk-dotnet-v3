using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPayment
{
    public class Data
    {
        public string batchRef { get; set; }
        public int totalAmount { get; set; }
        public string authorizationId { get; set; }
        public string transactionDate { get; set; }
    }
}
