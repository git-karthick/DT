using System.ComponentModel.DataAnnotations;

namespace DT.Models
{
    public class Dt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
    }
}
