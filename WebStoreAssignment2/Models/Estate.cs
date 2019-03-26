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
        [Required]
        public virtual int EstateID { get; set; }

        [Required]
        public virtual String Type { get; set; }

        [Required]
        public virtual String Address { get; set; }

        [Required]
        public virtual Double Price { get; set; }

        [Required]
        public virtual String location { get; set; }

        [Required]
        public virtual String Description { get; set; }

        [Required]
        [DisplayName("Picture")]
        public virtual String EstatePhoto { get; set; }
    }
}