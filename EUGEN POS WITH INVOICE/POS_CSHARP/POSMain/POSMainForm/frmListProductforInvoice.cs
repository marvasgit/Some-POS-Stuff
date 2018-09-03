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
    public partial class frmListProductforInvoice : Form
    {

        frmAddEditInvoice Invoice;
        public frmListProductforInvoice(frmAddEditInvoice invoice)
        {
            InitializeComponent();
            Invoice = invoice;
        }

        public void LoadProducts(string strSearch)
        {
            try
            {
                SQLConn.sqL = "SELECT ProductNo, ProductCOde, P.Description,  UnitPrice, StocksOnHand FROM Product as P LEFT JOIN Category C ON P.CategoryNo = C.CategoryNo WHERE P.Description LIKE  @Description OR P.ProductCOde LIKE @ProductCOde   ORDER BY Description";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.Parameters.AddWithValue("@Description", "%" + strSearch + "%");
                SQLConn.cmd.Parameters.AddWithValue("@ProductCOde", "%" + strSearch + "%");
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                dgw.Rows.Clear();
                while (SQLConn.dr.Read() == true)
                {
                    dgw.Rows.Add(SQLConn.dr[0].ToString(), SQLConn.dr[1].ToString(), SQLConn.dr[2].ToString(), Strings.Format(SQLConn.dr[3], "#,##0.00"), SQLConn.dr[4].ToString());
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtName.Text);
        }

        private void frmListCustomerforInvoice_Load(object sender, EventArgs e)
        {
            LoadProducts("");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int itemno = Convert.ToInt32(dgw.CurrentRow.Cells[0].Value);
            try
            {
                Invoice.ItemNo = itemno;
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
                        
        }

        private void dgw_DoubleClick(object sender, EventArgs e)
        {
            int itemno = Convert.ToInt32(dgw.CurrentRow.Cells[0].Value);
            try
            {
                Invoice.ItemNo = itemno;
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
