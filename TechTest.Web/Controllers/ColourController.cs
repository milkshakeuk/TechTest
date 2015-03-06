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
    [RoutePrefix("api/colour")]
    public class ColourController : ApiController
    {
        private readonly TechTestEntities _context;

        public ColourController()
            : this(new TechTestEntities())
        {

        }

        public ColourController(TechTestEntities context)
        {
            _context = context;
        }

        [Route("")]
        [ResponseType(typeof(List<ColourApiModel>))]
        public IHttpActionResult GetAllColours()
        {
            var colours = _context.Colours.ToList().Select(p => new ColourApiModel(p)).ToList();

            return Ok(colours);
        }
    }
}
