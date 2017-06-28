using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hPayWebAPIClient
{
    class Program
    {
        public static string userId;
        public static string invoiceId;
        static void Main(string[] args)
        {
            Console.Write("Please select web API to run");
            Console.WriteLine(Environment.NewLine);
            Console.Write("1.GetInvoices");
            Console.WriteLine(Environment.NewLine);
            Console.Write("2.GetInvoiceStatus");
            Console.WriteLine(Environment.NewLine);
            Console.Write("3.GetInvoiceBalance");
            Console.WriteLine(Environment.NewLine);
            Console.Write("4.GetInvoicePayment");
            Console.WriteLine(Environment.NewLine);
            Console.Write("5.GetPayments");
            Console.WriteLine(Environment.NewLine);
            Console.Write("6.RecordPayment");
            Console.WriteLine(Environment.NewLine);
            Console.Write("7.GetInvoiceDetails");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Enter option number from above: ");
            string caseNumber = Console.ReadLine();
            ExecuteTask(caseNumber);



        }


        public static void ExecuteTask(string caseNumber)
        {
            if (caseNumber == "1")
            {
                Console.WriteLine("Enter userId: ");
                userId = Console.ReadLine();
                ConsumeWebApi.GetInvoices(userId);
            }

            if (caseNumber == "2")
            {
                Console.WriteLine("Enter userId: ");
                userId = Console.ReadLine();
                Console.WriteLine("Enter InvoiceId: ");
                invoiceId = Console.ReadLine();
                ConsumeWebApi.GetInvoiceStatus(userId, invoiceId);
            }


            if (caseNumber == "3")
            {
                Console.WriteLine("Enter UserId: ");
                userId = Console.ReadLine();
                Console.WriteLine("Enter InvoiceId: ");
                invoiceId = Console.ReadLine();
                ConsumeWebApi.GetInvoiceBalance(userId, invoiceId);
            }

            if (caseNumber == "4")
            {
                Console.WriteLine("Enter UserId: ");
                userId = Console.ReadLine();
                Console.WriteLine("Enter InvoiceId: ");
                invoiceId = Console.ReadLine();
                ConsumeWebApi.GetInvoicePayment(userId, invoiceId);
            }

            if (caseNumber == "5")
            {
                Console.WriteLine("Enter UserId: ");
                userId = Console.ReadLine();
                ConsumeWebApi.GetPayment(userId);
            }

            if (caseNumber == "6")
            {
                Console.WriteLine("Enter UserId: ");
                userId = Console.ReadLine();
                Console.WriteLine("Enter invoiceId: ");
                invoiceId = Console.ReadLine();
                Console.WriteLine("Enter isDirectPaymentToProvider (it should be true or false): ");
                string isDirectPaymentToProvider = Console.ReadLine();
                Console.WriteLine("Enter paymentAmt: ");
                string paymentAmt = Console.ReadLine();
                Console.WriteLine("Enter paymentModeId: ");
                string paymentModeId = Console.ReadLine();

                ConsumeWebApi.RecordPayment(Convert.ToInt32(userId), Convert.ToInt32(invoiceId), Convert.ToBoolean(isDirectPaymentToProvider), Convert.ToDecimal(paymentAmt), Convert.ToInt32(paymentModeId));
            }

            if (caseNumber == "7")
            {
                Console.WriteLine("Enter UserId: ");
                userId = Console.ReadLine();
                Console.WriteLine("Enter InvoiceId: ");
                invoiceId = Console.ReadLine();
                ConsumeWebApi.GetInvoiceDetails(userId, invoiceId);
            }


            Console.ReadLine();

        }
    }
}
