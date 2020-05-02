using System;
using Blog.Domain.Articles;
using Blog.Domain.Authors;
using Blog.Domain.Infrastructure.Entities;

namespace Blog.Domain.Comments
{
    public class Comment : AuditableEntity
    {
        private string content;

        internal Comment(string content, Article article, Author author = null)
        {
            this.Content = content;
            this.Article = article;
            this.Author = author;
        }

        internal Comment(string content, int articleId, int? authorId = null)
        {
            this.Content = content;
            this.ArticleId = articleId;
            this.AuthorId = authorId;
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

        public Article Article { get; }

        public int ArticleId { get; }

        public Author Author { get; }

        public int? AuthorId { get; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }
    }
}
