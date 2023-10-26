
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel_Management_System.Models;
using Hotel_Management_System.Views.Admin;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Hotel_Management_System.Views.Users
{
    public partial class Booking : System.Web.UI.Page
    {
        Functions Con;

        string ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();

            ShowRooms();
            ShowBookings();


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
                    string St = "Available";
                    string query = "select RId as Id,RName as RoomName,RLocation as RoomLocation,RCost as Cost ,Status from RoomTbl where Status = '"+St+"'";
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
        private void ShowBookings()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    connection.Open();
                    string St = "Available";
                    string query = "SELECT * FROM BookingTbl WHERE Agent = '" + Session["UId"] + "';";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        BookingGV.DataSource = dt;
                        BookingGV.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                ErrMsg.InnerHtml = "An error occurred: " + ex.Message;
            }

        }
        int key = 0;
        int Days = 1;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RoomTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            int Cost = Days * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
            AmountTb.Value = Cost.ToString();
        }
        private void UpdateRoom()
        {
            try
            {
                string st = "Booked";

                string Query = "update RoomTbl set Status = '{0}' where RId = {1}";
                Query = string.Format(Query, st,RoomsGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowRooms();
             
        
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        int TCost = 0;
        private void GetCost()
        {
            DateTime DIn = Convert.ToDateTime(DateInTb.Value);
            DateTime Dout = Convert.ToDateTime(DateOutTb.Value);
            TimeSpan value = Dout.Subtract(DIn);
            TCost = Convert.ToInt32(value.ToString().Substring(0,2)) * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
            AmountTb.Value=TCost.ToString();

        }
        protected void BookBtn_Click(object sender, EventArgs e)
        {
            string RId = RoomsGV.SelectedRow.Cells[1].Text;
            DateTime BDate = DateTime.Today;
            string InDate = DateInTb.Value.ToString();
            string OutDate = DateOutTb.Value.ToString();
            string Agent = Session["UId"] as string;
            int Amount = Convert.ToInt32(AmountTb.Value.ToString());
            Console.WriteLine("RId: " + RId);
            Console.WriteLine("BDate: " + BDate.ToString());
            Console.WriteLine("InDate: " + InDate);
            Console.WriteLine("OutDate: " + OutDate);
            Console.WriteLine("Agent: " + Agent);
            Console.WriteLine("Amount: " + Amount);
            try
            {
                

                if (Agent == null)
                {
                   
                    ErrMsg.InnerText = "No User is Login";

                }
                else
                {
                    GetCost();
                    string Query = "INSERT INTO BookingTbl (BDate, BRoom, Agent, DateIn, DateOut, Amount) VALUES (@BDate, @BRoom, @Agent, @DateIn, @DateOut, @Amount)";

                    using (SqlConnection connection = new SqlConnection(ConStr))
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(Query, connection))
                        {
                            cmd.Parameters.AddWithValue("@BDate", BDate);
                            cmd.Parameters.AddWithValue("@BRoom", RId);
                            cmd.Parameters.AddWithValue("@Agent", Agent);
                            cmd.Parameters.AddWithValue("@DateIn", InDate);
                            cmd.Parameters.AddWithValue("@DateOut", OutDate);
                            cmd.Parameters.AddWithValue("@Amount", Amount);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    UpdateRoom();
                    ShowRooms();

                    ErrMsg.InnerText = "Room Booked!!!";
                    ShowBookings();
                    RoomTb.Value = "";
                    AmountTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            RoomTb.Value = "";
            AmountTb.Value = "";
        }
       

protected void GeneratePDFButton_Click(object sender, EventArgs e)
    {
        Document doc = new Document();
        string pdfFilePath = Server.MapPath("Booking.pdf"); // Adjust the file path as needed

        try
        {
            PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
            doc.Open();

            // Add content to the PDF
            Paragraph paragraph = new Paragraph("This is a sample PDF generated from your booking data.");
            doc.Add(paragraph);

            // You can add more content as needed

            // Close the document
            doc.Close();

            // Provide a download link for the generated PDF
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Booking.pdf");
            Response.TransmitFile(pdfFilePath);
            Response.Flush();
        }
        catch (Exception ex)
        {
            ErrMsg.InnerText = "An error occurred while generating the PDF: " + ex.Message;
        }
    }
        private DataTable RetrieveDataFromBookingTbl()
        {
            // Replace with your database connection and query logic to fetch data from the "BookingTbl"
            DataTable bookingData = new DataTable();

            // Example connection and query:
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM BookingTbl", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(bookingData);
                    }
                }
            }
          
            return bookingData;
        }

    }
}