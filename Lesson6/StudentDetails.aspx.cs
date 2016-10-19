using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lesson6.Models;
using System.Web.ModelBinding;

namespace Lesson6
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //redirect back tot he students page
            Response.Redirect("~/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // use ef to connect to server
            using (ContosoContext db = new ContosoContext())
            {
                //use the student model to create a new student object and
                //save a new record

                Student newStudent = new Student();

                int StudentID = 0;

                if (Request.QueryString.Count > 0)
                //our URL has a STUDENTID in it
                {
                    //get the id from the url
                }

                //add form data to the new student record
                newStudent.LastName = LastNameTextbox.Text;
                newStudent.FirstMidName = FirstNameTextbox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextbox.Text);

                // use LINQ to ADO.NET to add / insert new student into db
                if (StudentID == 0)
                {
                    db.Students.Add(newStudent);
                }

                //savee our changes - also updates and inserts
                db.SaveChanges();

                //redirect back to students page
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}