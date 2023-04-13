using Microsoft.eShopWeb.Web.Pages.Basket;

namespace UnitTests;

public class UnitTest1
{
    [Fact]
    public void ShouldApplyPromo()
    {
        var basketViewModel = new BasketViewModel();
        basketViewModel.Items.Add(new BasketItemViewModel()
        {
            UnitPrice = new decimal(55.0)
        });

        Assert.Equal(new decimal(55.0 * .9), basketViewModel.Total()); // she'll want to add this test
    }
}
