using System;
using System.Collections.Generic;

namespace TestTsskAboutClientServices_TraineeMaUi_.Models;

public partial class ClientOrder
{
    public int Id { get; set; }

    public string ClientId { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
