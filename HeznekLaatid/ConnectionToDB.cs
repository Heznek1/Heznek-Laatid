using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeznekLaatid
{
    public class ConnectionToDB
    {
        public ConnectionToDB()
        {
            SqlConnection a = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            a.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into scholarship values('dsfs',588,'sdfds','Active')", a);
            int numOfRows = sqlCommand.ExecuteNonQuery();
            a.Close();
        }
       
    }
}