using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1API.Models
{
    public class StudentInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
