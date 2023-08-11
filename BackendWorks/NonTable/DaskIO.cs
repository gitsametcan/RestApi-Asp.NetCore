using BackendWorks.Models;

namespace BackendWorks.NonTable
{
    public class DaskIO
    {
        public Policy PolicyObj { get; set; }
        public int DaskId { get; set; }
        public int PolicyId { get; set; }
        public string Adres { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }

        public DaskIO Yarat(Dask dask, DaskContext dCon)
        {
            var retVal = new DaskIO();

            retVal.PolicyObj = GetById(dask.PolicyId, dCon);
            retVal.DaskId = dask.DaskId;
            retVal.PolicyId = dask.PolicyId;
            retVal.Adres = dask.Adres;
            retVal.Ilce = dask.Ilce;
            retVal.Il = dask.Il;

            return retVal;
        }

        private Policy GetById(int id, DaskContext dCon)
        {
            if (dCon.Policy == null)
            {
                return null;
            }

            Policy policy = dCon.Policy.Find(id);

            if (policy == null)
            {
                return null;
            }

            return policy;
        }
    }

    


}
