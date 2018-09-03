using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace POSMainForm
{
    public partial class frmListInvoice : Form
    {
        string invoice_no;
        string new_invoice_no;
        public frmListInvoice()
        {
            InitializeComponent();
        }

        public void SalesReturns(DateTime startDate, DateTime endDate, string searchString)
        {

            try
            {
                SQLConn.sqL = "SELECT InvoiceDate, InvoiceNo, Customer, SalesPerson,  TotalAmount FROM Invoice WHERE InvoiceDate  BETWEEN '" + startDate.ToString("yyyy-MM-dd") + "' AND '" + endDate.ToString("yyyy-MM-dd") + "' AND (InvoiceNo LIKE '%" + txtSearch.Text + "%' OR SalesPerson LIKE '%" + txtSearch.Text + "%' OR Customer LIKE '%" + txtSearch.Text + "%') GROUP BY InvoiceNo ORDER BY InvoiceDate, InvoiceNo DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                dgw.Rows.Clear();
          
                while (SQLConn.dr.Read() == true)
                {
                    dgw.Rows.Add(Convert.ToDateTime(SQLConn.dr[0]).ToString("MM/dd/yyyy"), SQLConn.dr[1].ToString(), SQLConn.dr[2].ToString(), SQLConn.dr[3].ToString(), Strings.FormatNumber(SQLConn.dr[4]).ToString(), Strings.FormatNumber(SQLConn.dr[4]).ToString());
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }


        public string GetInvoiceNo()
        {
            string ret = "";
            try
            {
                SQLConn.sqL = "SELECT Id FROM Invoice ORDER BY Id DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    ret = "INV-000-" + (Convert.ToInt32(SQLConn.dr["Id"]) + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
            return ret;
        }


        private void DeleteInvoice()
        {
            try
            {
                SQLConn.sqL = "DELETE FROM Invoice WHERE InvoiceNo = @InvoiceNo";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", dgw.CurrentRow.Cells[1].Value.ToString());
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("Invoice deleted sucessfully.",MsgBoxStyle.Information,"Deleting Invoice");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void CopyInvoice()
        {
            new_invoice_no = GetInvoiceNo();
            try
            {
                SQLConn.sqL = "INSERT INTO invoice(InvoiceDate, InvoiceNo, CustomerPONo, Terms, Duration, SalesPerson, DiscountPercent, DiscountAmount, TotalAmount, Subtotal, TaxAmount, Note, CustomerId, BillAddress, Customer) SELECT InvoiceDate, '" + new_invoice_no + "' InvoiceNo, CustomerPONo, Terms, Duration, SalesPerson, DiscountPercent, DiscountAmount, TotalAmount, Subtotal, TaxAmount, Note, CustomerId, BillAddress, Customer FROM invoice WHERE InvoiceNo=@InvoiceNo";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", dgw.CurrentRow.Cells[1].Value.ToString());
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void CopyInvoiceShipping()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO invoiceshipping(InvoiceNo, ShiptoAddress, ShipBy, TrackingNo, ShippingCost, ShippingTax) SELECT '" + new_invoice_no + "' InvoiceNo, ShiptoAddress, ShipBy, TrackingNo, ShippingCost, ShippingTax FROM invoiceshipping WHERE InvoiceNo=@InvoiceNo";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", dgw.CurrentRow.Cells[1].Value.ToString());
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void CopyInvoiceItems()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO InvoiceItems(InvoiceNo, Quantity, UnitPrice, Discount, Tax, Taxtype, ItemTotalAmount, Item, ItemDescription, ItemId) SELECT '" + new_invoice_no + "' InvoiceNo, Quantity, UnitPrice, Discount, Tax, Taxtype, ItemTotalAmount, Item, ItemDescription, ItemId FROM invoiceitems WHERE InvoiceNo=@InvoiceNo";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", dgw.CurrentRow.Cells[1].Value.ToString());
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SQLConn.adding = true;
            SQLConn.updating = false;
            invoice_no = "";
            frmAddEditInvoice aeC = new frmAddEditInvoice(invoice_no);
            aeC.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count == 0)
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(dgw.CurrentRow.Cells[2].Value.ToString()))
                {

                }
                else
                {
                    SQLConn.adding = false;
                    SQLConn.updating = true;
                    invoice_no = dgw.CurrentRow.Cells[1].Value.ToString(); ;
                    frmAddEditInvoice aeC = new frmAddEditInvoice(invoice_no);
                    aeC.ShowDialog();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
        }

        private void frmListInvoice_Load(object sender, EventArgs e)
        {
            SalesReturns(dtStartDate.Value, dtEndDate.Value, txtSearch.Text);
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            SalesReturns(dtStartDate.Value, dtEndDate.Value, txtSearch.Text);
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            SalesReturns(dtStartDate.Value, dtEndDate.Value, txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SalesReturns(dtStartDate.Value, dtEndDate.Value, txtSearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesReturns(dtStartDate.Value, dtEndDate.Value, txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Delete Invoice") == MsgBoxResult.Yes) 
            {
                DeleteInvoice();
                SalesReturns(dtStartDate.Value, dtEndDate.Value, txtSearch.Text);
            }
        }

        private void btnStocksIn_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("Are you sure you want to copy this invoice?", MsgBoxStyle.YesNo, "Delete Invoice") == MsgBoxResult.Yes)
            {
                CopyInvoice();
                CopyInvoiceShipping();
                CopyInvoiceItems();
                SalesReturns(dtStartDate.Value, dtEndDate.Value, txtSearch.Text);
                Interaction.MsgBox("Invoice copied sucessfully.", MsgBoxStyle.Information, "Copying Invoice");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count == 0)
            {
                Interaction.MsgBox("Please select record to print", MsgBoxStyle.Exclamation, "Print");
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(dgw.CurrentRow.Cells[2].Value.ToString()))
                {

                }
                else
                {
                  
                    invoice_no = dgw.CurrentRow.Cells[1].Value.ToString(); ;
                    frmReportInvoice aeC = new frmReportInvoice(invoice_no);
                    aeC.Show();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to print", MsgBoxStyle.Exclamation, "Print");
                return;
            }
        }
    }
}
