  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
  
using System;
using System.Collections;
using System.Collections.Generic;
  
using System.Text;
  
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;


namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPayment
{
    class BulkPayment
    {
        private BulkPaymentResponseData result;
        private string baseUrl;

        public BulkPayment(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public BulkPaymentResponseData makeBulkPayment(BulkPaymentPayload bulkPaymentPayload, string accessToken)
        {
            BulkPaymentResponseData altResult = new BulkPaymentResponseData();
             
                try
                {

                //URL
                string url = baseUrl + EnvironmentConfig.BULK_PAYMENT;

                //HEADERS
                List<Header> headers = new List<Header>();
                headers.Add(new Header { header = "Content-Type", value = "application/json" });
                string token = "Bearer " + accessToken;
                headers.Add(new Header { header = "Authorization", value = token });

                var body = new
                 {
                    batchRef = bulkPaymentPayload.batchRef,
                    totalAmount = bulkPaymentPayload.totalAmount,
                    sourceAccount = bulkPaymentPayload.sourceAccount,
                    sourceAccountName = bulkPaymentPayload.sourceAccountName,
                    sourceBankCode = bulkPaymentPayload.sourceBankCode,
                    currency = bulkPaymentPayload.currency,
                    sourceNarration = bulkPaymentPayload.sourceNarration,
                    originalAccountNumber = bulkPaymentPayload.originalAccountNumber,
                    originalBankCode = bulkPaymentPayload.originalBankCode,
                    customReference = bulkPaymentPayload.customReference,
                    transactions = bulkPaymentPayload.transactions
                };

                 var response = WebClientUtil.PostResponse(url, JsonConvert.SerializeObject(body), headers);
                 result = JsonConvert.DeserializeObject<BulkPaymentResponseData>(response);
                
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                return result;                   
        }
    }
}
