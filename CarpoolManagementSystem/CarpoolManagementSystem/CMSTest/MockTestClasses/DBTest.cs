namespace CMSTest.TripClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTest")]
    public partial class DBTest
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string source { get; set; }

        [StringLength(50)]
        public string destination { get; set; }

        [StringLength(50)]
        public string date { get; set; }

        [StringLength(128)]
        public string created_by { get; set; }

        public bool? carAvailable { get; set; }

        public string description { get; set; }

        public int? vacant_seats { get; set; }

        public decimal? estimated_cost { get; set; }
    }
}
