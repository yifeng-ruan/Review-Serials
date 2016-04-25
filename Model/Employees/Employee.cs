using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string Name { get; set; }

        public decimal? Salary { get; set; }
        public int Age { get; set; }
    }
}
