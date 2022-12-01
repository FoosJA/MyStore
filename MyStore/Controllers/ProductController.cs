using Microsoft.AspNetCore.Mvc;
using MyStore.Models;

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

        public ViewResult List(int productPage) => 
            View(_repository.Products
                .OrderBy(p=>p.ProductID)
                .Skip((productPage-1)*PageSize) //пропускаем те товары, которые располагаются до начала текущей страницы
                .Take(PageSize));
    }
}
