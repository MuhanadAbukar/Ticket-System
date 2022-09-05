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
                
                var cmd = new SqlCommand("select * from ticket where ticketnr=" + ticketIDTextBox.Text, conn);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {

                    Label1.Text = "hi";
                    Button1.Text = "Invalid ticket ID.";
                    return;
                }
                Button1.Text = "Check ticket status";
            }
            catch (Exception)
            {
                Label1.Text = "hi";
                Button1.Text = "Invalid ticket ID.";
            }
            
            
        }
    }
}