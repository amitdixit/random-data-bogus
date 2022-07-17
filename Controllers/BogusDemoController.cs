using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace nuget_demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BogusDemoController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<BogusDemoController> _logger;

    public BogusDemoController(ILogger<BogusDemoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBlogPost")]
    public IActionResult GetBlogPost()
    {
        return Ok(BogusDataGenerator.GetSampleBlogPostData());
    }

    [HttpGet(Name = "GetTestUsers")]
    public IActionResult GetTestUsers()
    {
        return Ok(BogusDataGenerator.GetSampleTableData());
    }

    [HttpGet(Name = "GetTestOrders")]
    public async Task<IActionResult> GetTestOrders()
    {
        return Ok(await BogusDataGenerator.GetTestOrders());
    }
}
