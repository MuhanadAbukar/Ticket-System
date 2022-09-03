using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

namespace Ticket_System_Real
{
    public partial class Login : System.Web.UI.Page
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

        protected void Register_Click(object sender, EventArgs e)
        {
            var user = username.Text;
            var pass = password.Text;

            if (pass.Length > 15 || pass.Length < 5)
            {
                Label1.Text = "Password length should be between 5 and 15.";
                return;
            }
            else if(!pass.Any(c=>Char.IsDigit(c)))
            {
                Label1.Text = "Password should contain at least 1 number";
                return;
                
            }
            else
            {
                var userid = -1;
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select max(userid) from users", conn);
                var exec = cmd.ExecuteReader();
                exec.Read();
                userid = int.Parse(exec[0].ToString()) + 1;
                conn.Close();
                conn.Open();
                var ip = GetIPAddress();
                Label1.Text = "hi";
                var cmd3 = new SqlCommand("select uIP from users where uIP = '"+ip+"'", conn);
                var reader1 = cmd3.ExecuteReader();
                reader1.Read();
                GridView1.DataSource = reader1;
                GridView1.DataBind();
                Label1.Text = GridView1.SelectedRow.Cells[1].ToString();
                conn.Close();
                conn.Open();
                var cmd2 = new SqlCommand("insert into users values("+userid+ ",'" + user+ "','" + pass+ "','" + ip+ "')", conn); 
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}