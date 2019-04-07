using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutofacCore2_2.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutofacCore2_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IPerson _aPerson;
        ICar _aCar;
        public ValuesController(IPerson aPerson, ICar aCar)
        {
            _aPerson = aPerson;
            _aCar = aCar;
        }

        /// <summary>
        /// LD002 we do a nested class generation and method calls to obtain the result
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("api/nodependency")]
        public ActionResult<IEnumerable<ICar>> Get()
        {
            Person person = new Person("luca", "dangelo", new Car("suzuki", "white"));
            person.BuyCar();
            return person.Cars;
        }

        /// <summary>
        /// LD008 creation of api using Dependency Injection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("dependency")]
        public ActionResult<IEnumerable<ICar>> GetDepInj()
        {
            _aPerson.Name = "luca";
            _aPerson.Surname = "dangelo";

            _aCar.Brand = "ferrari";
            _aCar.Color = "red";

            _aPerson.Cars.Add(_aCar);
            _aPerson.BuyCar();

            return _aPerson.Cars;
        }

        #region Region default Endpoints

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion Region Default Endpoints
    }
}
