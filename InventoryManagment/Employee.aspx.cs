using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace InventoryManagment
{
    public partial class Employee : System.Web.UI.Page
    {
        string Connection = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployee();
            }
        }
        private void clear()
        {
            try
            {
                txtname.Text = string.Empty;
                txtphone.Text = string.Empty;
            }
            catch
            {

            }
        }
        private void BindEmployee()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    string query = "select * from Employee";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Columns.Count>0)
                    {
                        RPEmployee.DataSource= dt;
                        RPEmployee.DataBind();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection con= new SqlConnection(Connection))
                {
                    string query = "INSERT INTO [dbo].[Employee]  ([Name],[Phone]) VALUES (@Name ,@Phone)";
                    SqlCommand cmd = new SqlCommand(query,con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    int i = cmd.ExecuteNonQuery();
                    if(i>0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('added Successfully')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Something went Wrong')", true);

                    }

                }
                clear();
                BindEmployee();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    string query = "update Employee set Name=@Name,Phone=@Phone where ID=@ID";
                    SqlCommand cmd=new SqlCommand(query,con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                    cmd.Parameters.AddWithValue("@ID", ViewState["id"]);
                    int i = cmd.ExecuteNonQuery();
                    if(i>0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('updated Successfully')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Something went wrong')", true);

                    }
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnedit_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string id=e.CommandArgument.ToString();
                using (SqlConnection con = new SqlConnection(Connection))
                {
                    string query = "select * from Employee where ID=@ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataReader reader= cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        txtname.Text = reader["Name"].ToString();
                        txtphone.Text = reader["Phone"].ToString();

                    }

                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void btndelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                String id=e.CommandArgument.ToString();
                using (SqlConnection con=new SqlConnection(Connection))
                {
                    string query = "delete from Employee where  ID=@ID";
                    SqlCommand cmd=new SqlCommand(query,con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", id);
                    int i=cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Deleted Successfully')", true);

                    }

                    else
                    {

                    }
                    clear();
                    BindEmployee();
                }

            }
            catch(Exception ex)
            {

            }
        }
    }
}