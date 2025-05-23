using System;

namespace MeinProjekt;

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public CartItem(Product product, int quantity = 1)
    {
        Product = product;
        Quantity = quantity;
    }
}
