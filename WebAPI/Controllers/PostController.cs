using Application.LogicInterfaces;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpPost()]
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
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<PostTitleDto>>> GetAsync()
    {
        try
        {
            IEnumerable<PostTitleDto> posts = await PostLogic.GetTitlesAsync();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("{title}")]
    public async Task<ActionResult<Post>> GetByIdAsync([FromRoute] string title)
    {
        try
        {
            Post post = await PostLogic.GetByTitleAsync(title);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await PostLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}