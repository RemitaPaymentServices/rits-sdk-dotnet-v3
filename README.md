# Remita Interbank Transfer Service (RITs) .NET SDK
.NET SDK for Remita Interbank Transfer Service.

## Prerequisites
The workflow to getting started on RITs is as follows:

*  Register a profile on Remita: You can visit [Remita](https://login.remita.net) to sign-up if you are not already registered as a merchant/biller on the platform.
*  Receive the Remita credentials that certify you as a Biller: Remita will send you your merchant ID and an API Key necessary to secure your handshake to the Remita platform.
## Requirements
*  Microsoft Visual Studio 
* .NET 2.0 or later

## Running the application
*  Clone project, review and run:
   https://github.com/RemitaNet/rits-sdk-dotnet-v3/blob/main/rits-nuget-dotnet/Com/Systemspecs/Paymentinfra/TestRemitaRITsServices.cs

**Sample Demo Code:**
```java
	public class TestRemitaRITsServices
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#########################################################");
            Console.WriteLine("## INITIALIZING REMITA PAYMENT CREDENTIALS AND GATEWAY ##");
            Console.WriteLine("#########################################################");
            Console.WriteLine(" ");

            Console.WriteLine("#################################");
            Console.WriteLine("###### SETTING ENVIRONMENT ######");
            Console.WriteLine("#################################");
            Console.WriteLine(" ");
            RemitaRITs remitaRITs = new RemitaRITs(EnvironmentConfig.TEST);
            Console.WriteLine("++++ ENVIRONMENT BASE URL: " + remitaRITs.baseUrl);

            Console.WriteLine(" ");
            Console.WriteLine("#############################");
            Console.WriteLine("###### GENERATING TOKEN ######");
            Console.WriteLine("#############################");
            Console.WriteLine(" ");
            GenerateTokenPayload generateTokenPayload = new GenerateTokenPayload();
            generateTokenPayload.username = "UHSU6ZIMAVXNZHXW";
            generateTokenPayload.password = "K8JE73OFE508GMOW9VWLX5SLH5QG1PF2";
            GenerateTokenResponseData generateTokenResponseData = remitaRITs.generateToken(generateTokenPayload);
            Console.WriteLine("++++ RESPONSE: " + JsonConvert.SerializeObject(generateTokenResponseData));
            Console.WriteLine(" ");
            string accessToken = generateTokenResponseData.data[0].accessToken;
            Console.WriteLine("++++ ACCESS TOKEN: " + accessToken);


            Console.WriteLine(" ");
            Console.WriteLine("#############################");
            Console.WriteLine("###### ACCOUNT ENQUIRY ######");
            Console.WriteLine("#############################");
            Console.WriteLine(" ");
            AccountEnquiryPayload accountEnquiryPayload = new AccountEnquiryPayload();
            accountEnquiryPayload.sourceAccount = "4589999044";
            accountEnquiryPayload.sourceBankCode = "044";
            AccountEnquiryResponseData accountEnquiryResponseData = remitaRITs.accountEnquiry(accountEnquiryPayload, accessToken);
            Console.WriteLine("++++ RESPONSE: " + JsonConvert.SerializeObject(accountEnquiryResponseData));
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine("#############################");
            Console.WriteLine("###### SINGLE PAYMENT ######");
            Console.WriteLine("#############################");
            Console.WriteLine(" ");
            SinglePaymentPayload singlePaymentPayload = new SinglePaymentPayload();
            singlePaymentPayload.amount = 1000;
            singlePaymentPayload.transactionRef = generateUniqueID();
            singlePaymentPayload.transactionDescription = "Payment for services";
            singlePaymentPayload.channel = "WEB";
            singlePaymentPayload.currency = "NGN";
            singlePaymentPayload.destinationAccount = "4589999044";
            singlePaymentPayload.destinationAccountName = "Doe John";
            singlePaymentPayload.destinationBankCode = "044";
            singlePaymentPayload.destinationEmail = "Doe.john@specs.com";
            singlePaymentPayload.sourceAccount = "8909090989";
            singlePaymentPayload.sourceAccountName = "Femi John";
            singlePaymentPayload.sourceBankCode = "058";
            singlePaymentPayload.originalAccountNumber = "8909090989";
            singlePaymentPayload.originalBankCode = "058";
            singlePaymentPayload.customReference = Guid.NewGuid().ToString("N");
            singlePaymentPayload.remitaFunded = true;
            SingleResponseData singleResponseData= remitaRITs.singlePayment(singlePaymentPayload, accessToken);
            Console.WriteLine("++++ RESPONSE: " + JsonConvert.SerializeObject(singleResponseData));
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine("###################################");
            Console.WriteLine("###### SINGLE PAYMENT STATUS ######");
            Console.WriteLine("###################################");
            Console.WriteLine(" ");
            SinglePaymentStatusPayload singlePaymentStatusPayload = new SinglePaymentStatusPayload();
            singlePaymentStatusPayload.transRef = singleResponseData.data.transactionRef;// NUMERIC VALUES ONLY
            SinglePaymentStatusReponseData singlePaymentStatusReponseData = remitaRITs.singlePaymentStatus(singlePaymentStatusPayload, accessToken);
            Console.WriteLine("++++ RESPONSE: " + JsonConvert.SerializeObject(singlePaymentStatusReponseData));
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine("#############################");
            Console.WriteLine("###### BULK PAYMENT ######");
            Console.WriteLine("#############################");
            Console.WriteLine(" ");
            BulkPaymentPayload bulkPaymentPayload = new BulkPaymentPayload();
            bulkPaymentPayload.batchRef = generateUniqueID();
            bulkPaymentPayload.totalAmount = 4500;
            bulkPaymentPayload.sourceAccount = "8909090989";
            bulkPaymentPayload.sourceAccountName = "ABC";
            bulkPaymentPayload.sourceBankCode = "058";
            bulkPaymentPayload.currency = "NGN";
            bulkPaymentPayload.sourceNarration = "Bulk Transfer";
            bulkPaymentPayload.originalAccountNumber = "8909090989"; 
            bulkPaymentPayload.originalBankCode = "058"; 
            bulkPaymentPayload.customReference = Guid.NewGuid().ToString("N");

            List<RitsBulkPayment.Transaction> transactions = new List<RitsBulkPayment.Transaction>();
            RitsBulkPayment.Transaction txn1 = new RitsBulkPayment.Transaction();
            txn1.amount = 2500;
            txn1.transactionRef = generateUniqueID();
            txn1.destinationAccount = "0037475942";
            txn1.destinationAccountName = "Kelvin John";
            txn1.destinationBankCode = "058";
            txn1.destinationNarration = "Bulk Transfer";
            transactions.Add(txn1);
            
            RitsBulkPayment.Transaction txn2 = new RitsBulkPayment.Transaction();
            txn2.amount = 1500;
            txn2.transactionRef = generateUniqueID();
            txn2.destinationAccount = "0037475942";
            txn2.destinationAccountName = "Martin John";
            txn2.destinationBankCode = "058";
            txn2.destinationNarration = "Bulk Transfer";
            transactions.Add(txn2);

            RitsBulkPayment.Transaction txn3 = new RitsBulkPayment.Transaction();
            txn3.amount = 500;
            txn3.transactionRef = generateUniqueID();
            txn3.destinationAccount = "0037475942";
            txn3.destinationAccountName = "James John";
            txn3.destinationBankCode = "058";
            txn3.destinationNarration = "Bulk Transfer";
            transactions.Add(txn3);

            bulkPaymentPayload.transactions = transactions;
            BulkPaymentResponseData bulkPaymentResponseData = remitaRITs.bulkPayment(bulkPaymentPayload, accessToken);
            Console.WriteLine("++++ RESPONSE: " + JsonConvert.SerializeObject(bulkPaymentResponseData));
            Console.WriteLine(" ");

            Console.WriteLine(" ");
            Console.WriteLine("###################################");
            Console.WriteLine("###### BULK PAYMENT STATUS ######");
            Console.WriteLine("###################################");
            Console.WriteLine(" ");
            BulkPaymentStatusPayload bulkPaymentStatusPayload = new BulkPaymentStatusPayload();
            bulkPaymentStatusPayload.batchRef = bulkPaymentResponseData.data.batchRef;// "540911";// NUMERIC VALUES ONLY
            BulkPaymentStatusResponseData bulkPaymentStatusResponseData = remitaRITs.bulkPaymentStatus(bulkPaymentStatusPayload, accessToken);
            Console.WriteLine("++++ RESPONSE: " + JsonConvert.SerializeObject(bulkPaymentStatusResponseData));
            Console.WriteLine(" ");


            Console.ReadLine();
        }

        public static string generateUniqueID()
        {
            string uniqueId = Guid.NewGuid().ToString("N");           
            string newUniqueId = uniqueId.Replace('a', '2').Replace('b', '3').Replace('c', '5').Replace('d', '7').Replace('e', '9').Replace('f', '1');
            return newUniqueId;
        }

    }
	
```

## Useful links
* Join our Slack channel at http://bit.ly/RemitaDevSlack
    
## Support
- For all other support needs, support@remita.net
