﻿using System;
using Blog.Domain.Infrastructure;

namespace Blog.Domain.Articles
{
    public class ArticleException : DomainException
    {
        private static readonly Type Type = typeof(Article);

        public ArticleException(string propertyName)
            : base(Type.Name, propertyName)
        {
        }

        public ArticleException(string propertyName, string messageTemplate)
            : base(Type.Name, propertyName, messageTemplate)
        {
        }
    }
}
