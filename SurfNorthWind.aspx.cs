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
    public partial class SurfNorthWind : System.Web.UI.Page
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
            string constr = ConfigurationManager.ConnectionStrings["myLocalDB2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT ContactName, CompanyName, Phone,TotalOrders FROM dbo.Customers";
                    if (!string.IsNullOrEmpty(SearchField.Text.Trim()))
                    {
                        switch (searchTerm) 
                        {
                            case "BeginWith":

                                {
                                    sql += " WHERE " + searchKey + " LIKE @" + searchKey + "+'%'";
                                    cmd.Parameters.AddWithValue("@" + searchKey, SearchField.Text.Trim());
                                }
                             break;

                            case "Includes":

                                {
                                    sql += " WHERE " + searchKey + " LIKE '%'+@" + searchKey + " +'%'";
                                    cmd.Parameters.AddWithValue("@" + searchKey, SearchField.Text.Trim());
                                }
                                break;

                            case "EndsWith":

                                {
                                    sql += " WHERE " + searchKey + " LIKE '%'+@" + searchKey;
                                    cmd.Parameters.AddWithValue("@" + searchKey, SearchField.Text.Trim());
                                }
                                break;
                        }

                    }
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        myGrid.DataSource = dt;
                        myGrid.DataBind();
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

