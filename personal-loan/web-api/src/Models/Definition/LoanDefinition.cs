using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loanapi.Models.Definition
{
    public class LoanDefinition : object
    {
        public string Id { get; set; }
        public int Balance { get; set; }
    }
}