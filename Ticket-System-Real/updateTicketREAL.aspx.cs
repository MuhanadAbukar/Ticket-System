using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Ticket_System_Real
{
    public partial class updateTicketREAL : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                var cmd = new SqlCommand("select * from ticket where ticketnr = '" + Request.QueryString["TicketNR"]+"'", conn);
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}