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
    public partial class frmAddEditCustomer : Form
    {
        int customerID;
        public frmAddEditCustomer(int custID)
        {
            InitializeComponent();
            customerID = custID;

        }

        private void GetCustomerInformation()
        {
            try
            {
                SQLConn.sqL = "SELECT Id, Lastname, Firstname, ContactNo, Address FROM customer WHERE id = '" + customerID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.dr = SQLConn.cmd.ExecuteReader();

                if (SQLConn.dr.Read() == true)
                {
                    txtLastname.Tag = SQLConn.dr[0].ToString();
                    txtLastname.Text = SQLConn.dr[1].ToString();
                    txtFirstname.Text = SQLConn.dr[2].ToString();
                    txtContactno.Text = SQLConn.dr[3].ToString();
                    txtAddress.Text = SQLConn.dr[4].ToString();
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

        private void AddCustomer()
        {
            try
            {
                SQLConn.sqL = "INSERT INTO customer(Lastname, firstname, contactno, address) VALUES('" + txtLastname.Text + "', '" + txtFirstname.Text + "', '" + txtContactno.Text + "', '" + txtAddress.Text + "')";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("New Customer successfully added.", MsgBoxStyle.Information, "Add Customer");
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

        private void UpdateCustomer()
        {
            try
            {
                SQLConn.sqL = "UPDATE customer SET Lastname ='" + txtLastname.Text + "', firstname='" + txtFirstname.Text + "', contactno='" + txtContactno.Text + "', address='" + txtAddress.Text + "' WHERE Id = '" + customerID + "'";
                SQLConn.ConnDB();
                SQLConn.cmd = new MySqlCommand(SQLConn.sqL, SQLConn.conn);
                SQLConn.cmd.ExecuteNonQuery();
                Interaction.MsgBox("Customer successfully updated.", MsgBoxStyle.Information, "Update Customer");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                AddCustomer();
            }
            else
            {
                UpdateCustomer();

            }
            if (System.Windows.Forms.Application.OpenForms["frmListCustomer"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["frmListCustomer"] as frmListCustomer).LoadCustomers("");
            }

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            if (SQLConn.adding == true)
            {
                lblTitle.Text = "Adding New Customer";
                
            }
            else
            {
                lblTitle.Text = "Updating Customer";
                GetCustomerInformation();
            }
        }
    }


}
