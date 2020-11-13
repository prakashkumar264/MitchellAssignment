using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MitchellAssignment.Models
{
    /// <summary>
    /// Vehicle model based on the requirements
    /// </summary>
    public class vehicle
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is Required. Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Make is Required. Please Enter Make")]
        [StringLength(50)]
        public string Make { get; set; }

        [Range(1950, 2050)]
        [Required(ErrorMessage = "Year is Required. Please Enter Year")]
        public int Year { get; set; }
    }
}