using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Hotel_Management_System.Views.Admin
{

    public partial class Users : System.Web.UI.Page
    {
        Functions Con;

        string ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();

            ShowUsers();
          
        }
        private void ShowUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    connection.Open();
                    string query = "select * from UserTbl";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        UserGV.DataSource = dt;
                        UserGV.DataBind();
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
                string UName = UNameTb.Value;
                string UPhone = PhoneTb.Value;
                string UGen = GenCb.SelectedValue;
                string UAdd = AddressTb.Value;
                string UPass = PasswordTb.Value;
             
                string Query = "insert into UserTbl values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, UName, UPhone, UGen,UAdd,UPass);
                Con.SetData(Query);
                ShowUsers();
                ErrMsg.InnerText = "Users Added!!!";
                UNameTb.Value = "";
                GenCb.SelectedIndex = -1;
                PhoneTb.Value = "";
                AddressTb.Value = "";
                PasswordTb.Value = "";


            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        int key = 0;
        protected void UserGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(UserGV.SelectedRow.Cells[1].Text);
            UNameTb.Value = UserGV.SelectedRow.Cells[2].Text;
            PhoneTb.Value = UserGV.SelectedRow.Cells[3].Text;
            GenCb.SelectedValue = UserGV.SelectedRow.Cells[4].Text;         
            AddressTb.Value = UserGV.SelectedRow.Cells[5].Text;
            PasswordTb.Value = UserGV.SelectedRow.Cells[6].Text;
    
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string UName = UNameTb.Value;
                string UPhone = PhoneTb.Value;
                string UGen = GenCb.SelectedValue;
                string UAdd = AddressTb.Value;
                string UPass = PasswordTb.Value;

                string Query = "update UserTbl Set UName = '{0}', UPhone = '{1}', UGen= '{2}', UAdd = '{3}',UPass='{4}' where UId = {5}";
                Query = string.Format(Query, UName, UPhone, UGen, UAdd, UPass, UserGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowUsers();
                ErrMsg.InnerText = "Users Updated!!!";
                UNameTb.Value = "";
                GenCb.SelectedIndex = -1;
                PhoneTb.Value = "";
                AddressTb.Value = "";
                PasswordTb.Value = "";


            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "delete from UserTbl where UId = {0}";
                Query = string.Format(Query, UserGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User Deleted Successfully !!!";
                UNameTb.Value = "";
                GenCb.SelectedIndex = -1;
                PhoneTb.Value = "";
                AddressTb.Value = "";
                PasswordTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}