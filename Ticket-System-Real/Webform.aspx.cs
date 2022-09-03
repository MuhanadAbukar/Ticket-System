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
        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
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
            conn.Close();
            conn.Open();
            var description = TicketDescription.Text;
            if(description.Length == 0)
            {
                TicketDescription.Text = "Du må skrive noe...";
                return;
            }

            var author = TicketAuthor.Text;
            
            var cmd2 = new SqlCommand("insert into ticket values(" + ticketnr + ",'" + description + "','" + TicketType.SelectedItem.Text+"','"+ DateTime.Now.ToString("dd/MM/yy") + "','"+author+"',0)", conn); ;
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
    }
}



