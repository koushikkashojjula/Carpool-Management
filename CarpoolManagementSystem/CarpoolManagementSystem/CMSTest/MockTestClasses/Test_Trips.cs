namespace CMSTest.TripClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Test_Trips
    {
        public int id { get; set; }

        [StringLength(50)]
        public string source { get; set; }

        [StringLength(50)]
        public string destination { get; set; }

        [StringLength(50)]
        public string date { get; set; }

        public int? created_by { get; set; }

        public bool? carAvailable { get; set; }

        public string description { get; set; }

        public int? vacant_seats { get; set; }

        public decimal? estimated_cost { get; set; }
    }
}
