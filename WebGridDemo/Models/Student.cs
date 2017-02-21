using System.ComponentModel.DataAnnotations;

namespace WebGridDemo.Models
{
    public class Student
    {

        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Student Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Phone No.")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Qualification")]
        public string Class { get; set; }
        //Default value as it is goint to be active when we add a student
        public int IsActive { get; set; } = 1;
    }
}