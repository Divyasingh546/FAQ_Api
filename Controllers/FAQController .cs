// FAQController.cs
using FAQ_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class FAQController : ControllerBase
{
    private static List<FAQItem> _faqList = new List<FAQItem>
    {
        new FAQItem { Id = 1, Question = "What is FAQ?", Answer = "FAQ stands for Frequently Asked Questions." },
        new FAQItem { Id = 2, Question = "How do I use this API?", Answer = "You can send GET requests to /api/faq to get the list of FAQs." }
    };

    [HttpGet]
    public IActionResult GetFAQs()
    {
        return Ok(_faqList);
    }

    [HttpPost]
    public IActionResult AddFAQ(FAQItem newItem)
    {
        if (newItem == null)
        {
            return BadRequest("Invalid data");
        }

        newItem.Id = _faqList.Max(item => item.Id) + 1;
        _faqList.Add(newItem);

        return CreatedAtAction(nameof(GetFAQs), new { id = newItem.Id }, newItem);
    }
}
