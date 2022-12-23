using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Models.ViewModels;

namespace MyStore.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository _repository;
		public int PageSize = 4;

		public ProductController(IProductRepository repo)//вот тут из Program контроллер понимает, что нужно применять класс Fake.
														 //Это и есть внедрение зависимостей
		{
			_repository = repo;
		}

		public ViewResult List(string category, int productPage = 1) =>
			View(new ProductListViewModel
			{
				Products = _repository.Products
					.Where(p => category == null || p.Category == category)
					.OrderBy(p => p.ProductID)
					.Skip((productPage - 1) * PageSize) //пропускаем те товары, которые располагаются до начала текущей страницы
					.Take(PageSize),
				PageInfo = new PagingInfo
				{
					CurrentPage = productPage,
					ItemsPerPage = PageSize,
					TotalItems = _repository.Products.Count()
				},
				CurrentCategory = category
			});
	}
}
