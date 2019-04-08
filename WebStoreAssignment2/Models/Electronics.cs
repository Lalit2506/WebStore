using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class Electronics
    {
        // This field is to enter the electronics id
        [Required]
        public virtual int Electronicsid { get; set; }

        // This filed is required to enter which type of electronic item you want to sell.
        [Required]
        [DisplayName("Electronic type")]
        public virtual String Type { get; set; }

        // This is to enter the name of electronic 
        [Required]
        [DisplayName("Electronic Name")]
        public virtual String Model { get; set; }

        // This is to enter the name of the brand.
        [Required]
        [DisplayName("Electronic Brand")]
        public virtual String Brand { get; set; }

        // Price for which the owner wants to sell the product.
        [Required]
        [DisplayName("Electronic Price")]
        [Range(1, 10000000000000000000)]
        [DataType(DataType.Currency)]
        public virtual Double price { get; set; }

        // This is to enter the condition of the product
        [Required]
        [DisplayName("Electronic Description")]
        public virtual String Description { get; set; }

        // This is to show the picture of electronic product.
        [Required]
        [DisplayName("Picture")]
        public virtual String electronicPicture { get; set; }
    }
}