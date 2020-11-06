using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistration.WebApi.Factory.IdGeneration
{
    public class IdGenerator
    {
        public static string GenerateApplicationId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateCertificateNumber()
        {
            return "RHK/2019/VOL-1/152";
        }
    }
}
