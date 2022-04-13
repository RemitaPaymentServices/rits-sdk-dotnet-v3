using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsGenerateBearerToken
{
    public class GenerateTokenResponseData
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Datum> data { get; set; }
    }
}
