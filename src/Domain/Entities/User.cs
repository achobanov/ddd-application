namespace Blog.Domain.Entities
{
    using System.Collections.Generic;
    using Blog.Domain.Common;

    public class User : AuditableEntity
    {
        User(string IdentityId)
        {
            this.IdentityId = IdentityId;
        }
        public string Username { get; set; }

        public string IdentityId { get; }

        public ICollection<Article> Articles { get; } = new List<Article>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
