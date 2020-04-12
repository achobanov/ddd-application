namespace Blog.Domain.Entities
{
    using System.Collections.Generic;
    using Blog.Domain.Common;

    public class DomainUser : DomainEntity
    {
        public DomainUser()
        {

        }
        public DomainUser(string userName, string identityId)
        {
            this.Username = userName;
            this.IdentityId = identityId;
        }
        public string Username { get; set; }

        public string IdentityId { get; private set; }

        public ICollection<Article> Articles { get; } = new List<Article>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
