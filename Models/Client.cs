using ProjectManager.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم العميل مطلوب")]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string ContactInfo { get; set; }

        // علاقة: العميل الواحد لديه قائمة من المواقع
        public ICollection<Website> Websites { get; set; }
    }
}
