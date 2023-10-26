using Hotel_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management_System.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Functions Con;

        string ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();
            Session["UserName"] = "";
            Session["UId"] = "";

        }


        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            
            if (AdminCb.Checked)
            {
                if(UserTb.Value == "Admin" && PasswordTb.Value == "Password")
                {
                    Session["UserName"] = "Admin";
                    Response.Redirect("Admin/Rooms.aspx");
                }
                else
                {
                    ErrMsg.InnerText = "InValid Admin!!";

                }
            }
            else
            {
                string Query = "Select UId,UName,UPass from UserTbl where UName='{0}' and UPass='{1}'";
                Query=string.Format(Query,UserTb.Value,PasswordTb.Value);
                DataTable dt = Con.GetData(Query);
                if(dt.Rows.Count == 0) {
                    ErrMsg.InnerText = "InValid User!!!";
                }
                else
                {
                    Session["UserName"] = dt.Rows[0][1].ToString();
                    Session["UId"] = dt.Rows[0][0].ToString();
                    Response.Redirect("Users/Booking.aspx");
                }
               
            }
           

          
        }
    }
}