using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SkillsShowcase.Data;
using Microsoft.AspNet.Identity;

namespace SkillsShowcase.Tasks
{
    public partial class Done : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!Context.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login");
                }
            }
            rptDoneTasks.DataSource = new Data.Tasks().GetTasksByUser(Context.User.Identity.GetUserName(), true);
            rptDoneTasks.DataBind(); 

        }

    }
}