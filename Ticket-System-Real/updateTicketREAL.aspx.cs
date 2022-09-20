using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DatabaseLayer;
namespace Ticket_System_Real
{
    public partial class updateTicketREAL : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var DBL = new DBL();
                var query = "select * from ticket where ticketnr = '" + Request.QueryString["TicketNR"] + "'";
                var reader = DBL.getReader(query);
                DBL.bindToGridView(reader, GridView1);

            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            var DBL = new DBL();
            var index = DropDownList1.SelectedIndex;
            var key = Request.QueryString["TicketNR"];
            var name = "ticketnr";
            var values = $"ticketstatus = {index}";
            var tablename = "ticket";
            var email = Request.QueryString["email"];
            string[] ticketmessages = { "started", "in progress.", "resolved." };
            DBL.editColumn($"'{key}'", name, values, tablename);
            Label1.CssClass = "TextBox23";
            Label1.Text = $"Successfully updated ticket status of ticket {key}";
            DBL.sendEmail(email, "Ticket status has been updated.", $"Your ticket {key} has been updated. \n Status: "+ $"{ticketmessages[index]}.");
        }
    }
}