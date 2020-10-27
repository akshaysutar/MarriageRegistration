using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.DataAccess;
using MarriageRegistration.WebApi.Entities;
using MarriageRegistration.WebApi.Factory;
using MarriageRegistration.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarriageRegistration.WebApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AdminController : ControllerBase
    {

        private readonly DataContext _context;

        private readonly IAmazonDynamoDB _amazonDynamoDb;

        private const string PendingRequestsTableName = "PendingRequests";

        private const string ApprovedRequestsTableName = "ApprovedRequests";

        public AdminController(DataContext context, IAmazonDynamoDB amazonDynamoDb)
        {
            _context = context;
            _amazonDynamoDb = amazonDynamoDb;
        }

        // GET api/Admin/init
        [HttpGet]
        [Route("init")]
        public async Task Initialise()
        {
            var request = new ListTablesRequest
            {
                Limit = 10
            };

            var response = await _amazonDynamoDb.ListTablesAsync(request);

            var results = response.TableNames;

            if (!results.Contains(ApprovedRequestsTableName))
            {
                var createRequest = new CreateTableRequest
                {
                    TableName = ApprovedRequestsTableName,
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition
                        {
                            AttributeName = "CertificateNumber",
                            AttributeType = "N"
                        }
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "CertificateNumber",
                            KeyType = "HASH"  //Partition key
                        }
                    },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 2,
                        WriteCapacityUnits = 2
                    }
                };

                await _amazonDynamoDb.CreateTableAsync(createRequest);
            }
        }

        // GET api/Admin/pending
        [HttpGet]
        [Route("pending")]
        public async Task<List<MarriageRegistrationResponseEntity>> GetPendingRequests()
        {
            var request = ModelFactory.CreateScanRequest(PendingRequestsTableName);

            var response = await _context.GetPendingRecords(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateScanResponse(response);
        }

        // GET api/Admin/pending
        [HttpGet]
        [Route("pending/{id}")]
        public async Task<MarriageRegistrationResponseDomainModel> GetPendingRequest(int ApplicationId)
        {
            var request = ModelFactory.CreateRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.GetDetails(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateResponse(response);
        }

        // GET api/Admin/approved
        [HttpGet]
        [Route("approved/{id}")]
        public async Task<MarriageRegistrationResponseDomainModel> GetApprovedRequests(int CertificateId)
        {
            
            var request = ModelFactory.CreateApprovedRequest(CertificateId, ApprovedRequestsTableName);

            var response = await _context.GetApprovedRecord(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateApprovedResponse(response);
        }

        [HttpDelete]
        [Route("reject/{id}")]
        public async Task<MarriageRegistrationResponseDomainModel> DeletePendingRequest(int CertificateId)
        {

            var request = ModelFactory.CreateApprovedRequest(CertificateId, ApprovedRequestsTableName);

            var response = await _context.GetApprovedRecord(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateResponse(response);
        }

    }
}
