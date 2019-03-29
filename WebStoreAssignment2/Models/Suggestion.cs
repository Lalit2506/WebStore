using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoreAssignment2.Models
{
    public class Suggestion
    {
        // This is to enter the suggestions using the suggestionID
        [Required]
        public virtual int SuggestionID { get; set; }


        // This is to enter the name of person who is entering the suggestion.
        [Required]
        public virtual String Name { get; set; }

        // This is to enter the Suggestion
        [Required]
        [DisplayName("Suggestion")]
        public virtual String Comment { get; set; }
    }
}