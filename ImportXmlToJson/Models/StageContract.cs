using System.ComponentModel.DataAnnotations;

namespace ImportXmlToJson.Models
{
    public class StageContract
    {
        public int Id { get; set; }
        public short Contract_Stage { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
