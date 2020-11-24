using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.Entities;
using Microsoft.AspNetCore.Http;

namespace MarriageRegistration.WebApi.DataAccess
{
    public class DataContext : IDataContext
    {
        private readonly IAmazonDynamoDB _amazonDynamoDb;

        public DataContext(IAmazonDynamoDB amazonDynamoDb)
        {
            _amazonDynamoDb = amazonDynamoDb;

        }

       
        public async Task<PutItemResponse> SaveDetails(PutItemRequest request, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            try
            {
                var response = await _amazonDynamoDb.PutItemAsync(request);

                 return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetItemResponse> GetItemDetails(GetItemRequest request)
        {
            try
            {
                 var response = await _amazonDynamoDb.GetItemAsync(request);

                 return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }

}

        public async Task<DeleteItemResponse> DeleteDetails(DeleteItemRequest request)
        {
            try
            {
                 var response = await _amazonDynamoDb.DeleteItemAsync(request);

                 return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
}

        public async Task<ScanResponse> GetPendingRecords(ScanRequest request)
        {
            try
            {
                var response = await _amazonDynamoDb.ScanAsync(request);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

        }

        public async Task<PutItemResponse> PutItem(PutItemRequest request)
        {
            try
            {
                var response = await _amazonDynamoDb.PutItemAsync(request);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
