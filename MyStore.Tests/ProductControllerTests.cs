using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Controllers;
using MyStore.Models;
using MyStore.Models.ViewModels;

namespace MyStore.Tests
{
	public class ProductControllerTests
	{
		[Fact]
		public void Can_Paginate()
		{
			//Организация
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

			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;
			//Действие
			var result = controller.List(null, 2).ViewData.Model as ProductListViewModel;

			//Утверждение
			var prodArray = result.Products.ToArray();
			Assert.True((prodArray.Length == 3));
			Assert.Equal("P4", prodArray[0].Name);
			Assert.Equal("P5", prodArray[1].Name);
		}

		[Fact]
		public void Can_Send_Pagination_View_Model()
		{
			//Организация
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products)
				.Returns((new ProductClass[]
			{
				new ProductClass { ProductID = 1, Name = "P1" },
				new ProductClass { ProductID = 2, Name = "P2" },
				new ProductClass { ProductID = 3, Name = "P3" },
				new ProductClass { ProductID = 4, Name = "P4" },
				new ProductClass { ProductID = 5, Name = "P5" }
			}).AsQueryable<ProductClass>());

			ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

			//Действие
			var result = controller.List(null, 2).ViewData.Model as ProductListViewModel;
			//Утверждение
			var pagingInfo = result.PageInfo;
			Assert.Equal(2, pagingInfo.CurrentPage);
			Assert.Equal(3, pagingInfo.ItemsPerPage);
			Assert.Equal(5, pagingInfo.TotalItems);
			Assert.Equal(2, pagingInfo.TotalPages);

		}

		[Fact]
		public void Can_Filter_Products()
		{
			//Организация - создание имитированного хранилища
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns((new ProductClass[]
			{
				new ProductClass { ProductID = 1, Name = "P1", Category = "Cat1" },
				new ProductClass { ProductID = 2, Name = "P2", Category = "Cat2" },
				new ProductClass { ProductID = 3, Name = "P3", Category = "Cat1" },
				new ProductClass { ProductID = 4, Name = "P4", Category = "Cat2" },
				new ProductClass { ProductID = 5, Name = "P5", Category = "Cat3" }
			}).AsQueryable<ProductClass>());
			//Организация - создание контроллера и установка размера страницы в три элемента
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;
			//Действие
			ProductClass[] result =
				(controller.List("Cat2", 1).ViewData.Model as ProductListViewModel).Products.ToArray();
			//Утверждение 
			Assert.Equal(2, result.Length);
			Assert.True(result[0].Name == "P2" && result[0].Category=="Cat2");
			Assert.True(result[1].Name == "P4" && result[1].Category == "Cat2");
		}
	}
}
