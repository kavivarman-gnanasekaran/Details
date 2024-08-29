using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesslayerkavi.Entity
{
    public class Location
    {
        internal long id;

        [Key]
        public long LocationId { get; set; }

        public string Name { get; set; }

        public string DistrictName { get; set; }

        public string Description { get; set; }

    }
}
