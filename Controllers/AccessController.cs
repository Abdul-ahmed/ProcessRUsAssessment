using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProcessRUsAssessment.Models;
using System.Collections;

namespace ProcessRUsAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,BackOffice")]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        [Route("fruit/types")]
        public async Task<ActionResult<IEnumerable>> GetFruitTypes()
        {
            string[] fruitTypes = { "Apple", "Orange", "Avocado", "Strawberry", "Plum", "Papaya", "Blackberry", "Blueberry", "Grape", "Banana" };
            return Ok(fruitTypes);
        }
    }
}
