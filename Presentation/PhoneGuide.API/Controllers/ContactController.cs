using Microsoft.AspNetCore.Mvc;
using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Dto.Contact;
using System.Net;

namespace PhoneGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DtoCreateContact dtoCreateContact)
        {
            var result = await _contactService.CreateAsync(dtoCreateContact);

            if (result) return new StatusCodeResult((int)HttpStatusCode.Created);

            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _contactService.DeleteByIdAsync(Guid.Parse(id));

            if (result) return Ok();

            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }
    }
}
