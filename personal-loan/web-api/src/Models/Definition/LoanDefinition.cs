using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApi.Models.Definition
{
    public class LoanDefinition : object
    {
        public string Id { get; set; }
        public int Balance { get; set; }
    }
}