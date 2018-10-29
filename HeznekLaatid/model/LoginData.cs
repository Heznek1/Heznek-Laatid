using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeznekLaatid.entities;

namespace HeznekLaatid.model
{
    public class LoginData
    {
        public static List<loginAndPermissions> getLoginList()
        //give all the registered users to system in the table with no filter
        {
            using (var db = new HeznekDB())
            {
                List<loginAndPermissions> usersRegistered = db.loginAndPermissions.ToList();
                return usersRegistered;
            }
        }
        
        public static List<userTbl> getAllUsersByType(int numType)
        {
            List<loginAndPermissions> usersLogin = getLoginList();
            List<userTbl> users = new List<userTbl>();
            foreach(var user in usersLogin)
            {
                if(user.userType == numType)
                {
                    userTbl userToList = ForeignKeys.getUserConnectedByID(user.id);
                    users.Add(userToList);
                }
            }
            return users;
        }
    }
}