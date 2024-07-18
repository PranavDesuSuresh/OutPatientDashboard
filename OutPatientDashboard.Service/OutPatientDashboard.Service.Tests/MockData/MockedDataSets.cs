using OutPatientDashboard.Service.Models;

namespace OutPatientDashboard.Service.Tests.MockData
{
    internal class MockedDataSets
    {
        public static List<Physician> GetMockPhysicianList()
        {
            return new List<Physician>()
                {
                    new Physician
                    {
                        Id = 1,
                        FirstName = "testPhysicianF1",
                        LastName="testPhysicianL1",
                        NPI=1234567890,
                        SpecialityId=1
                    },
                    new Physician
                    {
                        Id = 2,
                        FirstName = "testPhysicianF2",
                        LastName="testPhysicianL2",
                        NPI=987654321,
                        SpecialityId=1
                    }
                };
        }

        public static List<Patient> GetMockPatientList()
        {
            return new List<Patient>()
                {
                    new Patient
                    {
                        Id = 1,
                        FirstName = "testPatientF1",
                        LastName="testPatientL1",
                        Age=42,
                        StatusTypeId=2,
                        AdmissionDate = DateTime.Now,
                        DischargeDate = DateTime.Now,
                        PhysicianId=1,
                        Physician= new Physician
                        {
                            Id = 1,
                            FirstName = "testPhysicianF1",
                            LastName="testPhysicianL1",
                            NPI=1234567890,
                            SpecialityId=1
                        }
                    },
                    new Patient
                    {
                        Id = 2,
                        FirstName = "testPatientF2",
                        LastName="testPatientL2",
                        Age=32,
                        StatusTypeId=2,
                        AdmissionDate = DateTime.Now,
                        DischargeDate = DateTime.Now,
                        PhysicianId=2,
                        Physician= new Physician
                        {
                             Id = 2,
                            FirstName = "testPhysicianF2",
                            LastName="testPhysicianL2",
                            NPI=987654321,
                            SpecialityId=1
                        }
                    },
                    new Patient
                    {
                        Id = 3,
                        FirstName = "testPatientF3",
                        LastName="testPatientL3",
                        Age=32,
                        StatusTypeId=2,
                        AdmissionDate = DateTime.Now,
                        DischargeDate = null,
                        PhysicianId=2,
                        Physician= new Physician
                        {
                             Id = 2,
                            FirstName = "testPhysicianF2",
                            LastName="testPhysicianL2",
                            NPI=987654321,
                            SpecialityId=1
                        }
                    }
                };
        }
    }
}
