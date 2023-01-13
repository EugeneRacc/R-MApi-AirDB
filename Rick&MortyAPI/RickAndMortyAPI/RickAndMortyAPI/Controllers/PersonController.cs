using Microsoft.AspNetCore.Mvc;
using RickAndMortyBLL.Interfaces;
using RickAndMortyBLL.Models;

namespace RickAndMortyAPI.Controllers;
[ApiController]
[Route("api/v1")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    [Route("check-person")]
    public async Task<IActionResult> CheckPerson([FromBody] PersonInEpisodeModel personInEpisodeModel)
    {
        return Ok(await _personService.CheckIfPersonInEpisode(personInEpisodeModel));
    } 
    
    [HttpGet]
    [Route("person")]
    public async Task<IActionResult> GetPersonDetails([FromQuery] string name)
    {
        return Ok(await _personService.GetPersonDetails(name));
    }
}