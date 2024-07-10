﻿namespace TodoList.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id)
        {
        }

        #region Required for EF Core

        #pragma warning disable CS8618
        protected AggregateRoot()
        {
        }
        #pragma warning restore CS8618

        #endregion
    }
}
