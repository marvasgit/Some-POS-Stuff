using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using Microsoft.Reporting.WinForms;

namespace POSMainForm
{
    public partial class frmReportInvoice : Form
    {
        string InvoiceNo;
        public frmReportInvoice(string inv_no)
        {
            InitializeComponent();
            InvoiceNo = inv_no;
        }

        private void frmReportInvoice_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            LoadReport();
        }

        private void LoadReport()
        {
            try
            {
                SQLConn.sqL = "SELECT InvoiceDate, i.InvoiceNo, CustomerPONo, TotalAmount, Subtotal, TaxAmount,  BillAddress, Customer, ShiptoAddress, ShipBy, TrackingNo, ShippingCost, ShippingTax, Terms, Duration,   Quantity, Item, ItemDescription, UnitPrice, Discount, Tax as TaxItemAmount, ItemTotalAmount FROM Invoice i   INNER JOIN InvoiceShipping invS ON i.InvoiceNo =invS.InvoiceNo INNER JOIN invoiceitems ii ON ii.InvoiceNo = i.InvoiceNo WHERE i.InvoiceNo = '" + InvoiceNo + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.da = new MySqlDataAdapter(SQLConn.cmd);

                this.dsReportC.Invoice.Clear();
                SQLConn.da.Fill(this.dsReportC.Invoice);

                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer1.ZoomPercent = 90;
                this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;

                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
    }
}
