using System.ComponentModel.DataAnnotations;

namespace MiniCrudMvc.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public bool IsDone { get; set; }
    }
}