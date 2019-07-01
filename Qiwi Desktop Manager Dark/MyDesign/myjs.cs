using System;
using System.Collections.Generic;


namespace MyDesign
{
    class myjs
    {
        public class Sum
        {
            public double amount { get; set; }
            public int currency { get; set; }

            public string MSC()
            {
                string wal = "";

                if (currency == 643)
                {
                    wal = "RUB";
                }
                else
                {
                    if (currency == 840)
                    {
                        wal = "USD";
                    }
                    else
                    {
                        if (currency == 978)
                        {
                            wal = "EUR";
                        }
                        else
                        {
                            if (currency == 398)
                            {
                                wal = "KZT";
                            }
                            else
                            {

                            }
                        }
                    }
                }
                return wal;
            }
        }

        public class Commission
        {
            public double amount { get; set; }
            public int currency { get; set; }
        }

        public class Total
        {
            public double amount { get; set; }
            public int currency { get; set; }
        }

        public class Provider
        {
            public int id { get; set; }
            public string shortName { get; set; }
            public string longName { get; set; }
            public string logoUrl { get; set; }
            public object description { get; set; }
            public string keys { get; set; }
            public string siteUrl { get; set; }
            public List<object> extras { get; set; }
        }

        public class Source
        {
            public int id { get; set; }
            public string shortName { get; set; }
            public string longName { get; set; }
            public string logoUrl { get; set; }
            public object description { get; set; }
            public string keys { get; set; }
            public string siteUrl { get; set; }
            public List<object> extras { get; set; }
        }

        public class Features
        {
            public bool chequeReady { get; set; }
            public bool bankDocumentReady { get; set; }
            public bool regularPaymentEnabled { get; set; }
            public bool bankDocumentAvailable { get; set; }
            public bool repeatPaymentEnabled { get; set; }
            public bool favoritePaymentEnabled { get; set; }
            public bool chatAvailable { get; set; }
            public bool greetingCardAttached { get; set; }
        }

        public class ServiceExtras
        {
        }

        public class View
        {
            public string title { get; set; }
            public string account { get; set; }
        }

        public class Datum
        {
            public object txnId { get; set; }
            public object personId { get; set; }
            public DateTime date { get; set; }
            public int errorCode { get; set; }
            public object error { get; set; }
            public string status { get; set; }

            public string type { get; set; }

            public string MS()
            {
                string tpe = "";
                if (type == "IN")
                {
                    tpe = "Пополнение";
                }
                else
                {
                    if (type == "OUT")
                    {
                        tpe = "Платеж";
                    }
                    else
                    {
                        if (type == "QIWI_CARD")
                        {
                            tpe = "платеж с карты QIWI";
                        }
                    }
                }
                return tpe;
            }

            public string statusText { get; set; }
            public string trmTxnId { get; set; }
            public string account { get; set; }
            public Sum sum { get; set; }
            public Commission commission { get; set; }
            public Total total { get; set; }
            public Provider provider { get; set; }
            public Source source { get; set; }
            public string comment { get; set; }

            public string mcomment()
            {
                string nn = "";
                if (comment == null)
                {
                    nn = "";
                }
                else
                {
                    nn = "\r\nКомментарий: " + comment;
                }
                return nn;
            }
            public int currencyRate { get; set; }
            public List<object> paymentExtras { get; set; }
            public Features features { get; set; }
            public ServiceExtras serviceExtras { get; set; }
            public View view { get; set; }
        }

        public class RootObject
        {
            public List<Datum> data { get; set; }
            public long nextTxnId { get; set; }
            public DateTime nextTxnDate { get; set; }
        }
    }
}
