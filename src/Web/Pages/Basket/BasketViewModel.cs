namespace Microsoft.eShopWeb.Web.Pages.Basket;

public class BasketViewModel
{
    public int Id { get; set; }
    
    public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
    
    public string? BuyerId { get; set; }

    public bool WasDiscountApplied()
    {
        var total = Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        if (Items.Sum(x => x.Quantity) >= 3)
        {
            if (total >= 50)
            {
                return true;
            }
        }
        return false;
    }

    public decimal Total()
    {
        var total = Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        if (this.WasDiscountApplied())
        {
            if (total >= 50 && total < 100)
            {
                return Math.Round(total * new decimal(0.9), 2);
            }
            if (total >= 100)
            {
                return Math.Round(total * new decimal(0.8), 2);
            }
        }
        return total;
    }
}
