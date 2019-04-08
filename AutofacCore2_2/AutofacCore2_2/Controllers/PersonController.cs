using AutofacCore2_2.DataLayer;
using AutofacCore2_2.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacCore2_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericApplicationRepository<Person> _personRepository;

        public PersonController(IGenericApplicationRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public IQueryable<Person> GetPersonList()
        {
            return _personRepository.GetAll();
        }
    }
}
