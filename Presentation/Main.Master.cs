﻿using System;

namespace Presentation
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LBProviders_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFProviders.aspx");
        }

        protected void LBDriver_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFDriver.aspx");
        }

        protected void LBSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("WFSend.aspx");
        }
    }
}