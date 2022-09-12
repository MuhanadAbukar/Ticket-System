using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ticket_System_Real
{
    public partial class updateTickets : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                var cmd = new SqlCommand("select ticketnr,tickettype,ticketdate from ticket where ticketstatus != 2 order by ticketdate", conn);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Row_Selected(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string ticketNR = btn.CommandName;
            Response.Redirect("updateTicketREAL.aspx?TicketNR="+ ticketNR);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}