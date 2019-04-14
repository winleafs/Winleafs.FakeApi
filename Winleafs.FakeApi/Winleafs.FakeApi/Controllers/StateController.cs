using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Winleafs.Models;

namespace Winleafs.FakeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private Faker _faker = new Faker();

        /// <summary>
        /// Indicates if the lights are on or of. 
        /// </summary>
        /// <returns>The state of the device.</returns>
        [Route("on")]
        public IActionResult On()
        {
            return Ok(new {value = _faker.Random.Bool() });
        }

        /// <summary>
        /// Call to change the brightness
        /// TODO Change logic for bad requests.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult ChangeBrightness()
        {
            return NoContent();
        }

        [Route("hue")]
        public IActionResult GetHue()
        {
            return CreateRandomBrightnessLikeMessage(0, 360);
        }

        [Route("/brightness")]
        public IActionResult GetBrightness()
        {
            return CreateRandomBrightnessLikeMessage(0, 100);
        }

        [Route("sat")]
        [HttpGet]
        public IActionResult GetSaturation()
        {
            return CreateRandomBrightnessLikeMessage(0, 100);
        }

        [Route("ct")]
        [HttpGet]
        public IActionResult GetColorTemperature()
        {
            return CreateRandomBrightnessLikeMessage(1200, 6500);
        }


        private IActionResult CreateRandomBrightnessLikeMessage(int min, int max)
        {
            var message = new Brightness { Value = _faker.Random.Int(min, max), Max = max, Min = min };

            return Ok(message);
        }
    }
}