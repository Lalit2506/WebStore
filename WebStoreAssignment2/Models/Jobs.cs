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
        // This is to enter the job using the jobid
        [Required]
        public virtual int Jobsid { get; set; }

        // This is to enter the type of the job
        [Required]
        public virtual String Jobtype { get; set; }

        // This is to enter the salary you will get for working 
        [Required]
        public virtual double Salary { get; set; }

        // This is to enter the name of Company
        [Required]
        public virtual String Company { get; set; }

        // This is to enter the number of hours 
        [Required]
        [DisplayName("Number of hours")]
        public virtual Double Hours { get; set; }

        // This is to enter the city in which company is situated
        [Required]
        public virtual String location { get; set; }

        // THis is to enter the type of work you have to do in job
        [Required]
        [DisplayName(" Description")]
        public virtual String Description { get; set; }

        // This is to enter the picture of the company
        [Required]
        [DisplayName("Company Logo")]
        public virtual String CompanyPicture { get; set; }
    }
}