using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TechTest.Data;
using TechTest.Web.Models;

namespace TechTest.Web.Controllers
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController
    {
        private readonly TechTestEntities _context;

        public PeopleController()
            : this(new TechTestEntities())
        {

        }

        public PeopleController(TechTestEntities context)
        {
            _context = context;
        }

        [Route("")]
        [ResponseType(typeof(List<PersonApiModel>))]
        public IHttpActionResult GetAllPeople()
        {
            var people = _context.People.Include("Colours").OrderBy(p => p.FirstName).ToList().Select(p => new PersonApiModel(p)).ToList();

            return Ok(people);
        }

        [Route("{id:int}")]
        [ResponseType(typeof(PersonApiModel))]
        public IHttpActionResult GetPersonById(int id)
        {
            var person = _context.People.Include("Colours")
                                        .Where(p => p.PersonId == id)
                                        .SingleOrDefault();

            if (person == null)
            {
                return NotFound();
            }

            return Ok(new PersonApiModel(person));
        }

        [Route("{id:int}")]
        [ResponseType(typeof(PersonApiModel))]
        public IHttpActionResult PutPersonById(int id, PersonApiModel person)
        {
            var dbPerson = _context.People.Include("Colours")
                                        .Where(p => p.PersonId == id)
                                        .SingleOrDefault();

            if (person == null)
            {
                return NotFound();
            }

            var addColours = person.Colours.Select(c => c.ColourId).ToArray();
            dbPerson.Colours = _context.Colours.Where(c => addColours.Contains(c.ColourId)).ToList();
            dbPerson.IsAuthorised = person.IsAuthorised;
            dbPerson.IsEnabled = person.IsEnabled;

            _context.SaveChanges();

            return Ok(new PersonApiModel(dbPerson));
        }
    }
}
