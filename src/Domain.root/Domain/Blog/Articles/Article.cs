using EnduranceContestManager.Domain.Core;
using System;
using EnduranceContestManager.Domain.Core.Entities;

namespace EnduranceContestManager.Domain.Blog.Articles
{
    public class Article : AuditableEntity, IAggregateRoot
    {
        private string title;
        private string content;

        public Article()
        {
        }

        public Article(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArticleException(nameof(this.Title));
                }

                if (value.Length > 40)
                {
                    throw new ArticleException(nameof(this.Title), "Article title cannot be more than 40 symbols.");
                }

                this.title = value;
            }
        }

        public string Content
        {
            get => this.content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArticleException(nameof(this.Content), "Article content cannot be null.");
                }

                this.content = value;
            }
        }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }
    }
}
