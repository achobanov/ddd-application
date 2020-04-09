namespace Blog.Domain.Entities
{
    using System.Collections.Generic;
    using Blog.Domain.Common;

    public class User : AuditableEntity
    {
        public string Username { get; set; }

        public string IdentityId { get; set; }

        public ICollection<Article> Articles { get; } = new List<Article>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
