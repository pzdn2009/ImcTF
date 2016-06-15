using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImcFramework.Winform
{
    public class RequestLogArgs : EventArgs
    {
        public string SellerAccount { get; set; }
        public string Date { get; set; }
        public string LogLevel { get; set; }
        public RequestLogArgs(string date, string sellerAccount, string logLevel)
        {
            this.Date = date;
            this.SellerAccount = sellerAccount;
            this.LogLevel = logLevel;
        }
    }
}
