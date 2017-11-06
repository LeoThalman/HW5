using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class DMV
    {
        /// <summary>
        /// Database fields with required and length restrictions marked as necessary
        /// </summary>
        [Required]
        public int ID { get; set; }

        [Required, Range( 1, 10000000, ErrorMessage = "Permit must be a postive number less than 8 digits")]
        public int Permit { get; set; }

        [Required, StringLength(192)]
        public string FullName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required, StringLength(192)]
        public string ResidenceAddress { get; set; }

        [Required, StringLength(64)]
        public string City { get; set; }

        [Required, StringLength(2, ErrorMessage = "State must be in Abbv. form(i.e. OR, CA)"), MinLength(2, ErrorMessage="State must be in Abbv. form(i.e. OR, CA)")]
        public string StateAbbreviated { get; set; }

        [Required, Range(1, 100000, ErrorMessage = "Zipcode must be a postive number less than 6 digits")]
        public int ZipCode { get; set; }

        [Required, StringLength(64)]
        public string County { get; set; }

    }

}