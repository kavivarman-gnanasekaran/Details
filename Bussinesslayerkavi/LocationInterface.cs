using Bussinesslayerkavi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesslayerkavi
{
   public interface ILocationRepository
    {
        public void InsertLocation(Location loc);
        public List<Location> GetAllLocation();
        public Location GetLocationByName(string name);
        public void UpdateLocation(Location loc);
        public void DeleteLocation(long loc);

    }
}
