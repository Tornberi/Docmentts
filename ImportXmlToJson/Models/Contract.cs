using System.ComponentModel.DataAnnotations;

namespace ImportXmlToJson.Models
{
    public class Contract
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name ="Шифр договора")]
        public int? Shifr_Contract { get; set; }

        [Required]
        [Display(Name ="Наименование договора")]
        public string Name_Contract { get; set;}

        [Required]
        [Display(Name ="Заказчик")]
        public string Seller { get; set; }
    }
}
