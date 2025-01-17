﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.DataAccess;
using MarriageRegistration.WebApi.Entities;
using MarriageRegistration.WebApi.Factory;
using MarriageRegistration.WebApi.Services;
using MarriageRegistration.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarriageRegistration.WebApi.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AdminController : ControllerBase
    {

        private readonly IDataContext _context;

        private readonly IdGenerator _idGenerator;

        private readonly IAmazonDynamoDB _amazonDynamoDb;

        private const string PendingRequestsTableName = "PendingRequests";

        private const string ApprovedRequestsTableName = "ApprovedRequests";

        public AdminController(IDataContext context, IAmazonDynamoDB amazonDynamoDb, IdGenerator idGenerator)
        {
            _context = context;
            _amazonDynamoDb = amazonDynamoDb;
            _idGenerator = idGenerator;
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
                            AttributeType = "S"
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
            var request = ModelFactory.CreateScanItemRequest(PendingRequestsTableName);

            var response = await _context.GetPendingRecords(request);

            return ModelFactory.CreateScanResponse(response);
        }

        // GET api/Admin/pendingrecords/{id}
        [HttpGet]
        [Route("pendingrecords/{ApplicationId}")]
        public async Task<MarriageRegistrationResponseDomainModel> GetPendingRequestDetails(string ApplicationId)
        {
            var request = ModelFactory.CreateScanItemRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.GetItemDetails(request);

            return ModelFactory.CreateGetItemResponse(response, PendingRequestsTableName);
        }

        // GET api/Admin/approvedrecords/{CertificateId}
        [HttpGet]
        [Route("approvedrecords")]
        public async Task<MarriageRegistrationResponseDomainModel> GetApprovedRequestDetails([FromQuery] string CertificateId)
        {
            
            var request = ModelFactory.CreateApprovedRequest(CertificateId, ApprovedRequestsTableName);

            var response = await _context.GetItemDetails(request);

            return ModelFactory.CreateGetItemResponse(response, ApprovedRequestsTableName);
        }

        // DELETE api/Admin/reject/{ApplicationId}
        [HttpDelete]
        [Route("reject/{ApplicationId}")]
        public async Task<IActionResult> DeletePendingRequest(string ApplicationId)
        {

            var request = ModelFactory.CreateDeleteRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.DeleteDetails(request);

            return StatusCode((int)response.HttpStatusCode);
        }

        // DELETE api/Admin/approve/{ApplicationId}
        [HttpPost]
        [Route("approve/{ApplicationId}")]
        public async Task<string> ApproveRequest(string ApplicationId)
        {
            var request = ModelFactory.CreateScanItemRequest(ApplicationId, PendingRequestsTableName);

            var response = await _context.GetItemDetails(request);

            var recordToApprove = ModelFactory.CreateGetItemResponse(response, PendingRequestsTableName);

            var CertificateNumber = await _idGenerator.GenerateCertificateNumber();
            
            var marriageRegistrationRequestEntity = ModelFactory.GetApproveRequestEntity(CertificateNumber, recordToApprove.marriageRegistrationResponseEntity);

            var requestToApprove = ModelFactory.CreatePutItemRequest(ApprovedRequestsTableName,marriageRegistrationRequestEntity);

            var responseOfApprove = await _context.SaveDetails(requestToApprove, marriageRegistrationRequestEntity);

            var deleteRequest = ModelFactory.CreateDeleteRequest(ApplicationId, PendingRequestsTableName);

            var deleteResponse = await _context.DeleteDetails(deleteRequest);

            //return ModelFactory.CreateResponse(requestOfApprove, marriageRegistrationRequestEntity);

            return CertificateNumber;
        }

    }
}
