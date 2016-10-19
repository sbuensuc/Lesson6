﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;


namespace Lesson6
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //chekc if a user is checked in
                if(HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //show the contoso content area
                    ContosoPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                }
                else
                {
                    //only login and register
                    ContosoPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                }
            }
            SetActivePage();
        }

        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home":
                    home.Attributes.Add("class", "active");
                    break;
                case "Courses":
                    courses.Attributes.Add("class", "active");
                    break;
                case "Students":
                    students.Attributes.Add("class", "active");
                    break;
                case "Departments":
                    departments.Attributes.Add("class", "active");
                    break;
                case "About":
                    about.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}