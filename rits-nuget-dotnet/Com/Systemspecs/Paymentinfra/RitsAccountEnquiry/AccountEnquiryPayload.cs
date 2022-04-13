using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsAccountEnquiry
{
    public class AccountEnquiryPayload
    {
        public string sourceAccount { get; set; }
        public string sourceBankCode { get; set; }
    }
}
