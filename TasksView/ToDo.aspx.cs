using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkillsShowcase.Tasks
{
    public partial class ToDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Context.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login");
                }
            }
        }
    }
}