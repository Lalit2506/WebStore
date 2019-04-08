using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class Estate
    {
        // This is to enter the estate using the estate ID
        [Required]
        public virtual int EstateID { get; set; }

        // This is to enter the type of Rental
        [Required]
        public virtual String Type { get; set; }

        // This is to enter the address of the home
        [Required]
        public virtual String Address { get; set; }

        // This is the price for selling or renting
        [Required]
        [Range(1, 10000000000000000000)]
        [DataType(DataType.Currency)]
        public virtual Double Price { get; set; }

        // This is to enter the city 
        [Required]
        public virtual String location { get; set; }

        // This is to describe the facilities of the estate
        [Required]
        public virtual String Description { get; set; }

        // This is to show the picture of the property 
        [Required]
        [DisplayName("Picture")]
        public virtual String EstatePhoto { get; set; }
    }
}