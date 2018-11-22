using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using HeznekLaatid.entities;
using System.Collections;

namespace HeznekLaatid
{
    class ForeignKeys
    {
        public static int getCityNumberByName(String city)
        {

            using (var db = new HeznekDB())
            {
                int cityNum = 0;
                var query = (from cityTbl in db.cityTbl
                             where (cityTbl.city.Equals(city))
                             select cityTbl.sn);
                try
                {
                    cityNum = query.ToArray().Last();

                }
                catch
                {
                    return 0;
                }
                return cityNum;

            }
        }

        public static int getInstitutionNumberByName(String institue)
        {

            using (var db = new HeznekDB())
            {
                int instituteNum = 0;
                var query = (from academicInstitutTbl in db.academicInstitutTbl
                             where (academicInstitutTbl.nameOfInstitut.Equals(institue))
                             select academicInstitutTbl.sn);
                try
                {
                    instituteNum = query.Last();

                }
                catch
                {
                    return 0;
                }
                return instituteNum;

            }
        }

        public static int getnumberOfFieldByName(String field)
        {
            int fieldNum = 0;
            using (var db = new HeznekDB())
            {
                var query = (from studyFieldTbl in db.studyFieldTbl
                             where (studyFieldTbl.field.Equals(field))
                             select studyFieldTbl.sn);
                try
                {
                    fieldNum = query.Last();

                }
                catch
                {
                    return 0;
                }
                return fieldNum;

            }
        }

        public static userTbl getUserConnectedByID(string id)
        {
            List<userTbl> users = UserData.getAllUsers();
            foreach (var user in users)
            {
                if (user.id.Equals(id))
                {
                    return user;
                }
            }
            return null;
        }


        /// <Summary>
        /// Cross tables - get all the candidates and search them by id(foreign key) in all
        /// users table(id primary key there)
        /// </Summary>
        public static List<userTbl> getAllCandidatesDetails()
        {
            List<generalDetailsActiveCandidate> candidates = UserData.getCandidatesGenralDetails();
            List<userTbl> allUsers = UserData.getAllUsers();
            List<userTbl> candidateUsers = new List<userTbl>();

            foreach (var candidate in candidates)
            {
                foreach (var user in allUsers)
                {
                    if (candidate.idCandidate.Equals(user))
                         candidateUsers.Add(user);        
                }
            }
            return candidateUsers;//return a list of the full details of the candidates
        }
    }
}