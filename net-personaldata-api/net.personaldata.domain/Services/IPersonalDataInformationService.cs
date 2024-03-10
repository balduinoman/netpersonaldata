using net.personaldata.domain.Entities;

namespace net.personaldata.domain.Services
{
    public interface IPersonalDataInformationService
    {
        PersonalDataInformation GetPersonalDataInformation(string id);
        void Add(PersonalDataInformation personalDataInformation);
        void Update(PersonalDataInformation personalDataInformation);
    }
}
