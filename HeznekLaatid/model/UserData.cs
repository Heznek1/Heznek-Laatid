using System;
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
        /// <Summary>
        /// retrieval from DB all the users(scholarships student and candidates)
        /// </Summary>
        public static List<userTbl> getAllUsers()
        {
            using (var db = new HeznekDB())
            {
                List<userTbl> users = db.userTbl.ToList();
                return users;
            }
        }


        /// <Summary>
        /// give all the users in the table with the same status
        /// </Summary>
        public static ArrayList getUsersByStatus(int status)
        {  
            List<userTbl> users = getAllUsers();
            ArrayList usersAL = new ArrayList();

                foreach(var user in users)
                {
                    if(user.status == status)
                    {
                        usersAL.Add(user);
                    }
                }
                return usersAL;      
        }

        /// <Summary>
        /// give all the scholarships students in the table(no matter what is their secondary status)
        /// </Summary>
        public static ArrayList getAllScholarshipsStudents()
        {
           
            using (var db = new HeznekDB())
            {
                List<userTbl> users = getAllUsers();
                ArrayList usersAL = new ArrayList();

                foreach(var user in users)
                {
                    if (user.status < 3)
                        usersAL.Add(user);
                }
                return usersAL;
            }
        }
        /// <Summary>
        /// give all chosen users in the table that are from a specific city
        /// </Summary>
        public static List<userTbl> getAllChosenUsersFromSpecificCity(List<userTbl> usersList,String city)
        {
                //get the serial number of the specific city
                int sn = ForeignKeys.getCityNumberByName(city);
                List<userTbl> users = usersList;
                ArrayList usersAL = new ArrayList();

                foreach(var user in users)
                {
                    if(user.cityNumber == sn)
                    {
                        usersAL.Add(user);
                    }
                }
                return users;
           
        }

        /// <Summary>
        /// gets a specific user by Id(primary key) from the list of users that i get as a parameter
        /// </Summary>
        public static userTbl getSpecificUserById(char id, List<userTbl> usersList)
        {
            List<userTbl> users = usersList;

                foreach (var user in users)
                {
                    if(user.id.Equals(id))
                    {
                        return user;
                    }
                }
                return null;       
        }
      
        /// <Summary>
        /// get users with the same first name from a list of chosen users
        /// </Summary>   
        public static ArrayList getSpecificUsersByFn(List<userTbl> usersList,String fn)
        {
            List<userTbl> users = usersList;
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

        /// <Summary>
        /// get users with the same last name from a list of chosen users
        /// </Summary>   
        public static ArrayList getSpecificUsersByLn(List<userTbl> usersList,String ln)
        {    
                List<userTbl> users = usersList;
                ArrayList usersAL = new ArrayList();

                foreach (var user in users)
                {
                    if (user.lastName.Equals(ln))
                    {
                        usersAL.Add(user);
                    }
                }
            return usersAL;          
        }

        /// <Summary>
        /// get users with the same full name from a list of chosen users
        /// </Summary>
        public static ArrayList getSpecificUserByFullName(List<userTbl> usersList, String fullName)
        {   
            List<userTbl> users = usersList;
            ArrayList usersAL = new ArrayList();

                foreach (var user in users)
                {
                    if ((user.firstName + user.lastName).Equals(fullName))
                    {
                        usersAL.Add(user);
                    }
                }
                return usersAL;   
        }

        /// <Summary>
        /// get all active candidates(from genral details candidates table)
        /// </Summary>
        public static List<generalDetailsActiveCandidate> getCandidatesGenralDetails()
        {
            using (var db = new HeznekDB())
            {
                List<generalDetailsActiveCandidate> users = db.generalDetailsActiveCandidate.ToList();
                return users;
            }
        }
        /// <Summary>
        /// get all active candidates with equal or grater psychometric grade
        /// </Summary>
        public static ArrayList getActiveCandidatesByPsychometricGrade(int grade)
        {
            List<generalDetailsActiveCandidate> users = getCandidatesGenralDetails();
            ArrayList usersAL = new ArrayList();

                foreach (var user in users)
                {
                    if (user.psychometric_grade >= grade)
                    {
                        usersAL.Add(user);
                    }
                }
                return usersAL;   
        }


        /// <Summary>
        /// filter scholarships students table by averege degree grade - get all the scholarships students with
        /// equal or greater grade averege degree
        /// </Summary>
        public static ArrayList getStudentsHigerAverege(float avergeGrade)
        {                  
                ArrayList students = getAllScholarshipsStudents();
                ArrayList studentsAL = new ArrayList();

                foreach (userTbl student in students)
                {
                    if (student.averageDegree >= avergeGrade)
                    {
                        studentsAL.Add(student);
                    }
                }
                return studentsAL;         
        }

        /// <Summary>
        /// filter scholarships students table by averege degree grade - get all the scholarships students with
        /// equal or lower grade averege degree
        /// </Summary>
        public static ArrayList getStudentsLowerAverege(int avergeGrade)
        {
               ArrayList students = getAllScholarshipsStudents();
               ArrayList studentsAL = new ArrayList();

                foreach (userTbl student in students)
                {
                    if (student.averageDegree <= avergeGrade)
                    {
                        studentsAL.Add(student);
                    }
                }
                return studentsAL;
            
        }


        /// <Summary>
        /// filter students table by academic institue - get all the students from the same academy
        /// </Summary>
        public static ArrayList getStudentsFromTheSameInstitution(String institute)
        {
               ArrayList students = getAllScholarshipsStudents();
                ArrayList studentsAL = new ArrayList();
                int num = ForeignKeys.getInstitutionNumberByName(institute);

                foreach(userTbl student in students)
                {
                    if(student.academicInstitution == num)
                    {
                        studentsAL.Add(student);
                    }
                }
                return studentsAL;    
        }

        /// <Summary>
        /// filter scholarships students table by age - get all the scholarships students with
        /// equal or higher age
        /// </Summary>
        public static ArrayList getAllStudentsByHigerAge(int age)
        {//get all the students with  equal or greater age
            ArrayList students = getAllScholarshipsStudents();
            ArrayList studentsAL = new ArrayList();
            int ageOfStudent = 0;

            foreach(userTbl student in students)
            {
                //calaulate the age of the student by date of birth
                ageOfStudent = DateTime.Today.Year-student.dateOfBirth.Value.Year;
                if (ageOfStudent >= age)
                {
                    studentsAL.Add(student);

                }
            }
            return studentsAL;
        }

        public static ArrayList getAllStudentsByLowerAge(int age)
        {//get all the students with  equal or lower age
            List<userTbl> students = getAllScholarshipsStudents().ToList();
            ArrayList studentsAL = new ArrayList();
            int ageOfStudent = 0;

            foreach (var student in students)
            {
                //calaulate the age of the student by date of birth
                ageOfStudent = DateTime.Today.Year - student.dateOfBirth.Value.Year;
                if (ageOfStudent <= age)
                {
                    studentsAL.Add(student);

                }
            }
            return studentsAL;
        }

        public static ArrayList getAllStudentsFromTheSameStudyField(String field)
        {//get all the students from the same study field(not from the same degree)
            List<userTbl> students = getAllScholarshipsStudents().ToList();
            ArrayList studentsAL = new ArrayList();
            int num = ForeignKeys.getnumberOfFieldByName(field);

            foreach(var student in students)
            {
                if(student.studyField == num)
                {
                    studentsAL.Add(student);
                }
            }
            return studentsAL;
        }

        public static ArrayList getAllAwareCandidatesByNumOfAcademicParents(int academicParents)
        {//get all the candidates with specific number of academic parents
            List<userTbl> candiates = getAllAwareCandidates().ToList();
            ArrayList candiatesAL = new ArrayList();
            

            foreach (var candidate in candiates)
            {
                if (candidate.academicParents == academicParents)
                {
                    candiatesAL.Add(candidate);
                }
            }
            return candiatesAL;
        }

        public static ArrayList getAllStudentsByNumOfAcademicParents(int academicParents)
        {//get all the students with specific number of academic parents
            List<userTbl> students = getAllScholarshipsStudents().ToList();
            ArrayList studentsAL = new ArrayList();


            foreach (var student in students)
            {
                if (student.academicParents == academicParents)
                {
                    studentsAL.Add(student);
                }
            }
            return studentsAL;
        }


        public static ArrayList getAllStudentsWithTheSameStartYear(int year)
        {//get all the students with the same start year
            List<userTbl> students = getAllScholarshipsStudents().ToList();
            ArrayList studentsAL = new ArrayList();

            foreach (var student in students)
            {
                if (student.startYear == year)
                {
                    studentsAL.Add(student);
                }
            }
            return studentsAL;
        }


        public static ArrayList getAllStudentsWithSameFinishYear (int year)
        {//get all the students with the same finish year
            List<userTbl> students = getAllScholarshipsStudents().ToList();
            ArrayList studentsAL = new ArrayList();

            foreach (var student in students)
            {
                if (student.excpectedCompletionYear == year)
                {
                    studentsAL.Add(student);
                }
            }
            return studentsAL;
        }
        /*
        public static ArrayList getAllStudentsFromTheSameGender(char gender)
        {//get all the students from the same gender 'F' = female or 'M'=male
            List<userTbl> students = getAllStudents().ToList();
            ArrayList studentsAL = new ArrayList();

            foreach (var student in students)
            {
                if (student.gender.Equals(gender))
                {
                    studentsAL.Add(student);
                }
            }
            return studentsAL;
        }

        public static ArrayList getAllAwareCandidatesFromTheSameGender(char gender)
        {//get all the candidates from the same gender 'F' = female or 'M'=male
            List<userTbl> candidates = getAllAwareCandidates().ToList();
            ArrayList candidatesAL = new ArrayList();

            foreach (var candidate in candidates)
            {
                if (candidate.gender.Equals(gender))
                {
                    candidatesAL.Add(candidate);
                }
            }
            return candidatesAL;
        }

        
        public static ArrayList getAllCandidatesFromTheSameGender(char gender)
        {//get all the candidates from the same gender 'F' = female or 'M'=male
            List<userTbl> candidates = getAllCandidates();
            ArrayList candidatesAL = new ArrayList();

            foreach (var candidate in candidates)
            {
                if (candidate.gender.Equals(gender))
                {
                    candidatesAL.Add(candidate);
                }
            }
            return candidatesAL;
        }*/



        public static ArrayList getAllChosenUsersFromTheSameGender(char gender,ArrayList usersArr)
        {//get all the chosen users from the same gender 'F' = female or 'M'=male
            List<userTbl> users = usersArr.Cast<userTbl>().ToList();
            ArrayList usersAL = new ArrayList();

            foreach (userTbl user in users)
            {
                if (user.gender.Equals(gender))
                {
                    usersAL.Add(user);
                }
            }
            return usersAL;
        }
        /*
        public int getAllUsersFromTheSameGender(char gender)
        {//get all the users from the same gender 'F' = female or 'M'=male - aware\unaware candidates and all the students
            return getAllCandidatesFromTheSameGender(gender).Count + getAllStudentsFromTheSameGender(gender).Count;
        }*/

                            /*Add functions*/
        public static void addUserToUsers(userTbl user,List<userTbl> users)
        {
            using (var db = new HeznekDB())
            {
                db.userTbl.Add(user);
                db.SaveChanges();
            }      
        }
                             /*update functions*/
        public static void updateUserInList(userTbl updatedUser)
        {
            using (var db = new HeznekDB())
            {           
                List<userTbl> users = getAllUsers();

                foreach(userTbl user in users)
                {
                    if(user.id.Equals(updatedUser.id))
                    {                 
                        db.userTbl.Remove(user);
                        db.userTbl.Add(updatedUser);
                    }
                }
            }           
        }

                            /*removal functions*/

        public static void removeUserFromList(userTbl userToRemove)
        {
            using (var db = new HeznekDB())
            {
                List<userTbl> users = getAllUsers();

                foreach (userTbl user in users)
                {
                    if (user.id.Equals(userToRemove.id))
                    {
                        db.userTbl.Remove(user);
                    }
                }
            }
        }
        /*
        public static void addBankToBanks(string name)
        {
            using (var db = new HeznekDB())
            {
                db.bank.Add(new bank(name));
                db.SaveChanges();
            }
        }
        */
    }
}
