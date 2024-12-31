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
    public partial class ItemMaster : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindItem();
            }
        }

        private void BindItem()
        {
            try
            {
                using(SqlConnection con=new SqlConnection(ConnectionString))
                {
                    string Query = @"select * from Item_master";
                    SqlDataAdapter da = new SqlDataAdapter(Query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        gvItem.DataSource= dt;
                        gvItem.DataBind();
                    }
                   

                }
            }
            catch(Exception ex)
            {

            }
        }
        private void Clear()
        {
            try
            {
                txtitemname.Text = string.Empty;
                txtrate.Text = string.Empty;
                txtqty.Text = string.Empty;

            }
            catch (Exception ex)
            {

            }
        }

        private void Delete(string Id)
        {
            try
            {
                using(SqlConnection con=new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Item_id", Id);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('deleted Successfully')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('something went wrong')", true);
                    }
                    BindItem();
                    Clear();
                }
            }
            catch(Exception ex )
            {

            }
            BindItem();
            Clear();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Save", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Item_name", txtitemname.Text);
                    cmd.Parameters.AddWithValue("@Balance_quantity", txtqty.Text);
                    cmd.Parameters.AddWithValue("@Rate", txtrate.Text);
                    cmd.Parameters.AddWithValue("@Category", ddlcategory.SelectedValue);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if(i>0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Saved Successfully')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Something Went Wrong')", true);

                    }
                    BindItem();
                    Clear();
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand("Sp_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Item_id", ViewState["ItemId"]);
                    cmd.Parameters.AddWithValue("@Item_name", txtitemname.Text);
                    cmd.Parameters.AddWithValue("@Balance_quantity", txtqty.Text);
                    cmd.Parameters.AddWithValue("@Rate", txtrate.Text);
                    cmd.Parameters.AddWithValue("@Category", ddlcategory.SelectedValue);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Updated Successfully')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('something went wrong')", true);
                    }
                    BindItem();
                    Clear();
                }
            }
            catch (Exception ex)
            {

            }
            BindItem();
            Clear();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void gvItem_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                int rowindex = e.NewEditIndex;
                GridViewRow row = gvItem.Rows[rowindex];
                ViewState["ItemId"] = gvItem.DataKeys[rowindex]["Item_id"].ToString();
                txtitemname.Text = row.Cells[1].Text;
                ddlcategory.SelectedValue = row.Cells[2].Text;
                txtrate.Text = row.Cells[3].Text;
                txtqty.Text = row.Cells[4].Text;
                e.Cancel = true;
            }
            catch(Exception ex)
            {

            }
        }

        protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                string Id = gvItem.DataKeys[rowindex]["Item_id"].ToString();
                Delete(Id);
            }
            catch
            {

            }
        }
       

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string Searchstring = txtsearch.Text.Trim();
                if(!string.IsNullOrEmpty(Searchstring))
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        string Query = @"select * from Item_master where Item_name Like '%" + Searchstring + "%' ";
                        SqlDataAdapter da = new SqlDataAdapter(Query, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            gvItem.DataSource = dt;
                            gvItem.DataBind();
                        }
                        else
                        {
                            gvItem.DataSource = null;
                            gvItem.DataBind();
                        }


                    }
                    
                }
                else
                {
                    gvItem.DataSource = null;
                    gvItem.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}