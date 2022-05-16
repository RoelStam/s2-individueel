using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.ViewModels
{
    public class AccountViewModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int WalletID { get; set; }
        public List<HoldingViewModel> Holdings { get; set; }
        public double TotalAccount { get; set; }
        public double Available { get; set; }
        public double InHoldings { get; set; }
        public double TotalGain { get; set; }

    }
}
