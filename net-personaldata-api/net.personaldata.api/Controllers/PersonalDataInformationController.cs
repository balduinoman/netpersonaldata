using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net.personaldata.domain.Entities;
using net.personaldata.domain.Services;
using net.personaldata.security.attributes;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace net.personaldata.api.Controllers
{
    /// <summary>
    /// Personal Data Information Web Api
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PersonalDataInformationController : ControllerBase
    {
        private readonly ILogger<PersonalDataInformationController> _logger;
        private readonly IPersonalDataInformationService _personalDataInformationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="personalDataInformationService"></param>
        public PersonalDataInformationController(
            ILogger<PersonalDataInformationController> logger,
            IPersonalDataInformationService personalDataInformationService)
        {
            _logger = logger;
            _personalDataInformationService = personalDataInformationService;
        }

        /// <summary>
        /// Gets a determined personal data information related to the token's owner user
        /// </summary>
        /// <returns>Personal data information related to the token's owner user</returns>
        [HttpGet]
        [TokenAuthorizeAttibute]
        public PersonalDataInformation Get()
        {
            PersonalDataInformation personalDataInformation = null;

            if (HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
            {
                personalDataInformation = ParseAccessToken(token);
            }

            if (personalDataInformation != null)
                return _personalDataInformationService.GetPersonalDataInformation(personalDataInformation.Email);
            else
                return null;
        }

        /// <summary>
        /// Gets all emails
        /// </summary>
        /// <returns>All emails recorded </returns>
        [HttpGet("GetAllEmails")]
        [TokenAuthorizeAttibute]
        public IList<string> GetAllEmails()
        {
            return _personalDataInformationService.GetAllEmails();
        }

        private PersonalDataInformation ParseAccessToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token.Replace("Bearer ", "")); // Remove "Bearer " prefix if present

            var personalData = new PersonalDataInformation
            {
                Id = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value,
                FirstName = jwtToken.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value,
                LastName = jwtToken.Claims.FirstOrDefault(c => c.Type == "family_name")?.Value,
                PhoneNumber = jwtToken.Claims.FirstOrDefault(c => c.Type == "phone_number")?.Value,
                Email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value,
                Address = jwtToken.Claims.FirstOrDefault(c => c.Type == "address")?.Value
            };

            return personalData;
        }

        /// <summary>
        /// Adds a personal data information
        /// </summary>
        /// <param name="personalDataInformation">Personal data informations</param>
        [HttpPost]
        [TokenAuthorizeAttibute]
        public void Add([FromForm]PersonalDataInformation personalDataInformation)
        {
            _personalDataInformationService.Add(personalDataInformation);
        }

        /// <summary>
        /// Updates a personal data information
        /// </summary>
        /// <param name="personalDataInformation">Personal data informations</param>
        [HttpPut]
        [TokenAuthorizeAttibute]
        public void Update(PersonalDataInformation personalDataInformation)
        {
            _personalDataInformationService.Update(personalDataInformation);
        }
    }
}
