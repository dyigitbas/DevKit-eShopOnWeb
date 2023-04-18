using Microsoft.eShopWeb.Web.Pages.Basket;

namespace ShopTest;

public class BasketTest
{
    [Fact]
    public void ShouldApply10pDiscount()
    {
        var basketViewModel = new BasketViewModel();
        basketViewModel.Items.Add(new BasketItemViewModel()
        {
            UnitPrice = new decimal(20.0),
            Quantity = 3,
        });

        var total = basketViewModel.Total();
        Assert.Equal(new decimal(60.0 * .9), total);
    }

    [Fact]
    public void ShouldApply20pDiscount()
    {
        var basketViewModel = new BasketViewModel();
        basketViewModel.Items.Add(new BasketItemViewModel()
        {
            UnitPrice = new decimal(20.0),
            Quantity = 5,
        });

        var total = basketViewModel.Total();
        Assert.Equal(new decimal(100.0 * .8), total);
    }
}