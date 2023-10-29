using System;
using System.Collections.Generic;

namespace TestTsskAboutClientServices_TraineeMaUi_.Models;

public partial class Client
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public int? Discount { get; set; }

    public virtual ICollection<ClientOrder> ClientOrders { get; set; } = new List<ClientOrder>();
}
