using LoanApi.Models.Definition;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApi.Models
{
    public class LoanEntity: TableEntity
    {
        public static string TableName = "PersonalLoan";
        public static string FixedPartitionKey = "Region"; // use fixed partition key as temp solution. should extended for user's location info like postcode or state region

        public LoanEntity() { }

        public LoanEntity(string id, int balance, string userId)
        {
            this.RowKey = id;
            this.PartitionKey = FixedPartitionKey;
            this.UserId = userId;
            this.Balance = balance;
        }

        public string UserId { get; set; }
        public int Balance { get; set; }
        public int Interest { get; set; }
        public int EarlyRepaymentFee { get; set; }

        public LoanDefinition ToDefinition()
        {
            return new LoanDefinition()
            {
                id = this.RowKey,
                balance = this.Balance,
                interest = this.Interest,
                earlyRepaymentFee = this.EarlyRepaymentFee,
                payoutOrCarryover = this.Balance + this.Interest + this.EarlyRepaymentFee,
            };
        }
    }
}