﻿using Microsoft.AspNetCore.Mvc;
using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Dto.Person;
using System.Net;

namespace PhoneGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DtoCreatePerson dtoPerson)
        {
            var result = await _personService.CreateAsync(dtoPerson);

            if (result) return new StatusCodeResult((int)HttpStatusCode.Created);

            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return new OkObjectResult(persons);
        }
    }
}
