using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ticket_System_Real
{
    public partial class Webform : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var ticketnr = -1;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select max(ticketnr) from ticket", conn);
            var exec = cmd.ExecuteReader();
            exec.Read();
            ticketnr = int.Parse(exec[0].ToString()) + 1;
            exec.Close();
            conn.Close();
            var description = TicketDescription.Text;
            if(description.Length == 0)
            {
                TicketDescription.Text = "Du må skrive noe...";
                return;
            }

            var author = TicketAuthor.Text;
            conn.Open();
            var cmd2 = new SqlCommand("insert into ticket values(" + ticketnr + ",'" + description + "','" + TicketType.SelectedItem.Text+"','"+ DateTime.Now.ToString("dd/MM/yy") + "','"+author+"',0)", conn); ;
            cmd2.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("redirectWhenCreated.aspx?TicketNR="+ticketnr.ToString());


        }
    }
}



