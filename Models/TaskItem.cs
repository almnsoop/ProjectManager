using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        // مفتاح أجنبي لربط المهمة بالموقع
        public int WebsiteId { get; set; }
        [ForeignKey("WebsiteId")]
        public Website Website { get; set; }

        // مفتاح أجنبي لربط المهمة بعضو الفريق
        public int AssignedToId { get; set; }
        [ForeignKey("AssignedToId")]
        public TeamMember TeamMember { get; set; }
    }
}