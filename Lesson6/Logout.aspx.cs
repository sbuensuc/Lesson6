using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Lesson6
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // store session info and authentication methods in the authenticationmanager object
            var autheticationManager = HttpContext.Current.GetOwinContext().Authentication;

            //perform sign out
            autheticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}