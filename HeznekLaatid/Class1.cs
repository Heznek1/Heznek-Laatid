using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using HeznekLaatid.model;

namespace HeznekLaatid
{
    class Program
    {
        static void Main(String[] args)
        {
                var context = new HeznekDBE();
            var studyField = new studyFieldTbl()
            {
               
                field = "computers",
                nameOfDegree = "Computer Science"      
        };
            context.studyFieldTbl.Add(studyField);
            context.SaveChanges();

        }
     }
}
        


