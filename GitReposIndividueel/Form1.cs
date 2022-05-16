using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitReposIndividueel
{
    public partial class Form1 : Form
    {
        int amount;
        decimal limit;
        string selectedStock;
        string type;
        PlaceOrder[] orders;
        int ordernr = -1;

        public Form1()
        {
            InitializeComponent();
            orders = new PlaceOrder[10];
        }

        private void btnPlaceBuyOrder_Click(object sender, EventArgs e)
        {
            ordernr++;
            amount = int.Parse(txtAmount.Text);
            limit = decimal.Parse(txtLimit.Text);
            selectedStock = listBoxStocks.GetItemText(listBoxStocks.SelectedItem);
            type = "buy";
            orders[ordernr] = new PlaceOrder("buy", amount, limit, selectedStock);
            listBoxOrderlist.Items.Add("Buy " + selectedStock + " " + amount + " " + limit);
        }

        private void btnPlaceSellOrder_Click(object sender, EventArgs e)
        {
            ordernr++;
            amount = int.Parse(txtAmount.Text);
            limit = decimal.Parse(txtLimit.Text);
            selectedStock = listBoxStocks.GetItemText(listBoxStocks.SelectedItem);
            type = "sell";
            orders[ordernr] = new PlaceOrder("sell", amount, limit, selectedStock);
            listBoxOrderlist.Items.Add("Sell " + selectedStock + " " + amount + " " + limit);
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            selectedStock = listBoxOrderlist.GetItemText(listBoxOrderlist.SelectedItem);
            listBoxOrderlist.Items.Remove(selectedStock);
            // messagebox doesn't work properly when inserting multiple orders
            //have to figure out how to get the variables from the selected order, not the last made order.
            MessageBox.Show("Deleted: " + "\n" + "Stock: " + selectedStock + "\n" + "Type: " + type + "\n" + "Amount: " + amount + "\n" + "Limit: " + limit.ToString());
        }

        private void lblDeleteOrder_Click(object sender, EventArgs e)
        {

        }

        private void listBoxStocks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
