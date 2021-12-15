using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.DLA.EF;

namespace DLA.Entites
{
    public class Facade
    {
        public Region MainRegion;
        public Lokality MainLokality;
        public District MainDistrict;

        Facade(Region mr, Lokality ml, District md)
        {
            MainRegion = mr;
            MainLokality = ml;
            MainDistrict = md;
        }

        public void addLokalityToRegion()
        {   
            MainRegion.Loсalities.Add(MainLokality);
            /*using (LokalityContext db = new LokalityContext())
            {

                db.
                db.SaveChanges();
            }*/
        }

        public void addDistrictToLokality()
        {
            MainLokality.Districts.Add(MainDistrict);
            /*using (LokalityContext db = new LokalityContext())
            {

                db.
                db.SaveChanges();
            }*/
        }
    }
}
