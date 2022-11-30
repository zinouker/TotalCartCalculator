// See https://aka.ms/new-console-template for more information
using TotalCartCalculator;

var cart = new Cart();

var allOff5Coupon = new Coupon(TypeCouponEnum.AllOff, 5);

cart.AddCoupon(allOff5Coupon);

cart.AddProduct(new Product { Name = "Pen", Price = 10 });

cart.AddProduct(new Product { Name = "Book", Price = 15 });

var off5AmountForThirdPenCoupon = new Coupon(TypeCouponEnum.AmountOfProductType, 5, "Pen", 3);

cart.AddCoupon(off5AmountForThirdPenCoupon);

var off50PercentFornextProductCoupon = new Coupon(TypeCouponEnum.NextProductOff, 50);

cart.AddCoupon(off50PercentFornextProductCoupon);

cart.AddProduct(new Product { Name = "Pen", Price = 10 });

cart.AddProduct(new Product { Name = "NoteBook", Price = 18 });

var off2AmountForSecondPenCoupon = new Coupon(TypeCouponEnum.AmountOfProductType, 2, "Pen", 2);

cart.AddCoupon(off2AmountForSecondPenCoupon);

cart.AddProduct(new Product { Name = "Pen", Price = 16 });

cart.AddProduct(new Product { Name = "Pen", Price = 10 });


Console.WriteLine("The total price of your cart is : " + cart.GetTotalPrice());


