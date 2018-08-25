namespace MyBlog.Services
{
    using AutoMapper;
    using MyBlog.Data;

    public class BaseBlogService
    {
        protected const int ErrorId = -1;
        protected const string ErrorUserId = "NoSuchUser";

        protected BaseBlogService(
            BlogDataDbContext context,
            IMapper mapper)
        {
            this.DbContext = context;
            this.Mapper = mapper;
        }

        protected BlogDataDbContext DbContext { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
