namespace Blog.Domain.Entities
{
    using System.Collections.Generic;
    using Blog.Domain.Infrastructure;

    public class Person : Entity
    {
        public Person()
        {

        }
        public Person(string userName, string identityId)
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
