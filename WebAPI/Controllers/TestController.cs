using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TestController:ControllerBase
{
    [HttpGet("authorized")]
    public ActionResult GetAsAuthorized()
    {
        return Ok("This was accepted as authorized");
    }
    
    [HttpGet("allowanon"), AllowAnonymous]
    public ActionResult GetAsAnon()
    {
        return Ok("This was accepted as anonymous");
    }
    [HttpGet("mustbeover18"), Authorize("Must be over 18")]
    public ActionResult GetAsOver18()
    {
        return Ok("This was accepted as via domain");
    }
}