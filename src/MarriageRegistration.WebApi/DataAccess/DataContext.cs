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
            var response = await _amazonDynamoDb.PutItemAsync(request);

            return response;
        }

        public async Task<GetItemResponse> GetDetails(GetItemRequest request)
        {
            var response = await _amazonDynamoDb.GetItemAsync(request);

            return response;

        }

        public async Task<DeleteItemResponse> DeleteDetails(DeleteItemRequest request)
        {

            var response = await _amazonDynamoDb.DeleteItemAsync(request);

            return response;
        }

        public async Task<ScanResponse> GetPendingRecords(ScanRequest request)
        {
            var response = await _amazonDynamoDb.ScanAsync(request);

            return response;

        }

        public async Task<GetItemResponse> GetApprovedRecord(GetItemRequest request)
        {
            var response = await _amazonDynamoDb.GetItemAsync(request);

            return response;

        }
    }
}
