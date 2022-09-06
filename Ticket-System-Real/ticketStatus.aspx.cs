using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            try
            {
                
                var cmd = new SqlCommand("select * from ticket where ticketnr='" + ticketIDTextBox.Text+"'", conn);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {

                    Button1.Text = "Invalid ticket ID.";
                    return;
                }
                Button1.Text = "Check ticket status";
                Description.Text = GridView1.Rows[0].Cells[1].Text;
                var status = GridView1.Rows[0].Cells[5].Text;
                Date.Text = GridView1.Rows[0].Cells[3].Text;
                Author.Text = GridView1.Rows[0].Cells[4].Text;
                if(status == "0")
                {
                    Status.Text = "Ikke startet";
                }
                else if(status == "1")
                {
                    Status.Text = "Startet å jobbe med den";
                }
                else if(status == "2")
                {
                    Status.Text = "Fikset";
                }
            }
            catch (Exception)
            {
                Button1.Text = "Invalid ticket ID.";
            }
            
            
        }
    }
}