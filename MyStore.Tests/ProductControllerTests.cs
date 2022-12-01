using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Controllers;
using MyStore.Models;

namespace MyStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new ProductClass[]
            {
                new ProductClass { ProductID = 1, Name = "P1" },
                new ProductClass { ProductID = 2, Name = "P2" },
                new ProductClass { ProductID = 3, Name = "P3" },
                new ProductClass { ProductID = 4, Name = "P4" },
                new ProductClass { ProductID = 5, Name = "P5" },
                new ProductClass { ProductID = 6, Name = "P6" }
            }).AsQueryable<ProductClass>());
            var controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            var result = controller.List(2).ViewData.Model as IEnumerable<ProductClass>;
            //assert
            var prodArray = result.ToArray();
            Assert.True((prodArray.Length == 3));
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}
