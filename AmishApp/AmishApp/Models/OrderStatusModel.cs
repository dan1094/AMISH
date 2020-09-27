using System;

namespace AmishApp.Models
{
    public class OrderStatusModel
    {
        public StatusModel StatusProperty { get; set; }

        public string Comments { get; set; }

        public DateTime Update { get; set; }
    }
}
