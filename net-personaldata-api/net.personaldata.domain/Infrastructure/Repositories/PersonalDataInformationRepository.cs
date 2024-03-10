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
        private static readonly IList<PersonalDataInformation> _PersonalDataInformationDataBase = new List<PersonalDataInformation>();

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
    }
}
