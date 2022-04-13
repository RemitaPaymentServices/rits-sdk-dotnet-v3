  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
  
using System;
using System.Collections.Generic;
  
using System.Text;
  
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsSinglePayment
{
    class SinglePayment
    {
        private SingleResponseData result;
        private string baseUrl;
        public SinglePayment(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public SingleResponseData makeSinglePayment(SinglePaymentPayload singlePaymentPayload, string accessToken)
        {
            SingleResponseData altResult = new SingleResponseData();     
            {
                try
                {
                    //URL
                    string url = baseUrl + EnvironmentConfig.SINGLE_PAYMENT;

                    //HEADERS
                    List<Header> headers = new List<Header>();
                    headers.Add(new Header { header = "Content-Type", value = "application/json" });
                    string token = "Bearer " + accessToken;
                    headers.Add(new Header { header = "Authorization", value = token });


                    var body = new
                    {
                        amount = singlePaymentPayload.amount,
                        transactionRef = singlePaymentPayload.transactionRef,
                        transactionDescription = singlePaymentPayload.transactionDescription,
                        channel = singlePaymentPayload.channel,
                        currency = singlePaymentPayload.currency,
                        destinationAccount = singlePaymentPayload.destinationAccount,
                        destinationAccountName = singlePaymentPayload.destinationAccountName,
                        destinationBankCode = singlePaymentPayload.destinationBankCode,
                        destinationEmail = singlePaymentPayload.destinationEmail,
                        sourceAccount = singlePaymentPayload.sourceAccount,
                        sourceAccountName = singlePaymentPayload.sourceAccountName,
                        sourceBankCode = singlePaymentPayload.sourceBankCode,
                        originalAccountNumber = singlePaymentPayload.originalAccountNumber,
                        originalBankCode = singlePaymentPayload.originalBankCode,
                        customReference = singlePaymentPayload.customReference,
                        remitaFunded = singlePaymentPayload.remitaFunded
                    };
          
                        var response = WebClientUtil.PostResponse(url, JsonConvert.SerializeObject(body), headers);
                        result = JsonConvert.DeserializeObject<SingleResponseData>(response);
       
                }
                catch (Exception ex)
                {
                   ex.ToString();
                }

                return result;
            }
        }
    }
}
