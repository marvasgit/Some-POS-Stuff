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
    public partial class frmListCustomer : Form
    {

        int customerID;
        public frmListCustomer()
        {
            InitializeComponent();
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

        private void frmListCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers("");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SQLConn.adding = true;
            SQLConn.updating = false;
            int init = 0;
            frmAddEditCustomer aeC = new frmAddEditCustomer(init);
            aeC.ShowDialog();
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
                if (string.IsNullOrEmpty(dgw.CurrentRow.Cells[0].Value.ToString()))
                {

                }
                else
                {
                    SQLConn.adding = false;
                    SQLConn.updating = true;
                    customerID = Convert.ToInt32(dgw.CurrentRow.Cells[0].Value.ToString());
                    frmAddEditCustomer aeC = new frmAddEditCustomer(customerID);
                    aeC.ShowDialog();
                }
            }
            catch
            {
                Interaction.MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update");
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SQLConn.strSearch = Interaction.InputBox("ENTER CATEGORY NAME.", "Search Category", " ");

            if (SQLConn.strSearch.Length >= 1)
            {
                LoadCustomers(SQLConn.strSearch.Trim());
            }
            else if (string.IsNullOrEmpty(SQLConn.strSearch))
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
