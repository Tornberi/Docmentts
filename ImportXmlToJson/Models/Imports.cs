using System.ComponentModel.DataAnnotations;

namespace ImportXmlToJson.Models
{
    public class Imports
    {
        public int Id { get; set; }

        [Display(Name="Наименование Этапа")]
        public string NameStage { get; set; }

        [Display(Name="Дата начала")]
        [DataType(DataType.Date)]
        public DateTime StardDate { get; set; }
        [Display(Name ="Дата окончания")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
