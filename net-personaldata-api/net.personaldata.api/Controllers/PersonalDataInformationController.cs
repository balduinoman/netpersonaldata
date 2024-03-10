using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net.personaldata.domain.Entities;
using net.personaldata.domain.Services;
using net.personaldata.security.attributes;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace net.personaldata.api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PersonalDataInformationController : ControllerBase
    {
        private readonly ILogger<PersonalDataInformationController> _logger;
        private readonly IPersonalDataInformationService _personalDataInformationService;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="personalDataInformation"></param>
        [HttpPost]
        [TokenAuthorizeAttibute]
        public void Add([FromForm]PersonalDataInformation personalDataInformation)
        {
            _personalDataInformationService.Add(personalDataInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personalDataInformation"></param>
        [HttpPut]
        [TokenAuthorizeAttibute]
        public void Update(PersonalDataInformation personalDataInformation)
        {
            _personalDataInformationService.Update(personalDataInformation);
        }
    }
}
