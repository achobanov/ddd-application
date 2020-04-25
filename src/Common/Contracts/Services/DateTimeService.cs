namespace Blog.Common.Contracts.Services
{
    using System;
    using Blog.Common.Contracts;

    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
