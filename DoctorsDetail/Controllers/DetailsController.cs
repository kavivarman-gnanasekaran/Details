using DataAccesslayers;
using DataAccesslayers.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorsDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        IDetailRepository reg = null;
       public DetailsController(IDetailRepository DetaRepo)
        {
            reg = DetaRepo;
        }

        
        // GET: api/<DetailsController>
        [HttpGet]
        public IEnumerable<Details> Get()
        {
            return reg.showallname();
        }

        // GET api/<DetailsController>/5
        [HttpGet( "{Name}")]
        public Details Get(string Name)
        {
            return reg.showDetailsbyName(Name) ;
        }

        // POST api/<DetailsController>
        [HttpPost]
        public void Post([FromBody] Details value)
        {
            reg.InsertDetails(value);
        }

        // PUT api/<DetailsController>/5
        [HttpPut]
        public void Put( [FromBody] Details regs)
        {
            reg.UpdateDetatils(regs);
        }

        // DELETE api/<DetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            reg.DeleteTable(id);
        }
    }
}
