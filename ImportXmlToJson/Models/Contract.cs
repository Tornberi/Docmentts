using System.ComponentModel.DataAnnotations;

namespace ImportXmlToJson.Models
{
    public class Contract
    {
        public int Id { get; set; }
        [Display(Name ="Шифр договора")]
        public short Shifr_Contract { get; set; }
        [Display(Name ="Наименование договора")]
        public string Name_Contract { get; set;}
        [Display(Name ="Заказчик")]
        public string Seller { get; set; }
    }
}
