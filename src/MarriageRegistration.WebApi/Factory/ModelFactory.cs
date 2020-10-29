using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.Entities;
using MarriageRegistration.WebApi.Models;

namespace MarriageRegistration.WebApi.Factory
{

    public class ModelFactory
    {

        public static MarriageRegistrationRequestEntity GetRequestEntity(MarriageDetailsInput marriageDetailsInputDomainModel)
        {
            var marriageRegistrationRequestEntity = new MarriageRegistrationRequestEntity
            {
                //Application Details
                ApplicationId = marriageDetailsInputDomainModel.ApplicationId,
                ApplicantDistrict = marriageDetailsInputDomainModel.ApplicantDistrict,
                ApplicantTaluka = marriageDetailsInputDomainModel.ApplicantTaluka,
                MarriageDate = marriageDetailsInputDomainModel.MarriageDate,
                MarriagePlace = marriageDetailsInputDomainModel.MarriagePlace,
                LawOfMarriage = marriageDetailsInputDomainModel.LawOfMarriage,
                DocumentsPresented = marriageDetailsInputDomainModel.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageDetailsInputDomainModel.IsMarriageRegisteredAlready,
                SubmissionDate = marriageDetailsInputDomainModel.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageDetailsInputDomainModel.HusbandFirstName,
                HusbandMiddleName = marriageDetailsInputDomainModel.HusbandMiddleName,
                HusbandLastName = marriageDetailsInputDomainModel.HusbandLastName,
                UidOfHusband = marriageDetailsInputDomainModel.UidOfHusband,
                OtherNameOfHusband = marriageDetailsInputDomainModel.OtherNameOfHusband,
                ReligionByBirthOfHusband = marriageDetailsInputDomainModel.ReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageDetailsInputDomainModel.ReligionByAdoptionOfHusband,
                AgeOfHusband = marriageDetailsInputDomainModel.AgeOfHusband,
                OccupationOfHusbandWithAddress = marriageDetailsInputDomainModel.OccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageDetailsInputDomainModel.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageDetailsInputDomainModel.AddressOfHusband,

                //Wife's Details
                WifeFirstName = marriageDetailsInputDomainModel.WifeFirstName,
                WifeMiddleName = marriageDetailsInputDomainModel.WifeMiddleName,
                WifeLastName = marriageDetailsInputDomainModel.WifeLastName,
                UidOfWife = marriageDetailsInputDomainModel.UidOfWife,
                OtherNameOfWife = marriageDetailsInputDomainModel.OtherNameOfWife,
                ReligionByBirthOfWife = marriageDetailsInputDomainModel.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageDetailsInputDomainModel.ReligionByAdoptionOfWife,
                AgeOfWife = marriageDetailsInputDomainModel.AgeOfWife,
                StatusOfWifeAtMarriage = marriageDetailsInputDomainModel.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageDetailsInputDomainModel.AddressOfWifeBeforeMarriage,

                //Witness Details
                NameofWitness1 = marriageDetailsInputDomainModel.NameofWitness1,
                UidOfWitness1 = marriageDetailsInputDomainModel.UidOfWitness1,
                AddressOfWitness1 = marriageDetailsInputDomainModel.AddressOfWitness1,
                OccupationOfWitness1WithAddress = marriageDetailsInputDomainModel.OccupationOfWitness1WithAddress,
                RelationWithCoupleOfWitness1 = marriageDetailsInputDomainModel.RelationWithCoupleOfWitness1,
                NameofWitness2 = marriageDetailsInputDomainModel.NameofWitness2,
                UidOfWitness2 = marriageDetailsInputDomainModel.UidOfWitness2,
                AddressOfWitness2 = marriageDetailsInputDomainModel.AddressOfWitness2,
                OccupationOfWitness2WithAddress = marriageDetailsInputDomainModel.OccupationOfWitness2WithAddress,
                RelationWithCoupleOfWitness2 = marriageDetailsInputDomainModel.RelationWithCoupleOfWitness2,
                NameOfWitness3 = marriageDetailsInputDomainModel.NameOfWitness3,
                UidOfWitness3 = marriageDetailsInputDomainModel.UidOfWitness3,
                AddressOfWitness3 = marriageDetailsInputDomainModel.AddressOfWitness3,
                OccupationOfWitness3WithAddress = marriageDetailsInputDomainModel.OccupationOfWitness3WithAddress,
                RelationWithCoupleOfWitness3 = marriageDetailsInputDomainModel.RelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageDetailsInputDomainModel.PriestName,
                PriestAddress = marriageDetailsInputDomainModel.PriestAddress,
                PriestReligion = marriageDetailsInputDomainModel.PriestReligion,
                PriestAge = marriageDetailsInputDomainModel.PriestAge,

            };

            return marriageRegistrationRequestEntity;
        }

        public static String GenerateCertificateNumber()
        {
            return "RHK/2019/VOL-1/152";
        }

        public static MarriageRegistrationResponseDomainModel CreateResponse(GetItemResponse response)
        {
            var marriageRegistrationResponseDomainModel = new MarriageRegistrationResponseDomainModel
            {
                httpStatusCode = response.HttpStatusCode,
                marriageRegistrationResponseEntity = CreateMarriageRegistrationResponseEntity(response),
            };

            return marriageRegistrationResponseDomainModel;
        }

        private static MarriageRegistrationResponseEntity CreateMarriageRegistrationResponseEntity(GetItemResponse response)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
                ApplicationId = response.Item["ApplicationId"].N,
                ApplicantDistrict = response.Item["applicantDistrict"].S,
                ApplicantTaluka = response.Item["applicantTaluka"].S,
                MarriageDate = response.Item["MarriageDate"].S,
                MarriagePlace = response.Item["marriagePlace"].S,
                LawOfMarriage = response.Item["lawOfMarriage"].S,
                DocumentsPresented = response.Item["documents_presented"].S,
                IsMarriageRegisteredAlready = response.Item["isMarriageRegisterAlready"].BOOL,
                SubmissionDate = response.Item["submissionDate"].S,

                //Husbands's Details
                HusbandFirstName = response.Item["husbandFirstName"].S,
                HusbandMiddleName = response.Item["husbandMiddleName"].S,
                HusbandLastName = response.Item["husbandLastName"].S,
                UidOfHusband = response.Item["uidOfHusband"].S,
                OtherNameOfHusband = response.Item["otherNameOfHusband"].S,
                ReligionByBirthOfHusband = response.Item["religionByBirthOfHusband"].S,
                ReligionByAdoptionOfHusband = response.Item["religionByAdoptionOfHusband"].S,
                AgeOfHusband = response.Item["ageOfHusband"].S,
                OccupationOfHusbandWithAddress = response.Item["occupationOfHusbandWithAddress"].S,
                StatusOfHusbandAtMarriage = response.Item["statusOfHusbandAtMarriage"].S,
                AddressOfHusband = response.Item["addressOfHusband"].S,

                //Wife's Details
                WifeFirstName = response.Item["wifeFirstName"].S,
                WifeMiddleName = response.Item["wifeMiddleName"].S,
                WifeLastName = response.Item["wifeLastName"].S,
                UidOfWife = response.Item["uidOfWife"].S,
                OtherNameOfWife = response.Item["otherNameOfWife"].S,
                ReligionByBirthOfWife = response.Item["religionByBirthOfWife"].S,
                ReligionByAdoptionOfWife = response.Item["religionByAdoptionOfWife"].S,
                AgeOfWife = response.Item["ageOfWife"].S,
                StatusOfWifeAtMarriage = response.Item["statusOfWifeAtMarriage"].S,
                AddressOfWifeBeforeMarriage = response.Item["addressOfWifeBeforeMarriage"].S,

                //Witness Details
                NameofWitness1 = response.Item["nameOfWitness1"].S,
                UidOfWitness1 = response.Item["uidOfWitness1"].S,
                AddressOfWitness1 = response.Item["addressOfWitness1"].S,
                OccupationOfWitness1WithAddress = response.Item["occupationOfWitness1WithAddress"].S,
                RelationWithCoupleOfWitness1 = response.Item["relationWithCoupleOfWitness1"].S,
                NameofWitness2 = response.Item["nameOfWitness2"].S,
                UidOfWitness2 = response.Item["uidOfWitness2"].S,
                AddressOfWitness2 = response.Item["addressOfWitness2"].S,
                OccupationOfWitness2WithAddress = response.Item["occupationOfWitness2WithAddress"].S,
                RelationWithCoupleOfWitness2 = response.Item["relationWithCoupleOfWitness2"].S,
                NameOfWitness3 = response.Item["nameOfWitness3"].S,
                UidOfWitness3 = response.Item["uidOfWitness3"].S,
                AddressOfWitness3 = response.Item["addressOfWitness3"].S,
                OccupationOfWitness3WithAddress = response.Item["occupationOfWitness3WithAddress"].S,
                RelationWithCoupleOfWitness3 = response.Item["relationWithCoupleOfWitness3"].S,

                //Priest Details
                PriestName = response.Item["priestName"].S,
                PriestAddress = response.Item["priestAddress"].S,
                PriestReligion = response.Item["priestReligion"].S,
                PriestAge = response.Item["priestAge"].S,

            };

            return marriageRegistrationResponseEntity;
        }

        public static GetItemRequest CreateRequest(int id, string TableName)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "ApplicationId", new AttributeValue { N = id.ToString() } } }
            };

            return request;
        }

        public static DeleteItemRequest CreateDeleteRequest(int id, string TableName)
        {
            var request = new DeleteItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "ApplicationId", new AttributeValue { N = id.ToString() } } }
            };

            return request;
        }

        public static ScanRequest CreateScanRequest(string pendingRequestsTableName)
        {
            var request = new ScanRequest
            {
                TableName = pendingRequestsTableName,
            };

            return request;
        }

        public static PutItemRequest CreateRequest(MarriageRegistrationRequestEntity marriageRegistrationRequestEntity, string TableName)
        {
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "ApplicationId", new AttributeValue { N = marriageRegistrationRequestEntity.ApplicationId.ToString() }},
                    { "applicantDistrict", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantDistrict }},
                    { "applicantTaluka", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantTaluka }},
                    { "MarriageDate", new AttributeValue { S = marriageRegistrationRequestEntity.MarriageDate.ToString() }},
                    { "marriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarriagePlace }},
                    { "lawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.LawOfMarriage }},
                    { "documents_presented", new AttributeValue { S = marriageRegistrationRequestEntity.DocumentsPresented }},
                    { "isMarriageRegisterAlready", new AttributeValue { BOOL = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready }},
                    { "submissionDate", new AttributeValue { S = marriageRegistrationRequestEntity.SubmissionDate.ToString() }},

                    { "husbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandFirstName }},
                    { "husbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandMiddleName }},
                    { "husbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandLastName }},
                    { "uidOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfHusband }},
                    { "otherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfHusband }},
                    { "religionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfHusband }},
                    { "religionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband }},
                    { "ageOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband }},
                    { "occupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress }},
                    { "statusOfHusbandAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage }},
                    { "addressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfHusband }},

                    { "wifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeFirstName }},
                    { "wifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeMiddleName }},
                    { "wifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeLastName }},
                    { "uidOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWife }},
                    { "otherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfWife }},
                    { "religionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfWife }},
                    { "religionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife }},
                    { "ageOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife }},
                    { "statusOfWifeAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage }},
                    { "addressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage }},

                    { "nameOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness1 }},
                    { "uidOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness1 }},
                    { "addressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness1 }},
                    { "occupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness1WithAddress }},
                    { "relationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness1 }},
                    { "nameOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness2 }},
                    { "uidOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness2 }},
                    { "addressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness2 }},
                    { "occupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness2WithAddress }},
                    { "relationWithCoupleOfWitness2", new AttributeValue { S =marriageRegistrationRequestEntity.RelationWithCoupleOfWitness2 }},
                    { "nameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.NameOfWitness3 }},
                    { "uidOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness3 }},
                    { "addressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness3 }},
                    { "occupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness3WithAddress }},
                    { "relationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness3 }},

                    { "priestName", new AttributeValue { S = marriageRegistrationRequestEntity.PriestName }},
                    { "priestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAddress }},
                    { "priestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.PriestReligion }},
                    { "priestAge", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAge }},

                }
            };

            return request;
        }

        public static MarriageRegistrationResponseDomainModel CreateResponse(PutItemResponse response, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            var marriageRegistrationResponseDomainModel = new MarriageRegistrationResponseDomainModel
            {
                httpStatusCode = response.HttpStatusCode,
                marriageRegistrationResponseEntity = CreateMarriageRegistrationResponseEntity(marriageRegistrationRequestEntity),
            };

            return marriageRegistrationResponseDomainModel;
        }


        public static MarriageRegistrationResponseEntity CreateMarriageRegistrationResponseEntity(MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
                ApplicationId = marriageRegistrationRequestEntity.ApplicationId,
                ApplicantDistrict = marriageRegistrationRequestEntity.ApplicantDistrict,
                ApplicantTaluka = marriageRegistrationRequestEntity.ApplicantTaluka,
                MarriageDate = marriageRegistrationRequestEntity.MarriageDate,
                MarriagePlace = marriageRegistrationRequestEntity.MarriagePlace,
                LawOfMarriage = marriageRegistrationRequestEntity.LawOfMarriage,
                DocumentsPresented = marriageRegistrationRequestEntity.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready,
                SubmissionDate = marriageRegistrationRequestEntity.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageRegistrationRequestEntity.HusbandFirstName,
                HusbandMiddleName = marriageRegistrationRequestEntity.HusbandMiddleName,
                HusbandLastName = marriageRegistrationRequestEntity.HusbandLastName,
                UidOfHusband = marriageRegistrationRequestEntity.UidOfHusband,
                OtherNameOfHusband = marriageRegistrationRequestEntity.OtherNameOfHusband,
                ReligionByBirthOfHusband = marriageRegistrationRequestEntity.ReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband,
                AgeOfHusband = marriageRegistrationRequestEntity.AgeOfHusband,
                OccupationOfHusbandWithAddress = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageRegistrationRequestEntity.AddressOfHusband,

                //Wife's Details
                WifeFirstName = marriageRegistrationRequestEntity.WifeFirstName,
                WifeMiddleName = marriageRegistrationRequestEntity.WifeMiddleName,
                WifeLastName = marriageRegistrationRequestEntity.WifeLastName,
                UidOfWife = marriageRegistrationRequestEntity.UidOfWife,
                OtherNameOfWife = marriageRegistrationRequestEntity.OtherNameOfWife,
                ReligionByBirthOfWife = marriageRegistrationRequestEntity.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife,
                AgeOfWife = marriageRegistrationRequestEntity.AgeOfWife,
                StatusOfWifeAtMarriage = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage,

                //Witness Details
                NameofWitness1 = marriageRegistrationRequestEntity.NameofWitness1,
                UidOfWitness1 = marriageRegistrationRequestEntity.UidOfWitness1,
                AddressOfWitness1 = marriageRegistrationRequestEntity.AddressOfWitness1,
                OccupationOfWitness1WithAddress = marriageRegistrationRequestEntity.OccupationOfWitness1WithAddress,
                RelationWithCoupleOfWitness1 = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness1,
                NameofWitness2 = marriageRegistrationRequestEntity.NameofWitness2,
                UidOfWitness2 = marriageRegistrationRequestEntity.UidOfWitness2,
                AddressOfWitness2 = marriageRegistrationRequestEntity.AddressOfWitness2,
                OccupationOfWitness2WithAddress = marriageRegistrationRequestEntity.OccupationOfWitness2WithAddress,
                RelationWithCoupleOfWitness2 = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness2,
                NameOfWitness3 = marriageRegistrationRequestEntity.NameOfWitness3,
                UidOfWitness3 = marriageRegistrationRequestEntity.UidOfWitness3,
                AddressOfWitness3 = marriageRegistrationRequestEntity.AddressOfWitness3,
                OccupationOfWitness3WithAddress = marriageRegistrationRequestEntity.OccupationOfWitness3WithAddress,
                RelationWithCoupleOfWitness3 = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageRegistrationRequestEntity.PriestName,
                PriestAddress = marriageRegistrationRequestEntity.PriestAddress,
                PriestReligion = marriageRegistrationRequestEntity.PriestReligion,
                PriestAge = marriageRegistrationRequestEntity.PriestAge,

            };

            return marriageRegistrationResponseEntity;
        }

        public static List<MarriageRegistrationResponseEntity> CreateScanResponse(ScanResponse response)
        {
            List<MarriageRegistrationResponseEntity> marriageRegistrationResponseEntity= new List<MarriageRegistrationResponseEntity>();
            foreach (var item in response.Items)
            {
                marriageRegistrationResponseEntity.Add(GetResult(item));
            }
            return marriageRegistrationResponseEntity;
        }

        private static MarriageRegistrationResponseEntity GetResult(Dictionary<string, AttributeValue> Item)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity()
            {
                ApplicationId = Item["ApplicationId"].N,
                ApplicantDistrict = Item["applicantDistrict"].S,
                ApplicantTaluka = Item["applicantTaluka"].S,
                MarriageDate = Item["MarriageDate"].S,
                MarriagePlace = Item["marriagePlace"].S,
                LawOfMarriage = Item["lawOfMarriage"].S,
                DocumentsPresented = Item["documents_presented"].S,
                IsMarriageRegisteredAlready = Item["isMarriageRegisterAlready"].BOOL,
                SubmissionDate = Item["submissionDate"].S,

                //Husbands's Details
                HusbandFirstName = Item["husbandFirstName"].S,
                HusbandMiddleName = Item["husbandMiddleName"].S,
                HusbandLastName = Item["husbandLastName"].S,
                UidOfHusband = Item["uidOfHusband"].S,
                OtherNameOfHusband = Item["otherNameOfHusband"].S,
                ReligionByBirthOfHusband = Item["religionByBirthOfHusband"].S,
                ReligionByAdoptionOfHusband = Item["religionByAdoptionOfHusband"].S,
                AgeOfHusband = Item["ageOfHusband"].S,
                OccupationOfHusbandWithAddress = Item["occupationOfHusbandWithAddress"].S,
                StatusOfHusbandAtMarriage = Item["statusOfHusbandAtMarriage"].S,
                AddressOfHusband = Item["addressOfHusband"].S,

                //Wife's Details
                WifeFirstName = Item["wifeFirstName"].S,
                WifeMiddleName = Item["wifeMiddleName"].S,
                WifeLastName = Item["wifeLastName"].S,
                UidOfWife = Item["uidOfWife"].S,
                OtherNameOfWife = Item["otherNameOfWife"].S,
                ReligionByBirthOfWife = Item["religionByBirthOfWife"].S,
                ReligionByAdoptionOfWife = Item["religionByAdoptionOfWife"].S,
                AgeOfWife = Item["ageOfWife"].S,
                StatusOfWifeAtMarriage = Item["statusOfWifeAtMarriage"].S,
                AddressOfWifeBeforeMarriage = Item["addressOfWifeBeforeMarriage"].S,

                //Witness Details
                NameofWitness1 = Item["nameOfWitness1"].S,
                UidOfWitness1 = Item["uidOfWitness1"].S,
                AddressOfWitness1 = Item["addressOfWitness1"].S,
                OccupationOfWitness1WithAddress = Item["occupationOfWitness1WithAddress"].S,
                RelationWithCoupleOfWitness1 = Item["relationWithCoupleOfWitness1"].S,
                NameofWitness2 = Item["nameOfWitness2"].S,
                UidOfWitness2 = Item["uidOfWitness2"].S,
                AddressOfWitness2 = Item["addressOfWitness2"].S,
                OccupationOfWitness2WithAddress = Item["occupationOfWitness2WithAddress"].S,
                RelationWithCoupleOfWitness2 = Item["relationWithCoupleOfWitness2"].S,
                NameOfWitness3 = Item["nameOfWitness3"].S,
                UidOfWitness3 = Item["uidOfWitness3"].S,
                AddressOfWitness3 = Item["addressOfWitness3"].S,
                OccupationOfWitness3WithAddress = Item["occupationOfWitness3WithAddress"].S,
                RelationWithCoupleOfWitness3 = Item["relationWithCoupleOfWitness3"].S,

                //Priest Details
                PriestName = Item["priestName"].S,
                PriestAddress = Item["priestAddress"].S,
                PriestReligion = Item["priestReligion"].S,
                PriestAge = Item["priestAge"].S,

            };

            return marriageRegistrationResponseEntity;
        }

        public static GetItemRequest CreateApprovedRequest(int id, string approvedRequestsTableName)
        {
            var request = new GetItemRequest
            {
                TableName = approvedRequestsTableName,
                Key = new Dictionary<string, AttributeValue> { { "CertificateNumber", new AttributeValue { N = id.ToString() } } }
            };

            return request;
        }

        public static MarriageRegistrationResponseDomainModel CreateApprovedResponse(GetItemResponse response)
        {
            var marriageRegistrationResponseDomainModel = new MarriageRegistrationResponseDomainModel
            {
                httpStatusCode = response.HttpStatusCode,
                marriageRegistrationResponseEntity = CreateMarriageRegistrationResponseEntityModel(response),
            };

            return marriageRegistrationResponseDomainModel;
        }

        private static MarriageRegistrationResponseEntity CreateMarriageRegistrationResponseEntityModel(GetItemResponse response)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
                ApplicationId = response.Item["ApplicationId"].N,
                CertificateNumber = response.Item["CertificateId"].S,
                ApplicantDistrict = response.Item["applicantDistrict"].S,
                ApplicantTaluka = response.Item["applicantTaluka"].S,
                MarriageDate = response.Item["MarriageDate"].S,
                MarriagePlace = response.Item["marriagePlace"].S,
                LawOfMarriage = response.Item["lawOfMarriage"].S,
                DocumentsPresented = response.Item["documents_presented"].S,
                IsMarriageRegisteredAlready = response.Item["isMarriageRegisterAlready"].BOOL,
                SubmissionDate = response.Item["submissionDate"].S,

                //Husbands's Details
                HusbandFirstName = response.Item["husbandFirstName"].S,
                HusbandMiddleName = response.Item["husbandMiddleName"].S,
                HusbandLastName = response.Item["husbandLastName"].S,
                UidOfHusband = response.Item["uidOfHusband"].S,
                OtherNameOfHusband = response.Item["otherNameOfHusband"].S,
                ReligionByBirthOfHusband = response.Item["religionByBirthOfHusband"].S,
                ReligionByAdoptionOfHusband = response.Item["religionByAdoptionOfHusband"].S,
                AgeOfHusband = response.Item["ageOfHusband"].S,
                OccupationOfHusbandWithAddress = response.Item["occupationOfHusbandWithAddress"].S,
                StatusOfHusbandAtMarriage = response.Item["statusOfHusbandAtMarriage"].S,
                AddressOfHusband = response.Item["addressOfHusband"].S,

                //Wife's Details
                WifeFirstName = response.Item["wifeFirstName"].S,
                WifeMiddleName = response.Item["wifeMiddleName"].S,
                WifeLastName = response.Item["wifeLastName"].S,
                UidOfWife = response.Item["uidOfWife"].S,
                OtherNameOfWife = response.Item["otherNameOfWife"].S,
                ReligionByBirthOfWife = response.Item["religionByBirthOfWife"].S,
                ReligionByAdoptionOfWife = response.Item["religionByAdoptionOfWife"].S,
                AgeOfWife = response.Item["ageOfWife"].S,
                StatusOfWifeAtMarriage = response.Item["statusOfWifeAtMarriage"].S,
                AddressOfWifeBeforeMarriage = response.Item["addressOfWifeBeforeMarriage"].S,

                //Witness Details
                NameofWitness1 = response.Item["nameOfWitness1"].S,
                UidOfWitness1 = response.Item["uidOfWitness1"].S,
                AddressOfWitness1 = response.Item["addressOfWitness1"].S,
                OccupationOfWitness1WithAddress = response.Item["occupationOfWitness1WithAddress"].S,
                RelationWithCoupleOfWitness1 = response.Item["relationWithCoupleOfWitness1"].S,
                NameofWitness2 = response.Item["nameOfWitness2"].S,
                UidOfWitness2 = response.Item["uidOfWitness2"].S,
                AddressOfWitness2 = response.Item["addressOfWitness2"].S,
                OccupationOfWitness2WithAddress = response.Item["occupationOfWitness2WithAddress"].S,
                RelationWithCoupleOfWitness2 = response.Item["relationWithCoupleOfWitness2"].S,
                NameOfWitness3 = response.Item["nameOfWitness3"].S,
                UidOfWitness3 = response.Item["uidOfWitness3"].S,
                AddressOfWitness3 = response.Item["addressOfWitness3"].S,
                OccupationOfWitness3WithAddress = response.Item["occupationOfWitness3WithAddress"].S,
                RelationWithCoupleOfWitness3 = response.Item["relationWithCoupleOfWitness3"].S,

                //Priest Details
                PriestName = response.Item["priestName"].S,
                PriestAddress = response.Item["priestAddress"].S,
                PriestReligion = response.Item["priestReligion"].S,
                PriestAge = response.Item["priestAge"].S,

            };

            return marriageRegistrationResponseEntity;
        }
    }   
}
