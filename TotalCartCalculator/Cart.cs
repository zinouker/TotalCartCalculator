using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCartCalculator
{
    public class Cart
    {
        public List<Product> Products { get; set; }
        public List<Coupon> Coupons { get; set; }
        public decimal Total { get; set; }

        public Cart()
        {
            Products = new List<Product>();
            Coupons = new List<Coupon>();
            Total = 0;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            CheckCouponToApplyOnProduct(product);
        }

        public void AddCoupon(Coupon coupon)
        {
            Coupons.Add(coupon);
            ApplyCoupon(coupon);
        }

        public void ApplyCoupon(Coupon coupon)
        {
            decimal productDiscount = 0;

            // Check to apply ammount of product type coupon
            var productsCount = Products.Where(p => p.Name == coupon.ProductName).Count();

            var amountOfProductType = Coupons.FirstOrDefault(c => c.CouponType == TypeCouponEnum.AmountOfProductType
                                                                    && c.ProductName == coupon.ProductName
                                                                    && !c.IsApplied
                                                                    && c.NumberOfProducts == productsCount);
            if (amountOfProductType != null)
            {
                productDiscount = amountOfProductType.Amount;
                amountOfProductType.IsApplied = true;
                Total = Total - productDiscount;
            }
        }

        public void CheckCouponToApplyOnProduct(Product product)
        {
            decimal productDiscount = 0;
            decimal productTotal = 0;

            // Check to apply AllOff Coupon tyoe
            if (Coupons.Any(c => c.CouponType == TypeCouponEnum.AllOff))
            {
                var coupon = Coupons.FirstOrDefault(c => c.CouponType == TypeCouponEnum.AllOff);

                productDiscount = productDiscount + (product.Price * (coupon.Amount / 100));
            }

            // check to apply amount of product type Coupon
            var productsCount = Products.Where(p => p.Name == product.Name).Count();

            var amountOfProductTypeCoupon = Coupons.FirstOrDefault(c => c.CouponType == TypeCouponEnum.AmountOfProductType
                                                                    && c.ProductName == product.Name
                                                                    && !c.IsApplied
                                                                    && c.NumberOfProducts == productsCount);
            if (amountOfProductTypeCoupon != null)
            {
                productDiscount = productDiscount + amountOfProductTypeCoupon.Amount;
                amountOfProductTypeCoupon.IsApplied = true;
            }

            productTotal = product.Price - productDiscount;

            // check to apply next product off type Coupon
            var nextProductOff = Coupons.FirstOrDefault(c => c.CouponType == TypeCouponEnum.NextProductOff && !c.IsApplied);
            if (nextProductOff != null)
            {
                productTotal = (product.Price - productDiscount) * (nextProductOff.Amount / 100);
                nextProductOff.IsApplied = true;
            }

            Total = Total + productTotal;
        }

        public decimal GetTotalPrice()
        {
            return Math.Round(Total, 2);
        }

    }
}
