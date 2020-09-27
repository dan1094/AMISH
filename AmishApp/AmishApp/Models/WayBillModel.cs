using System;

namespace AmishApp.Models
{
    public class WayBillModel
    {
        public string WayBillId { get; set; }

        public BillModel BillProperty { get; set; }

        public OperatorModel OperatorProperty { get; set; }

        public DateTime MaxDeliveryDate { get; set; }

        public DateTime MinDeliveryDate { get; set; }

        public StatusModel StatusProperty { get; set; }

        public string WeightPackage { get; set; }

        public string UrlproductImage { get; set; }
    }
}
