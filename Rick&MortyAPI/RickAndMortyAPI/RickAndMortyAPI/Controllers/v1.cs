using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class v1 : ControllerBase
{
    [HttpGet]
    [Route("person")]
    public async Task<IActionResult> CheckPerson([FromQuery] string name)
    {
        return Ok(new {Response = $"Hello {name}"});
    }
}