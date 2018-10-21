using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HeznekLaatid.model;
using HeznekLaatid.utils;

namespace HeznekLaatid
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

            var db = new HeznekDBE();
            int num = foreignKeys.Instance.getCityNumberByName("בית שאן");
            Label1.Text = Convert.ToString(num);

            /*
            var users = userLogic.Instance.getAllUsers().ToList();
            // Console.WriteLine("the users are" + users);
            if(users.Count > 1)
            {
                Label1.Text = "there are users in the table";
            }
            else
            {
                //Label1.Text = "there are just one user in the table";
                if(userLogic.Instance.getAllUsersFromSpecificCity("אופקים").Count != 0)
                {
                    Label1.Text = "True";
                }
            }*/
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
}