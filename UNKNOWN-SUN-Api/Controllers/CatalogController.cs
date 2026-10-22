
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Unknown_Sun_Domain.Catalog;

namespace Unknown_SunApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };

            return Ok(items);
        }

        
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item(
                "Shirt",
                "Ohio State shirt.",
                "Nike",
                29.99m
            );

            item.Id = id;

            return Ok(item);
        }

    }
}
