using System.Collections.Generic;
using Blog.Domain.Infrastructure;
using Blog.Domain.Infrastructure.Entities;

namespace Blog.Domain.Entities
{
    public class Person : Entity
    {
        private string username;

        public Person()
        {

        }

        public Person(string username, string identityId)
        {
            this.Username = username;
            this.IdentityId = identityId;
        }

        public string Username {
            get => this.username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomainException("Username cannot be null");
                }

                this.username = value;
            }
        }

        public string IdentityId { get; private set; }

        public ICollection<Article> Articles { get; } = new List<Article>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
