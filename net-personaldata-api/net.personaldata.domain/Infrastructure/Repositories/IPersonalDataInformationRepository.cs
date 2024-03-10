using net.personaldata.domain.Entities;
using System.Collections.Generic;

namespace net.personaldata.domain.Infrastructure.Repositories
{
    /// <summary>
    /// PersonalData repository
    /// </summary>
    public interface IPersonalDataInformationRepository
    {
        /// <summary>
        /// Add an PersonalData into database
        /// </summary>
        /// <param name="personalData">PersonalData's data</param>
        void Add(PersonalDataInformation personalData);

        /// <summary>
        /// Update an PersonalData to database
        /// </summary>
        /// <param name="personalData">PersonalData's data</param>
        void Update(PersonalDataInformation personalData);

        /// <summary>
        /// Get all PersonalDatas from database
        /// </summary>
        /// <returns>All PersonalDatas</returns>
        IList<PersonalDataInformation> GetAll();

        /// <summary>
        /// Get an PersonalData from database by its id
        /// </summary>
        /// <returns>PersonalData related to the id requested</returns>
        PersonalDataInformation GetPersonalDataInformationById(string PersonalDataId);
    }
}
