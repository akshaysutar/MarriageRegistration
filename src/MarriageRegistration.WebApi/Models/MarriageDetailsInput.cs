using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageRegistration.WebApi.Models
{
    public class MarriageDetailsInput
    {
        //Application Details
        public string ApplicationId { get; set; }

        public string ApplicantDistrict { get; set; }

        public string ApplicantTaluka { get; set; }

        public string MarriageDate { get; set; }

        public string MarriagePlace { get; set; }

        public string LawOfMarriage { get; set; }

        public string SubmissionDate { get; set; }

        public string DocumentsPresented { get; set; }

        public bool IsMarriageRegisteredAlready { get; set; }

        //Husband's Details
        public string HusbandFirstName { get; set; }

        public string HusbandMiddleName { get; set; }

        public string HusbandLastName { get; set; }

        public string UidOfHusband { get; set; }

        public string OtherNameOfHusband { get; set; }

        public string ReligionByBirthOfHusband { get; set; }

        public string AgeOfHusband { get; set; }

        public string ReligionByAdoptionOfHusband { get; set; }

        public string StatusOfHusbandAtMarriage { get; set; }

        public string AddressOfHusband { get; set; }

        public string OccupationOfHusbandWithAddress { get; set; }

        //Wife Details
        public string WifeFirstName { get; set; }

        public string WifeMiddleName { get; set; }

        public string WifeLastName { get; set; }

        public string UidOfWife { get; set; }

        public string OtherNameOfWife { get; set; }

        public string ReligionByBirthOfWife { get; set; }

        public string ReligionByAdoptionOfWife { get; set; }

        public string AgeOfWife { get; set; }

        public string StatusOfWifeAtMarriage { get; set; }

        public string AddressOfWifeBeforeMarriage { get; set; }

        //Witness Details
        public string NameofWitness1 { get; set; }

        public string UidOfWitness1 { get; set; }

        public string AddressOfWitness1 { get; set; }

        public string RelationWithCoupleOfWitness1 { get; set; }

        public string OccupationOfWitness1WithAddress { get; set; }

        public string NameofWitness2 { get; set; }

        public string UidOfWitness2 { get; set; }
        
        public string AddressOfWitness2 { get; set; }

        public string RelationWithCoupleOfWitness2 { get; set; }

        public string OccupationOfWitness2WithAddress { get; set; }

        public string NameOfWitness3 { get; set; }

        public string UidOfWitness3 { get; set; }

        public string AddressOfWitness3 { get; set; }

        public string RelationWithCoupleOfWitness3 { get; set; }

        public string OccupationOfWitness3WithAddress { get; set; }


        //Priest Details
        public string PriestName { get; set; }

        public string PriestAddress { get; set; }

        public string PriestReligion { get; set; }

        public string PriestAge { get; set; }
      
    }
}
