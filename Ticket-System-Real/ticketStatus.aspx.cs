using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;
namespace Ticket_System_Real
{

    public partial class ticketStatus : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                var DBL = new DBL();
                var query = "select * from ticket where ticketnr='" + ticketIDTextBox.Text + "'";
                Button1.Text = query;
                var reader = DBL.getReader(query);
                DBL.bindReaderToGridView(reader, GridView1);
                
                if (GridView1.Rows.Count == 0)
                {

                    return;
                }
                Button1.Text = "Check ticket status";
                Description.Text = GridView1.Rows[0].Cells[1].Text;
                var status = GridView1.Rows[0].Cells[5].Text;
                Date.Text = GridView1.Rows[0].Cells[3].Text;
                Author.Text = GridView1.Rows[0].Cells[4].Text;
                if (status == "0")
                {
                    Status.Text = "Ikke startet";
                }
                else if (status == "1")
                {
                    Status.Text = "Startet å jobbe med den";
                }
                else if (status == "2")
                {
                    Status.Text = "Fikset";
                }
            }
            catch (Exception)
            {
            }


        }
    }
}