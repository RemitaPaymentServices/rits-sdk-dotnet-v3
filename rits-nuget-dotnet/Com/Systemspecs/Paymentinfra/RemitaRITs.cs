using System;
using System.Collections.Generic;
using System.Text;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsGetBankList;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsAccountEnquiry;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPayment;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsBulkPaymentStatus;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsSinglePayment;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsSinglePaymentStatus;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsGenerateBearerToken;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig;

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra
{
    public class RemitaRITs
    {
        public string baseUrl { get; set; }

        public RemitaRITs(string environment)
        {
            if (string.IsNullOrEmpty(environment))
            {
                baseUrl  =  EnvironmentConfig.TEST;
            }
            else
            {
              baseUrl =  environment;
            }
        }

     public GenerateTokenResponseData generateToken(GenerateTokenPayload generateTokenPayload)
     {
            GenerateBearerToken generateBearToken = new GenerateBearerToken(baseUrl);
            return generateBearToken.generateToken(generateTokenPayload);
     }
    
      public AccountEnquiryResponseData accountEnquiry(AccountEnquiryPayload accountEnquiryPayload, string accessToken)
      {
          AccountEnquiry accountEnquiry = new AccountEnquiry(baseUrl);
          return accountEnquiry.getAccountEnquiry(accountEnquiryPayload, accessToken);
      }

      public SingleResponseData singlePayment(SinglePaymentPayload singlePaymentPayload, string accessToken)
      {
            SinglePayment singlePayment = new SinglePayment(baseUrl);
            return singlePayment.makeSinglePayment(singlePaymentPayload, accessToken);
      }

      public SinglePaymentStatusReponseData singlePaymentStatus(SinglePaymentStatusPayload singlePaymentStatusPayload, string accessToken)
      {
            SinglePaymentStatus singlePaymentStatus = new SinglePaymentStatus(baseUrl);
            return singlePaymentStatus.checkSinglePaymentStatus(singlePaymentStatusPayload, accessToken);
      }

      public BulkPaymentResponseData bulkPayment(BulkPaymentPayload bulkPaymentPayload, string accessToken)
      {
            BulkPayment bulkPayment = new BulkPayment(baseUrl);
            return bulkPayment.makeBulkPayment(bulkPaymentPayload, accessToken);
      }

      public BulkPaymentStatusResponseData bulkPaymentStatus(BulkPaymentStatusPayload bulkPaymentStatusPayload, string accessToken)
      {
        BulkPaymentStatus bulkPaymentStatus = new BulkPaymentStatus(baseUrl);
        return bulkPaymentStatus.checkBulkPaymentStatus(bulkPaymentStatusPayload, accessToken);
      }
        /*
      public BankListResponseData getActiveBanks(GetActiveBankPayload getActiveBankPayload, string accessToken)
      {
         GetActiveBank getActiveBank = new GetActiveBank(baseUrl);
         return getActiveBank.getListOfActiveBanks(getActiveBankPayload, accessToken);
      }
        */
    }
}
