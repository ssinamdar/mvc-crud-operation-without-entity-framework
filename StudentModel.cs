using System.ComponentModel.DataAnnotations;

namespace MVC_Crud.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Please provide Name.")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Please provide City.")]
        public string City { get; set; }
        [Required (ErrorMessage = "Please provide Address.")]
        public string Address { get; set; }

    }
}