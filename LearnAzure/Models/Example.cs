using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LearnAzure.Models
{
    public class Example
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Output { get; set; }
        public string Template { get; set; }
    }
}