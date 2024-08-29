using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Bussinesslayerkavi;
using Bussinesslayerkavi.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMTPController : ControllerBase
    {
       
        private readonly IEmailRepository _email;
        private readonly IConfiguration _Configuration;

     public SMTPController(IEmailRepository email, IConfiguration Configuration)
        {
            _Configuration = Configuration;
            _email = email;
        }
       

        // POST api/<SMTPController>
        [HttpPost]
        public ActionResult<Email> Post([FromBody] Email value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var fromAddress = _Configuration.GetSection("FromAddress").Value;
            var password = _Configuration.GetSection("Password").Value;
            _email.SendEmail(fromAddress, password, value.ToAddress, value.Subject, value.Body);
            return Ok("Email sent");

        }

       
    }
}
