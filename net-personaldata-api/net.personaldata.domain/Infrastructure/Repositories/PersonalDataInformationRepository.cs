using net.personaldata.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net.personaldata.domain.Infrastructure.Repositories
{
    /// <summary>
    /// PersonalDataInformation repository
    /// </summary>
    public class PersonalDataInformationRepository : IPersonalDataInformationRepository
    {
        /// <summary>
        /// This is like a memory database
        /// </summary>
        private static IList<PersonalDataInformation> _PersonalDataInformationDataBase;

        public PersonalDataInformationRepository()
        {
            if (_PersonalDataInformationDataBase == null)
                LoadSampleList();
        }

        /// <summary>
        /// Add an PersonalDataInformation into database
        /// </summary>
        /// <param name="personalDataInformation">PersonalDataInformation's data</param>
        public void Add(PersonalDataInformation personalDataInformation)
        {
            _PersonalDataInformationDataBase.Add(personalDataInformation);
        }

        /// <summary>
        /// Get all PersonalDataInformations from database
        /// </summary>
        /// <returns>All PersonalDataInformations</returns>
        public IList<PersonalDataInformation> GetAll()
        {
            return _PersonalDataInformationDataBase.ToList();
        }

        /// <summary>
        /// Get an PersonalDataInformation from database by its id
        /// </summary>
        /// <returns>PersonalDataInformation related to the id asked</returns>
        public PersonalDataInformation GetPersonalDataInformationById(string personalDataInformationId)
        {
            PersonalDataInformation personalDataInformationRecovered = _PersonalDataInformationDataBase.FirstOrDefault(o => o.Id.Equals(personalDataInformationId));

            return personalDataInformationRecovered;
        }

        /// <summary>
        /// Update an PersonalDataInformation to database
        /// </summary>
        /// <param name="personalDataInformation">PersonalDataInformation's data</param>
        public void Update(PersonalDataInformation personalDataInformation)
        {
            PersonalDataInformation personalDataInformationRecovered = GetPersonalDataInformationById(personalDataInformation.Id);

            personalDataInformationRecovered.Address = personalDataInformation.Address;
            personalDataInformationRecovered.PhoneNumber = personalDataInformation.PhoneNumber;
            personalDataInformationRecovered.FirstName = personalDataInformation.FirstName;
            personalDataInformationRecovered.LastName = personalDataInformation.LastName;
        }

        private void LoadSampleList()
        {
            _PersonalDataInformationDataBase = new List<PersonalDataInformation>
            {
                new PersonalDataInformation
                {
                    Id = "web-user@email.com",
                    FirstName = "Web",
                    LastName = "User",
                    PhoneNumber = "111-111-1111",
                    Email = "web-user@email.com",
                    Address = "123 Oak St, Anytown",
                    WebSite = "www.aliceanderson.com",
                    Profile = "Experienced software engineer with a passion for creating innovative solutions.",
                    Education = "Bachelor's degree in Computer Science from University A.",
                    EmploymentHistory = "5 years at Company X as a Senior Developer, 2 years at Company Y as a Software Engineer.",
                    Languages = "English",
                    Certifications = "Certified Scrum Master (CSM)"
                },
                new PersonalDataInformation
                {
                    Id = "alice.anderson@example.com",
                    FirstName = "Alice",
                    LastName = "Anderson",
                    PhoneNumber = "111-111-1111",
                    Email = "alice.anderson@example.com",
                    Address = "123 Oak St, Anytown",
                    WebSite = "www.aliceanderson.com",
                    Profile = "Experienced software engineer with a passion for creating innovative solutions.",
                    Education = "Bachelor's degree in Computer Science from University A.",
                    EmploymentHistory = "5 years at Company X as a Senior Developer, 2 years at Company Y as a Software Engineer.",
                    Languages = "English",
                    Certifications = "Certified Scrum Master (CSM)"
                },
                new PersonalDataInformation
                {
                    Id = "bob.brown@example.com",
                    FirstName = "Bob",
                    LastName = "Brown",
                    PhoneNumber = "222-222-2222",
                    Email = "bob.brown@example.com",
                    Address = "456 Pine St, Somewhere",
                    WebSite = "www.bobbrown.com",
                    Profile = "Dedicated project manager with a track record of delivering projects on time and within budget.",
                    Education = "Master's degree in Business Administration from University B.",
                    EmploymentHistory = "3 years at Company Z as a Project Manager, 2 years at Company W as a Team Lead.",
                    Languages = "English, Spanish",
                    Certifications = "Project Management Professional (PMP)"
                },
                new PersonalDataInformation
                {
                    Id = "charlie.clark@example.com",
                    FirstName = "Charlie",
                    LastName = "Clark",
                    PhoneNumber = "333-333-3333",
                    Email = "charlie.clark@example.com",
                    Address = "789 Maple St, Nowhere",
                    WebSite = "www.charlieclark.com",
                    Profile = "Passionate teacher with a commitment to fostering a positive learning environment.",
                    Education = "Bachelor's degree in Education from University C.",
                    EmploymentHistory = "5 years at School D as a Teacher, 2 years at School E as a Head Teacher.",
                    Languages = "English, French",
                    Certifications = "Certified Teacher"
                },
                new PersonalDataInformation
                {
                    Id = "david.davis@example.com",
                    FirstName = "David",
                    LastName = "Davis",
                    PhoneNumber = "444-444-4444",
                    Email = "david.davis@example.com",
                    Address = "1010 Elm St, Elsewhere",
                    WebSite = "www.daviddavis.com",
                    Profile = "Creative graphic designer with a keen eye for detail and a passion for visual communication.",
                    Education = "Bachelor's degree in Graphic Design from University F.",
                    EmploymentHistory = "3 years at Company V as a Graphic Designer, 2 years at Company U as a Senior Designer.",
                    Languages = "English, German",
                    Certifications = "Adobe Certified Expert (ACE)"
                },
                new PersonalDataInformation
                {   
                    Id = "eve.evans@example.com",
                    FirstName = "Eve",
                    LastName = "Evans",
                    PhoneNumber = "555-555-5555",
                    Email = "eve.evans@example.com",
                    Address = "1212 Cedar St, Anywhere",
                    WebSite = "www.eveevans.com",
                    Profile = "Dynamic marketing professional with a proven track record of driving brand awareness and customer engagement.",
                    Education = "Bachelor's degree in Marketing from University G.",
                    EmploymentHistory = "4 years at Company T as a Marketing Specialist, 3 years at Company S as a Marketing Manager.",
                    Languages = "English, Spanish",
                    Certifications = "Google Ads Certified"
                }
            };
        }
    }
}
