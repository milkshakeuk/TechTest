using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTest.Data;

namespace TechTest.Web.Models
{
    public class PersonApiModel
    {
        public PersonApiModel()
        {
        }

        public PersonApiModel(Person person)
        {
            this.PersonId = person.PersonId;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.IsAuthorised = person.IsAuthorised;
            this.IsValid = person.IsValid;
            this.IsEnabled = person.IsEnabled;
            this.Colours = person.Colours.ToList().Select(c => new ColourApiModel(c)).ToList();
        }
    
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }
    
        public List<ColourApiModel> Colours { get; set; }
    }
}