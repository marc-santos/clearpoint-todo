using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TodoList.Domain.TodoItems.Entities;
using TodoList.Domain.TodoItems.ValueObjects;

namespace TodoList.Infrastructure.Persistence.Configurations
{
    [ExcludeFromCodeCoverage(Justification = "Wiring")]
    internal class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
           ConfigureTodoItemsTable(builder);
        }

        private void ConfigureTodoItemsTable(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("todo_items");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => TodoItemId.Create(value));

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IsCompleted)
                .HasColumnName("is_completed")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(e => e.ModifiedAt)
                .HasColumnName("modified_at")
                .IsRequired();
        }
    }
}
