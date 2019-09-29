﻿using Beer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer.Utility
{
    public class SD
    {
        public const string DefaultBeerImage = "default_image.png";

        public const string ManagerUser = "Manager";
        public const string OfficeUser = "Office";
        public const string FrontDeskUser = "FrontDesk";
        public const string CustomerEndUser = "Customer";
        public const string cntShoppingCart = "ssCartCount";
        public const string cntCouponCode = "ssCouponCode";

        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];

            int arrayIndex = 0;

            bool inside = false;

            for(int i=0; i < source.Length; i++)
            {
                char let = source[i];
                if(let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                    
                }
            }

            return new string(array, 0, arrayIndex);

        }

        public static double DiscountedPrice(Coupon couponFromDb, double originalOrderTotal)
        {

            if(couponFromDb == null)
            {
                return originalOrderTotal;
            }

            if(couponFromDb.MinimumAmount > originalOrderTotal)
            {
                return originalOrderTotal;
            }
            else
            {
                if(Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Dollar)
                {
                    return Math.Round(originalOrderTotal - couponFromDb.Discount, 2);
                }

                if(Convert.ToInt32(couponFromDb.CouponType) == (int) Coupon.ECouponType.Percent)
                {
                    return Math.Round(originalOrderTotal - (originalOrderTotal * couponFromDb.Discount / 100), 2);
                }
            }

            return originalOrderTotal;


        }
        
    }
}
