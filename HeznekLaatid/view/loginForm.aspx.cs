using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HeznekLaatid;


    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //UserData.getAllUsers();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
               if (TextBox1.Text != string.Empty)
               {
                   Button1.Text = "elinor";
               }
             //  ConnectionToDB db = new ConnectionToDB();
             */

            /* var studyField = new studyFieldTbl()
             {

                 field = "מדעי הרוח",
                 nameOfDegree = "Computer Science"
             };
             db.studyFieldTbl.Add(studyField);
             db.SaveChanges();*/

            //var db = new HeznekDBE();

            var users = UserData.getAllUsers().ToArray();
            //var users = userLogic.Instance.getAllUsersFromSpecificCity("אופקים").ToArray();
            int[] numbers = { 0, 1, 2 };
            int num = numbers[0];
            var a = users[0];
            Label1.Text = users[0].firstName + " " +  users[0].lastName;
        }

        protected void Button1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }
        
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
        

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }