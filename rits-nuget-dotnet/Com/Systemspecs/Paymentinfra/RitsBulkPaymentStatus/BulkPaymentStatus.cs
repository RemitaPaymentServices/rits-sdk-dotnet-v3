

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPaymentStatus
{
    class BulkPaymentStatus
    {
        private BulkPaymentStatusResponseData result;

        private string baseUrl;
        public BulkPaymentStatus(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public BulkPaymentStatusResponseData checkBulkPaymentStatus(BulkPaymentStatusPayload bulkPaymentStatusPayload, string accessToken)
        {
            BulkPaymentStatusResponseData altResult = new BulkPaymentStatusResponseData();
                try
                {
                    //HEADERS
                    List<Header> headers = new List<Header>();
                    headers.Add(new Header { header = "Content-Type", value = "application/json" });
                    string token = "Bearer " + accessToken;
                    headers.Add(new Header { header = "Authorization", value = token });

                    var response = WebClientUtil.GetResponse(baseUrl, EnvironmentConfig.BULK_PAYMENT_STATUS + bulkPaymentStatusPayload.batchRef, headers);
                    result = JsonConvert.DeserializeObject<BulkPaymentStatusResponseData>(response);

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

                return result;
         }
    }
}
