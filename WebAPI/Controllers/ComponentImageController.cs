using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentImagesController : ControllerBase
    {
        private readonly IComponentImageService _componentImageService;

        public ComponentImagesController(IComponentImageService componentImageService)
        {
            _componentImageService = componentImageService;
        }


        [HttpPost("uploadimage")]

        public IActionResult UploadImage([FromForm] IFormFile file, [FromForm] ComponentImage componentImage)
        {
            var result = _componentImageService.UploadImage(file, componentImage);
            if(result.Success)
            {
                return Ok(result.Message);
            }

            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("allimages")]
        public IActionResult Get()
        {
            var result = _componentImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


        [HttpGet("byid")]
        public IActionResult GetById(int componentImageId)
        {
            var result = _componentImageService.GetById(componentImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] ComponentImage componentImage)
        {
            var result = _componentImageService.Update(file, componentImage);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(ComponentImage componentImage)
        {
            var result = _componentImageService.Delete(componentImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
