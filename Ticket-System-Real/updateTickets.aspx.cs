using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
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
                var cmd = new SqlCommand("select ticketnr,tickettype,ticketdate from ticket order by ticketdate", conn);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        
        protected void Row_Selected(object sender, EventArgs e)
        {
            //Get the Button reference.
            Button btnSelect = (sender as Button);

            //Get the Command Name.
            string commandName = btnSelect.CommandName;

            //Get the Command Argument.
            string commandArgument = btnSelect.CommandArgument;

            //Get the Row reference in which Button was clicked.
            GridViewRow row = (btnSelect.NamingContainer as GridViewRow);

            //Get the Row Index.
            int rowIndex = row.RowIndex;
            Label1.Text = commandName;
        }
    }
}