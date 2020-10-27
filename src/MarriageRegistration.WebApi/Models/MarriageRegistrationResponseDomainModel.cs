﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MarriageRegistration.WebApi.Entities;

namespace MarriageRegistration.WebApi.Models
{
    public class MarriageRegistrationResponseDomainModel
    {

        public HttpStatusCode httpStatusCode { get; set; }

        public MarriageRegistrationResponseEntity marriageRegistrationResponseEntity { get; set; }
    }
}
