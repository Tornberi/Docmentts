using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportXmlToJson.Models
{
    [Table("StageContract")]
    public class Imports
    {
        public int? Id { get; set; }

        [Display(Name="Наименование Этапа")]
        public string Contract_Stage { get; set; }

        [Display(Name="Дата начала")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name ="Дата окончания")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
