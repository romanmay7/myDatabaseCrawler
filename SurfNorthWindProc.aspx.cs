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
    public partial class SurfNorthWindProc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.SearchCustomers();
            }

        }

        private void SearchCustomers(string searchKey = "ContactName", string searchTerm = "BeginWith")
        {
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myLocalDB2"].ConnectionString))
            {
                // Create a SqlCommand, and identify it as a stored procedure.
                using (SqlCommand sqlCommand = new SqlCommand("dbo.uspSearchCustomers", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;


                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@SearchKey", SqlDbType.NVarChar, 40));
                    sqlCommand.Parameters["@SearchKey"].Value = searchKey;

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@SearchValue", SqlDbType.NVarChar, 40));
                    sqlCommand.Parameters["@SearchValue"].Value = SearchField.Text.Trim();

                    // Add input parameter for the stored procedure and specify what to use as its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@SearchTerm", SqlDbType.NVarChar, 40));
                    sqlCommand.Parameters["@SearchTerm"].Value = searchTerm;


                    try
                    {
                        connection.Open();

                        // Run the stored procedure.
                       // sqlCommand.ExecuteNonQuery();

                        using (SqlDataAdapter sda = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            myGrid.DataSource = dt;
                            myGrid.DataBind();
                        }

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

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            SearchCustomers(FilterBy.Text.Trim(), FilterOption.Text.Trim());
        }

    }


}

