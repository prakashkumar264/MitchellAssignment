using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MitchellAssignment.Models
{
    /// <summary>
    /// Used to create enum of Make of vehicles
    /// </summary>
    public class MakeData
    {
        [Key]
        public string Make { get; set; }
    }
}