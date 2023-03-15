using DetailsTracking.Model;
using Microsoft.AspNetCore.Mvc;

namespace DetailsTracking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalDetails : ControllerBase
    {
        private readonly IPersonalDetailsService _IpersonalDetailsService;

        public PersonalDetails(IPersonalDetailsService ipersonalDetailsService)
        {
            _IpersonalDetailsService = ipersonalDetailsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PersonalDetail> lResult = _IpersonalDetailsService.GetAll();
            return Ok(lResult);
        }

        [HttpGet("Details")]
        public IActionResult search(string PName) 
        {
            List<PersonalDetail> lResult = _IpersonalDetailsService.GetByName(PName);
            return Ok(lResult);
        }

        [HttpPut]
        public IActionResult Update(PersonalDetail personalDetail)
        {
            return Ok(_IpersonalDetailsService.Update(personalDetail));
        }
        [HttpPost]
        public IActionResult Save(PersonalDetail personalDetail) 
        {
            return Ok(_IpersonalDetailsService.Save(personalDetail));
        }

        [HttpDelete]
        public IActionResult Delete(PersonalDetail personalDetail)
        {
            _IpersonalDetailsService.Delete(personalDetail);
            return Ok();
        }
    }
}
