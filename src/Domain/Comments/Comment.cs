using System;
using Blog.Domain.Articles;
using Blog.Domain.Authors;
using Blog.Domain.Infrastructure.Entities;

namespace Blog.Domain.Comments
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
                    throw new CommentException(nameof(this.Content));
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
