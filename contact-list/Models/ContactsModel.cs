using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsList.Models
{
    public class ContactsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This is to auto-generate the Id
        public int Id { get; set; }
        [Required(ErrorMessage = "Mandatory field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mandatory field.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Mandatory field.")]
        public string Email { get; set; }
    }
}
