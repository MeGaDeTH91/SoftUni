namespace MyBlog.Tests.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using MyBlog.App.Areas.Administrator.Controllers;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.BindingModels.Products;
    using MyBlog.CommonModels.ViewModels.Products;
    using MyBlog.Data;
    using MyBlog.Services;
    using MyBlog.Services.Interfaces;
    using MyBlog.Tests.Common;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class ProductControllerTests
    {
        private BlogDataDbContext dbContext;
        private IMapper mapper;

        [TestInitialize]
        public void TestInitializer()
        {

            this.dbContext = BlogDatabaseMock.GetDbContext();
            this.mapper = AutoMapperMock.GetInstance();
        }

        [TestMethod]
        public void GetAllProducts_CallsGetAllDatabaseProducts()
        {
            var productsService = new Mock<IProductService>();

            var methodCalled = false;
            productsService.Setup(service => service.GetAllProducts())
                .Returns(new List<ProductConciseViewModel>()
                {
                    new ProductConciseViewModel()
                    {
                        Id = TestConstants.Products.Id_Index_3,
                        ProductName = TestConstants.Products.BillyName,
                        PhotoURL = TestConstants.Products.BillyImageURL,
                        Price = TestConstants.Products.BillyPrice
                    }
                })
                .Callback(() => methodCalled = true);

            var controller = new ProductsController(productsService.Object);

            var result = controller.Index();

            Assert.IsTrue(methodCalled);
        }

        [TestMethod]
        public void ProductsIndex_RetursViewResult()
        {
            var productsService = new Mock<IProductService>();

            var controller = new ProductsController(productsService.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var resultModel = result as ViewResult;
        }

        [TestMethod]
        public void ProductsIndex_RetursCorrectModel()
        {
            var productsService = new Mock<IProductService>();

            var controller = new ProductsController(productsService.Object);

            ProductTypeViewModel productTypeViewModel = new ProductTypeViewModel()
            {
                Id = 3,
                TypeName = TestConstants.Products.TypeName
            };

            productsService.Setup(service => service.GetProductType(productTypeViewModel.Id))
                .Returns(new ProductTypeViewModel()
                {
                    Id = productTypeViewModel.Id,
                    TypeName = productTypeViewModel.TypeName
                });
            
            var result = controller.ProductTypeDetails(productTypeViewModel.Id);

            var resultModel = result as ViewResult;
            Assert.IsNotNull(resultModel.Model);
            Assert.IsInstanceOfType(resultModel.Model, typeof(ProductTypeViewModel));

            var productType = (resultModel.Model as ProductTypeViewModel);
            Assert.AreEqual(productTypeViewModel.Id, productType.Id);
            Assert.AreEqual(productTypeViewModel.TypeName, productType.TypeName);
        }
    }
}
