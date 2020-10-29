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

        // GET api/Admin/pendingrecords
        [HttpGet]
        [Route("pendingrecords")]
        public async Task<List<MarriageRegistrationResponseEntity>> GetPendingRequests()
        {
            var request = ModelFactory.CreateScanRequest(PendingRequestsTableName);

            var response = await _context.GetPendingRecords(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateScanResponse(response);
        }

        // GET api/Admin/pendingrecords/{id}
        [HttpGet]
        [Route("pendingrecords/{id}")]
        public async Task<MarriageRegistrationResponseDomainModel> GetPendingRequest(int ApplicationId)
        {
            var request = ModelFactory.CreateRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.GetDetails(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateResponse(response);
        }

        // GET api/Admin/approvedrecords
        [HttpGet]
        [Route("approvedrecords/{id}")]
        public async Task<MarriageRegistrationResponseDomainModel> GetApprovedRequests(int CertificateId)
        {
            
            var request = ModelFactory.CreateApprovedRequest(CertificateId, ApprovedRequestsTableName);

            var response = await _context.GetApprovedRecord(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateApprovedResponse(response);
        }

        // DELETE api/Admin/reject/{id}
        [HttpDelete]
        [Route("reject/{id}")]
        public async Task<IActionResult> DeletePendingRequest(int ApplicationId)
        {

            var request = ModelFactory.CreateDeleteRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.DeleteDetails(request);

            return StatusCode((int)response.HttpStatusCode);
        }

        // DELETE api/Admin/approve
        [HttpPost]
        [Route("approve/{id}")]
        public async Task<MarriageRegistrationResponseDomainModel> ApproveRequest(int ApplicationId)
        {
            var request = ModelFactory.CreateRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.GetDetails(request);

            ModelFactory.CreateResponse(response);

            var CertificateNumber = ModelFactory.GenerateCertificateNumber();
            
            var marriageRegistrationRequestEntity = ModelFactory.GetRequestEntity(marriageDetailsInput);

            var request = ModelFactory.CreateRequest(marriageRegistrationRequestEntity, PendingRequestsTableName);

            var response = await _context.SaveDetails(request, marriageRegistrationRequestEntity);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateResponse(response, marriageRegistrationRequestEntity);

            var request = ModelFactory.CreateApprovedRequest(ApplicationId, ApprovedRequestsTableName);

            var response = await _context.GetApprovedRecord(request);


            return ModelFactory.CreateApprovedResponse(response);
        }

    }
}
