﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Collections;
using HeznekLaatid.entities;

namespace HeznekLaatid
{
    class UserData

    {
    
        /* gets functions*/

        public static List<userTbl> getAllUsers()
            //give all the users in the table with no filter
        {
            using (var db = new HeznekDBE())
            {
                List<userTbl> users = db.userTbl.ToList();
                return users;
                

            }

        }

        public static List<userTbl> getAllStudents()
        {
            //give all the students in the table by their status
            using (var db = new HeznekDBE())
            {
                var query = (from userTbl in db.userTbl where (userTbl.status<=3) select userTbl);
                var students = query.ToList();
                return students;
            }
        }

        public static List<userTbl> getAllCandidates()
        {
            //give all the candidates in the table by their status
            using (var db = new HeznekDBE())
            {
                var query = (from userTbl in db.userTbl where (userTbl.status > 3
                             && userTbl.status < 6) select userTbl);
                var candidates = query.ToList();
                return candidates;
            }
        }

        public static List<userTbl> getAllUsersFromSpecificCity(String city)
        {
            //give all the users in the table that are from a specific city
            using (var db = new HeznekDBE())
            {
                //get the serial number of the specific city
                int sn = ForeignKeys.getCityNumberByName(city);

                var query = (from userTbl in db.userTbl
                             where (userTbl.cityNumber.Value == sn)
                             select userTbl);
                var users = query.ToList();
                return users;
            }

        }
       
        public static userTbl getSpecificUserById(char id)
        {
            //gets a specific user by Id(table key) from the list of users
            using (var db = new HeznekDBE())
            {
                List<userTbl> users = db.userTbl.ToList();
                
                foreach(var user in users)
                {
                    if(user.id.Equals(id))
                    {
                        return user;
                    }
                }
                return null;

            }

        } 
        
        public static ArrayList getSpecificUserByFn(String fn)
        {
            //filter users table by first name- get all the users with the same first name
            using (var db = new HeznekDBE())
            {
                List<userTbl> users = db.userTbl.ToList();
                ArrayList usersAL = new ArrayList();

                foreach (var user in users)
                {
                    if (user.firstName.Equals(fn))
                    {
                        usersAL.Add(user);
                    }
                }
                return usersAL;
            }
        }

        public static ArrayList getSpecificUserByLn(String ln)
        {
            //filter users table by last name- get all the users with the same last name
            using (var db = new HeznekDBE())
            {
                List<userTbl> users = db.userTbl.ToList();
                ArrayList usersAL = new ArrayList();

                foreach (var user in users)
                {
                    if (user.firstName.Equals(ln))
                    {
                        usersAL.Add(user);
                    }
                }
                return usersAL;
            }
        }


        

        /*updates functions*/

    }
}