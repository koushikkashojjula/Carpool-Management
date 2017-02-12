namespace LoginSignup.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Data.SqlClient;

    public class Trip
    {
        
        public int id { get; set; }

        [Required]
        //[StringLength(50)]
        public string source { get; set; }

        [Required]
        //[StringLength(50)]
        public string destination { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //[DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public string date { get; set; }

        //[Required]
        //[StringLength(128)]
        public string created_by { get; set; }
            
            //get
            //{
            //    SqlDataReader userId = null;
            //    bool bRet = DB.Open();
            //    if (bRet)
            //    {
            //        string query = "select Id from AspNetUsers where Email = '" + HttpContext.Current.User.Identity.Name + "'";
            //        userId = DB.DataRetrieve(query);
            //    }

            //    userId.Read();
            //    return userId["Id"].ToString();
            //}
            //set { }
        
        [Required]
        public bool carAvailable { get; set; }

        public string description { get; set; }

        
        
        public int? vacant_seats { get; set; }

        public decimal? estimated_cost { get; set; }
    }
}
