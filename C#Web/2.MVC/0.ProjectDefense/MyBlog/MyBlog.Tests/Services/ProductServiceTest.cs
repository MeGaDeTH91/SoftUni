namespace MyBlog.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyBlog.CommonModels.BindingModels.Products;
    using MyBlog.Data;
    using MyBlog.Services;
    using MyBlog.Tests.Common;

    [TestClass]
    public class ProductServiceTest
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
        public void AddProduct_WithValidData_ShouldWorkCorrectly()
        {            
            var productService = new ProductService(this.dbContext, this.mapper);

            var validProductModel = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct1);

            var returnId = productService.AddProductAsync(validProductModel).Result;

            Assert.AreEqual(TestConstants.Products.Id_Index_1, returnId);
        }

        [TestMethod]
        public void AddProduct_WithInValidData_ShouldThrowException()
        {
            var productService = new ProductService(this.dbContext, this.mapper);

            var invalidProductModel = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.invalidProduct1);
            Assert.AreEqual(true, productService.AddProductAsync(invalidProductModel).IsFaulted);
        }

        [TestMethod]
        public void AddMultipleProducts_WithInValidData_ShouldThrowException()
        {
            var productService = new ProductService(this.dbContext, this.mapper);

            var invalidProductModel = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.invalidProduct1);
            var invalidProductModel2 = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.invalidProduct2);

            Assert.AreEqual(true, productService.AddProductAsync(invalidProductModel).IsFaulted);
            Assert.AreEqual(true, productService.AddProductAsync(invalidProductModel2).IsFaulted);
        }

        [TestMethod]
        public void AddMultipleValidProducts_ShouldWorkCorrectly()
        {
            var productService = new ProductService(this.dbContext, this.mapper);

            var validProductModel = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct1);
            var validProductModel2 = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct2);

            var validProductsList = new List<AddProductBindingModel>()
            {
                validProductModel,
                validProductModel2
            };

            var returnId1 = productService.AddProductAsync(validProductModel).Result;
            var returnId2 = productService.AddProductAsync(validProductModel2).Result;

            var resultProducts = productService.GetAllProducts().ToList();

            Assert.AreNotEqual(TestConstants.Products.ErrorId, resultProducts.Select(x => x.Id));
            Assert.AreEqual(TestConstants.Products.ValidProductsAddedExpected, resultProducts.Count);
        }

        [TestMethod]
        public void GetAllProducts_WithNoProducts_ShouldReturnEmptyCollection()
        {
            var productService = new ProductService(this.dbContext, this.mapper);
            
            var resultProducts = productService.GetAllProducts().ToList();

            Assert.AreEqual(TestConstants.Products.NoProductsAddedExpected, resultProducts.Count);
        }

        [TestMethod]
        public void GetAllProducts_WithSomeProducts_ShouldWorkCorrectly()
        {
            var productService = new ProductService(this.dbContext, this.mapper);

            var validProductModel = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct1);
            var validProductModel2 = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct2);

            var validProductsList = new List<AddProductBindingModel>()
            {
                validProductModel,
                validProductModel2
            };

            var returnId1 = productService.AddProductAsync(validProductModel).Result;
            var returnId2 = productService.AddProductAsync(validProductModel2).Result;

            var resultProducts = productService.GetAllProducts().ToList();

            for (int index = 0; index < resultProducts.Count; index++)
            {
                var actualProduct = resultProducts[index];
                var expectedProduct = validProductsList[index];
                
                Assert.AreEqual(expectedProduct.Price, actualProduct.Price);
                Assert.AreEqual(expectedProduct.PhotoURL, actualProduct.PhotoURL);
                Assert.AreEqual(expectedProduct.ProductName, actualProduct.ProductName);
            }
        }

        [TestMethod]
        public void DeleteProduct_ShouldWorkCorrectly()
        {
            var productService = new ProductService(this.dbContext, this.mapper);

            var validProductModel = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct1);
            var validProductModel2 = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct2);

            var validProductsList = new List<AddProductBindingModel>()
            {
                validProductModel,
                validProductModel2
            };

            var returnId1 = productService.AddProductAsync(validProductModel).Result;
            var returnId2 = productService.AddProductAsync(validProductModel2).Result;

            var isDeleted = productService.DeleteProductAsync(returnId1).Result;

            var resultProduct = productService.GetAllProducts().ToList();

            Assert.AreEqual(TestConstants.Products.IsDeletedTrue, isDeleted);
            Assert.AreEqual(TestConstants.Products.ExpectedProductsAfterDeletion, resultProduct.Count);
        }

        [TestMethod]
        public void DeleteNonExistingProduct_ShouldWorkCorrectly()
        {
            var productService = new ProductService(this.dbContext, this.mapper);

            var validProductModel = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct1);
            var validProductModel2 = this.mapper.Map<AddProductBindingModel>(TestConstants.Products.validProduct2);

            var validProductsList = new List<AddProductBindingModel>()
            {
                validProductModel,
                validProductModel2
            };

            var returnId1 = productService.AddProductAsync(validProductModel).Result;
            var returnId2 = productService.AddProductAsync(validProductModel2).Result;

            var isDeleted = productService.DeleteProductAsync(TestConstants.Products.NonExistingId).Result;

            var resultProduct = productService.GetAllProducts().ToList();

            Assert.AreEqual(TestConstants.Products.IsDeletedFalse, isDeleted);
            Assert.AreEqual(TestConstants.Products.ExpectedProductsAfterNoDeletion, resultProduct.Count);
        }
    }
}
