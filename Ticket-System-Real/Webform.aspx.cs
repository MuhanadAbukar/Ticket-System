using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using DatabaseLayer;
namespace Ticket_System_Real
{
    public partial class Webform : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var DBL = new DBL();
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
            var ticketnr = DBL.generateTicket();
            var description = TicketDescription.Text;
            if (description.Length == 0)
            {
                TicketDescription.Text = "Du må skrive noe...";
                return;
            }
            DBL.sendEmail(TicketEmail.Text,"Support ticket "+ticketnr, "Thank you for creating a support ticket, your ticket ID is "+ticketnr);
            var author = TicketAuthor.Text;
            var email = TicketEmail.Text;
            var query = "insert into ticket values('" + ticketnr + "','" + description + "','" + TicketType.SelectedItem.Text + "','" + DateTime.Now.ToString("dd/MM/yy") + "','" + author + "','" + email + "',0)";
            DBL.writeToDB(query);
            Response.Redirect("redirectWhenCreated.aspx?TicketNR=" + ticketnr.ToString());
        }

        protected void TicketDescription_TextChanged(object sender, EventArgs e)
        {
            Label1.Text = TicketDescription.Text.Length + "/1000";
        }
    }
}



