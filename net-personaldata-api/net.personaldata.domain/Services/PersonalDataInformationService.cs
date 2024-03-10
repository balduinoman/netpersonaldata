using net.personaldata.domain.Entities;
using net.personaldata.domain.Infrastructure.Repositories;

namespace net.personaldata.domain.Services
{
    public class PersonalDataInformationService : IPersonalDataInformationService
    {
        private readonly IPersonalDataInformationRepository _personalDataRepository;

        public PersonalDataInformationService(IPersonalDataInformationRepository personalDataRepository)
        {
            _personalDataRepository = personalDataRepository;
        }

        public void Add(PersonalDataInformation personalDataInformation)
        {
            personalDataInformation.Id = personalDataInformation.Email;
            _personalDataRepository.Add(personalDataInformation);
        }

        public PersonalDataInformation GetPersonalDataInformation(string id)
        {
            return _personalDataRepository.GetPersonalDataInformationById(id);
        }

        public void Update(PersonalDataInformation personalDataInformation)
        {
            personalDataInformation.Id = personalDataInformation.Email;
            _personalDataRepository.Update(personalDataInformation);
        }
    }
}
