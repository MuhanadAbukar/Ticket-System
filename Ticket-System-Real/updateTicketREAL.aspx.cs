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
                DBL.bindReaderToGridView(reader, GridView1);
                
            }
        }
    }
}