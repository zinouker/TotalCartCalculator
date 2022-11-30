using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCartCalculator
{
    public class Coupon
    {
        public TypeCouponEnum CouponType { get; set; }
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public int NumberOfProducts { get; set; }
        public bool IsApplied { get; set; }

        public Coupon(TypeCouponEnum type, decimal percentage)
        {
            CouponType = type;
            Amount = percentage;
        }

        public Coupon(TypeCouponEnum type, decimal percentage, string productName, int numberOfProducts)
        {
            CouponType = type;
            Amount = percentage;
            ProductName = productName;
            NumberOfProducts = numberOfProducts;
        }
    }
}
