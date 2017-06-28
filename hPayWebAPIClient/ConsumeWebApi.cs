using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace hPayWebAPIClient
{
    public static class ConsumeWebApi
    {
        public static async void GetInvoices(string userId)
        {
            using (var client = new HttpClient()) 
            {
                var response = client.GetAsync("http://localhost:52795/api/v1/Invoice/GetInvoices/" + userId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        public static async void GetInvoiceStatus(string userId, string invoiceId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:52795/api/v1/Invoice/GetInvoiceStatus/" + userId + "/Invoice/" + invoiceId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }



        public static async void GetPayment(string userId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:52795/api/v1/Payment/GetPayments/" + userId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

        }



        public static async void GetInvoicePayment(string userId, string invoiceId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:52795/api/v1/Payment/GetInvoicePayments/" + userId + "/Invoice/" + invoiceId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

        }


        public static async void GetInvoiceDetails(string userId, string invoiceId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:52795/api/v1/Invoice/GetInvoiceDetails/" + userId + "/Invoice/" + invoiceId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

        }


        public static async void GetInvoiceBalance(string userId, string invoiceId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:52795/api/v1/Invoice/GetInvoiceBalance/" + userId + "/Invoice/" + invoiceId).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

        }



        public static async void RecordPayment(int userId, int invoiceId, bool isDirectPaymentToProvider, decimal paymentAmt, int paymentModeId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var recordPaymentModel = new RecordPaymentModel
                {
                    InvoiceId = invoiceId,
                    IsDirectPaymentToProvider = isDirectPaymentToProvider,
                    PaymentAmt = paymentAmt,
                    PaymentModeId = paymentModeId,
                    UserId = userId
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:52795/api/v1/Payment/RecordPayment", recordPaymentModel);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }

        }

        class RecordPaymentModel
        {
            public int UserId { get; set; }
            public int InvoiceId { get; set; }
            public bool IsDirectPaymentToProvider { get; set; }
            public decimal PaymentAmt { get; set; }
            public int PaymentModeId { get; set; }
        }

    }
}
