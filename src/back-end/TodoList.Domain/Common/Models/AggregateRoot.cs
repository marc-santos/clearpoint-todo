﻿using System.Diagnostics.CodeAnalysis;

 namespace TodoList.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id)
        {
        }

        #pragma warning disable CS8618
        [ExcludeFromCodeCoverage(Justification = "Required by EF Core")]
        protected AggregateRoot()
        {
        }
        #pragma warning restore CS8618
    }
}
