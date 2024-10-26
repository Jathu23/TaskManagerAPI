using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly dueDate { get; set; }
        [Required]
        public string Priority { get; set; }
    }
}
