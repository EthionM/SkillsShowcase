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
                BindRepeater();

            }
        }

        protected void rptDoneTasks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl div = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("divRepeaterTask");
            div.Attributes.CssStyle.Clear();
            HiddenField hdn = (HiddenField)e.Item.FindControl("hdnDone");
            bool Done = hdn.Value == "True";
            div.Attributes["class"] = Done ? "TaskDone" : "TaskPending";
            ((System.Web.UI.HtmlControls.HtmlTableRow)e.Item.FindControl("trDescription")).Attributes["style"] = "display:" + (Done ? "none" : "block");
            ((ImageButton)e.Item.FindControl("btnMarkDone")).Visible = !Done;
        }

        protected void rptDoneTasks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "MarkAsDone")
            {
                Data.Tasks task = new Data.Tasks();
                task.IdTask = Convert.ToInt32(e.CommandArgument);
                task.DateFinished = DateTime.Now;
                task.MarkDone();
                BindRepeater();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Data.Tasks task = new Data.Tasks();
            task.Username = Context.User.Identity.GetUserName();
            task.Title = txtTitle.Text;
            task.Description = txtDescription.Text;
            task.DateAdded = DateTime.Now;
            task.Insert();
            BindRepeater();
        }

        protected void BindRepeater()
        {
            rptDoneTasks.DataSource = new Data.Tasks().GetTasksForToDoView(Context.User.Identity.GetUserName());
            rptDoneTasks.DataBind();
        }
    }
}