using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVT.Model
{
    public class ImageTyp
    {
        public int MedlemID { get; set; }


        public int ImageID { get; set; }

        [Required(ErrorMessage = "Ett bildnamn måste anges.")]
        [StringLength(50, ErrorMessage = "Ett bildnamn kan bestå av som mest 50 tecken.")]
        public string ImageAdres { get; set; }

    }
}
