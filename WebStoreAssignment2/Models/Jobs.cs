using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class Jobs
    {
        [Required]
        public virtual int Jobsid { get; set; }
        [Required]
        public virtual String Jobtype { get; set; }

        [Required]
        public virtual double Salary { get; set; }

        [Required]
        public virtual String Company { get; set; }

        [Required]
        [DisplayName("Number of hours")]
        public virtual Double Hours { get; set; }

        [Required]
        public virtual String location { get; set; }

        [Required]
        [DisplayName(" Description")]
        public virtual String Description { get; set; }

        [Required]
        [DisplayName("Company Picture")]
        public virtual String CompanyPicture { get; set; }
    }
}