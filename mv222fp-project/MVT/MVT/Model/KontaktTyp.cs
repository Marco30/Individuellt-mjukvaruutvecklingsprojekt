using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVT.Model// Marco Villegas
{
    public class KontaktTyp
    {
        public int MedID { get; set; }
        public int KontakttypID { get; set; }
        public string Kontakttyp { get; set; }

        /*[Required(ErrorMessage = "En Kontaktuppgift måste anges.")]
        [StringLength(30, ErrorMessage = "Kontaktuppgift kan bestå av som mest 30 tecken")]*/
        public string Kontaktuppgift { get; set; }

        public int KontaktID { get; set; }

    }
}