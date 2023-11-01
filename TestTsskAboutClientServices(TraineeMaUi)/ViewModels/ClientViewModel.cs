using TestTsskAboutClientServices_TraineeMaUi_.Models;

namespace TestTsskAboutClientServices_TraineeMaUi_.ViewModels
{
    public class ClientViewModel
    {
        public IEnumerable<ClientIdModel>? ClientsId { get; set; }

        public Client? SelectedClient { get; set; }

        public List<Product>? ClientsOrders {  get; set; }

        public IEnumerable<ProductIdModel>? ProductsId { get; set; }

        public decimal? PriceWidthDiscount { get; set; }
    }
}
