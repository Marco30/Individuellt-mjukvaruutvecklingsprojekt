using System.ComponentModel.DataAnnotations;


namespace MVT.Model
{
    public class Activity
    {
        public int AktID { get; set; }

        [Required(ErrorMessage = "En aktivitetstyp måste anges.")]
        [StringLength(15, ErrorMessage = "Aktivitetstypen kan bestå av som mest 15 tecken.")]
        public string Akttyp { get; set; }

        [Required(ErrorMessage = "En aktivitet Startdatum måste anges.")]
        [StringLength(15, ErrorMessage = "Aktivitetstypen kan bestå av som mest 15 tecken.")]
        public string Startdatum { get; set; }

        [Required(ErrorMessage = "En aktivitet Slutdatum måste anges.")]
        [StringLength(15, ErrorMessage = "Aktivitetstypen kan bestå av som mest 15 tecken.")]
        public string Slutdatum { get; set; }
    }
}