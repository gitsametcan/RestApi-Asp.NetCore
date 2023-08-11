using BackendWorks.Controllers;
using BackendWorks.Models;

namespace BackendWorks.NonTable
{
    public class TrafficIO
    {
        public Policy PolicyObj { get; set; }
        public int TrafficId { get; set; }
        public int PolicyId { get; set; }
        public string PlakaIlKodu { get; set; }
        public string PlakaKodu { get; set; }



        public TrafficIO Yarat(Traffic traffic, TrafficContext tCon)
        {
            var retVal = new TrafficIO();
            
            retVal.PolicyObj = GetById(traffic.PolicyId,tCon);
            retVal.PolicyId = traffic.PolicyId;
            retVal.PlakaIlKodu = traffic.PlakaIlKodu;
            retVal.PlakaKodu = traffic.PlakaKodu;
            retVal.TrafficId = traffic.TrafficId;

            return retVal;
        }

        private Policy GetById(int id, TrafficContext tCon)
        {
            //Policy policy = new Policy();

            if (tCon.Policy == null)
            {
                return null;
            }

            Policy policy = tCon.Policy.Find(id);

            if (policy == null)
            {
                return null;
            }

            return policy;
        }

    }
}
