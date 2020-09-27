using System;

namespace AmishApp.Models
{
    public class BillModel
    {
        public string IdBill { get; set; }

        public string ProductId { get; set; }

        public DateTime BuyDate { get; set; }

        public ClientModel ClientProperty { get; set; }

        public SellerModel SellerProperty { get; set; }
    }
}
