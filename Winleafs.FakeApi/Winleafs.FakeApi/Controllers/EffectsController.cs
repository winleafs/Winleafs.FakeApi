using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Winleafs.FakeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffectsController : ControllerBase
    {
        private readonly Faker _faker = new Faker();

        [HttpGet]
        [Route("select")]
        public IActionResult SelectedEffect()
        {
            return Ok(string.Join(' ', _faker.Lorem.Words(_faker.Random.Int(1, 5))));
        }

        [HttpPut]
        public IActionResult SetEffect()
        {
            return NoContent();
        }

        [HttpGet]
        [Route("effectsList")]
        public IActionResult EffectsList()
        {
            return Ok(_faker.Lorem.Words(_faker.Random.Int(1, 5)));
        }
    }
}