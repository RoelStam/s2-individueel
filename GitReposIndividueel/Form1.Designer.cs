
namespace GitReposIndividueel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlaceBuyOrder = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnPlaceSellOrder = new System.Windows.Forms.Button();
            this.lblLimit = new System.Windows.Forms.Label();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.listBoxStocks = new System.Windows.Forms.ListBox();
            this.lblChoosStock = new System.Windows.Forms.Label();
            this.listBoxOrderlist = new System.Windows.Forms.ListBox();
            this.lblChooseStock2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlaceBuyOrder
            // 
            this.btnPlaceBuyOrder.Location = new System.Drawing.Point(12, 370);
            this.btnPlaceBuyOrder.Name = "btnPlaceBuyOrder";
            this.btnPlaceBuyOrder.Size = new System.Drawing.Size(100, 23);
            this.btnPlaceBuyOrder.TabIndex = 0;
            this.btnPlaceBuyOrder.Text = "Place buy order";
            this.btnPlaceBuyOrder.UseVisualStyleBackColor = true;
            this.btnPlaceBuyOrder.Click += new System.EventHandler(this.btnPlaceBuyOrder_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(12, 412);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 1;
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(118, 412);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(100, 20);
            this.txtLimit.TabIndex = 2;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(12, 396);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Amount";
            // 
            // btnPlaceSellOrder
            // 
            this.btnPlaceSellOrder.Location = new System.Drawing.Point(118, 370);
            this.btnPlaceSellOrder.Name = "btnPlaceSellOrder";
            this.btnPlaceSellOrder.Size = new System.Drawing.Size(100, 23);
            this.btnPlaceSellOrder.TabIndex = 4;
            this.btnPlaceSellOrder.Text = "Place sell order";
            this.btnPlaceSellOrder.UseVisualStyleBackColor = true;
            this.btnPlaceSellOrder.Click += new System.EventHandler(this.btnPlaceSellOrder_Click);
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(115, 396);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(28, 13);
            this.lblLimit.TabIndex = 5;
            this.lblLimit.Text = "Limit";
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(570, 319);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrder.TabIndex = 7;
            this.btnDeleteOrder.Text = "Delete order";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // listBoxStocks
            // 
            this.listBoxStocks.FormattingEnabled = true;
            this.listBoxStocks.Items.AddRange(new object[] {
            "(PLTR) Palantir Technologies Inc.",
            "(ASTR) Assertio Holdings, Inc.",
            "(CTXR) Citius Pharmaceuticals, Inc.",
            "(OBSV) ObsEva SA",
            "(GME) GameStop Corp.",
            ""});
            this.listBoxStocks.Location = new System.Drawing.Point(12, 218);
            this.listBoxStocks.Name = "listBoxStocks";
            this.listBoxStocks.Size = new System.Drawing.Size(206, 95);
            this.listBoxStocks.TabIndex = 9;
            this.listBoxStocks.SelectedIndexChanged += new System.EventHandler(this.listBoxStocks_SelectedIndexChanged);
            // 
            // lblChoosStock
            // 
            this.lblChoosStock.AutoSize = true;
            this.lblChoosStock.Location = new System.Drawing.Point(12, 202);
            this.lblChoosStock.Name = "lblChoosStock";
            this.lblChoosStock.Size = new System.Drawing.Size(95, 13);
            this.lblChoosStock.TabIndex = 10;
            this.lblChoosStock.Text = "Choose your stock";
            // 
            // listBoxOrderlist
            // 
            this.listBoxOrderlist.FormattingEnabled = true;
            this.listBoxOrderlist.Location = new System.Drawing.Point(571, 218);
            this.listBoxOrderlist.Name = "listBoxOrderlist";
            this.listBoxOrderlist.Size = new System.Drawing.Size(206, 95);
            this.listBoxOrderlist.TabIndex = 11;
            // 
            // lblChooseStock2
            // 
            this.lblChooseStock2.AutoSize = true;
            this.lblChooseStock2.Location = new System.Drawing.Point(568, 202);
            this.lblChooseStock2.Name = "lblChooseStock2";
            this.lblChooseStock2.Size = new System.Drawing.Size(95, 13);
            this.lblChooseStock2.TabIndex = 12;
            this.lblChooseStock2.Text = "Choose your stock";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblChooseStock2);
            this.Controls.Add(this.listBoxOrderlist);
            this.Controls.Add(this.lblChoosStock);
            this.Controls.Add(this.listBoxStocks);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.lblLimit);
            this.Controls.Add(this.btnPlaceSellOrder);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnPlaceBuyOrder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlaceBuyOrder;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnPlaceSellOrder;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.ListBox listBoxStocks;
        private System.Windows.Forms.Label lblChoosStock;
        private System.Windows.Forms.ListBox listBoxOrderlist;
        private System.Windows.Forms.Label lblChooseStock2;
    }
}

