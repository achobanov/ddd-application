using System;
using EnduranceContestManager.Domain.Articles;
using EnduranceContestManager.Domain.Authors;
using EnduranceContestManager.Domain.Infrastructure.Entities;

namespace EnduranceContestManager.Domain.Comments
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

        public Author Author { get; set; }

        public int? AuthorId { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }
    }
}
