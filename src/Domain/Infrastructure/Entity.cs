﻿namespace Blog.Domain.Common
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }

        // Add GetHashCode(), Equals(), etc.
    }
}