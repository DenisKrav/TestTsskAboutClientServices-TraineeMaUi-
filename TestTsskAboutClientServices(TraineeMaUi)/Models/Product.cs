using System;
using System.Collections.Generic;

namespace TestTsskAboutClientServices_TraineeMaUi_.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();
}
