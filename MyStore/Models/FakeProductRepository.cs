using System.Linq;
using System.Net.Sockets;

namespace MyStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<ProductClass> Products => new List<ProductClass>()
        {
            new ProductClass { Name = "Jacket", Price = 3500 },
            new ProductClass { Name = "Suit", Price = 4000 },
            new ProductClass { Name = "Pants", Price = 1000 }
        }.AsQueryable<ProductClass>(); //служит для преобразования фиксированной коллекции, чтобы реализовать интерфейс
                                  //и позволить создавать совместимое фиктивное хранилище
    }
}
