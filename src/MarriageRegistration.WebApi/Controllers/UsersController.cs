﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.DataAccess;
using MarriageRegistration.WebApi.Factory;
using MarriageRegistration.WebApi.Services;
using MarriageRegistration.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace MarriageRegistration.WebApi.Controllers
{
    [ApiController]
    //[ApiExceptionFilter]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IDataContext _context;

        private readonly IAmazonDynamoDB _amazonDynamoDb;

        private const string PendingRequestsTableName = "LatestCertificateNumber";

        public UsersController(IDataContext context, IAmazonDynamoDB amazonDynamoDb)
        {
            _context = context;
            _amazonDynamoDb = amazonDynamoDb;
        }


        // GET api/Users/init
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

            if (!results.Contains(PendingRequestsTableName))
            {
                var createRequest = new CreateTableRequest
                {
                    TableName = PendingRequestsTableName,
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

        // POST api/Users
        [HttpPost]
        public async Task<MarriageRegistrationResponseDomainModel> SaveDetails([FromBody] MarriageDetailsInput marriageDetailsInput)
        {
            string ApplicationId = IdGenerator.GenerateApplicationId();

            var marriageRegistrationRequestEntity = ModelFactory.GetPutItemRequestEntity(marriageDetailsInput, ApplicationId);

            var request = ModelFactory.CreatePutItemRequest(marriageRegistrationRequestEntity, PendingRequestsTableName);

            var response = await _context.SaveDetails(request, marriageRegistrationRequestEntity);
                     
            return ModelFactory.CreateResponse(response, marriageRegistrationRequestEntity);
        }


    }
}
