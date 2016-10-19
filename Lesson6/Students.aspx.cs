using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are required to connect to EF DB
using Lesson6.Models;
using System.Web.ModelBinding;

namespace Lesson6
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if im loading the page for the first time
            //populate student grid
            if (!IsPostBack)
            {
                //get the student data
                this.GetStudents();
            }
        }

        /// <summary>
        /// This method gets the student data from db
        /// </summary>

        private void GetStudents()
        {
            //connect to EF DB
            using (ContosoContext db = new ContosoContext())
            {
                //query the student table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                //bind the result to the Students GridView
                StudentsGridView.DataSource = Students.ToList();
                StudentsGridView.DataBind();
            }
        }

        protected void StudentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //store which row was clicked
            int selectedRow = e.RowIndex;

            //get the selected StudentID using the grids DataKey collection
            int StudentID = Convert.ToInt32(StudentsGridView.DataKeys[selectedRow].Values["StudentID"]);

            //use EF and Ling to fidn the selected student in the db and remove it
            using (ContosoContext db = new ContosoContext())
            {
                //create and object of the student class and store th query  inside of it
                Student deletedStudent = (from studentRecords in db.Students
                                          where studentRecords.StudentID == StudentID
                                          select studentRecords).FirstOrDefault();
                //remove the selected student from the db
                db.Students.Remove(deletedStudent);

                //save my changes back tot he database
                db.SaveChanges();

                //refresh the grid
                this.GetStudents();
            }

        }
    }
}