﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
namespace Ticket_System_Real
{
    public partial class Webform : System.Web.UI.Page
    {
        void sendTicketEmail(string toEmail,string ticketID)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("glemmenvgsticket@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Your support ticket";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "<h1> Thanks for making a support ticket. Your ticket id is: "+ticketID+" </h1>" };
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
            var validator = new EmailAddressAttribute();
            if(TicketEmail.Text.Length == 0 || !validator.IsValid(TicketEmail.Text))
            {
                TicketEmail.Text = "Invalid email";
                return;
            }
            var ticketnr = "";
            var w = new List<string>();
            w.Add("1234567890");
            w.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            w.Add("abcdefghijklmnopqrstuvwxyz");
            var len = 9;
            var r = new Random();
            var ut = "";
            for (int i = 0; i < len; i++)
            {
                try
                {
                    var chosen = w.ToArray()[r.Next(0, w.Count)];
                    ut += chosen[r.Next(0, chosen.Length)];
                }
                catch (Exception) { };
            }
            ticketnr = ut;
            SqlConnection conn = new SqlConnection(connectionString);
            var description = TicketDescription.Text;
            if (description.Length == 0)
            {
                TicketDescription.Text = "Du må skrive noe...";
                return;
            }
            sendTicketEmail(TicketEmail.Text, ticketnr);
            var author = TicketAuthor.Text;
            conn.Open();
            var cmd2 = new SqlCommand("insert into ticket values('" + ticketnr + "','" + description + "','" + TicketType.SelectedItem.Text + "','" + DateTime.Now.ToString("dd/MM/yy") + "','" + author + "',0)", conn); ;
            cmd2.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("redirectWhenCreated.aspx?TicketNR=" + ticketnr.ToString());


        }
    }
}



