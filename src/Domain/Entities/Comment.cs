using System;
using Blog.Domain.Infrastructure.Entities;
using Blog.Domain.Exceptions;

namespace Blog.Domain.Entities
{

    public class Comment : AuditableEntity
    {
        private string content;

        public Comment(string content, string createdBy)
        {
            this.Content = content;
            this.CreatedBy = createdBy;
        }

        public string Content
        {
            get => this.content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidArticleException("Comment content cannot be null.");
                }

                this.content = value;
            }
        }

        public Article Article { get; set; }

        public int ArticleId { get; set; }

        public Person Author { get; set; }

        public int AuthorId { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }
    }
}
