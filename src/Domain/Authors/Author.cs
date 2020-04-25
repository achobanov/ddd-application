using System.Collections.Generic;
using Blog.Domain.Articles;
using Blog.Domain.Comments;
using Blog.Domain.Infrastructure.Entities;

namespace Blog.Domain.Authors
{
    public class Author : Entity
    {
        private string username;

        public Author()
        {

        }

        public Author(string username, string identityId)
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
                    throw new AuthorException(nameof(this.Username));
                }

                this.username = value;
            }
        }

        public string IdentityId { get; private set; }

        public ICollection<Article> Articles { get; } = new List<Article>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
