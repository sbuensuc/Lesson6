using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//requiered for Idenitiy and Owin security

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Lesson6
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // create a new userstore and usermanager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //search for and create a new user object

            var user = new IdentityUser()
            {
                UserName = UserNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };
            //create a new user in the db and store results

            IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

            //check if successfully registered
            if(result.Succeeded)
            {
                //authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // sign in the user
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                Response.Redirect("~/Contoso/MainMenu.aspx");
            }
            else
            {
                //display error in alertflash div
                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }
        }
    }
}