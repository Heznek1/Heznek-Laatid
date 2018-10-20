using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using HeznekLaatid.model;

namespace HeznekLaatid
{
    class userLogic
    {
                             /* gets functions*/

        public List<userTbl> getAllUsers()
            //give all the users in the table with no filter
        {
            using (var db = new HeznekDBE())
            {
                List<userTbl> users = db.userTbl.ToList();
                return users;

            }

        }

        public List<userTbl> getAllStudents()
        {
            //give all the students in the table by their status
            using (var db = new HeznekDBE())
            {
                var query = (from userTbl in db.userTbl where (userTbl.status<=3) select userTbl);
                var students = query.ToList();
                return students;
            }
        }

        public List<userTbl> getAllCandidates()
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

                                /*updates functions*/
                               
    }
}
