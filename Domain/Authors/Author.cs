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

        public Author(string username)
            => this.Username = username;

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AuthorException(nameof(this.Username));
                }

                this.username = value;
            }
        }

        public ICollection<Article> Articles { get; } = new List<Article>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();

        public void SetUser(string username)
        {
            if (this.Username != null)
            {
                throw new AuthorException(
                    nameof(this.Username),
                    $"Cannot set username '{username}' Author. It is already set to '{this.Username}'");
            }

            this.Username = username;
        }
    }
}
