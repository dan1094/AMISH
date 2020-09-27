using System.Collections.Generic;

namespace AmishApp.Models
{
    public class BillRequestModel
    {
        public string BillIdSearch { get; set; }

        public List<BillModel> BillModelProperty { get; set; }
    }
}
