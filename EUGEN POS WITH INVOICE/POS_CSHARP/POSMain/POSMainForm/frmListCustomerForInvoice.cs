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
    public partial class frmListCustomerForInvoice : Form
    {
        frmAddEditInvoice CInvoice;
        public frmListCustomerForInvoice(frmAddEditInvoice inv)
        {
            InitializeComponent();
            CInvoice = inv;
        }


        public void LoadCustomers(string strSearch)
        {
            try
            {
                SQLConn.sqL = "SELECT id, lastname, firstname, contactno, address FROM customer WHERE lastname LIKE '" + strSearch + "%' OR firstname LIKE '" + strSearch + "%' ORDER By lastname";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader(CommandBehavior.CloseConnection);

                dgw.Rows.Clear();

                while (SQLConn.dr.Read() == true)
                {
                    dgw.Rows.Add(SQLConn.dr[0].ToString(), SQLConn.dr[1].ToString(), SQLConn.dr[2].ToString(), SQLConn.dr[3].ToString(), SQLConn.dr[4].ToString());
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

        private void frmListCustomerForInvoice_Load(object sender, EventArgs e)
        {
            LoadCustomers("");
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadCustomers(txtName.Text);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedCustomer();
        }

        private void SelectedCustomer()
        {

            int cust_id = Convert.ToInt32(dgw.CurrentRow.Cells[0].Value);
            try
            {
                CInvoice.CustomerId = cust_id;
                CInvoice.CustomerName = dgw.CurrentRow.Cells[1].Value.ToString() + ", " + dgw.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgw_DoubleClick(object sender, EventArgs e)
        {
            SelectedCustomer();
        }
    }
}
