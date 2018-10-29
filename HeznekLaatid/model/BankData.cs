using HeznekLaatid.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeznekLaatid.model
{
    public class BankData
    {
                    /*Get function*/
        
        public static List<bank> getAllBanks()
        {         
            using (var db = new HeznekDB())
            {
                List<bank> banks = db.bank.ToList();
                return banks;
            }
        }

         public static bank getBankByName(string name)
        {
            List<bank> banks = getAllBanks();
            foreach(var bank in banks)
            {
                if(bank.name.Equals(name))
                {
                    return bank;
                }
            }
            return null;
        }

        public static bank getBankBySn(int sn)
        {
            List<bank> banks = getAllBanks();
            foreach (var bank in banks)
            {
                if (bank.sn == sn)
                {
                    return bank;
                }
            }
            return null;
        }

        /*Add function*/
        public static void addBankToList(bank bank)
        {
            using (var db = new HeznekDB())
            {
                db.bank.Add(bank);
                db.SaveChanges();
            }
        }
    }
}