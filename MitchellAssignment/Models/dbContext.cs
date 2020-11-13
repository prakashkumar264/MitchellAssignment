using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MitchellAssignment.Models
{
    public class dbContext : DbContext
    {
        /// <summary>
        /// This class connects to the database using the connection string DBModel from web.config
        /// </summary>
        public dbContext() : base("DBModel")
        {

        }

        public System.Data.Entity.DbSet<MitchellAssignment.Models.vehicle> vehicles { get; set; }
        public System.Data.Entity.DbSet<MitchellAssignment.Models.MakeData> MakeDatas { get; set; }
    }
}