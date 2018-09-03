using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSMainForm
{
    public partial class frmEnterDiscount : Form
    {
        frmAddEditInvoice Invoice;
        public frmEnterDiscount(frmAddEditInvoice invoice)
        {
            InitializeComponent();
            Invoice = invoice;
        }

        private void rbAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAmount.Checked == true) 
            {
                rbPercent.Checked = false;
                txtPercent.Enabled = false;
                txtPercent.Text = "";
                txtAmount.Enabled = true;
                txtAmount.Focus();
                
            }
        }

        private void rbPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPercent.Checked == true)
            {
                rbAmount.Checked = false;
                txtAmount.Enabled = false;
                txtAmount.Text = "";
                txtPercent.Enabled = true;
                txtPercent.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text != "") 
            {
                Invoice.DiscountAmount = Convert.ToDouble(txtAmount.Text);
            }

            if (txtPercent.Text != "") 
            {
                Invoice.DiscountPercent = Convert.ToDouble(txtPercent.Text);
            }

            this.Close();
        }

        private void frmEnterDiscount_Load(object sender, EventArgs e)
        {
            rbAmount.Checked = true;
        }
    }
}
