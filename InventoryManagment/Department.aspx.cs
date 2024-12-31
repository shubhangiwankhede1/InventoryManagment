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
    public partial class Department : System.Web.UI.Page
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    BindDepartment();
                }
                catch(Exception ex)
                {

                }
            }
        }
        private void BindDepartment()
        
        {
            try
            {
                SqlConnection con=new SqlConnection(connectionstring);
                SqlDataAdapter da=new SqlDataAdapter ("select * from Department_mast", con);
                DataTable dt=new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0 )
                {
                    GVDepartment.DataSource = dt;
                    GVDepartment.DataBind();
                }
                else
                {
                    GVDepartment.DataSource = null;
                    GVDepartment.DataBind();
                }
                con.Open();
            }
            catch (Exception ex)
            {

            }
        }
        private void clear()
        {
            try
            {
                txtDeptName.Text=string.Empty;
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("Sp_SaveDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Department_name", txtDeptName.Text);
                    con.Open();
                    int i=  cmd.ExecuteNonQuery();
                    if(i>0 )
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Saved Successfully')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('something Went Wrong')", true);
                    }

                }
              
            }
            catch (Exception ex)
            {

            }
            BindDepartment();
            clear();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateDepartment", con);
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Department_id", ViewState["ID"]);
                    cmd.Parameters.AddWithValue("@Department_name", txtDeptName.Text);
                    con.Open();
                    int i= cmd.ExecuteNonQuery();
                    if(i>0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Updated Successfully')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(),"alert()","alert('Something went wrong')",true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            BindDepartment();
            clear();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {

            }
            BindDepartment();
            clear();
        }
        private void Delete(string Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Department_id", Id);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if(i>0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(),"alert","alert('Deleted Successfully')",true );
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Something Went Wrong')", true);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
       
       
        protected void GVDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                string Id = GVDepartment.DataKeys[rowindex]["Department_id"].ToString();
                Delete(Id);
            }
            catch (Exception ex)
            {

            }
        }

        protected void GVDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVDepartment.PageIndex = e.NewPageIndex;
            BindDepartment();
        }

        protected void GVDepartment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVDepartment.EditIndex = -1;
            BindDepartment();
        }

        protected void GVDepartment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                int rowindex = e.NewEditIndex;
                GridViewRow row = GVDepartment.Rows[rowindex];
                ViewState["Id"] = GVDepartment.DataKeys[rowindex]["Department_id"].ToString();
                txtDeptName.Text = row.Cells[1].Text;
                // e.Cancel=true;
            }
            catch (Exception ex)
            {

            }
        }
    }
}