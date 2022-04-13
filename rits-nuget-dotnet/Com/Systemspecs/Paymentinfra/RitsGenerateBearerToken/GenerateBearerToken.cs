  
using Newtonsoft.Json;
  
using System;
using System.Collections.Generic;
  
using System.Text;
  
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsGenerateBearerToken
{
    class GenerateBearerToken
    {
       private GenerateTokenResponseData result;

        private string baseUrl;

        public GenerateBearerToken(string baseUrl)
        {
           this.baseUrl = baseUrl;
        }

        public GenerateTokenResponseData generateToken(GenerateTokenPayload generateTokenPayload)
        {
               try
                {
                    //URL
                    string url = baseUrl + EnvironmentConfig.GENERATE_TOKEN; 
                   
                    //HEADERS
                    List<Header> headers = new List<Header>();
                    headers.Add(new Header { header = "Content-Type", value = "application/json" });

                    var body = new
                    {
                        username = generateTokenPayload.username,
                        password = generateTokenPayload.password
                    };

                    var response = WebClientUtil.PostResponse(url, JsonConvert.SerializeObject(body), headers);
                    result = JsonConvert.DeserializeObject<GenerateTokenResponseData>(response);
                
                } catch (Exception ex)
                {
                    ex.ToString();
                }

            return result;
        }
    }
}
