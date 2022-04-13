using System;
using System.Collections.Generic;
using System.Text;
using RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsInit;

namespace RemitaRITsGateway.Com.Systemspecs.Paymentinfra.RitsConfig
{
    class EnvironmentConfig
    {
        public static string TEST = "https://remitademo.net/remita/exapp/api/v1/send/api/";
        public static string PRODUCTION = "https://login.remita.net/remita/exapp/api/v1/send/api/";
        public static string GENERATE_TOKEN = "uaasvc/uaa/token";
        public static string ACCOUNT_ENQUIRY = "rpgsvc/v3/rpg/account/lookup";
        public static string SINGLE_PAYMENT = "rpgsvc/v3/rpg/single/payment";
        public static string SINGLE_PAYMENT_STATUS = "rpgsvc/v3/rpg/single/payment/status/";
        public static string BULK_PAYMENT = "rpgsvc/v3/rpg/bulk/payment";
        public static string BULK_PAYMENT_STATUS = "rpgsvc/v3/rpg/bulk/payment/status/";
    }
}
