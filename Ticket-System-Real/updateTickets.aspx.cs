using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseLayer;
namespace Ticket_System_Real
{
    public partial class updateTickets : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!Page.IsPostBack)
            {
                var DBL = new DBL();
                var query = "select ticketnr,tickettype,ticketdate from ticket where ticketstatus != 2 order by ticketdate";
                var reader = DBL.getReader(query);
                DBL.bindReaderToGridView(reader, GridView1);
                
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