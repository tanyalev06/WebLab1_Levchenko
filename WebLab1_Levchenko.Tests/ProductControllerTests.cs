using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebLab1_Levchenko.Controllers;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;
using WebLab1_Levchenko.Models;
using WebLab1_Levchenko;
using Xunit;

namespace WebLab1_Levchenko.Tests
{
    public class ProductControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests() => _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "testDb").Options;

        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {

            var controllerContext = new ControllerContext(); // Контекст контроллера
            var moqHttpContext = new Mock<HttpContext>(); // Макет HttpContext
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
           
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }

            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };

                //controller._cats = TestData.GetCatsList();
                // Act
                var result =  controller.Index(pageNo: page, group: null) as ViewResult;
                var model = result?.Model as List<Cats>;
                // Assert
                Assert.NotNull(model);
                Assert.Equal(qty, model.Count);
                Assert.Equal(id, model[0].CatsID);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers).Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController()
                { ControllerContext = controllerContext };
                var comparer = Comparer<Cats>.GetComparer((d1, d2) => d1.CatsID.Equals(d2.CatsID));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Cats>;
                // assert
                Assert.Equal(2, model.Count);
                Assert.Equal(context.Cats.ToArrayAsync().GetAwaiter().GetResult()[2], model[0], comparer);
            }
        }
    }
}
        