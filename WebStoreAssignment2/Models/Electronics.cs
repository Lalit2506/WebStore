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
        [Required]
        public virtual int Electronicsid { get; set; }

        [Required]
        [DisplayName("Electronic type")]
        public virtual String Type { get; set; }

        [Required]
        [DisplayName("Electronic Model")]
        public virtual String Model { get; set; }

        [Required]
        [DisplayName("Electronic Brand")]
        public virtual String Brand { get; set; }

        [Required]
        [DisplayName("Electronic Price")]
        public virtual Double price { get; set; }

        [Required]
        [DisplayName("Electronic Description")]
        public virtual String Description { get; set; }

        [Required]
        [DisplayName("Picture")]
        public virtual String electronicPicture { get; set; }
    }
}