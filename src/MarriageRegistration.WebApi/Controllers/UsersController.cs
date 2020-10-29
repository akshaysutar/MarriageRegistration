using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.DataAccess;
using MarriageRegistration.WebApi.Factory;
using MarriageRegistration.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace MarriageRegistration.WebApi.Controllers
{
    [ApiController]
    [ApiExceptionFilter]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IAmazonDynamoDB _amazonDynamoDb;

        private const string PendingRequestsTableName = "PendingRequests";

        public UsersController(DataContext context, IAmazonDynamoDB amazonDynamoDb)
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
                            AttributeName = "ApplicationId",
                            AttributeType = "N"
                        }
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "ApplicationId",
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
            var marriageRegistrationRequestEntity = ModelFactory.GetRequestEntity(marriageDetailsInput);

            var request = ModelFactory.CreateRequest(marriageRegistrationRequestEntity, PendingRequestsTableName);

            var response = await _context.SaveDetails(request, marriageRegistrationRequestEntity);
           
            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateResponse(response, marriageRegistrationRequestEntity);
        }

        // GET api/Users
        [HttpGet("{id}")]
        public async Task <MarriageRegistrationResponseDomainModel> GetDetails(int ApplicationId)
        {
            var request = ModelFactory.CreateRequest(ApplicationId, PendingRequestsTableName);
            
            var response = await _context.GetDetails(request);

            StatusCode((int)response.HttpStatusCode);

            return ModelFactory.CreateResponse(response);

        }


        // DELETE api/Users
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetails(int id)
        {
            
            var request = ModelFactory.CreateDeleteRequest(id, PendingRequestsTableName);

            var response = await _context.DeleteDetails(request);

            return StatusCode((int)response.HttpStatusCode);
        }

    }
}
