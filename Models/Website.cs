using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models
{
    // تعريف حالات المشروع
    public enum ProjectStatus
    {
        Pending,
        Design,
        Development,
        ContentReview,
        Completed
    }

    public class Website
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم النطاق")]
        public string DomainName { get; set; }

        public bool IsHostingReady { get; set; }

        public ProjectStatus Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        // مفتاح أجنبي لربط الموقع بالعميل
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        // علاقة: الموقع الواحد له قائمة من المهام
        public ICollection<TaskItem> Tasks { get; set; }
    }
}