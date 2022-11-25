namespace MyStore.Models
{
    public interface IProductRepository//позволяет получать объекты из БД
    {
        //IQueryable предпочтительнее IEnumerable, для эффективности запросов коллекций из БД
        IQueryable<ProductClass> Products { get; } //позволяет вызывающему коду получать последовательность объектов
    }
}
