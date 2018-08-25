namespace MyBlog.Tests.Common
{
    using Microsoft.EntityFrameworkCore;
    using MyBlog.Data;
    using System;

    public class BlogDatabaseMock
    {
        public static BlogDataDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<BlogDataDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new BlogDataDbContext(options);
        }
    }
}
