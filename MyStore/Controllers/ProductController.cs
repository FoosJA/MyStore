using Microsoft.AspNetCore.Mvc;
using MyStore.Models;

namespace MyStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        
        public ProductController(IProductRepository repo)//вот тут из Program контроллер понимает, что нужно применять класс Fake.
                                                         //Это и есть внедрение зависимостей
        {
            _repository = repo;
        }

        public ViewResult List() => View(_repository.Products);
    }
}
