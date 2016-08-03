using ImcFramework.WcfInterface.ProgressInfos;
using System;
using System.Collections.Generic;

namespace ImcFramework.Winform
{
    public class ProgressSynchronous
    {
        private Dictionary<string, ucSellerProgressBar> dictUcSellerProgressBars = new Dictionary<string, ucSellerProgressBar>();

        private ProgressSynchronous()
        {

        }
        public static ProgressSynchronous Create()
        {
            return new ProgressSynchronous();
        }

        public bool IsTotalCountSet
        {
            get;
            private set;
        }

        public TotalType TotalType { get; private set; }

        private int totalCount;
        public int TotalCount
        {
            get { return totalCount; }
        }
        public int TotalValue { get; set; }
        public void SetTotal(int value, int total, TotalType totalType)
        {
            this.TotalValue = value;
            this.totalCount = total;
            this.TotalType = totalType;
            IsTotalCountSet = true;

            this.dictUcSellerProgressBars.Clear();
        }

        public void SetSellerAccountValueAndTotal(string sellerAccount, int value, int total, Func<ucSellerProgressBar> lazyGet)
        {
            if (dictUcSellerProgressBars.ContainsKey(sellerAccount))
            {
                dictUcSellerProgressBars[sellerAccount].Value = value;
                dictUcSellerProgressBars[sellerAccount].Maximum = total;
            }
            else
            {
                dictUcSellerProgressBars[sellerAccount] = lazyGet();
            }
        }

        public void SetSellerAccountFinish(string sellerAccount)
        {
            if (dictUcSellerProgressBars.ContainsKey(sellerAccount))
            {
                dictUcSellerProgressBars[sellerAccount].Value = dictUcSellerProgressBars[sellerAccount].Maximum;
            }
            else
            {
                throw new Exception("SetSellerAccountFinish sellerAccount not exist");
            }
        }

        public bool Exist(string sellerAccount)
        {
            return dictUcSellerProgressBars.ContainsKey(sellerAccount);
        }
        public bool IsSellerAccountFinished(string sellerAccount)
        {
            return dictUcSellerProgressBars[sellerAccount].Maximum == dictUcSellerProgressBars[sellerAccount].Value;
        }


        public ucSellerProgressBar GetSellerProgressBar(string sellerAccount)
        {
            return dictUcSellerProgressBars[sellerAccount];
        }

        public void Add(string sellerAccount, ucSellerProgressBar bar)
        {
            dictUcSellerProgressBars.Add(sellerAccount, bar);
        }
    }
}
