using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ticket_System_Real
{
    public partial class redirectWhenCreated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Ticketnr.Text = "Thank you for creating a ticket, your ticket ID is: "+Request.QueryString["TicketNR"].ToString();
            }
            catch(Exception) { Ticketnr.Text = "No ticket created recently"; }
        }
        

    }
}