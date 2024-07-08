using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TodoList.Infrastructure.Data.Models
{
    [ExcludeFromCodeCoverage(Justification = "Model")]
    [Table("todo_items")]
    public class TodoItemDto
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.Empty;
        
        [Required]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("is_completed")]
        public bool isCompleted { get; set; } = false;
        
        [Required]
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.MinValue;

        [Required]
        [Column("modified_at")]
        public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.MinValue;
    }
}
