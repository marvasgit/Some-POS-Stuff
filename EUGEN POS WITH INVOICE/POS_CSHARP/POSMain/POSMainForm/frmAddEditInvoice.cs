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

namespace POSMainForm
{
    public partial class frmAddEditInvoice : Form
    {

        int itemNo;
        double tax_decimal;
        double tax_percent;
        double tax_amount;
        bool is_has_tax;
        double discountAmount;
        double discountPercent;
        string selected_item = "";
        
        int customer_id;
        string invoice_no;

        bool is_invoice_success = true;
        bool is_invoice_shipping_success = true;
        bool is_invoice_items_sucess = true;
       
        public frmAddEditInvoice(string inv_no)
        {
            InitializeComponent();
            invoice_no = inv_no;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditInvoice_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            getStaffInfo();
            txtAddress.Text = "";
            cmbCustomerTax.SelectedIndex = 0;
            cmbCreateForm.SelectedIndex = 0;
            txtShippingCost.Text = "0";
            txtDuration.Text = "30";
            cmbTerms.SelectedIndex = 1;
            //shipping tab
            rbSameBilling.Checked = true;
            txtShipTo.Enabled = false;
            cmbShippingTax.SelectedIndex = 0;
            //initialize tax
            tax_decimal = GetTax();

            //disable remove button
            btnRemove.Enabled = false;

            if (SQLConn.adding == true)
            {
                GetInvoiceNo();
            }
            else
            {
                GetInvoiceInformation();
                GetInvoiceShipping();
                GetInvoiceItems();
                lblTax.Visible = true;
                lblTaxlabel.Visible = true;
            }
        }

        public void GetInvoiceNo()
        {
            try
            {
                SQLConn.sqL = "SELECT Id FROM Invoice ORDER BY Id DESC";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    txtInvoiceNo.Text = "INV-000-" + (Convert.ToInt32(SQLConn.dr["Id"]) + 1).ToString();
                }
                else
                {
                    txtInvoiceNo.Text = "INV-000-1";
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

        private void AddInvoice()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO invoice(InvoiceDate, InvoiceNo, CustomerPONo, Terms, Duration, SalesPerson, DiscountPercent, DiscountAmount, TotalAmount, Subtotal, TaxAmount, Note, CustomerId, BillAddress, Customer) VALUES (@InvoiceDate, @InvoiceNo, @CustomerPONo, @Terms, @Duration, @SalesPerson, @DiscountPercent, @DiscountAmount, @TotalAmount, @Subtotal, @TaxAmount, @Note, @CustomerId, @BillAddress, @Customer)";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceDate", dtpDate.Value.ToString("yyyy-MM-dd"));
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@CustomerPONo", txtPONumber.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Terms", cmbTerms.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
                SQLConn.cmd.Parameters.AddWithValue("@SalesPerson", txtSalesperson.Text);
                SQLConn.cmd.Parameters.AddWithValue("@DiscountPercent", lblDiscountPercent.Text);
                SQLConn.cmd.Parameters.AddWithValue("@DiscountAmount", lblDiscountAmount.Text.Replace(",",""));
                SQLConn.cmd.Parameters.AddWithValue("@TotalAmount", lblTotalAmount.Text.Replace(",", ""));
                SQLConn.cmd.Parameters.AddWithValue("@Subtotal", lblSubtotal.Text.Replace(",", ""));
                SQLConn.cmd.Parameters.AddWithValue("@TaxAmount", lblTax.Text.Replace(",", ""));
                SQLConn.cmd.Parameters.AddWithValue("@Note", txtNoteComment.Text);
                SQLConn.cmd.Parameters.AddWithValue("@CustomerId", customer_id);
                SQLConn.cmd.Parameters.AddWithValue("@BillAddress", txtAddress.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Customer", cmbCustomer.Text);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                is_invoice_success = false;
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void AddInvoiceShipping()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO invoiceshipping(InvoiceNo, ShiptoAddress, ShipBy, TrackingNo, ShippingCost, ShippingTax) VALUES(@InvoiceNo, @ShiptoAddress, @ShipBy, @TrackingNo, @ShippingCost, @ShippingTax)";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ShiptoAddress", txtShipTo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ShipBy", txtShipBy.Text);
                SQLConn.cmd.Parameters.AddWithValue("@TrackingNo", txtTrackingNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ShippingCost", Convert.ToDouble(txtShippingCost.Text));
                SQLConn.cmd.Parameters.AddWithValue("@ShippingTax", cmbShippingTax.Text);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                is_invoice_shipping_success = false;
                Interaction.MsgBox(ex.ToString());
            }
        }

        //Decrease product's stocks on hand
        public void UpdateProductQuantity()
        {
            try
            {
                SQLConn.sqL = "UPDATE Product SET StocksOnHand = StocksOnHand - @Quantity WHERE ProductNo = @ProductNo";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.Add("ProductNo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                SQLConn.cmd.Parameters.Add("Quantity", MySql.Data.MySqlClient.MySqlDbType.Double);

                for (int i = 0; i <= dgw.Rows.Count - 1; i++)
                {
                    SQLConn.cmd.Parameters["ProductNo"].Value = dgw.Rows[i].Cells[0].Value;
                    SQLConn.cmd.Parameters["Quantity"].Value = Convert.ToDouble(dgw.Rows[i].Cells[1].Value);
                    SQLConn.cmd.ExecuteNonQuery();
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

        public void AddInvoiceItems()
        {

            double taxItemAmount;
            try
            {
                SQLConn.sqL = "INSERT INTO InvoiceItems(InvoiceNo, Quantity, UnitPrice, Discount, Tax, Taxtype, ItemTotalAmount, Item, ItemDescription, ItemId) VALUES(@InvoiceNo, @Quantity, @UnitPrice, @Discount, @Tax, @Taxtype, @ItemTotalAmount, @Item, @ItemDescription, @ItemId)";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.Add("InvoiceNo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("Quantity", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("UnitPrice", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("Discount", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("Tax", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("TaxType", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("ItemTotalAmount", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("Item", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("ItemDescription", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("ItemId", MySql.Data.MySqlClient.MySqlDbType.Int32);

                for (int i = 0; i <= dgw.Rows.Count - 1; i++)
                {
                    taxItemAmount = Convert.ToDouble(dgw.Rows[i].Cells[7].Value.ToString().Replace(",", "")) * tax_decimal;

                    SQLConn.cmd.Parameters["InvoiceNo"].Value = txtInvoiceNo.Text;
                    SQLConn.cmd.Parameters["Quantity"].Value = dgw.Rows[i].Cells[1].Value;
                    SQLConn.cmd.Parameters["UnitPrice"].Value = Convert.ToDouble(dgw.Rows[i].Cells[4].Value.ToString().Replace(",", ""));
                    SQLConn.cmd.Parameters["Discount"].Value = Convert.ToDouble(dgw.Rows[i].Cells[5].Value.ToString());
                    SQLConn.cmd.Parameters["Tax"].Value = taxItemAmount;
                    SQLConn.cmd.Parameters["TaxType"].Value = dgw.Rows[i].Cells[6].Value.ToString();
                    SQLConn.cmd.Parameters["ItemTotalAmount"].Value = Convert.ToDouble(dgw.Rows[i].Cells[7].Value.ToString().Replace(",", ""));
                    SQLConn.cmd.Parameters["Item"].Value = dgw.Rows[i].Cells[2].Value.ToString();
                    SQLConn.cmd.Parameters["ItemDescription"].Value = dgw.Rows[i].Cells[3].Value.ToString();
                    SQLConn.cmd.Parameters["ItemId"].Value = Convert.ToInt32(dgw.Rows[i].Cells[0].Value.ToString());
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                is_invoice_items_sucess = false;
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void UpdateInvoice()
        {
            try
            {
                SQLConn.sqL = "UPDATE invoice SET InvoiceDate=@InvoiceDate,  CustomerPONo=@CustomerPONo, Terms=@Terms, Duration=@Duration, SalesPerson=@SalesPerson, DiscountPercent=@DiscountPercent, DiscountAmount=@DiscountAmount, TotalAmount=@TotalAmount, Subtotal=@Subtotal, TaxAmount=@TaxAmount, Note=@Note, CustomerId =@CustomerId, BillAddress=@BillAddress, Customer=@Customer WHERE InvoiceNo=@InvoiceNo";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceDate", dtpDate.Value.ToString("yyyy-MM-dd"));
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@CustomerPONo", txtPONumber.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Terms", cmbTerms.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Duration", txtDuration.Text);
                SQLConn.cmd.Parameters.AddWithValue("@SalesPerson", txtSalesperson.Text);
                SQLConn.cmd.Parameters.AddWithValue("@DiscountPercent", lblDiscountPercent.Text);
                SQLConn.cmd.Parameters.AddWithValue("@DiscountAmount", lblDiscountAmount.Text.Replace(",", ""));
                SQLConn.cmd.Parameters.AddWithValue("@TotalAmount", lblTotalAmount.Text.Replace(",", ""));
                SQLConn.cmd.Parameters.AddWithValue("@Subtotal", lblSubtotal.Text.Replace(",", ""));
                SQLConn.cmd.Parameters.AddWithValue("@TaxAmount", lblTax.Text.Replace(",", ""));
                SQLConn.cmd.Parameters.AddWithValue("@Note", txtNoteComment.Text);
                SQLConn.cmd.Parameters.AddWithValue("@CustomerId", customer_id);
                SQLConn.cmd.Parameters.AddWithValue("@BillAddress", txtAddress.Text);
                SQLConn.cmd.Parameters.AddWithValue("@Customer", cmbCustomer.Text);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                is_invoice_success = false;
                Interaction.MsgBox(ex.ToString());
            }
        }


        public void UpdateInvoiceItems()
        {

            double taxItemAmount;
            try
            {
                SQLConn.sqL = "UPDATE  InvoiceItems SET InvoiceNo=@InvoiceNo, Quantity=@Quantity, UnitPrice=@UnitPrice, Discount=@Discount, Tax=@Tax, Taxtype=@Taxtype, ItemTotalAmount=@ItemTotalAmount, Item=@Item, ItemDescription=@ItemDescription, ItemId=@ItemId WHERE Id=@Id";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.Add("InvoiceNo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("Quantity", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("UnitPrice", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("Discount", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("Tax", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("TaxType", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("ItemTotalAmount", MySql.Data.MySqlClient.MySqlDbType.Double);
                SQLConn.cmd.Parameters.Add("Item", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("ItemDescription", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                SQLConn.cmd.Parameters.Add("ItemId", MySql.Data.MySqlClient.MySqlDbType.Int32);
                SQLConn.cmd.Parameters.Add("Id", MySql.Data.MySqlClient.MySqlDbType.Int32);

                for (int i = 0; i <= dgw.Rows.Count - 1; i++)
                {
                    taxItemAmount = Convert.ToDouble(dgw.Rows[i].Cells[7].Value.ToString().Replace(",", "")) * tax_decimal;

                    SQLConn.cmd.Parameters["InvoiceNo"].Value = txtInvoiceNo.Text;
                    SQLConn.cmd.Parameters["Quantity"].Value = dgw.Rows[i].Cells[1].Value;
                    SQLConn.cmd.Parameters["UnitPrice"].Value = Convert.ToDouble(dgw.Rows[i].Cells[4].Value.ToString().Replace(",", ""));
                    SQLConn.cmd.Parameters["Discount"].Value = Convert.ToDouble(dgw.Rows[i].Cells[5].Value.ToString());
                    SQLConn.cmd.Parameters["Tax"].Value = taxItemAmount;
                    SQLConn.cmd.Parameters["TaxType"].Value = dgw.Rows[i].Cells[6].Value.ToString();
                    SQLConn.cmd.Parameters["ItemTotalAmount"].Value = Convert.ToDouble(dgw.Rows[i].Cells[7].Value.ToString().Replace(",", ""));
                    SQLConn.cmd.Parameters["Item"].Value = dgw.Rows[i].Cells[2].Value.ToString();
                    SQLConn.cmd.Parameters["ItemDescription"].Value = dgw.Rows[i].Cells[3].Value.ToString();
                    SQLConn.cmd.Parameters["ItemId"].Value = Convert.ToInt32(dgw.Rows[i].Cells[0].Value.ToString());
                    SQLConn.cmd.Parameters["Id"].Value = Convert.ToInt32(dgw.Rows[i].Cells[9].Value.ToString());
                    SQLConn.cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                is_invoice_items_sucess = false;
                Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void UpdateInvoiceShipping()
        {
            try
            {
                SQLConn.sqL = "UPDATE invoiceshipping SET  ShiptoAddress=@ShiptoAddress, ShipBy=@ShipBy, TrackingNo=@TrackingNo, ShippingCost=@ShippingCost, ShippingTax=@ShippingTax WHERE InvoiceNo=@InvoiceNo";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ShiptoAddress", txtShipTo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ShipBy", txtShipBy.Text);
                SQLConn.cmd.Parameters.AddWithValue("@TrackingNo", txtTrackingNo.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ShippingCost", txtShippingCost.Text);
                SQLConn.cmd.Parameters.AddWithValue("@ShippingTax", cmbShippingTax.Text);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                is_invoice_shipping_success = false;
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void DeleteInvoiceItemTobeReplacedByUpdate()
        {
            try
            {
                SQLConn.sqL = "DELETE FROM invoiceitems  WHERE InvoiceNo=@InvoiceNo";                
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                SQLConn.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                is_invoice_shipping_success = false;
                Interaction.MsgBox(ex.ToString());
            }
        }


        private void GetInvoiceInformation() 
        {
            try
            {
                SQLConn.sqL = "SELECT InvoiceDate, InvoiceNo, CustomerPONo, Terms, Duration, SalesPerson, DiscountPercent, DiscountAmount, TotalAmount, Subtotal, TaxAmount, Note, CustomerId, BillAddress, customer FROM Invoice where InvoiceNo ='" + invoice_no + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read()) {
                    dtpDate.Value = Convert.ToDateTime(SQLConn.dr[0]);
                    txtInvoiceNo.Text = SQLConn.dr[1].ToString();
                    txtPONumber.Text = SQLConn.dr[2].ToString();
                    cmbTerms.Text = SQLConn.dr[3].ToString();
                    txtDuration.Text = SQLConn.dr[4].ToString();
                    txtSalesperson.Text = SQLConn.dr[5].ToString();
                    lblDiscountPercent.Text = SQLConn.dr[6].ToString();
                    lblDiscountAmount.Text = SQLConn.dr[7].ToString();
                    lblTotalAmount.Text = Strings.FormatNumber(SQLConn.dr[8]).ToString();
                    lblSubtotal.Text = Strings.FormatNumber(SQLConn.dr[9]).ToString();
                    lblTax.Text = Strings.FormatNumber(SQLConn.dr[10]).ToString();
                    txtNoteComment.Text = SQLConn.dr[11].ToString();
                    customer_id = Convert.ToInt32(SQLConn.dr[12]);
                    txtAddress.Text = SQLConn.dr[13].ToString();
                    cmbCustomer.Text = SQLConn.dr[14].ToString();

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

        private void GetInvoiceShipping()
        {
            try
            {
                SQLConn.sqL = "SELECT ShiptoAddress, ShipBy, TrackingNo, ShippingCost, ShippingTax FROM InvoiceShipping where InvoiceNo ='" + txtInvoiceNo.Text +"'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read())
                {
                    txtShipTo.Text = SQLConn.dr[0].ToString();
                    txtShipBy.Text = SQLConn.dr[1].ToString();
                    txtTrackingNo.Text = SQLConn.dr[2].ToString();
                    txtShippingCost.Text = SQLConn.dr[3].ToString();
                    cmbShippingTax.Text = SQLConn.dr[4].ToString();
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

        private void GetInvoiceItems()
        {
            try
            {
                SQLConn.sqL = "SELECT ItemId,  Quantity, Item, ItemDescription, UnitPrice, Discount, Taxtype, ItemTotalAmount, Id  FROM InvoiceItems where InvoiceNo ='" + txtInvoiceNo.Text + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                while (SQLConn.dr.Read() == true)
                {
                    dgw.Rows.Add(SQLConn.dr[0].ToString(), SQLConn.dr[1].ToString(), SQLConn.dr[2].ToString(), SQLConn.dr[3].ToString(), Strings.FormatNumber(SQLConn.dr[4]).ToString(), SQLConn.dr[5].ToString(), SQLConn.dr[6].ToString(), Strings.FormatNumber(SQLConn.dr[7]).ToString(), "Remove", SQLConn.dr[8].ToString());
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

        private void AddItemDisplay(int itemNo)
        {
            try
            {
                SQLConn.sqL = "SELECT ProductNo, ProductCode, Description, UnitPrice, ProductNo FROM Product WHERE  ProductNo = '" + itemNo + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    dgw.Rows.Add(SQLConn.dr[0].ToString(), 1, SQLConn.dr[1].ToString(), SQLConn.dr[2].ToString(), Strings.FormatNumber(SQLConn.dr[3]).ToString(), '0', cmbCustomerTax.Text, Strings.FormatNumber(SQLConn.dr[3]).ToString(), "Remove");
                }

               //display amounts
                ComupteAmount();

                //dgw.SelectedRows.Clear();
                dgw.ClearSelection();
                selected_item = "";

                //disable remove button
                btnRemove.Enabled = false;
               
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void LoadCustomer()
        {
            try
            {
                SQLConn.sqL = "SELECT Id, CONCAT(Lastname,', ', Firstname) customername FROM customer ORDER BY lastname";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                cmbCustomer.Items.Clear();
                Dictionary<string, string>customer = new Dictionary<string, string>();
                
                while (SQLConn.dr.Read() == true)
                {
                    customer.Add(SQLConn.dr[0].ToString(), SQLConn.dr[1].ToString());
                }

                cmbCustomer.DataSource = new BindingSource(customer, null);
                cmbCustomer.DisplayMember = "Value";
                cmbCustomer.ValueMember = "Key";

                cmbCustomer.SelectedIndex = -1;
            }
            catch (Exception)
            {
              //  Interaction.MsgBox(ex.ToString());
               
            }

            SQLConn.cmd.Dispose();
            SQLConn.conn.Close();
        }

        private void getStaffInfo()
        {
            try
            {
                SQLConn.sqL = "SELECT CONCAT(lastname, ', ', Firstname, ' ', MI) as StaffName, StaffId FROM Staff WHERE StaffID = '" + SQLConn.staffid + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    txtSalesperson.Tag = SQLConn.dr["StaffId"].ToString();
                    txtSalesperson.Text = SQLConn.dr["Staffname"].ToString();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }

        }

        private void GetCustomerInfo(int custId)
        {


            try
            {
                SQLConn.sqL = "SELECT address FROM customer where id = " + custId;
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                while (SQLConn.dr.Read() == true)
                {
                    txtAddress.Text = SQLConn.dr[0].ToString();
                    txtShipTo.Text = SQLConn.dr[0].ToString();
                }

            }
            catch (Exception ex)
            {
               //Interaction.MsgBox(ex.ToString());
            }
            finally
            {
                SQLConn.cmd.Dispose();
                SQLConn.conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmListProductforInvoice aeP = new frmListProductforInvoice(this);
            aeP.ShowDialog();

            AddItemDisplay(ItemNo);
        }

        private void cmbCustomer_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            KeyValuePair<string, string> selectedEntry= (KeyValuePair<string, string>)comboBox.SelectedItem;
            int selectedKey = Convert.ToInt32(selectedEntry.Key);

            customer_id = selectedKey;
            GetCustomerInfo(selectedKey);
        }

        private void rbSameBilling_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSameBilling.Checked == true) {
                txtShipTo.Enabled = false;
                rbShippingAddress.Checked = false;
                txtShipTo.Text = txtAddress.Text;
            }
        }

        private void rbShippingAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShippingAddress.Checked == true)
            {
                rbSameBilling.Checked = false;
                txtShipTo.Enabled = true;
                txtShipTo.Text = "";
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            txtShipTo.Text = txtAddress.Text;
        }

        private double totalAmount() 
        {
            int row_count = dgw.Rows.Count;

            double total_amount = 0;
            tax_amount = 0;
            is_has_tax = false;
            for (int i = 0; i < row_count; i++)
            {
                total_amount = total_amount + Convert.ToDouble(dgw.Rows[i].Cells[7].Value.ToString().Replace(",",""));
                
                if ((string)dgw.Rows[i].Cells[6].Value == "Default") 
                {
                    tax_amount += Convert.ToDouble(dgw.Rows[i].Cells[7].Value) * tax_decimal;
                    is_has_tax = true;
                }
            }
            return total_amount;
        }

        private double GetTax()
        {

            double vatDecimal = 0;
            try
            {
                SQLConn.sqL = "SELECT VatPercent FROm VatSetting";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();
                if (SQLConn.dr.Read() == true)
                {
                    vatDecimal = (Convert.ToDouble(SQLConn.dr[0]) / 100);
                    tax_percent = Convert.ToDouble(SQLConn.dr[0]);
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

            return vatDecimal;
        }


        private void ComupteAmount()
        {
            double total_amount = totalAmount();
            lblTotalAmount.Text = Strings.FormatNumber(total_amount);

            if (is_has_tax == true)
            {
                lblTaxlabel.Visible = true;
                lblTax.Visible = true;
                lblSubtotal.Text = Strings.FormatNumber(total_amount - tax_amount);
                lblTax.Text = Strings.FormatNumber(tax_amount);
            }
            else
            {
                lblTaxlabel.Visible = false;
                lblTax.Visible = false;
                lblSubtotal.Text = Strings.FormatNumber(total_amount);
            }   
        }

        private void RemoveItem()
        {
            try
            {

                if (selected_item == "") 
                {
                    Interaction.MsgBox("Please select item to remove.", MsgBoxStyle.Information,"Remove Item");
                    return;
                }
                dgw.Rows.Remove(dgw.SelectedRows[0]);
                ComupteAmount();

                //dgw.SelectedRows.Clear();
                dgw.ClearSelection();
                selected_item = "";
            }
            catch (Exception)
            {
              
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           RemoveItem();
           
        }

        private void dgw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.CurrentRow.Cells[8].Value.ToString() == "Remove")
                {
                    selected_item = ((string)dgw.CurrentRow.Cells[2].Value).Trim();
                    RemoveItem();
                }

            }
            else
            {
                selected_item = ((string)dgw.CurrentRow.Cells[2].Value).Trim();
                btnRemove.Enabled = true;
               
            }
          
        }

        private void dgw_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex == 5 || e.ColumnIndex == 1 || e.ColumnIndex == 4) && dgw.CurrentRow.Cells[2].Value.ToString() != "")
                {
                    if (dgw.CurrentRow.Cells[5].Value.ToString() != "0")
                    {
                        dgw.CurrentRow.Cells[7].Value = Strings.FormatNumber((Convert.ToDouble(dgw.CurrentRow.Cells[4].Value) - ((Convert.ToDouble(dgw.CurrentRow.Cells[5].Value) / 100) * Convert.ToDouble(dgw.CurrentRow.Cells[4].Value))) * Convert.ToDouble(dgw.CurrentRow.Cells[1].Value));
                    }
                    else {
                        dgw.CurrentRow.Cells[7].Value = Strings.FormatNumber(Convert.ToDouble(dgw.CurrentRow.Cells[4].Value) * Convert.ToDouble(dgw.CurrentRow.Cells[1].Value));
                    }

                    ComupteAmount();
                }

                if (e.ColumnIndex == 6)
                {
                    ComupteAmount();
                }
            }
            catch (Exception)
            {
      
            }
           
        }

        private void dgw_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public int ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }

        public double DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }

        public double DiscountAmount
        {
            get { return discountAmount; }
            set { discountAmount = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double amount_to_deduct = 0;
            double total_amount = totalAmount();

            frmEnterDiscount aeP = new frmEnterDiscount(this);
            aeP.ShowDialog();

            if (DiscountAmount > 0)
            {
                amount_to_deduct = DiscountAmount;
                lblDiscountAmount.Text = DiscountAmount.ToString();
            }

            if (DiscountPercent > 0)
            {
                amount_to_deduct = total_amount * (DiscountPercent / 100);
                lblDiscountAmount.Text = amount_to_deduct.ToString();
                lblDiscountPercent.Text = DiscountPercent.ToString();
            }

            if (DiscountPercent <= 0 && DiscountAmount <= 0)
            {
                return;
            }

            dgw.Rows.Add(0, 1, "Discount", "Discount", Strings.FormatNumber(amount_to_deduct).ToString(), '0', cmbCustomerTax.Text, "-" + amount_to_deduct, "Remove");

            ComupteAmount();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                AddInvoice();
                AddInvoiceShipping();
                AddInvoiceItems();
                UpdateProductQuantity();

                if (is_invoice_success == true && is_invoice_shipping_success == true && is_invoice_items_sucess == true)
                {
                    Interaction.MsgBox("Invoice successfully created.", MsgBoxStyle.Information, "Creating Invoice");
                }
            }
            else
            {
                UpdateInvoice();
                UpdateInvoiceShipping();
                //UpdateInvoiceItems();
                DeleteInvoiceItemTobeReplacedByUpdate();
                AddInvoiceItems();

                if (is_invoice_success == true && is_invoice_shipping_success == true && is_invoice_items_sucess == true)
                {
                    Interaction.MsgBox("Invoice successfully updated.", MsgBoxStyle.Information, "Updating Invoice");
                }
            }
            this.Close();
        }

        public string CustomerName
        {
            get { return cmbCustomer.Text; }
            set { cmbCustomer.Text = value; }
        }

        public int CustomerId
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmListCustomerForInvoice aeP = new frmListCustomerForInvoice(this);
            aeP.ShowDialog();
        }
   
    }
}
