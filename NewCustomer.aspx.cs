using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDatabaseCrawler
{
    public partial class NewCustomer : System.Web.UI.Page
    {
        // Storage for IDENTITY values returned from database.
        private int parsedCustomerID;
        private int orderID;

        /// <summary>
        /// Verifies that the customer name text box is not empty.
        /// </summary>
        private bool IsCustomerNameValid()
        {
            if (txtCustomerName.Text == "")
            {
                Response.Write("<script>alert('Please enter a name.');</script>");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifies that a customer ID and order amount have been provided.
        /// </summary>
        private bool IsOrderDataValid()
        {
            // Verify that CustomerID is present.
            if (txtCustomerID.Text == "")
            {
                Response.Write("<script>alert('Please create customer account before placing order.');</script>");
                return false;
            }
            // Verify that Amount isn't 0.
            else if ((Int32.Parse(numOrderAmount.Text)) < 1)
            {
                Response.Write("<script>alert('Please specify an order amount.');</script>");
                return false;
            }
            else
            {
                // Order can be submitted.
                return true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

// <summary>
/// Creates a new customer by calling the Sales.uspNewCustomer stored procedure.
/// </summary>
protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (IsCustomerNameValid())
            {
                // Create the connection.
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myLocalDB"].ConnectionString))
                {
                    // Create a SqlCommand, and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspNewCustomer", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for the stored procedure and specify what to use as its value.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
                        sqlCommand.Parameters["@CustomerName"].Value = txtCustomerName.Text;

                        // Add the output parameter.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

                        try
                        {
                            connection.Open();

                            // Run the stored procedure.
                            sqlCommand.ExecuteNonQuery();

                            // Customer ID is an IDENTITY value from the database.
                            this.parsedCustomerID = (int)sqlCommand.Parameters["@CustomerID"].Value;

                            // Put the Customer ID value into the read-only text box.
                            Response.Write("<script>alert('New Account was created.');</script>");
                            this.txtCustomerID.Text = Convert.ToString(parsedCustomerID);
                        }
                        catch
                        {
                            Response.Write("<script>alert('Customer ID was not returned. Account could not be created.');</script>");
                            
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calls the Sales.uspPlaceNewOrder stored procedure to place an order.
        /// </summary>
        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Ensure the required input is present.
            if (IsOrderDataValid())
            {
                // Create the connection.
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myLocalDB"].ConnectionString))
                {
                    // Create SqlCommand and identify it as a stored procedure.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspPlaceNewOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if(this.parsedCustomerID==0)
                        {
                            parsedCustomerID = Int32.Parse(txtCustomerID.Text);
                        }
                        // Add the @CustomerID input parameter, which was obtained from uspNewCustomer.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Value = this.parsedCustomerID;

                        // Add the @OrderDate input parameter.
                        sqlCommand.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@OrderDate"].Value = dtpOrderDate.Text;

                        // Add the @Amount order amount input parameter.
                        sqlCommand.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int));
                        sqlCommand.Parameters["@Amount"].Value = numOrderAmount.Text;

                        // Add the @Status order status input parameter.
                        // For a new order, the status is always O (open).
                        sqlCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.Char, 1));
                        sqlCommand.Parameters["@Status"].Value = "O";

                        // Add the return value for the stored procedure, which is  the order ID.
                        sqlCommand.Parameters.Add(new SqlParameter("@RC", SqlDbType.Int));
                        sqlCommand.Parameters["@RC"].Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            //Open connection.
                            connection.Open();

                            // Run the stored procedure.
                            sqlCommand.ExecuteNonQuery();

                            // Display the order number.
                            this.orderID = (int)sqlCommand.Parameters["@RC"].Value;

                            Response.Write("<script>alert('Order has been submitted.');</script>");
                            //MessageBox.Show("Order number " + this.orderID + " has been submitted.");
                        }
                        catch
                        {
                            Response.Write("<script>alert('Order could not be placed.');</script>");
                            //MessageBox.Show("Order could not be placed.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}