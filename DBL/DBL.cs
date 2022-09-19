using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.UI.WebControls;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
namespace DatabaseLayer
{
    public class DBL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        public string generateTicket()
        {
            var ticketGenerator = new List<string>();
            ticketGenerator.Add("1234567890");
            ticketGenerator.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            ticketGenerator.Add("abcdefghijklmnopqrstuvwxyz");
            var len = 9;
            var r = new Random();
            var generatedTicket = "";
            for (int i = 0; i < len; i++)
            {
                try
                {
                    var chosen = ticketGenerator.ToArray()[r.Next(0, ticketGenerator.Count)];
                    generatedTicket += chosen[r.Next(0, chosen.Length)];
                }
                catch (Exception) { };
            }
            return generatedTicket;
        }
        public void writeToDB(string query)
        {

            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable getReader(string query)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand(query, conn);
            var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            conn.Close();
            return dt;
            
        }
        public void bindToGridView(DataTable dt, GridView gridview1)
        {
            gridview1.DataSource = dt;
            gridview1.DataBind();
        }
        public void sendEmail(string toEmail, string header, string message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("glemmenvgsticket@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = header;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "<h1> " + message + " </h1>" };
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("glemmenvgsticket@gmail.com", "fmaonjofxuftpopf");
            smtp.Send(email);
        }
        public void editColumn(string key, string keyname, string values, string tablename)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand($"update {tablename} set {values} where {keyname} = {key}", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
