﻿using System;
using System.Linq;
using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApp.DAL.DataServices;
using WebApp.Validators;

namespace WebApp.Controllers
{
    // todo implement authorization
    public class EstatesController : Controller
    {
        private readonly IDataService<EstateTempDto> _dataService;

        private readonly IValidator<EstateTempDto> _validator;

        public EstatesController(IDataService<EstateTempDto> dataService, IValidator<EstateTempDto> validator)
        {
            _dataService = dataService;
            _validator = validator;
        }

        [Route("api/estates")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _dataService.GetAll();

                if (data.Any())
                {
                    return Ok(data);
                }

                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/estates/{name}")]
        [HttpGet]
        public IActionResult Get(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name filter can not be empty");
            }

            try
            {
                var data = _dataService.GetFilteredBy(name);

                if (data.Any())
                {
                    return Ok(data);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/estates")]
        [HttpPost]
        public IActionResult Post([FromBody]EstateTempDto estate)
        {
            try
            {
                var validationErrors = _validator.Validate(estate);

                if (validationErrors.Any())
                {
                    return BadRequest(validationErrors);
                }

                var newId = _dataService.Create(estate);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/estates")]
        [HttpPut]
        public IActionResult Put([FromBody]EstateTempDto estate)
        {
            try
            {
                var validationErrors = _validator.Validate(estate);

                if (validationErrors.Any())
                {
                    return BadRequest(validationErrors);
                }

                return _dataService.Update(estate)
                    ? Ok()
                    : (IActionResult)NotFound();
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("api/estates/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                // todo should trigger also deleting the files from disk for that estate
                _dataService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}