using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management_System.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Models.Functions Con;
        string ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";
         
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();
            LogedUser.InnerText =Session["UserName"] as string;

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        private void ShowCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    connection.Open();
                    string query = "SELECT CatId as Id, CatName as CategoryName, CatRemarks as Remarks FROM CategoryTbl";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        CategoriesGV.DataSource = dt;
                        CategoriesGV.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                ErrMsg.InnerHtml = "An error occurred: " + ex.Message;
            }
        }


        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Rem = RemarkTb.Value;

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO CategoryTbl (CatName, CatRemarks) VALUES (@CatName, @Rem)";


                    using (SqlCommand command = new SqlCommand(query, connection))

                    {
                        command.Parameters.AddWithValue("@CatName", CatName);
                        command.Parameters.AddWithValue("@Rem", Rem);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            CatNameTb.Value = "";
                            RemarkTb.Value = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Added Success", "Swal.fire(' Added Successfully!!!', '', 'success');", true);

                            ShowCategories();



                        }
                        else
                        {
                            ErrMsg.InnerHtml = "Category not added. Please check your input.";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerHtml = "An error occurred: " + ex.Message;
            }
        }
        int key = 0;
        protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[1].Text);
            CatNameTb.Value = CategoriesGV.SelectedRow.Cells[2].Text;
            RemarkTb.Value = CategoriesGV.SelectedRow.Cells[3].Text;
        }
 

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatName = CatNameTb.Value;
                string Rem = RemarkTb.Value;
                string CatId = CategoriesGV.SelectedRow.Cells[1].Text; 

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE CategoryTbl SET CatName = @CatName, CatRemarks = @Rem WHERE CatId = @CatId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CatName", CatName);
                        command.Parameters.AddWithValue("@Rem", Rem);
                        command.Parameters.AddWithValue("@CatId", CatId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            CatNameTb.Value = "";
                            RemarkTb.Value = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Updated Success", "Swal.fire(' Edited Successfully!!!!', '', 'success');", true);
                            ShowCategories();
                        }
                        else
                        {
                            ErrMsg.InnerHtml = "Category not updated. Please check your input or category ID.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrMsg.InnerHtml = "An error occurred: " + ex.Message;
            }



        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string CatId = CategoriesGV.SelectedRow.Cells[1].Text;

                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM CategoryTbl WHERE CatId = @CatId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CatId", CatId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            CatNameTb.Value = "";
                            RemarkTb.Value = "";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Delete Success", "Swal.fire(' Deleted successfully!!!', '', 'success');", true);

                            ShowCategories();

                        }
                        else
                        {
                           
                            ErrMsg.InnerHtml = "Category not found or not deleted.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the delete process
                ErrMsg.InnerHtml = "An error occurred: " + ex.Message;
            }

        }

        protected void CategoriesGV_SelectedIndexChanged1(object sender, EventArgs e)
        {
            key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[1].Text);
            CatNameTb.Value = CategoriesGV.SelectedRow.Cells[2].Text;
            RemarkTb.Value = CategoriesGV.SelectedRow.Cells[3].Text;
        }
    }
}
