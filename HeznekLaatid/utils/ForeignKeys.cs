using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using HeznekLaatid.entities;


namespace HeznekLaatid
{
    class ForeignKeys
    {

        public static int getCityNumberByName(String city)
        {
          
            using (var db = new HeznekDBE())
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
    }
}