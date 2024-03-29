﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beer.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public double OriginalTotalOrder { get; set; }


        [Required]
        [DisplayFormat(DataFormatString ="{0:C}")]
        [Display(Name="Order Total")]
        public double OrderTotal { get; set; }

        [Required]
        [Display(Name="Pickup Time")]
        public DateTime PickUpTime { get; set; }

        [NotMapped]
        [Required]
        public DateTime PickUpDate { get; set; }

        [Display(Name="Coupon Code")]
        public string CouponCode { get; set; }

        public string CouponCodeDiscount { get; set; }

        public string Status { get; set; }

        public string PaymentStatus { get; set; }


        public string Comments { get; set; }

        [Display(Name = "Pickup Name")]
        public string PickUpName { get; set; }

        [Display(Name = "Pickup Number")]
        public string PickUpNumber { get; set; }

        public string TransactionId { get; set; }


    }
}
