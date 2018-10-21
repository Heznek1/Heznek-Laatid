using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using HeznekLaatid.model;


namespace HeznekLaatid.utils
{
    class foreignKeys
    {

        // singeltone class
        private static foreignKeys instance;

        private foreignKeys() { }

        public static foreignKeys Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new foreignKeys();
                }
                return instance;
            }
        }


        public int getCityNumberByName(String city)
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