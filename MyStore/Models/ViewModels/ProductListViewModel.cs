namespace MyStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductClass> Products { get; set; }
        public PagingInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
