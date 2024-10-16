using InterviewSample2.Application.Contracts;
using interviewSample2.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using InterviewSample2.Model.Entities;

namespace InterviewSample2.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IUrlRepository urlRepository) : ControllerBase
{
    private readonly Random _random = new Random();
    private readonly IUrlRepository _urlRepository = urlRepository;

    [HttpGet("Track/")]
    public IActionResult TrackingCode()
    {
        int trackingCode = _random.Next(0, 4000);
        return Ok(trackingCode);
    }

    [HttpGet("{trackingCode}")]
    public IActionResult Generate([FromRoute] int trackingCode,
                                  [FromServices] LinkGenerator linkGenerator)
    {
        string link = $"https://localhost:7016/Product/{trackingCode}";

        var url = _urlRepository.Get(link);
        if (url is not null)
        {
            url.Views++;
            _urlRepository.Update(url);
            return Ok(new UrlDto(url.Url, url.Views));
        }

        _urlRepository.Add(new UrlInfo
        {
            Url = link,
            Views = 1
        });

        return Ok(new UrlDto(link, 1));
    }
}
