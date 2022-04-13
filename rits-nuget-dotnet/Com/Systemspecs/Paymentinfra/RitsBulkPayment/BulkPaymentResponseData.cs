using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPayment
{
    public class BulkPaymentResponseData
    {
        public string status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}
