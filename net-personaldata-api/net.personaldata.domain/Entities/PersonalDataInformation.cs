using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace net.personaldata.domain.Entities
{
    /// <summary>
    /// Personal Data entity
    /// </summary>
    public class PersonalDataInformation
    {
        [JsonIgnore]
        /// <summary>
        /// Personal Data's id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Personal Data's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Personal Data's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Personal Data's phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Personal Data's e-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Personal Data's address
        /// </summary>
        public string Address { get; set; }
    }
}
