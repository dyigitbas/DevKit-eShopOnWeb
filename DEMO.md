`Pages/index.cshtml`
```
<div class="banner">
    <h2>Take 5% off when your total is more than $50!</h2>
</div>
```

```
    public bool WasPromotionApplied()
    {
        var total = Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        if (Items.Count = 3 && total >= 50)
        {
            return true;
        }
        return false;

    }
```

```
    public decimal Total()
    {
        var total = Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);

        if (Items.Count > 3)
        {
            if (total >= 50 && total <= 100)
            {
                total = Math.Round(total * new decimal(0.9), 2);
            }
            if (total >= 100)
            {
                total = Math.Round(total * new decimal(0.8), 2);
            }
        }

        return total;
    }
```

`Basket/index.cshtml`
```
                            @if (Model.BasketModel.WasPromotionApplied || Model.BasketModel.Total() > 50)
                            {
                                    <section class="esh-basket-title col-xs-2">Congratulations! You got a discount!</section>
                            }
```


`Tests`
```
    public void ShouldApply50Promo()
    {
        var basketViewModel = new BasketViewModel();
        basketViewModel.Items.Add(new BasketItemViewModel()
        {
            UnitPrice = new decimal(50.0),
            Quantity = 1
        });

        Assert.Equal(45.0, basketViewModel.Total());
    }

    public void ShouldApply100Promo()
    {
        var basketViewModel = new BasketViewModel();
        basketViewModel.Items.Add(new BasketItemViewModel()
        {
            UnitPrice = new decimal(100.0),
            Quantity = 1
        });

        Assert.Equal(80.0, basketViewModel.Total());
    }
```