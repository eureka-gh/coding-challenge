using loanapi.Models.Definition;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loanapi.Models
{
    public class LoanEntity: TableEntity
    {
        public static string TableName = "Loan";
        private static string FixedPartitionKey = "Region"; // use fixed partition key as temp solution. should extended for user's location info like postcode or state region

        public LoanEntity() { }

        public LoanEntity(string id, int balance)
        {
            this.RowKey = id;
            this.PartitionKey = FixedPartitionKey;
            this.Balance = balance;
        }

        public string UserId;
        public int Balance;

        public LoanDefinition ToDefinition()
        {
            return new LoanDefinition()
            {
                Id = this.RowKey,
                Balance = this.Balance,
            };
        }
    }
}