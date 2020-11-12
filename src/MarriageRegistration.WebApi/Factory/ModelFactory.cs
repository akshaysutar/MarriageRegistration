using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MarriageRegistration.WebApi.Entities;
using MarriageRegistration.WebApi.Models;

namespace MarriageRegistration.WebApi.Factory
{

    public class ModelFactory
    {

        public static MarriageRegistrationRequestEntity GetPutItemRequestEntity(MarriageDetailsInput marriageDetailsInputDomainModel, string ApplicationId)
        {
            var marriageRegistrationRequestEntity = new MarriageRegistrationRequestEntity
            {
                //Application Details
                ApplicationId = ApplicationId,
                ApplicantDistrict = marriageDetailsInputDomainModel.ApplicantDistrict,
                ApplicantTaluka = marriageDetailsInputDomainModel.ApplicantTaluka,
                MarriageDate = marriageDetailsInputDomainModel.MarriageDate,
                MarriagePlace = marriageDetailsInputDomainModel.MarriagePlace,
                MarathiMarriagePlace = marriageDetailsInputDomainModel.MarathiMarriagePlace,
                LawOfMarriage = marriageDetailsInputDomainModel.LawOfMarriage,
                MarathiLawOfMarriage = marriageDetailsInputDomainModel.MarathiLawOfMarriage,
                DocumentsPresented = marriageDetailsInputDomainModel.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageDetailsInputDomainModel.IsMarriageRegisteredAlready,
                SubmissionDate = marriageDetailsInputDomainModel.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageDetailsInputDomainModel.HusbandFirstName,
                HusbandMiddleName = marriageDetailsInputDomainModel.HusbandMiddleName,
                HusbandLastName = marriageDetailsInputDomainModel.HusbandLastName,
                MarathiHusbandFirstName = marriageDetailsInputDomainModel.MarathiHusbandFirstName,
                MarathiHusbandMiddleName = marriageDetailsInputDomainModel.MarathiHusbandMiddleName,
                MarathiHusbandLastName = marriageDetailsInputDomainModel.MarathiHusbandLastName,
                UidOfHusband = marriageDetailsInputDomainModel.UidOfHusband,
                OtherNameOfHusband = marriageDetailsInputDomainModel.OtherNameOfHusband,
                MarathiOtherNameOfHusband = marriageDetailsInputDomainModel.MarathiOtherNameOfHusband,
                ReligionByBirthOfHusband = marriageDetailsInputDomainModel.ReligionByBirthOfHusband,
                MarathiReligionByBirthOfHusband = marriageDetailsInputDomainModel.MarathiReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageDetailsInputDomainModel.ReligionByAdoptionOfHusband,
                MarathiReligionByAdoptionOfHusband = marriageDetailsInputDomainModel.MarathiReligionByAdoptionOfHusband,
                AgeOfHusband = GetAge(marriageDetailsInputDomainModel.AgeOfHusband),
                OccupationOfHusbandWithAddress = marriageDetailsInputDomainModel.OccupationOfHusbandWithAddress,
                MarathiOccupationOfHusbandWithAddress = marriageDetailsInputDomainModel.MarathiOccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageDetailsInputDomainModel.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageDetailsInputDomainModel.AddressOfHusband,
                MarathiAddressOfHusband = marriageDetailsInputDomainModel.MarathiAddressOfHusband,

                //Wife's Details
                WifeFirstName = marriageDetailsInputDomainModel.WifeFirstName,
                WifeMiddleName = marriageDetailsInputDomainModel.WifeMiddleName,
                WifeLastName = marriageDetailsInputDomainModel.WifeLastName,
                MarathiWifeFirstName = marriageDetailsInputDomainModel.MarathiWifeFirstName,
                MarathiWifeMiddleName = marriageDetailsInputDomainModel.MarathiWifeMiddleName,
                MarathiWifeLastName = marriageDetailsInputDomainModel.MarathiWifeLastName,
                UidOfWife = marriageDetailsInputDomainModel.UidOfWife,
                OtherNameOfWife = marriageDetailsInputDomainModel.OtherNameOfWife,
                MarathiOtherNameOfWife = marriageDetailsInputDomainModel.MarathiOtherNameOfWife,
                ReligionByBirthOfWife = marriageDetailsInputDomainModel.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageDetailsInputDomainModel.ReligionByAdoptionOfWife,
                MarathiReligionByBirthOfWife = marriageDetailsInputDomainModel.MarathiReligionByBirthOfWife,
                MarathiReligionByAdoptionOfWife = marriageDetailsInputDomainModel.MarathiReligionByAdoptionOfWife,
                AgeOfWife = GetAge(marriageDetailsInputDomainModel.AgeOfWife),
                StatusOfWifeAtMarriage = marriageDetailsInputDomainModel.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageDetailsInputDomainModel.AddressOfWifeBeforeMarriage,
                MarathiAddressOfWifeBeforeMarriage = marriageDetailsInputDomainModel.MarathiAddressOfWifeBeforeMarriage,

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

                MarathiNameofWitness1 = marriageDetailsInputDomainModel.MarathiNameofWitness1,
                MarathiAddressOfWitness1 = marriageDetailsInputDomainModel.MarathiAddressOfWitness1,
                MarathiOccupationOfWitness1WithAddress = marriageDetailsInputDomainModel.MarathiOccupationOfWitness1WithAddress,
                MarathiRelationWithCoupleOfWitness1 = marriageDetailsInputDomainModel.MarathiRelationWithCoupleOfWitness1,
                MarathiNameofWitness2 = marriageDetailsInputDomainModel.MarathiNameofWitness2,
                MarathiAddressOfWitness2 = marriageDetailsInputDomainModel.MarathiAddressOfWitness2,
                MarathiOccupationOfWitness2WithAddress = marriageDetailsInputDomainModel.MarathiOccupationOfWitness2WithAddress,
                MarathiRelationWithCoupleOfWitness2 = marriageDetailsInputDomainModel.MarathiRelationWithCoupleOfWitness2,
                MarathiNameOfWitness3 = marriageDetailsInputDomainModel.MarathiNameOfWitness3,
                MarathiAddressOfWitness3 = marriageDetailsInputDomainModel.MarathiAddressOfWitness3,
                MarathiOccupationOfWitness3WithAddress = marriageDetailsInputDomainModel.MarathiOccupationOfWitness3WithAddress,
                MarathiRelationWithCoupleOfWitness3 = marriageDetailsInputDomainModel.MarathiRelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageDetailsInputDomainModel.PriestName,
                PriestAddress = marriageDetailsInputDomainModel.PriestAddress,
                PriestReligion = marriageDetailsInputDomainModel.PriestReligion,
                PriestAge = marriageDetailsInputDomainModel.PriestAge,
                MarathiPriestName = marriageDetailsInputDomainModel.MarathiPriestName,
                MarathiPriestAddress = marriageDetailsInputDomainModel.MarathiPriestAddress,
                MarathiPriestReligion = marriageDetailsInputDomainModel.MarathiPriestReligion,

            };

            return marriageRegistrationRequestEntity;
        }

        public static PutItemRequest CreatePutItemRequest(string approvedRequestsTableName, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            var request = new PutItemRequest
            {
                TableName = approvedRequestsTableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "ApplicationId", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicationId.ToString() }},
                    { "CertificateNumber", new AttributeValue { S = marriageRegistrationRequestEntity.CertificateNumber }},
                    { "applicantDistrict", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantDistrict }},
                    { "applicantTaluka", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantTaluka }},
                    { "MarriageDate", new AttributeValue { S = marriageRegistrationRequestEntity.MarriageDate.ToString() }},
                    { "marriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarriagePlace }},
                    { "marathimarriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiMarriagePlace }},
                    { "lawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.LawOfMarriage }},
                    { "marathilawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiLawOfMarriage }},
                    { "documents_presented", new AttributeValue { S = marriageRegistrationRequestEntity.DocumentsPresented }},
                    { "isMarriageRegisterAlready", new AttributeValue { BOOL = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready }},
                    { "submissionDate", new AttributeValue { S = marriageRegistrationRequestEntity.SubmissionDate.ToString() }},

                    { "husbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandFirstName }},
                    { "husbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandMiddleName }},
                    { "husbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandLastName }},
                    { "marathihusbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandFirstName }},
                    { "marathihusbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandMiddleName } },
                    { "marathihusbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandLastName } },
                    { "uidOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfHusband }},
                    { "otherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfHusband }},
                    { "marathiotherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfHusband }},
                    { "religionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfHusband }},
                    { "religionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband }},
                    { "marathireligionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfHusband }},
                    { "marathireligionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfHusband }},
                    { "ageOfHusbandYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Years }},
                    { "ageOfHusbandMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Months }},
                    { "occupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress }},
                    { "marathioccupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfHusbandWithAddress }},
                    { "statusOfHusbandAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage }},
                    { "addressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfHusband }},
                    { "marathiaddressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfHusband }},

                    { "wifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeFirstName }},
                    { "wifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeMiddleName }},
                    { "wifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeLastName }},
                    { "marathiwifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeFirstName }},
                    { "marathiwifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeMiddleName }},
                    { "marathiwifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeLastName }},
                    { "uidOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWife }},
                    { "otherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfWife }},
                    { "marathiotherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfWife }},
                    { "religionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfWife }},
                    { "religionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife }},
                    { "marathireligionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfWife }},
                    { "marathireligionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfWife }},
                    { "ageOfWifeYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Years}},
                    { "ageOfWifeMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Months}},
                    { "statusOfWifeAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage }},
                    { "addressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage }},
                    { "marathiaddressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWifeBeforeMarriage }},

                    { "nameOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness1 }},
                    { "uidOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness1 }},
                    { "addressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness1 }},
                    { "occupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness1WithAddress }},
                    { "relationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness1 }},
                    { "marathinameOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness1 }},
                    { "marathiaddressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness1 }},
                    { "marathioccupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness1WithAddress }},
                    { "marathirelationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness1 }},
                    { "nameOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness2 }},
                    { "uidOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness2 }},
                    { "addressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness2 }},
                    { "occupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness2WithAddress }},
                    { "relationWithCoupleOfWitness2", new AttributeValue { S =marriageRegistrationRequestEntity.RelationWithCoupleOfWitness2 }},
                    { "marathinameOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness2 }},
                    { "marathiaddressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness2 }},
                    { "marathioccupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness2WithAddress }},
                    { "marathirelationWithCoupleOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness2 }},
                    { "nameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.NameOfWitness3 }},
                    { "uidOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness3 }},
                    { "addressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness3 }},
                    { "occupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness3WithAddress }},
                    { "relationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness3 }},
                    { "marathinameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness3 }},
                    { "marathiaddressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness3 }},
                    { "marathioccupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness3WithAddress }},
                    { "marathirelationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness3 }},

                    { "priestName", new AttributeValue { S = marriageRegistrationRequestEntity.PriestName }},
                    { "priestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAddress }},
                    { "priestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.PriestReligion }},
                    { "marathipriestName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestName }},
                    { "marathipriestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestAddress }},
                    { "marathipriestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestReligion }},
                    { "priestAge", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAge }},

                }
            };

            return request;
        }

        private static AgeEntity GetAge(Age age)
        {
            var ageEntity = new AgeEntity
            {
                Years = age.Years,
                Months = age.Months
            };
            return ageEntity;
        }

        public static MarriageRegistrationResponseDomainModel CreateGetItemResponse(GetItemResponse response, string TableName)
        {
            var marriageRegistrationResponseDomainModel = new MarriageRegistrationResponseDomainModel
            {
               
                marriageRegistrationResponseEntity = CreateMarriageRegistrationResponseEntity(response,TableName),
            };

            return marriageRegistrationResponseDomainModel;
        }

        private static MarriageRegistrationResponseEntity CreateMarriageRegistrationResponseEntity(GetItemResponse response, string TableName)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
                //Application Details
                ApplicationId = response.Item["ApplicationId"].S,
                CertificateNumber = getCertificateNumber(TableName, response),
                ApplicantDistrict = response.Item["applicantDistrict"].S,
                ApplicantTaluka = response.Item["applicantTaluka"].S,
                MarriageDate = response.Item["MarriageDate"].S,
                MarriagePlace = response.Item["marriagePlace"].S,
                LawOfMarriage = response.Item["lawOfMarriage"].S,
                MarathiMarriagePlace = response.Item["marathimarriagePlace"].S,
                MarathiLawOfMarriage = response.Item["marathilawOfMarriage"].S,
                DocumentsPresented = response.Item["documents_presented"].S,
                IsMarriageRegisteredAlready = response.Item["isMarriageRegisterAlready"].BOOL,
                SubmissionDate = response.Item["submissionDate"].S,

                //Husbands's Details
                HusbandFirstName = response.Item["husbandFirstName"].S,
                HusbandMiddleName = response.Item["husbandMiddleName"].S,
                HusbandLastName = response.Item["husbandLastName"].S,
                MarathiHusbandFirstName = response.Item["marathihusbandFirstName"].S,
                MarathiHusbandMiddleName = response.Item["marathihusbandMiddleName"].S,
                MarathiHusbandLastName = response.Item["marathihusbandLastName"].S,
                UidOfHusband = response.Item["uidOfHusband"].S,
                OtherNameOfHusband = response.Item["otherNameOfHusband"].S,
                ReligionByBirthOfHusband = response.Item["religionByBirthOfHusband"].S,
                ReligionByAdoptionOfHusband = response.Item["religionByAdoptionOfHusband"].S,
                MarathiOtherNameOfHusband = response.Item["marathiotherNameOfHusband"].S,
                MarathiReligionByBirthOfHusband = response.Item["marathireligionByBirthOfHusband"].S,
                MarathiReligionByAdoptionOfHusband = response.Item["marathireligionByAdoptionOfHusband"].S,
                AgeOfHusband = getAgeEntityResponse(response.Item["ageOfHusbandYears"].S, response.Item["ageOfHusbandMonths"].S),
                OccupationOfHusbandWithAddress = response.Item["occupationOfHusbandWithAddress"].S,
                MarathiOccupationOfHusbandWithAddress = response.Item["marathioccupationOfHusbandWithAddress"].S,
                StatusOfHusbandAtMarriage = response.Item["statusOfHusbandAtMarriage"].S,
                AddressOfHusband = response.Item["addressOfHusband"].S,
                MarathiAddressOfHusband = response.Item["marathiaddressOfHusband"].S,

                //Wife's Details
                WifeFirstName = response.Item["wifeFirstName"].S,
                WifeMiddleName = response.Item["wifeMiddleName"].S,
                WifeLastName = response.Item["wifeLastName"].S,
                MarathiWifeFirstName = response.Item["marathiwifeFirstName"].S,
                MarathiWifeMiddleName = response.Item["marathiwifeMiddleName"].S,
                MarathiWifeLastName = response.Item["marathiwifeLastName"].S,
                UidOfWife = response.Item["uidOfWife"].S,
                OtherNameOfWife = response.Item["otherNameOfWife"].S,
                ReligionByBirthOfWife = response.Item["religionByBirthOfWife"].S,
                ReligionByAdoptionOfWife = response.Item["religionByAdoptionOfWife"].S,
                MarathiOtherNameOfWife = response.Item["marathiotherNameOfWife"].S,
                MarathiReligionByBirthOfWife = response.Item["marathireligionByBirthOfWife"].S,
                MarathiReligionByAdoptionOfWife = response.Item["marathireligionByAdoptionOfWife"].S,
                AgeOfWife = getAgeEntityResponse(response.Item["ageOfWifeYears"].S, response.Item["ageOfWifeMonths"].S),
                StatusOfWifeAtMarriage = response.Item["statusOfWifeAtMarriage"].S,
                AddressOfWifeBeforeMarriage = response.Item["addressOfWifeBeforeMarriage"].S,
                MarathiAddressOfWifeBeforeMarriage = response.Item["marathiaddressOfWifeBeforeMarriage"].S,

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

                MarathiNameofWitness1 = response.Item["marathinameOfWitness1"].S,

                MarathiAddressOfWitness1 = response.Item["marathiaddressOfWitness1"].S,
                MarathiOccupationOfWitness1WithAddress = response.Item["marathioccupationOfWitness1WithAddress"].S,
                MarathiRelationWithCoupleOfWitness1 = response.Item["marathirelationWithCoupleOfWitness1"].S,
                MarathiNameofWitness2 = response.Item["marathinameOfWitness2"].S,

                MarathiAddressOfWitness2 = response.Item["marathiaddressOfWitness2"].S,
                MarathiOccupationOfWitness2WithAddress = response.Item["marathioccupationOfWitness2WithAddress"].S,
                MarathiRelationWithCoupleOfWitness2 = response.Item["marathirelationWithCoupleOfWitness2"].S,
                MarathiNameOfWitness3 = response.Item["marathinameOfWitness3"].S,

                MarathiAddressOfWitness3 = response.Item["marathiaddressOfWitness3"].S,
                MarathiOccupationOfWitness3WithAddress = response.Item["marathioccupationOfWitness3WithAddress"].S,
                MarathiRelationWithCoupleOfWitness3 = response.Item["marathirelationWithCoupleOfWitness3"].S,

                //Priest Details
                PriestName = response.Item["priestName"].S,
                PriestAddress = response.Item["priestAddress"].S,
                PriestReligion = response.Item["priestReligion"].S,
                PriestAge = response.Item["priestAge"].S,
                MarathiPriestName = response.Item["marathipriestName"].S,
                MarathiPriestAddress = response.Item["marathipriestAddress"].S,
                MarathiPriestReligion = response.Item["marathipriestReligion"].S,

            };

            return marriageRegistrationResponseEntity;
        }


        public static string getCertificateNumber(string TableName, GetItemResponse response)
        {
            if (TableName == "ApprovedRequests")
            {
                return response.Item["CertificateNumber"].S;
            }

            return null;
        }
        

        public static GetItemRequest CreateScanItemRequest(string id, string TableName)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "ApplicationId", new AttributeValue { S = id} } }
            };

            return request;
        }

        public static DeleteItemRequest CreateDeleteRequest(string id, string TableName)
        {
            var request = new DeleteItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "ApplicationId", new AttributeValue { S = id.ToString() } } }
            };

            return request;
        }

        public static ScanRequest CreateScanItemRequest(string TableName)
        {
            var request = new ScanRequest
            {
                TableName = TableName,
            };

            return request;
        }

        public static PutItemRequest CreatePutItemRequest(MarriageRegistrationRequestEntity marriageRegistrationRequestEntity, string TableName)
        {
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "ApplicationId", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicationId.ToString() }},
                    { "applicantDistrict", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantDistrict }},
                    { "applicantTaluka", new AttributeValue { S = marriageRegistrationRequestEntity.ApplicantTaluka }},
                    { "MarriageDate", new AttributeValue { S = marriageRegistrationRequestEntity.MarriageDate.ToString() }},
                    { "marriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarriagePlace }},
                    { "marathimarriagePlace", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiMarriagePlace }},
                    { "lawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.LawOfMarriage }},
                    { "marathilawOfMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiLawOfMarriage }},
                    { "documents_presented", new AttributeValue { S = marriageRegistrationRequestEntity.DocumentsPresented }},
                    { "isMarriageRegisterAlready", new AttributeValue { BOOL = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready }},
                    { "submissionDate", new AttributeValue { S = marriageRegistrationRequestEntity.SubmissionDate.ToString() }},

                    { "husbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandFirstName }},
                    { "husbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandMiddleName }},
                    { "husbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.HusbandLastName }},
                    { "marathihusbandFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandFirstName }},
                    { "marathihusbandMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandMiddleName } },
                    { "marathihusbandLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiHusbandLastName } },
                    { "uidOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfHusband }},
                    { "otherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfHusband }},
                    { "marathiotherNameOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfHusband }},
                    { "religionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfHusband }},
                    { "religionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband }},
                    { "marathireligionByBirthOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfHusband }},
                    { "marathireligionByAdoptionOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfHusband }},
                    { "ageOfHusbandYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Years }},
                    { "ageOfHusbandMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfHusband.Months }},
                    { "occupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress }},
                    { "marathioccupationOfHusbandWithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfHusbandWithAddress }},
                    { "statusOfHusbandAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage }},
                    { "addressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfHusband }},
                    { "marathiaddressOfHusband", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfHusband }},

                    { "wifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeFirstName }},
                    { "wifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeMiddleName }},
                    { "wifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.WifeLastName }},
                    { "marathiwifeFirstName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeFirstName }},
                    { "marathiwifeMiddleName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeMiddleName }},
                    { "marathiwifeLastName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiWifeLastName }},
                    { "uidOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWife }},
                    { "otherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.OtherNameOfWife }},
                    { "marathiotherNameOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOtherNameOfWife }},
                    { "religionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByBirthOfWife }},
                    { "religionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife }},
                    { "marathireligionByBirthOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByBirthOfWife }},
                    { "marathireligionByAdoptionOfWife", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfWife }},
                    { "ageOfWifeYears", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Years}},       
                    { "ageOfWifeMonths", new AttributeValue { S = marriageRegistrationRequestEntity.AgeOfWife.Months }},
                    { "statusOfWifeAtMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage }},
                    { "addressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage }},
                    { "marathiaddressOfWifeBeforeMarriage", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWifeBeforeMarriage }},

                    { "nameOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness1 }},
                    { "uidOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness1 }},
                    { "addressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness1 }},
                    { "occupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness1WithAddress }},
                    { "relationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness1 }},
                    { "marathinameOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness1 }},                  
                    { "marathiaddressOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness1 }},
                    { "marathioccupationOfWitness1WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness1WithAddress }},
                    { "marathirelationWithCoupleOfWitness1", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness1 }},
                    { "nameOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.NameofWitness2 }},
                    { "uidOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness2 }},
                    { "addressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness2 }},
                    { "occupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness2WithAddress }},
                    { "relationWithCoupleOfWitness2", new AttributeValue { S =marriageRegistrationRequestEntity.RelationWithCoupleOfWitness2 }},
                    { "marathinameOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiNameofWitness2 }},
                    { "marathiaddressOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness2 }},
                    { "marathioccupationOfWitness2WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness2WithAddress }},
                    { "marathirelationWithCoupleOfWitness2", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness2 }},
                    { "nameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.NameOfWitness3 }},
                    { "uidOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.UidOfWitness3 }},
                    { "addressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.AddressOfWitness3 }},
                    { "occupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.OccupationOfWitness3WithAddress }},
                    { "relationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.RelationWithCoupleOfWitness3 }},
                    { "marathinameOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness3 }},
                    { "marathiaddressOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiAddressOfWitness3 }},
                    { "marathioccupationOfWitness3WithAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiOccupationOfWitness3WithAddress }},
                    { "marathirelationWithCoupleOfWitness3", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness3 }},

                    { "priestName", new AttributeValue { S = marriageRegistrationRequestEntity.PriestName }},
                    { "priestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAddress }},
                    { "priestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.PriestReligion }},
                    { "marathipriestName", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestName }},
                    { "marathipriestAddress", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestAddress }},
                    { "marathipriestReligion", new AttributeValue { S = marriageRegistrationRequestEntity.MarathiPriestReligion }},
                    { "priestAge", new AttributeValue { S = marriageRegistrationRequestEntity.PriestAge }},

                }
            };

            return request;
        }

        
        public static MarriageRegistrationResponseDomainModel CreateResponse(PutItemResponse response, MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            var marriageRegistrationResponseDomainModel = new MarriageRegistrationResponseDomainModel
            {
                marriageRegistrationResponseEntity = CreateMarriageRegistrationResponseEntity(marriageRegistrationRequestEntity),
            };

            return marriageRegistrationResponseDomainModel;
        }


        public static MarriageRegistrationResponseEntity CreateMarriageRegistrationResponseEntity(MarriageRegistrationRequestEntity marriageRegistrationRequestEntity)
        {
            var marriageRegistrationResponseEntity = new MarriageRegistrationResponseEntity
            {
                //Application Details
                ApplicationId = marriageRegistrationRequestEntity.ApplicationId,              
                ApplicantDistrict = marriageRegistrationRequestEntity.ApplicantDistrict,
                ApplicantTaluka = marriageRegistrationRequestEntity.ApplicantTaluka,
                MarriageDate = marriageRegistrationRequestEntity.MarriageDate,
                MarriagePlace = marriageRegistrationRequestEntity.MarriagePlace,
                MarathiMarriagePlace = marriageRegistrationRequestEntity.MarathiMarriagePlace,
                LawOfMarriage = marriageRegistrationRequestEntity.LawOfMarriage,
                MarathiLawOfMarriage = marriageRegistrationRequestEntity.MarathiLawOfMarriage,
                DocumentsPresented = marriageRegistrationRequestEntity.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageRegistrationRequestEntity.IsMarriageRegisteredAlready,
                SubmissionDate = marriageRegistrationRequestEntity.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageRegistrationRequestEntity.HusbandFirstName,
                HusbandMiddleName = marriageRegistrationRequestEntity.HusbandMiddleName,
                HusbandLastName = marriageRegistrationRequestEntity.HusbandLastName,
                MarathiHusbandFirstName = marriageRegistrationRequestEntity.MarathiHusbandFirstName,
                MarathiHusbandMiddleName = marriageRegistrationRequestEntity.MarathiHusbandMiddleName,
                MarathiHusbandLastName = marriageRegistrationRequestEntity.MarathiHusbandLastName,
                UidOfHusband = marriageRegistrationRequestEntity.UidOfHusband,
                OtherNameOfHusband = marriageRegistrationRequestEntity.OtherNameOfHusband,
                MarathiOtherNameOfHusband = marriageRegistrationRequestEntity.MarathiOtherNameOfHusband,
                ReligionByBirthOfHusband = marriageRegistrationRequestEntity.ReligionByBirthOfHusband,
                MarathiReligionByBirthOfHusband = marriageRegistrationRequestEntity.MarathiReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageRegistrationRequestEntity.ReligionByAdoptionOfHusband,
                MarathiReligionByAdoptionOfHusband = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfHusband,
                AgeOfHusband = GetAge(marriageRegistrationRequestEntity.AgeOfHusband),
                OccupationOfHusbandWithAddress = marriageRegistrationRequestEntity.OccupationOfHusbandWithAddress,
                MarathiOccupationOfHusbandWithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageRegistrationRequestEntity.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageRegistrationRequestEntity.AddressOfHusband,
                MarathiAddressOfHusband = marriageRegistrationRequestEntity.MarathiAddressOfHusband,

                //Wife's Details
                WifeFirstName = marriageRegistrationRequestEntity.WifeFirstName,
                WifeMiddleName = marriageRegistrationRequestEntity.WifeMiddleName,
                WifeLastName = marriageRegistrationRequestEntity.WifeLastName,
                MarathiWifeFirstName = marriageRegistrationRequestEntity.MarathiWifeFirstName,
                MarathiWifeMiddleName = marriageRegistrationRequestEntity.MarathiWifeMiddleName,
                MarathiWifeLastName = marriageRegistrationRequestEntity.MarathiWifeLastName,
                UidOfWife = marriageRegistrationRequestEntity.UidOfWife,
                OtherNameOfWife = marriageRegistrationRequestEntity.OtherNameOfWife,
                MarathiOtherNameOfWife = marriageRegistrationRequestEntity.MarathiOtherNameOfWife,
                ReligionByBirthOfWife = marriageRegistrationRequestEntity.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageRegistrationRequestEntity.ReligionByAdoptionOfWife,
                MarathiReligionByBirthOfWife = marriageRegistrationRequestEntity.MarathiReligionByBirthOfWife,
                MarathiReligionByAdoptionOfWife = marriageRegistrationRequestEntity.MarathiReligionByAdoptionOfWife,
                AgeOfWife = GetAge(marriageRegistrationRequestEntity.AgeOfWife),
                StatusOfWifeAtMarriage = marriageRegistrationRequestEntity.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageRegistrationRequestEntity.AddressOfWifeBeforeMarriage,
                MarathiAddressOfWifeBeforeMarriage = marriageRegistrationRequestEntity.MarathiAddressOfWifeBeforeMarriage,

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

                MarathiNameofWitness1 = marriageRegistrationRequestEntity.MarathiNameofWitness1,
                MarathiAddressOfWitness1 = marriageRegistrationRequestEntity.MarathiAddressOfWitness1,
                MarathiOccupationOfWitness1WithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfWitness1WithAddress,
                MarathiRelationWithCoupleOfWitness1 = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness1,
                MarathiNameofWitness2 = marriageRegistrationRequestEntity.MarathiNameofWitness2,
                MarathiAddressOfWitness2 = marriageRegistrationRequestEntity.MarathiAddressOfWitness2,
                MarathiOccupationOfWitness2WithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfWitness2WithAddress,
                MarathiRelationWithCoupleOfWitness2 = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness2,
                MarathiNameOfWitness3 = marriageRegistrationRequestEntity.MarathiNameOfWitness3,
                MarathiAddressOfWitness3 = marriageRegistrationRequestEntity.MarathiAddressOfWitness3,
                MarathiOccupationOfWitness3WithAddress = marriageRegistrationRequestEntity.MarathiOccupationOfWitness3WithAddress,
                MarathiRelationWithCoupleOfWitness3 = marriageRegistrationRequestEntity.MarathiRelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageRegistrationRequestEntity.PriestName,
                PriestAddress = marriageRegistrationRequestEntity.PriestAddress,
                PriestReligion = marriageRegistrationRequestEntity.PriestReligion,
                PriestAge = marriageRegistrationRequestEntity.PriestAge,
                MarathiPriestName = marriageRegistrationRequestEntity.MarathiPriestName,
                MarathiPriestAddress = marriageRegistrationRequestEntity.MarathiPriestAddress,
                MarathiPriestReligion = marriageRegistrationRequestEntity.MarathiPriestReligion,


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
                //Application Details
                ApplicationId = Item["ApplicationId"].S,
                ApplicantDistrict = Item["applicantDistrict"].S,
                ApplicantTaluka = Item["applicantTaluka"].S,
                MarriageDate = Item["MarriageDate"].S,
                MarriagePlace = Item["marriagePlace"].S,
                LawOfMarriage = Item["lawOfMarriage"].S,
                MarathiMarriagePlace = Item["marathimarriagePlace"].S,
                MarathiLawOfMarriage = Item["marathilawOfMarriage"].S,
                DocumentsPresented = Item["documents_presented"].S,
                IsMarriageRegisteredAlready = Item["isMarriageRegisterAlready"].BOOL,
                SubmissionDate = Item["submissionDate"].S,

                //Husbands's Details
                HusbandFirstName = Item["husbandFirstName"].S,
                HusbandMiddleName = Item["husbandMiddleName"].S,
                HusbandLastName = Item["husbandLastName"].S,
                MarathiHusbandFirstName = Item["marathihusbandFirstName"].S,
                MarathiHusbandMiddleName = Item["marathihusbandMiddleName"].S,
                MarathiHusbandLastName = Item["marathihusbandLastName"].S,
                UidOfHusband = Item["uidOfHusband"].S,
                OtherNameOfHusband = Item["otherNameOfHusband"].S,
                ReligionByBirthOfHusband = Item["religionByBirthOfHusband"].S,
                ReligionByAdoptionOfHusband = Item["religionByAdoptionOfHusband"].S,
                MarathiOtherNameOfHusband = Item["marathiotherNameOfHusband"].S,
                MarathiReligionByBirthOfHusband = Item["marathireligionByBirthOfHusband"].S,
                MarathiReligionByAdoptionOfHusband = Item["marathireligionByAdoptionOfHusband"].S,
                AgeOfHusband = getAgeEntityResponse(Item["ageOfHusbandYears"].S, Item["ageOfHusbandMonths"].S),
                OccupationOfHusbandWithAddress = Item["occupationOfHusbandWithAddress"].S,
                MarathiOccupationOfHusbandWithAddress = Item["marathioccupationOfHusbandWithAddress"].S,
                StatusOfHusbandAtMarriage = Item["statusOfHusbandAtMarriage"].S,
                AddressOfHusband = Item["addressOfHusband"].S,
                MarathiAddressOfHusband = Item["marathiaddressOfHusband"].S,

                //Wife's Details
                WifeFirstName = Item["wifeFirstName"].S,
                WifeMiddleName = Item["wifeMiddleName"].S,
                WifeLastName = Item["wifeLastName"].S,
                MarathiWifeFirstName = Item["marathiwifeFirstName"].S,
                MarathiWifeMiddleName = Item["marathiwifeMiddleName"].S,
                MarathiWifeLastName = Item["marathiwifeLastName"].S,
                UidOfWife = Item["uidOfWife"].S,
                OtherNameOfWife = Item["otherNameOfWife"].S,
                ReligionByBirthOfWife = Item["religionByBirthOfWife"].S,
                ReligionByAdoptionOfWife = Item["religionByAdoptionOfWife"].S,
                MarathiOtherNameOfWife = Item["marathiotherNameOfWife"].S,
                MarathiReligionByBirthOfWife = Item["marathireligionByBirthOfWife"].S,
                MarathiReligionByAdoptionOfWife = Item["marathireligionByAdoptionOfWife"].S,
                AgeOfWife = getAgeEntityResponse(Item["ageOfWifeYears"].S, Item["ageOfWifeMonths"].S),
                StatusOfWifeAtMarriage = Item["statusOfWifeAtMarriage"].S,
                AddressOfWifeBeforeMarriage = Item["addressOfWifeBeforeMarriage"].S,
                MarathiAddressOfWifeBeforeMarriage = Item["marathiaddressOfWifeBeforeMarriage"].S,

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

                MarathiNameofWitness1 = Item["marathinameOfWitness1"].S,

                MarathiAddressOfWitness1 = Item["marathiaddressOfWitness1"].S,
                MarathiOccupationOfWitness1WithAddress = Item["marathioccupationOfWitness1WithAddress"].S,
                MarathiRelationWithCoupleOfWitness1 = Item["marathirelationWithCoupleOfWitness1"].S,
                MarathiNameofWitness2 = Item["marathinameOfWitness2"].S,

                MarathiAddressOfWitness2 = Item["marathiaddressOfWitness2"].S,
                MarathiOccupationOfWitness2WithAddress = Item["marathioccupationOfWitness2WithAddress"].S,
                MarathiRelationWithCoupleOfWitness2 = Item["marathirelationWithCoupleOfWitness2"].S,
                MarathiNameOfWitness3 = Item["marathinameOfWitness3"].S,

                MarathiAddressOfWitness3 = Item["marathiaddressOfWitness3"].S,
                MarathiOccupationOfWitness3WithAddress = Item["marathioccupationOfWitness3WithAddress"].S,
                MarathiRelationWithCoupleOfWitness3 = Item["marathirelationWithCoupleOfWitness3"].S,

                //Priest Details
                PriestName = Item["priestName"].S,
                PriestAddress = Item["priestAddress"].S,
                PriestReligion = Item["priestReligion"].S,
                PriestAge = Item["priestAge"].S,
                MarathiPriestName = Item["marathipriestName"].S,
                MarathiPriestAddress = Item["marathipriestAddress"].S,
                MarathiPriestReligion = Item["marathipriestReligion"].S,

            };

            return marriageRegistrationResponseEntity;
        }

        public static AgeEntity getAgeEntityResponse(string ageYears, string ageMonths)
        {
            var ageEntity = new AgeEntity
            {
                Years = ageYears,
                Months = ageMonths,
            };
            return ageEntity;
        }

        public static GetItemRequest CreateApprovedRequest(string id, string TableName)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue> { { "CertificateNumber", new AttributeValue { S = id } } }
            };

            return request;
        }

       
       
        public static MarriageRegistrationRequestEntity GetApproveRequestEntity(string CertificateNumber , MarriageRegistrationResponseEntity marriageRegistrationResponseEntity)
        {
            var marriageRegistrationRequestEntity = new MarriageRegistrationRequestEntity
            {
                //Application Details
                ApplicationId = marriageRegistrationResponseEntity.ApplicationId,
                CertificateNumber = CertificateNumber,
                ApplicantDistrict = marriageRegistrationResponseEntity.ApplicantDistrict,
                ApplicantTaluka = marriageRegistrationResponseEntity.ApplicantTaluka,
                MarriageDate = marriageRegistrationResponseEntity.MarriageDate,
                MarriagePlace = marriageRegistrationResponseEntity.MarriagePlace,
                MarathiMarriagePlace = marriageRegistrationResponseEntity.MarathiMarriagePlace,
                LawOfMarriage = marriageRegistrationResponseEntity.LawOfMarriage,
                MarathiLawOfMarriage = marriageRegistrationResponseEntity.MarathiLawOfMarriage,
                DocumentsPresented = marriageRegistrationResponseEntity.DocumentsPresented,
                IsMarriageRegisteredAlready = marriageRegistrationResponseEntity.IsMarriageRegisteredAlready,
                SubmissionDate = marriageRegistrationResponseEntity.SubmissionDate,

                //Husbands's Details
                HusbandFirstName = marriageRegistrationResponseEntity.HusbandFirstName,
                HusbandMiddleName = marriageRegistrationResponseEntity.HusbandMiddleName,
                HusbandLastName = marriageRegistrationResponseEntity.HusbandLastName,
                MarathiHusbandFirstName = marriageRegistrationResponseEntity.MarathiHusbandFirstName,
                MarathiHusbandMiddleName = marriageRegistrationResponseEntity.MarathiHusbandMiddleName,
                MarathiHusbandLastName = marriageRegistrationResponseEntity.MarathiHusbandLastName,
                UidOfHusband = marriageRegistrationResponseEntity.UidOfHusband,
                OtherNameOfHusband = marriageRegistrationResponseEntity.OtherNameOfHusband,
                MarathiOtherNameOfHusband = marriageRegistrationResponseEntity.MarathiOtherNameOfHusband,
                ReligionByBirthOfHusband = marriageRegistrationResponseEntity.ReligionByBirthOfHusband,
                MarathiReligionByBirthOfHusband = marriageRegistrationResponseEntity.MarathiReligionByBirthOfHusband,
                ReligionByAdoptionOfHusband = marriageRegistrationResponseEntity.ReligionByAdoptionOfHusband,
                MarathiReligionByAdoptionOfHusband = marriageRegistrationResponseEntity.MarathiReligionByAdoptionOfHusband,
                AgeOfHusband = GetAge(marriageRegistrationResponseEntity.AgeOfHusband),
                OccupationOfHusbandWithAddress = marriageRegistrationResponseEntity.OccupationOfHusbandWithAddress,
                MarathiOccupationOfHusbandWithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfHusbandWithAddress,
                StatusOfHusbandAtMarriage = marriageRegistrationResponseEntity.StatusOfHusbandAtMarriage,
                AddressOfHusband = marriageRegistrationResponseEntity.AddressOfHusband,
                MarathiAddressOfHusband = marriageRegistrationResponseEntity.MarathiAddressOfHusband,

                //Wife's Details
                WifeFirstName = marriageRegistrationResponseEntity.WifeFirstName,
                WifeMiddleName = marriageRegistrationResponseEntity.WifeMiddleName,
                WifeLastName = marriageRegistrationResponseEntity.WifeLastName,
                MarathiWifeFirstName = marriageRegistrationResponseEntity.MarathiWifeFirstName,
                MarathiWifeMiddleName = marriageRegistrationResponseEntity.MarathiWifeMiddleName,
                MarathiWifeLastName = marriageRegistrationResponseEntity.MarathiWifeLastName,
                UidOfWife = marriageRegistrationResponseEntity.UidOfWife,
                OtherNameOfWife = marriageRegistrationResponseEntity.OtherNameOfWife,
                MarathiOtherNameOfWife = marriageRegistrationResponseEntity.MarathiOtherNameOfWife,
                ReligionByBirthOfWife = marriageRegistrationResponseEntity.ReligionByBirthOfWife,
                ReligionByAdoptionOfWife = marriageRegistrationResponseEntity.ReligionByAdoptionOfWife,
                MarathiReligionByBirthOfWife = marriageRegistrationResponseEntity.MarathiReligionByBirthOfWife,
                MarathiReligionByAdoptionOfWife = marriageRegistrationResponseEntity.MarathiReligionByAdoptionOfWife,
                AgeOfWife = GetAge(marriageRegistrationResponseEntity.AgeOfWife),
                StatusOfWifeAtMarriage = marriageRegistrationResponseEntity.StatusOfWifeAtMarriage,
                AddressOfWifeBeforeMarriage = marriageRegistrationResponseEntity.AddressOfWifeBeforeMarriage,
                MarathiAddressOfWifeBeforeMarriage = marriageRegistrationResponseEntity.MarathiAddressOfWifeBeforeMarriage,

                //Witness Details
                NameofWitness1 = marriageRegistrationResponseEntity.NameofWitness1,
                UidOfWitness1 = marriageRegistrationResponseEntity.UidOfWitness1,
                AddressOfWitness1 = marriageRegistrationResponseEntity.AddressOfWitness1,
                OccupationOfWitness1WithAddress = marriageRegistrationResponseEntity.OccupationOfWitness1WithAddress,
                RelationWithCoupleOfWitness1 = marriageRegistrationResponseEntity.RelationWithCoupleOfWitness1,
                NameofWitness2 = marriageRegistrationResponseEntity.NameofWitness2,
                UidOfWitness2 = marriageRegistrationResponseEntity.UidOfWitness2,
                AddressOfWitness2 = marriageRegistrationResponseEntity.AddressOfWitness2,
                OccupationOfWitness2WithAddress = marriageRegistrationResponseEntity.OccupationOfWitness2WithAddress,
                RelationWithCoupleOfWitness2 = marriageRegistrationResponseEntity.RelationWithCoupleOfWitness2,
                NameOfWitness3 = marriageRegistrationResponseEntity.NameOfWitness3,
                UidOfWitness3 = marriageRegistrationResponseEntity.UidOfWitness3,
                AddressOfWitness3 = marriageRegistrationResponseEntity.AddressOfWitness3,
                OccupationOfWitness3WithAddress = marriageRegistrationResponseEntity.OccupationOfWitness3WithAddress,
                RelationWithCoupleOfWitness3 = marriageRegistrationResponseEntity.RelationWithCoupleOfWitness3,

                MarathiNameofWitness1 = marriageRegistrationResponseEntity.MarathiNameofWitness1,
                MarathiAddressOfWitness1 = marriageRegistrationResponseEntity.MarathiAddressOfWitness1,
                MarathiOccupationOfWitness1WithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfWitness1WithAddress,
                MarathiRelationWithCoupleOfWitness1 = marriageRegistrationResponseEntity.MarathiRelationWithCoupleOfWitness1,
                MarathiNameofWitness2 = marriageRegistrationResponseEntity.MarathiNameofWitness2,
                MarathiAddressOfWitness2 = marriageRegistrationResponseEntity.MarathiAddressOfWitness2,
                MarathiOccupationOfWitness2WithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfWitness2WithAddress,
                MarathiRelationWithCoupleOfWitness2 = marriageRegistrationResponseEntity.MarathiRelationWithCoupleOfWitness2,
                MarathiNameOfWitness3 = marriageRegistrationResponseEntity.MarathiNameOfWitness3,
                MarathiAddressOfWitness3 = marriageRegistrationResponseEntity.MarathiAddressOfWitness3,
                MarathiOccupationOfWitness3WithAddress = marriageRegistrationResponseEntity.MarathiOccupationOfWitness3WithAddress,
                MarathiRelationWithCoupleOfWitness3 = marriageRegistrationResponseEntity.MarathiRelationWithCoupleOfWitness3,

                //Priest Details
                PriestName = marriageRegistrationResponseEntity.PriestName,
                PriestAddress = marriageRegistrationResponseEntity.PriestAddress,
                PriestReligion = marriageRegistrationResponseEntity.PriestReligion,
                PriestAge = marriageRegistrationResponseEntity.PriestAge,
                MarathiPriestName = marriageRegistrationResponseEntity.MarathiPriestName,
                MarathiPriestAddress = marriageRegistrationResponseEntity.MarathiPriestAddress,
                MarathiPriestReligion = marriageRegistrationResponseEntity.MarathiPriestReligion,

            };
            return marriageRegistrationRequestEntity;
        }
        private static AgeEntity GetAge(AgeEntity age)
        {
            var ageEntity = new AgeEntity
            {
                Years = age.Years,
                Months = age.Months
            };
            return ageEntity;
        }
    }   
}
