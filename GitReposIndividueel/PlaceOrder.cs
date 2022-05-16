using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GitReposIndividueel
{
    class PlaceOrder
    {

        public PlaceOrder(string type, int amount, decimal limit, string stock)
        {
            MessageBox.Show("Stock: " + stock + "\n" + "Type: " + type + "\n" + "Amount: " + amount.ToString() + "\n" + "Limit: " + limit.ToString());
        }
    }
}
