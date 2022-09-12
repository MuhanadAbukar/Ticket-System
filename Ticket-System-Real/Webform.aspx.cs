using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
namespace Ticket_System_Real
{
    public partial class Webform : System.Web.UI.Page
    {
        void sendTicketEmail(string toEmail, string ticketID)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("glemmenvgsticket@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Support ticket " + ticketID;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "<h1> Thank you for creating a ticket, your ticket ID is: " + ticketID + " </h1>" };
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("glemmenvgsticket@gmail.com", "fmaonjofxuftpopf");
            smtp.Send(email);
        }
        string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TicketDescription.Text.Length > 1000)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Description is too long, please shorten it')", true);
                return;
            }
            var validator = new EmailAddressAttribute();
            if (!validator.IsValid(TicketEmail.Text))
            {
                TicketEmail.Text = "Invalid email";
                return;
            }
            var ticketnr = "";
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
            ticketnr = generatedTicket;
            SqlConnection conn = new SqlConnection(connectionString);
            var description = TicketDescription.Text;
            if (description.Length == 0)
            {
                TicketDescription.Text = "Du må skrive noe...";
                return;
            }
            sendTicketEmail(TicketEmail.Text, ticketnr);
            var author = TicketAuthor.Text;
            var email = TicketEmail.Text;
            conn.Open();
            try
            {
                var cmd2 = new SqlCommand("insert into ticket values('" + ticketnr + "','" + description + "','" + TicketType.SelectedItem.Text + "','" + DateTime.Now.ToString("dd/MM/yy") + "','" + author + "','"+email+"',0)", conn); ;
                cmd2.ExecuteNonQuery();

            }
            catch (Exception)
            {
                var ut2 = "";
                for (int i = 0; i < len; i++)
                {
                    try
                    {
                        var chosen = ticketGenerator.ToArray()[r.Next(0, ticketGenerator.Count)];
                        ut2 += chosen[r.Next(0, chosen.Length)];
                    }
                    catch (Exception) { };
                }
                var cmd2 = new SqlCommand("insert into ticket values('" + ut2 + "','" + description + "','" + TicketType.SelectedItem.Text + "','" + DateTime.Now.ToString("dd/MM/yy") + "','" + author + "',0)", conn); ;
                cmd2.ExecuteNonQuery();
            }

            conn.Close();
            Response.Redirect("redirectWhenCreated.aspx?TicketNR=" + ticketnr.ToString());


        }

        protected void TicketDescription_TextChanged(object sender, EventArgs e)
        {
            Label1.Text = TicketDescription.Text.Length + "/1000";
        }
    }
}



