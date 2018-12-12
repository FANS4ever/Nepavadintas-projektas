using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gear.Models;


namespace Gear.ViewModels
{
    public class ReceiptViewModel
    {
        public Receipt receipt { get; set; }
        public List<PaymentType> paymentType { get; set; }
    }
}