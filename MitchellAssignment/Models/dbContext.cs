using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MitchellAssignment.Models
{
    public class dbContext : DbContext
    {
        public dbContext() : base("DBModel")
        {

        }

        public System.Data.Entity.DbSet<MitchellAssignment.Models.vehicle> vehicles { get; set; }
        public System.Data.Entity.DbSet<MitchellAssignment.Models.MakeData> MakeDatas { get; set; }
    }
}