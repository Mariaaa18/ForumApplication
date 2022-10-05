using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTOs;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic PostLogic;

    public PostController(IPostLogic postLogic)
    {
        PostLogic = postLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync([FromBody] PostCreationDto dto)
    {
        try
        {
            Post post = await PostLogic.CreateAsync(dto);
            return Created($"/posts/{post.Id}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}