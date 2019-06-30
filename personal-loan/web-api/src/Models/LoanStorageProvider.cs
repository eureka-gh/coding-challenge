using loanapi.Models.Definition;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loanapi.Models
{
    public class LoanStorageProvider
    {
        private static CloudTableClient _tclient = null;
        private static CloudTable _table;

        private static CloudTable getTableHandler()
        {
            Init();
            return _table;
        }

        public static void Init()
        {
            if (_tclient == null)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
                _tclient = storageAccount.CreateCloudTableClient();
                _table = _tclient.GetTableReference(LoanEntity.TableName + Environment.GetEnvironmentVariable("Environment")??"LocDev");
                _table.CreateIfNotExists();
            }
        }

        public static List<LoanDefinition> GetLoansByUserId(string userId)
        {
            var all = new List<LoanDefinition>();
            TableQuery<LoanEntity> query = new TableQuery<LoanEntity>().Where(
                   TableQuery.GenerateFilterCondition("UserId", QueryComparisons.Equal, userId));

            all.AddRange(getTableHandler().ExecuteQuery(query)?.Select(e => e.ToDefinition()).ToList());
            return all;
        }
    }
}