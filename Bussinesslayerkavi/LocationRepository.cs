using Bussinesslayerkavi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesslayerkavi
{
  public
        class LocationRepository: ILocationRepository
    {
        LocationDbContext dbContext = null;
        public LocationRepository(LocationDbContext context)
        {
            dbContext = context;
        }

        public void InsertLocation(Location loc)
        {

            try
            {
                dbContext.Add(loc);
                dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Location> GetAllLocation()
        {
            try
            {
                return dbContext.Location.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Location GetLocationByName(string name)
        {
            try
            {
                return dbContext.Location.FirstOrDefault(X => X.Name == name);

            }
            catch (Exception ex)
            {
                throw;
            }

        }public void UpdateLocation(Location loc)
        {
            try
            {
                dbContext.Update(loc);
                dbContext.SaveChanges();
            }catch(Exception ex)
            {
                throw;
            }
        }
        public void DeleteLocation(long loc)
        {
            try
            {
                var count = dbContext.Location.Find(loc);
                dbContext.Remove(count);
                dbContext.SaveChanges();
            }catch(Exception ex)
            {
                throw;
            }
        }

    }
}

    