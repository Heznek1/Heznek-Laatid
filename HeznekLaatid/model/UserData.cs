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
                                                                      /* gets functions*/

        public static List<userTbl> getAllUsers()
            //give all the users in the table with no filter
        {
            using (var db = new HeznekDB())
            {
                List<userTbl> users = db.userTbl.ToList();
                return users;
            }
        }

        public static ArrayList getUsersByStatus(int status)
        {  //give all the users in the table by their status 
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
        /*
        public static List<userTbl> getStudentsByStatus(int status)
        {
            //give all the students in the table by their status
            using (var db = new HeznekDB())
            {
                var query = (from userTbl in db.userTbl where (userTbl.status == status) select userTbl);
                var students = query.ToList();
                return students;
            }
        }*/
        
        public static List<userTbl> getAllStudents()
        {
            //give all the students in the table by their status
            using (var db = new HeznekDB())
            {
                var query = (from userTbl in db.userTbl where (userTbl.status<=3) select userTbl);
                var students = query.ToList();
                return students;
            }
        }

        public static List<userTbl> getAllAwareCandidates()
        {
            //give all the aware candidates in the table by their status
            using (var db = new HeznekDB())
            {
                var query = (from userTbl in db.userTbl where (userTbl.status == 4) select userTbl);
                var candidates = query.ToList();
                return candidates;
            }
        }

        public static List<userTbl> getAllUnawareCandidates()
        {
            //give all the unaware candidates in the table by their status
            using (var db = new HeznekDB())
            {
                var query = (from userTbl in db.userTbl
                             where (userTbl.status == 5)
                             select userTbl);
                var candidates = query.ToList();
                return candidates;
            }
        }

        public static List<userTbl> getAllCandidates()
        {
            //give the all candidates

            List<userTbl> candidates = getAllUnawareCandidates();
            candidates.AddRange(getAllAwareCandidates());
            return candidates;
        }

        public static List<userTbl> getAllUsersFromSpecificCity(String city)
        {
            //give all the users in the table that are from a specific city
            using (var db = new HeznekDB())
            {
                //get the serial number of the specific city
                int sn = ForeignKeys.getCityNumberByName(city);
                List<userTbl> users = getAllUsers();
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
        }
/*
        public static ArrayList getAllStudentsFromSpecificCity(String city)
        {
            //give all the students in the table that are from a specific city
            using (var db = new HeznekDB())
            {
                //get the serial number of the specific city
                int sn = ForeignKeys.getCityNumberByName(city);

                List<userTbl> students = getAllStudents().ToList();
                ArrayList studentsAL = new ArrayList();

                foreach (var student in students)
                {
                    if(student.status < 4 && student.cityNumber == sn)
                    {
                        studentsAL.Add(student);
                    }
                }

                return studentsAL;
            }
        }

        public static ArrayList getAllCandidatesFromSpecificCity(String city)
        {
            //give all the candidates in the table that are from a specific city
                int sn = ForeignKeys.getCityNumberByName(city);  //get the serial number of the specific city
                List<userTbl> candidates = getAllCandidates();
                ArrayList candidatesAL = new ArrayList();

                foreach (var candidate in candidates)
                {
                    if (candidate.cityNumber == sn)
                    {
                    candidatesAL.Add(candidate);
                    }
                }
                return candidatesAL;     
        }*/

        //חוסך לי לעשות 2 פונקציות אחת של סטודנדטים ואחת של מועמדים
        public static List<userTbl> getAllUsersFromSpecificCity(String city, List<userTbl> usersList)
        {
            int sn = ForeignKeys.getCityNumberByName(city); //get the serial number of the specific city
            List<userTbl> users = usersList;
            ArrayList usersAL = new ArrayList();

            foreach (var user in users)
            {
                if (user.cityNumber == sn)
                {
                    usersAL.Add(user);
                }
            }
            return users;
        }
        //חוסך לי לעשות כמה פונקציות- מועמדים לא מודעים, מודעים וכל סוגי המלגאים 
        public static List<userTbl> getAllUsersFromSpecificCity(String city, int status)
        {           //give all users from the same status in the table that are from a specific city
            int sn = ForeignKeys.getCityNumberByName(city); //get the serial number of the specific city
            List<userTbl> users = getUsersByStatus(status).Cast<userTbl>().ToList();
            ArrayList usersAL = new ArrayList();

                foreach (var user in users)
                {
                    if (user.cityNumber == sn)
                    {
                        usersAL.Add(user);
                    }
                }
                return users;           
        }
    

        public static userTbl getSpecificUserById(char id, List<userTbl> usersList)
        {
            //gets a specific user by Id(table key) from the list of users that i get as a parameter
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

        //חוסך לי כמעט את כל הפונקציות 
        public static userTbl getSpecificUserById(char id, int status, List<userTbl> usersList)
        {
            List<userTbl> users = usersList;
            foreach(var user in users)
            {
                if(user.status == status && user.id.Equals(id))
                {
                    return user;
                }
            }
            return null;

            //gets a specific user by Id(table key) from the list of users from a specific type
            
          /*  ArrayList users = getUsersByStatus(status);

         
            foreach (userTbl user in users)
            {
                if (user.id.Equals(id))
                {
                    return user;
                }
            }
            return null;*/
        }

//here i stopped to improve my code


        public static ArrayList getSpecificUserByFn(String fn)
        {
            //filter users table by first name- get all the users with the same first name
            using (var db = new HeznekDB())
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
            using (var db = new HeznekDB())
            {
                List<userTbl> users = db.userTbl.ToList();
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
        }

        public static ArrayList getSpecificUserByFullName(String fullName)
        {
            //filter users table by full name- get all the users with the same name
            List<userTbl> users = getAllUsers();
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

        public static ArrayList getSpecificUserByFullName(String fullName, int status)
        {
            //filter users table by full name- get all users from specific status with the same name
            List<userTbl> users = getUsersByStatus(status).Cast<userTbl>().ToList();
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

        public static ArrayList getCandidatesByFullName(String fullName)
        {
            //filter candidates table by full name
            List<userTbl> candidates = getAllCandidates();
            ArrayList candidatesAL = new ArrayList();

            foreach (var user in candidates)
            {
                if ((user.firstName + user.lastName).Equals(fullName))
                {
                    candidatesAL.Add(user);
                }
            }
            return candidatesAL;
        }

        public static ArrayList getStudentsByFullName(String fullName)
        {
            //filter students table by full name
            List<userTbl> students = getAllStudents();
            ArrayList studentsAL = new ArrayList();

            foreach (var student in students)
            {
                if ((student.firstName + student.lastName).Equals(fullName))
                {
                    studentsAL.Add(student);
                }
            }
            return studentsAL;
        }


        public static ArrayList getSpecificUserByFn(String fn, int status)
        {
            //filter users table by first name- get all the users from the same status with the same first name
            List<userTbl> users = getUsersByStatus(status).Cast<userTbl>().ToList();
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

        public static ArrayList getSpecificUserByLn(String ln, int status)
        {
            //filter users table by first name- get all the users from the same status with the same first name
            List<userTbl> users = getUsersByStatus(status).Cast<userTbl>().ToList();
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

        public static ArrayList getSpecificCandidateByFn(String fn)
        {
            //filter candidates table by first name- get all the candidates with the same first name

            List<userTbl> candidates = getAllCandidates();
            ArrayList candidatesAL = new ArrayList();

            foreach (var candidate in candidates)
            {
                if (candidate.firstName.Equals(fn))
                {
                    candidatesAL.Add(candidate);
                }
            }
            return candidatesAL;

        }

        public static ArrayList getSpecificCandidateByLn(String ln)
        {
            //filter candidates table by last name- get all the candidates with the same last name
          
                List<userTbl> candidates = getAllCandidates();
                ArrayList candidatesAL = new ArrayList();

                foreach (var candidate in candidates)
                {
                    if (candidate.lastName.Equals(ln))
                    {
                        candidatesAL.Add(candidate);
                    }
                }
                return candidatesAL;
            
        }

        public static ArrayList getStudentsByPsychometric(int grade)
        {
            /*filter students table by psychometric grade - get all the students with
              equal or greater grade*/
            using (var db = new HeznekDB())
            {
                List<userTbl> students = getAllStudents().ToList();
                ArrayList studentsAL = new ArrayList();

                foreach (var student in students)
                {
                    if (student.psychometricGrade >= grade)
                    {
                        studentsAL.Add(student);
                    }
                }
                return studentsAL;
            }
        }

        public static ArrayList getCandidatesByPsychometric(int grade)
        {
            /*filter candidates table by psychometric grade - get all the users with
              equal or greater grade*/
            using (var db = new HeznekDB())
            {
                List<userTbl> candidates = getAllAwareCandidates().ToList();
                ArrayList candidatesAL = new ArrayList();

                foreach (var candidate in candidates)
                {
                    if (candidate.psychometricGrade >= grade)
                    {
                        candidatesAL.Add(candidate);
                    }
                }
                return candidatesAL;
            }
        }

        
        public static ArrayList getStudentsHigerAverege(int avergeGrade)
        {
            /*filter students table by averege dergree grade - get all the students with
              equal or greater grade averege degree*/
            using (var db = new HeznekDB())
            {
                List<userTbl> students = getAllStudents().ToList();
                ArrayList studentsAL = new ArrayList();

                foreach (var student in students)
                {
                    if (student.avergeDegree >= avergeGrade)
                    {
                        studentsAL.Add(student);
                    }
                }
                return studentsAL;
            }
        }

        public static ArrayList getStudentsLowerAverege(int avergeGrade)
        {
            /*filter students table by averege dergree grade - get all the students with
              equal or loawer grade averege degree*/
            using (var db = new HeznekDB())
            {
                List<userTbl> students = getAllStudents().ToList();
                ArrayList studentsAL = new ArrayList();

                foreach (var student in students)
                {
                    if (student.avergeDegree <= avergeGrade)
                    {
                        studentsAL.Add(student);
                    }
                }
                return studentsAL;
            }
        }

        public static ArrayList getStudentsFromTheSameInstitution(String institute)
        {
            /*filter students table by academic institue - get all the students from
              the same academy*/
            using (var db = new HeznekDB())
            {
                List<userTbl> students = getAllStudents().ToList();
                ArrayList studentsAL = new ArrayList();
                int num = ForeignKeys.getInstitutionNumberByName(institute);

                foreach(var student in students)
                {
                    if(student.academicInstitution == num)
                    {
                        studentsAL.Add(student);
                    }
                }
                return studentsAL;
            }
        }

        public static ArrayList getAllStudentsByHigerAge(int age)
        {//get all the students with  equal or greater age
            List<userTbl> students = getAllStudents().ToList();
            ArrayList studentsAL = new ArrayList();
            int ageOfStudent = 0;

            foreach(var student in students)
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
            List<userTbl> students = getAllStudents().ToList();
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
            List<userTbl> students = getAllStudents().ToList();
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

        public static ArrayList getAllSstudentsByNumOfAcademicParents(int academicParents)
        {//get all the students with specific number of academic parents
            List<userTbl> students = getAllStudents().ToList();
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
            List<userTbl> students = getAllStudents().ToList();
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
            List<userTbl> students = getAllStudents().ToList();
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

        public static ArrayList getAllStudentFromTheSameGender(char gender)
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

        public int getAllUsersFromTheSameGender(char gender)
        {//get all the users from the same gender 'F' = female or 'M'=male
            return getAllCandidatesFromTheSameGender(gender).Count + getAllStudentFromTheSameGender(gender).Count;
        }
    


    }
}
