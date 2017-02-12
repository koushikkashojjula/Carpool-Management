using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginSignup.Models
{
    public class SearchBarModel
    {

        [Required]
        public string source { get; set; }

        [Required]
        public string destination { get; set; }

        [StringLength(20)]
        [Required]
        public string date { get; set; }

    }
}