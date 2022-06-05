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

        public class Datum
        {
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
            
            public Sum sum { get; set; }            
            public string comment { get; set; }

            public string mcomment()
            {
                string nn = "";
                if (comment == null)
                {
                }
                else
                {
                    nn = "\r\nКомментарий: " + comment;
                }
                return nn;
            }
        }

        public class RootObject
        {
            public List<Datum> data { get; set; }
        }
    }
}
