using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HeznekLaatid;
using HeznekLaatid.entities;
using HeznekLaatid.model;


public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }

    protected void Button1_Click(object sender, EventArgs e)
    {

        using (var db = new HeznekDB())
        {
            List<loginAndPermissions> usersLogin = LoginData.getLoginList();
            string id = TextBox1.Text;
            string pass = TextBox2.Text;
            foreach (var loginObject in usersLogin)
            {
               /* if(string.IsNullOrEmpty(id))
                {
                    Label1.Text = "אנא הזן שם משתמש וסיסמא ";

                }*/
                if (id.Equals(loginObject.id) &&
                    pass.Equals(loginObject.password))
                {
                    if (Label1.Visible == false)
                    {
                        Label1.Visible = true;
                    }
                    Label1.Text = "ברוך הבא, " + ForeignKeys.getUserConnectedByID(id).firstName;
                }
                else
                {
                    if (Label1.Visible == false)
                    {
                        Label1.Visible = true;
                    }
                    Label1.Text = " שם משתמש או סיסמא אינם נכונים, נסה שוב";
                }
            }
         
        }
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