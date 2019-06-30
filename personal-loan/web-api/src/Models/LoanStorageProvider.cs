using LoanApi.Models.Definition;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanApi.Models
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
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]??"UseDevelopmentStorage=true");
                _tclient = storageAccount.CreateCloudTableClient();
                _table = _tclient.GetTableReference(LoanEntity.TableName + System.Configuration.ConfigurationManager.AppSettings["Environment"]??"LocDev");
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

        public static LoanDefinition GetLoanById(string Id)
        {
            var retriveOperation = TableOperation.Retrieve<LoanEntity>(LoanEntity.FixedPartitionKey, Id);

            var ret = getTableHandler().Execute(retriveOperation);
            var entity = ret?.Result as LoanEntity;
            return entity?.ToDefinition();
        }
    }
}