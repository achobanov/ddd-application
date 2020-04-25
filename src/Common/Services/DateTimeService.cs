namespace Blog.Common.Services
{
    using System;
    using Blog.Application.Contracts;

    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
