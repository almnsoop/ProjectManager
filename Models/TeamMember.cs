using ProjectManager.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; } // مبرمج، مصمم، الخ

        // علاقة: العضو الواحد لديه قائمة من المهام
        public ICollection<TaskItem> Tasks { get; set; }
    }
}