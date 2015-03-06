using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechTest.Data;

namespace TechTest.Web.Models
{
    public class ColourApiModel
    {
        public ColourApiModel()
        {
        }

        public ColourApiModel(Colour colour)
        {
            this.ColourId = colour.ColourId;
            this.Name = colour.Name;
        }
    
        public int ColourId { get; set; }
        public string Name { get; set; }
    
    }
}