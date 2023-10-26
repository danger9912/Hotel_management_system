using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Hotel_Management_System.Views.Users
{
    public partial class generatepdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                decimal totalAmount = 0;
                // Retrieve data from the "BookingTbl"
                DataTable bookingData = RetrieveDataFromBookingTbl();

                // Create a new PDF document
                Document doc = new Document();
                MemoryStream memStream = new MemoryStream();

                // Use PdfWriter to write the PDF content to a stream
                PdfWriter writer = PdfWriter.GetInstance(doc, memStream);
                doc.Open();

                // Set table properties
                PdfPTable table = new PdfPTable(bookingData.Columns.Count);
                table.WidthPercentage = 100;
                table.DefaultCell.BackgroundColor = BaseColor.LIGHT_GRAY; // Background color
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER; // Text alignment

                PdfPCell cell = new PdfPCell(new Phrase("Booking Data"));
                cell.Colspan = bookingData.Columns.Count;
                cell.BackgroundColor = BaseColor.MAGENTA; // Title cell background color
                cell.HorizontalAlignment = Element.ALIGN_CENTER; // Title cell text alignment
                cell.Phrase.Font.Color = BaseColor.WHITE; // Title cell text color
                table.AddCell(cell);

                // Add table headers
                foreach (DataColumn column in bookingData.Columns)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName));
                    headerCell.BackgroundColor = BaseColor.BLUE; // Header cell background color
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER; // Header cell text alignment
                    headerCell.Phrase.Font.Color = BaseColor.WHITE; // Header cell text color
                    table.AddCell(headerCell);
                }

                // Add table rows
                foreach (DataRow row in bookingData.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        if (item is DateTime dateValue)
                        {
                            // Format the date as "dd-MM-yyyy" (you can change the format as needed)
                            PdfPCell dataCell = new PdfPCell(new Phrase(dateValue.ToString("dd-MM-yyyy")));
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER; // Data cell text alignment
                            table.AddCell(dataCell);
                        }
                        else if (item is Decimal amountValue)
                        {
                            // If the item is a decimal (assuming the column is "Amount")
                            PdfPCell dataCell = new PdfPCell(new Phrase(amountValue.ToString()));
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER; // Data cell text alignment
                            table.AddCell(dataCell);

                            // Add the amount to the total
                            totalAmount += amountValue;
                        }
                        else
                        {
                            PdfPCell dataCell = new PdfPCell(new Phrase(item.ToString()));
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER; // Data cell text alignment
                            table.AddCell(dataCell);
                        }
                    }
                }
                PdfPCell totalAmountCell = new PdfPCell(new Phrase($"Total Amount: {totalAmount}"));
                totalAmountCell.Colspan = bookingData.Columns.Count;
                totalAmountCell.HorizontalAlignment = Element.ALIGN_RIGHT; // Right-align the total amount
                table.AddCell(totalAmountCell);
                doc.Add(table);
              

                doc.Close();

                // Generate a PDF file
                byte[] pdfBytes = memStream.ToArray();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=BookingData.pdf");
                Response.OutputStream.Write(pdfBytes, 0, pdfBytes.Length);
                Response.Flush();
                Response.End();
            }

        }
        private DataTable RetrieveDataFromBookingTbl()
        {
            // Replace with your database connection and query logic to fetch data from the "BookingTbl"
            DataTable bookingData = new DataTable();

            // Example connection and query:
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Shubham\\Documents\\HotelAsp.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM BookingTbl WHERE Agent = @UserId;", connection))
                {
                    command.Parameters.AddWithValue("@UserId",Session["UId"] as string);
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