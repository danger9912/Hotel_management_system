using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel_Management_System.Models;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Hotel_Management_System.Views.Admin
{
    public partial class Rooms : System.Web.UI.Page

    {
        Functions Con;

        string ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();

            ShowRooms();
            GetCategories();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
        private void ShowRooms()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    connection.Open();
                    string query = "select * from RoomTbl";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        RoomsGV.DataSource = dt;
                        RoomsGV.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                ErrMsg.InnerHtml = "An error occurred: " + ex.Message;
            }

        }
        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            DataTable data = Con.GetData(Query);

            if (data != null && data.Rows.Count > 0)
            {
                CatCb.DataTextField = data.Columns["CatName"].ColumnName; // Set DataTextField
                CatCb.DataValueField = data.Columns["CatId"].ColumnName;   // Set DataValueField
                CatCb.DataSource = data;
                CatCb.DataBind();
            }

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string RLoc = LocationTb.Value;
                string Cost = CostTb.Value;
                string Rem= RemarksTb.Value;
                string Status = StatusCb.SelectedValue.ToString();
                string Query = "insert into RoomTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, RName, RCat, RLoc, Cost, Rem, Status);
                Con.SetData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room Added!!!";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                RemarksTb.Value = "";


            }
            catch(Exception ex) {
                ErrMsg.InnerText = ex.Message;
             }

        }
        int key = 0;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RNameTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            CatCb.SelectedValue = RoomsGV.SelectedRow.Cells[3].Text;
            LocationTb.Value = RoomsGV.SelectedRow.Cells[4].Text;
            CostTb.Value = RoomsGV.SelectedRow.Cells[5].Text;
            RemarksTb.Value = RoomsGV.SelectedRow.Cells[6].Text;
            StatusCb.SelectedValue = RoomsGV.SelectedRow.Cells[7].Text;

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {

            try
            {
                string RName = RNameTb.Value;
                string RCat = CatCb.SelectedValue.ToString();
                string RLoc = LocationTb.Value;
                string Cost = CostTb.Value;
                string Rem = RemarksTb.Value;
                string Status = StatusCb.SelectedValue.ToString();
                string Query = "update RoomTbl set RName = '{0}' , RCategory = '{1}', RLocation = '{2}', RCost='{3}', RRemarks = '{4}', Status ='{5}' where RId = '{6}'";
                Query = string.Format(Query, RName, RCat, RLoc, Cost, Rem, Status, RoomsGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room Updated!!!";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                RemarksTb.Value = "";


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
                string Query = "delete from RoomTbl where RId = {0}";
                Query = string.Format(Query, RoomsGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room Deleted Successfully !!!";
                RNameTb.Value = "";
                CatCb.SelectedIndex = -1;
                LocationTb.Value = "";
                CostTb.Value = "";
                RemarksTb.Value = "";
            }
            catch(Exception ex)
            {
                ErrMsg.InnerText=ex.Message;
            }

        }
    }
}