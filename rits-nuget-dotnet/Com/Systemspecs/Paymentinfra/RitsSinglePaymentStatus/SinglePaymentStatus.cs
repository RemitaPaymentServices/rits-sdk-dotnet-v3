  
  
using System;
using System.Collections.Generic;
using System.Text;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;
using Newtonsoft.Json;

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsSinglePaymentStatus
{
    class SinglePaymentStatus
    {
        private SinglePaymentStatusReponseData result;

        private string baseUrl;

        public SinglePaymentStatus(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public SinglePaymentStatusReponseData checkSinglePaymentStatus(SinglePaymentStatusPayload singlePaymentStatusPayload, string accessToken)
        {
            SinglePaymentStatusReponseData altResult = new SinglePaymentStatusReponseData();
            {
                try
                {
                    //HEADERS
                    List<Header> headers = new List<Header>();
                    headers.Add(new Header { header = "Content-Type", value = "application/json" });
                    string token = "Bearer " + accessToken;
                    headers.Add(new Header { header = "Authorization", value = token });

                    var response = WebClientUtil.GetResponse(baseUrl, EnvironmentConfig.SINGLE_PAYMENT_STATUS + singlePaymentStatusPayload.transRef, headers);
                    result = JsonConvert.DeserializeObject<SinglePaymentStatusReponseData>(response);
                  
                }catch (Exception ex)
                {
                    ex.ToString();
                }

                return result;
            }
        }
    }
}
