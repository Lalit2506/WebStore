using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class Car
    {
        [Required]
        public virtual int Carid { get; set; }

        [Required]
        [DisplayName("Car Type")]
        public String Cartype { get; set; }


        [Required]
        [DisplayName("Car Model")]
        public virtual String Model { get; set; }

        [Required]
        [DisplayName("Car year")]
        public virtual int year { get; set; }

        [Required]
        [DisplayName("Car Make")]
        public virtual String Make { get; set; }

        [Required]
        [DisplayName("Car Price")]
        public virtual Double Price { get; set; }

        [Required]
        [DisplayName("Car Condition")]
        public virtual String Condition { get; set; }

        [Required]
        [DisplayName("Car Picture")]
        public virtual String CarPhoto { get; set; }
    }
}