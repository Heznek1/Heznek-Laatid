using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeznekLaatid
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TODO: noam: fsdkfjsdflsdflk
            if (TextBox1.Text != string.Empty)
            {
                Button1.Text = "elinor";
            }
            ConnectionToDB db = new ConnectionToDB();
         
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