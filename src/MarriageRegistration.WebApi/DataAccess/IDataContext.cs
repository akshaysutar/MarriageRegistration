using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.Entities;

namespace MarriageRegistration.WebApi.DataAccess
{
    public interface IDataContext
    {
        public Task<PutItemResponse> SaveDetails(PutItemRequest request, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity);

    }
}
