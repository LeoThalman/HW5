using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class DMV
    {
        public int ID { get; set; }
        public int Permit { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string ResidenceAddress { get; set; }
        public string City { get; set; }
        public string StateAbbreviated { get; set; }
        public int ZipCode { get; set; }
        public string County { get; set; }

    }

}