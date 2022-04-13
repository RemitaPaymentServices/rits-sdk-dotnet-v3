

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;

using System.Text;

using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsAccountEnquiry
{
    class AccountEnquiry
    {
        private AccountEnquiryResponseData result;

        private string baseUrl;
        public AccountEnquiry(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public AccountEnquiryResponseData getAccountEnquiry(AccountEnquiryPayload accountEnquiryPayload, string accessToken)
        {
            AccountEnquiryResponseData altResult = new AccountEnquiryResponseData();
            {
                try
                {
                    //URL
                    string url = baseUrl + EnvironmentConfig.ACCOUNT_ENQUIRY;

                    //HEADERS
                    List<Header> headers = new List<Header>();
                    headers.Add(new Header { header = "Content-Type", value = "application/json" });
                    string token = "Bearer " + accessToken;
                    headers.Add(new Header { header = "Authorization", value = token });

                    var body = new
                    {
                        sourceAccount = accountEnquiryPayload.sourceAccount,
                        sourceBankCode = accountEnquiryPayload.sourceBankCode
                    };

                    var response = WebClientUtil.PostResponse(url, JsonConvert.SerializeObject(body), headers);
                    result = JsonConvert.DeserializeObject<AccountEnquiryResponseData>(response);
                
                } catch (Exception ex)
                {
                    ex.ToString();
                }
                return result;
            }

        }
    }
}
