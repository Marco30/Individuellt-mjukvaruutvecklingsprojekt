using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVT.Model// Marco Villegas
{

    public class Member // En publik klass som innehåller samma parametrar som  i databasen.
    {

        public int MedID { get; set; }

        [Required(ErrorMessage = "Ett Förnamn måste anges")]
        [StringLength(10, ErrorMessage = "Förnamnet kan bestå av som mest 10 tecken")]
        public string Fnamn { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges")]
        [StringLength(10, ErrorMessage = "Efternamnet kan bestå av som mest 10 tecken")]
        public string Enamn { get; set; }

        [Required(ErrorMessage = "Ett personnummer måste anges")]
        [StringLength(12, ErrorMessage = "personnummer måste innehålla 12 tecken enligt formatet ÅÅMMDD-XXXX")]
        [RegularExpression(@"^\d{6}-\d{4}$", ErrorMessage = "Personnummret måste vara i formatet ÅÅMMDD-XXXX")]
        public string PersNR { get; set; }

        [Required(ErrorMessage = "En address måste anges")]
        [StringLength(30, ErrorMessage = "Addressen kan vara 20 tecken")]
        public string Address { get; set; }

        public int Arvode { get; set; }

        [Required(ErrorMessage = "En ort måste anges.")]
        [StringLength(25, ErrorMessage = "Orten kan bestå av som mest 25 tecken")]
        public string Ort { get; set; }

        public string Befattningstyp { get; set; }
        public string Blevmedlem { get; set; }

        public int BefattningID { get; set; }


    }

}