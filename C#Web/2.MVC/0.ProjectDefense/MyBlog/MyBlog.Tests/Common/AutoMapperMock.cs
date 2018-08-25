namespace MyBlog.Tests.Common
{
    using AutoMapper;
    using MyBlog.App.Mappings;
    using MyBlog.CommonModels.BindingModels.Products;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.Models.ProductsForSale;

    public static class AutoMapperMock
    {
        private class LocalAutoMapperProfile : Profile
        {
            public LocalAutoMapperProfile()
            {
                CreateMap<AddProductBindingModel, Product>(MemberList.Source);
                CreateMap<Product, AddProductBindingModel>(MemberList.Destination);
                CreateMap<Product, ProductConciseViewModel>(MemberList.Destination);
                CreateMap<Product, ProductDetailsViewModel>(MemberList.Destination);
                CreateMap<ProductType, AddProductTypeBindingModel>(MemberList.Destination);
            }
        }

        static AutoMapperMock()
        {
            Mapper.Initialize(configuration => configuration.AddProfile<LocalAutoMapperProfile>());
        }

        public static IMapper GetInstance()
        {
            return Mapper.Instance;
        }
    }
}
