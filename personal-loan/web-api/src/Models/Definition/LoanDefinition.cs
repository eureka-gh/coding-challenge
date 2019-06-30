using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApi.Models.Definition
{
    public class LoanDefinition : object
    {
        public string id { get; set; }
        public int balance { get; set; }
        public int interest { get; set; }
        public int earlyRepaymentFee { get; set; }
        public int payoutOrCarryover { get; set; }
    }
}