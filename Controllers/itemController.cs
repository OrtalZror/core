using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using  שיעור_2.Models;

namespace שיעור_2.Controllers
{
  

    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return ItemService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var t = ItemService.Get(id);
            if (t == null)
                return NotFound();
             return t;
        }

        [HttpPost]
        public ActionResult Post(Item item)
        {
            ItemService.Add(item);

            return CreatedAtAction(nameof(Post), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Item item)
        {
            if (!ItemService.Update(id, item))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            if (!ItemService.Delete(id))
                return NotFound();
            return NoContent();            
        }
         }
}