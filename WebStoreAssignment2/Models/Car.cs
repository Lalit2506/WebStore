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
        // This is the car id to enter the cars
        [Required]
        public virtual int Carid { get; set; }

        // This is to enter the type of car
        [Required]
        [DisplayName("Car Type")]
        public String Cartype { get; set; }


        // This is to enter the name of car
        [Required]
        [DisplayName("Car Name")]
        public virtual String Model { get; set; }

        // This is to enter the year of buying the car
        [Required]
        [DisplayName("Car year")]
        public virtual int year { get; set; }

        // This field is to enter the car brand
        [Required]
        [DisplayName("Car Make")]
        public virtual String Make { get; set; }


        // This is to enter the price of car which the owner wants for selling the car
        [Required]
        [DisplayName("Car Price")]
        public virtual Double Price { get; set; }

        // This field is to describe the condition of car
        [Required]
        [DisplayName("Car Condition")]
        public virtual String Condition { get; set; }

        //This filed is to enter the picture of car so that the owner can see it.
        [Required]
        [DisplayName("Car Picture")]
        public virtual String CarPhoto { get; set; }
    }
}