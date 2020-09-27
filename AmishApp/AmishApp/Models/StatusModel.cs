using System;

namespace AmishApp.Models
{
    public class StatusModel
    {
        public string StatusId { get; set; }

        public string Description { get; set; }

        public string TextMessage { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
