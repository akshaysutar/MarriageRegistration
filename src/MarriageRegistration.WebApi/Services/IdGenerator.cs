using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.DataAccess;
using MarriageRegistration.WebApi.Factory;

namespace MarriageRegistration.WebApi.Services
{
    public class IdGenerator
    {
        private readonly IDataContext _context;

        private static string TableName = "LatestCertificateNumber";

        public IdGenerator(IDataContext context)
        {
            _context = context;
        }

        public static string GenerateApplicationId()
        {
            return Guid.NewGuid().ToString();
        }

        public async Task<string> GenerateCertificateNumber()
        {
            string CertificateNumber = await GetCertificateNumber(TableName);
            return CertificateNumber;
                
        }

        private async Task<string> GetCertificateNumber(string TableName)
        {
            var request = ModelFactory.CreateScanItemRequest(TableName);
            var response = await _context.GetPendingRecords(request);
            var CertificateNumber =  CreateScanResponse(response);
            string substr = CertificateNumber.Substring(CertificateNumber.Length - 3);


            return CertificateNumber;
        }

        public static string CreateScanResponse(ScanResponse response)
        {
            string CertificateNumber = string.Empty;
            foreach (var item in response.Items)
            {
                CertificateNumber = item["CertificateNumber"].S;
            }
           
            return CertificateNumber;
        }

    }
}
