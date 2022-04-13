using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsSinglePayment
{
    public class Data
    {
        public int amount { get; set; }
        public string transactionRef { get; set; }
        public string transactionDescription { get; set; }
        public string authorizationId { get; set; }
        public string transactionDate { get; set; }
        public string paymentDate { get; set; }
    }
}
