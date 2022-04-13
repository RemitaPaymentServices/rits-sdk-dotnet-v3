using System;
using System.Collections.Generic;
  
using System.Text;
  

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsGenerateBearerToken
{
    public class Datum
    {
        public string accessToken { get; set; }
        public int expiresIn { get; set; }
    }
}
